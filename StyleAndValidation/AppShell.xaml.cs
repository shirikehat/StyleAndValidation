
using StyleAndValidation.Views;

namespace StyleAndValidation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RoutingPages();
        }

        private void RoutingPages()
        {
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("Register", typeof(RegisterPage));
            Routing.RegisterRoute("Loading", typeof(LoadingPage));
        }
    }
}
