using System.IdentityModel.Tokens.Jwt;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MudXtra.ThemeCreator.UI.Extensions;

internal static class ThemeCreatorAuthExtensions
{
    public static bool UseAuth0(this IConfiguration config)
        => !string.Equals(config["ThemeCreator:Authentication"], "None", StringComparison.OrdinalIgnoreCase);

    public static void AddThemeCreatorAuthentication(this IServiceCollection services, IConfiguration config)
    {
        if (!config.UseAuth0())
        {
            services.AddAuthentication();
            return;
        }

        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        services.AddAuth0WebAppAuthentication(options =>
        {
            options.Domain = config["domain"]!;
            options.ClientId = config["clientid"]!;
        });
    }

    public static void MapThemeCreatorAccountEndpoints(this WebApplication app, IConfiguration config)
    {
        if (!config.UseAuth0())
        {
            return;
        }

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
    }
}
