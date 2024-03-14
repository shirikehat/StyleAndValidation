using Microsoft.Extensions.Logging;
using StyleAndValidation.Services;
using StyleAndValidation.ViewModels;
using StyleAndValidation.Views;

namespace StyleAndValidation
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
            //register views,services and viewModels
            builder.RegiserServices().RegisterViews().RegisterViewModels();

#if DEBUG
    		builder.Logging.AddDebug();
#endif




            return builder.Build();
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder) 
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<LoadingPage>();
            builder.Services.AddTransient<MyPage>();

            return builder;
        } 
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder) 
        {
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<RegisterPageViewModel>();
            builder.Services.AddTransient<LoadingPageViewModel>();
            return builder;
        } 
        public static MauiAppBuilder RegiserServices(this MauiAppBuilder builder) 
        {
            builder.Services.AddSingleton<AppServices>();

            return builder;
        }
    }
}
