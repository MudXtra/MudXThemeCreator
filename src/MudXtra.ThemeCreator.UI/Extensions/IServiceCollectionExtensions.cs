using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MudXtra.ThemeCreator.Infrastructure.Data;
using Npgsql;

namespace MudXtra.ThemeCreator.UI.Extensions;

public static class IServiceCollectionExtensions
{
    public static async Task AddThemeDataBaseConnection(this IServiceCollection services, IConfiguration config)
    {
        if (string.Equals(config["ThemeCreator:DatabaseProvider"], "InMemory", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Using in-memory Theme Creator database (ThemeCreator:DatabaseProvider=InMemory).");
            services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseInMemoryDatabase("MudXThemeCreator"));
            return;
        }

        var primaryConn = config.GetConnectionString("postgresql");
        primaryConn = primaryConn?.Replace("[dbName]", config["dbName"]);
        primaryConn = primaryConn?.Replace("[dbPort]", config["dbPort"]);
        primaryConn = primaryConn?.Replace("[dbUser]", config["dbUser"]);
        primaryConn = primaryConn?.Replace("[dbPassword]", config["dbPassword"]);

        var altConnString = config.GetConnectionString("vs_sql_server");

        if (await CanConnectAsync(() => new NpgsqlConnection(primaryConn)))
        {
            Console.WriteLine("Connected to primary PostgreSQL database for Theme Creator.");
            services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseNpgsql(primaryConn));
            return;
        }

        if (await CanConnectAsync(() => new SqlConnection(altConnString)))
        {
            Console.WriteLine("Connected to SQL Server database for Theme Creator.");
            services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseSqlServer(altConnString));
            return;
        }

        Console.WriteLine("No external Theme Creator database available; using in-memory database for local development.");
        services.AddDbContextFactory<ThemeDbContext>(cfg => cfg.UseInMemoryDatabase("MudXThemeCreator"));
    }

    private static async Task<bool> CanConnectAsync(Func<System.Data.Common.DbConnection> connectionFactory)
    {
        try
        {
            await using var conn = connectionFactory();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
            await conn.OpenAsync(cts.Token);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Theme Creator database connection failed: {ex.Message}");
            return false;
        }
    }
}
