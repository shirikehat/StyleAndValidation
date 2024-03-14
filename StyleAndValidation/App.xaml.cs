namespace StyleAndValidation
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; private set; }
        public App(IServiceProvider services)
        {
            InitializeComponent();

            MainPage = new AppShell();
            Services = services;
        }
    }
}
