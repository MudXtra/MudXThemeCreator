using Microsoft.EntityFrameworkCore;
using MudXtra.ThemeCreator.Infrastructure.Data;
using Npgsql;

namespace MudXtra.ThemeCreator.UI.Extensions;

public static class IServiceCollectionExtensions
{
    public static async Task AddThemeDataBaseConnection(this IServiceCollection services, IConfiguration config)
    {
        var primaryConn = config.GetConnectionString("postgresql");
        primaryConn = primaryConn?.Replace("[dbName]", config["dbName"]);
        primaryConn = primaryConn?.Replace("[dbPort]", config["dbPort"]);
        primaryConn = primaryConn?.Replace("[dbUser]", config["dbUser"]);
        primaryConn = primaryConn?.Replace("[dbPassword]", config["dbPassword"]);

        var altConnString = config.GetConnectionString("vs_sql_server");

        bool canUsePrimary = false;
        try
        {
            // Try connecting to primary DB with a 1-second timeout
            using var conn = new NpgsqlConnection($"{primaryConn};");
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
            await conn.OpenAsync(cts.Token);
            canUsePrimary = true;
            Console.WriteLine("Connected to Primary PostgreSQL DB");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Primary DB connection failed switching to built in VS SQL Server: {ex.Message}");
        }

        if (canUsePrimary)
        {
            services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseNpgsql(primaryConn));
        }
        else
        {
            services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseSqlServer(altConnString));
        }
    }
}
