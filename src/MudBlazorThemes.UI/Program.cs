using System.IdentityModel.Tokens.Jwt;
using Auth0.AspNetCore.Authentication;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Extensions;
using MudBlazor.Extensions.Options;
using MudBlazor.Services;
using MudBlazorThemes.DAL.Data;
using MudBlazorThemes.DAL.Interfaces;
using MudBlazorThemes.DAL.Services;
using MudBlazorThemes.UI.Components;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
var connString = config.GetConnectionString("postgresql");
connString = connString?.Replace("[dbName]", config["dbName"]);
connString = connString?.Replace("[dbPort]", config["dbPort"]);
connString = connString?.Replace("[dbUser]", config["dbUser"]);
connString = connString?.Replace("[dbPassword]", config["dbPassword"]);

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning) // Suppress EF Core SQL commands
    .MinimumLevel.Override("Microsoft.AspNetCore.Components", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console(
        restrictedToMinimumLevel: LogEventLevel.Verbose)
    .WriteTo.File(
        path: "Logs/applog-.log",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Warning
    ));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthorization();
builder.Services.AddBlazoredLocalStorage();

// Add MudBlazor services, MudEx and MudMarkdown
void configMud(MudServicesConfiguration configMud)
{
    configMud.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopRight;
    configMud.SnackbarConfiguration.VisibleStateDuration = 5000; // show toasts for 5 seconds by default
    configMud.SnackbarConfiguration.PreventDuplicates = false;
    configMud.SnackbarConfiguration.HideTransitionDuration = 0;
}
void configMudEx(MudExConfiguration configMudEx)
{
    configMudEx.WithAutomaticCssLoading();
    configMudEx.WithDefaultDialogOptions(new DialogOptionsEx
    {
        CloseOnEscapeKey = true,
        BackdropClick = true,
        CloseButton = false,
        Animations = new[] { AnimationType.Pulse },
        DragMode = MudDialogDragMode.Simple,
        DisableSizeMarginY = true,
        DisablePositionMargin = true
    });
}
builder.Services.AddMudServicesWithExtensions(configMud, configMudEx);

// Add DB connection
builder.Services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseNpgsql(connString));

// Add other services
builder.Services.AddScoped<IThemeCreatorService, ThemeCreatorService>();
builder.Services.AddScoped<IThemeStateService, ThemeStateService>();
builder.Services.AddScoped<INotifierService, NotifierService>();
builder.Services.AddScoped<StyleService>();

// SEO improvements
builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(365);
});

// Authentication
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = config["domain"]!;
    options.ClientId = config["clientid"]!;
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedFor;
});
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});
builder.Services.Configure<HttpsRedirectionOptions>(options =>
{
    options.HttpsPort = 443;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

app.UseForwardedHeaders();

app.UseHttpsRedirection();
app.MapStaticAssets();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
        .WithScope("openid profile email roles")
        .WithRedirectUri(returnUrl)
        .Build();

    await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async (HttpContext httpContext) =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
            .WithRedirectUri("/")
            .Build();

    await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Add headers
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    await next();
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
