using Microsoft.Extensions.Logging;

namespace ITC2Wedstrijd
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

            builder.Services.AddSingleton<CategorieRepository>();
            builder.Services.AddSingleton<ClubRepository>();
            builder.Services.AddSingleton<SportRepository>();
            builder.Services.AddSingleton<SpelerRepository>();
            builder.Services.AddSingleton<PloegRepository>();
            builder.Services.AddSingleton<SpelerPloegRepository>();

            builder.Services.AddTransient<CategoriePage>();
            builder.Services.AddTransient<ClubPage>();
            builder.Services.AddTransient<SportPage>();
            builder.Services.AddTransient<SpelerPage>();
            builder.Services.AddTransient<PloegPage>();
            builder.Services.AddTransient<ToewijzenPage>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddSingleton<CategorieViewModel>();
            builder.Services.AddSingleton<ClubViewModel>();
            builder.Services.AddSingleton<SportViewModel>();
            builder.Services.AddSingleton<SpelerViewModel>();
            builder.Services.AddSingleton<PloegViewModel>();
            builder.Services.AddTransient<ToewijzenViewModel>();
            builder.Services.AddTransient<BaseViewModel>();

            return builder.Build();
        }
    }
}
