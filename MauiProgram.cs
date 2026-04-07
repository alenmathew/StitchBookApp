using Microsoft.Extensions.Logging;
using StitchBookApp.Services;

namespace StitchBookApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //SQLitePCL.Batteries.Init();
            SQLitePCL.Batteries_V2.Init();
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<NewOrderPage>();
            builder.Services.AddTransient<PendingPage>();
            builder.Services.AddTransient<SummaryPage>();
            builder.Services.AddTransient<TodayDeliveriesPage>();
            builder.Services.AddTransient<SearchPage>();
            builder.Services.AddTransient<BackupPage>();
            builder.Services.AddTransient<AddExpensePage>();
            return builder.Build();
        }
    }
}
