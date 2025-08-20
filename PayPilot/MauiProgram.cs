using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PayPilot.Database;
using SQLitePCL;

namespace PayPilot;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        Batteries_V2.Init();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "paypilot.db");
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlite($"Data Source={dbPath}");
#if DEBUG
            opt.EnableSensitiveDataLogging();
            opt.EnableDetailedErrors();
#endif
        });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        var logger = app.Services.GetRequiredService<ILoggerFactory>()
            .CreateLogger("Startup");

        try
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();
            logger.LogInformation($"[PayPilot] DB path: {dbPath}");
        }
        catch (Exception ex)
        {
            logger.LogError("[PayPilot] DB init failed: " + ex);
            throw;
        }

        return app;
    }
}