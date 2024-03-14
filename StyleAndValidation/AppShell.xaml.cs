
using StyleAndValidation.Services;
using StyleAndValidation.Views;
using System.Windows.Input;

namespace StyleAndValidation
{
    public partial class AppShell : Shell
    {
        public ICommand LogoutCommand { get; protected set; } 
        public AppShell()
        {
            InitializeComponent();
            RoutingPages();
            LogoutCommand = new Command(async () => { var ser = ((App)Application.Current).Services.GetService<AppServices>();  ser.Logout(); await AppShell.Current.GoToAsync("///MainPage");  });
        }

        private void RoutingPages()
        {
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("Register", typeof(RegisterPage));
            Routing.RegisterRoute("Loading", typeof(LoadingPage));
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var ser = ((App)Application.Current).Services.GetService<AppServices>(); ser.Logout(); await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}
