using StyleAndValidation.ViewModels;
namespace StyleAndValidation.Views
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage(MainPageViewModel vm)
        {
            this.BindingContext = vm;
            InitializeComponent();
        }

       
    }

}
