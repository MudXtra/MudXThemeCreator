using System.IdentityModel.Tokens.Jwt;
using Auth0.AspNetCore.Authentication;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using MudBlazor.Services;
using MudXtra.ThemeCreator.Infrastructure.Interfaces;
using MudXtra.ThemeCreator.Infrastructure.Services;
using MudXtra.ThemeCreator.UI;
using MudXtra.ThemeCreator.UI.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning) // Suppress EF Core SQL commands
    .MinimumLevel.Override("Microsoft.AspNetCore.Components", LogEventLevel.Information)
    .Enrich.FromLogContext()
#if DEBUG
    .WriteTo.Console(
        restrictedToMinimumLevel: LogEventLevel.Information)
    .WriteTo.File(
        path: "Logs/applog-.log",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Warning)
#else // Write to Console only warnings and errors in Release mode for Docker Console Viewer
    .WriteTo.Console(
        restrictedToMinimumLevel: LogEventLevel.Warning)
#endif
        );

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthorization();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMudServices(cfg =>
{
    cfg.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopRight;
    cfg.SnackbarConfiguration.PreventDuplicates = false;
    cfg.SnackbarConfiguration.HideTransitionDuration = 0;
    cfg.SnackbarConfiguration.VisibleStateDuration = 5000;
});

// Add DB connection, can swap this for SqlExpress or any other provider you have access to
// By default loads my private DB, if it can't connect it falls back to the built in VS database (not suitable for production)
await builder.Services.AddThemeDataBaseConnection(config);

//Add other services
builder.Services.AddScoped<UserPreferencesService>(); // track user preferences across app
builder.Services.AddSingleton<IThemeCreatorService, ThemeCreatorService>(); // database theme service
builder.Services.AddScoped<ThemeStateService>(); // theme state service
builder.Services.AddScoped<StyleService>(); // CSS style getter service

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
