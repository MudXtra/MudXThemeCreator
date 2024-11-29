using Microsoft.EntityFrameworkCore;
using MudBlazor.Extensions;
using MudBlazor.Extensions.Options;
using MudBlazor.Services;
using Serilog;
using Serilog.Events;
using ThemeCreatorMudBlazor.DAL.Data;
using ThemeCreatorMudBlazor.DAL.Interfaces;
using ThemeCreatorMudBlazor.DAL.Services;
using ThemeCreatorMudBlazor.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Configuration
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

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

void configMud(MudServicesConfiguration configMud)
{
    configMud.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopRight;
    configMud.SnackbarConfiguration.VisibleStateDuration = 5000; // show toasts for 5 seconds by default
    configMud.SnackbarConfiguration.PreventDuplicates = false;
    configMud.SnackbarConfiguration.HideTransitionDuration = 0;
}
void configMudEx(MudExConfiguration configMudEx)
{
    configMudEx.WithoutAutomaticCssLoading();
}
builder.Services.AddMudServicesWithExtensions(configMud, configMudEx);

//var connectionString = configuration.GetConnectionString("DefaultConnection") ??
//					   throw new NullReferenceException("No Connecting String Found");

//connectionString = connectionString.Trim()
//	.Replace("[USER]",
//		configuration["POSTGRESQLUSER"] ?? throw new NullReferenceException("Missing environment variables"))
//	.Replace("[PW]",
//		configuration["POSTGRESQLPW"] ?? throw new NullReferenceException("Missing environment variables"))
//	.Replace("[ADDR]",
//		configuration["POSTGRESQLADDR"] ?? throw new NullReferenceException("Missing environment variables"))
//	.Replace("[PORT]",
//		configuration["POSTGRESQLPORT"] ?? throw new NullReferenceException("Missing environment variables"));

//builder.Services.AddDbContextFactory<ThemeDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<StyleService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IThemeCreatorService, ThemeCreatorService>();
builder.Services.AddScoped<IThemeStateService, ThemeStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
