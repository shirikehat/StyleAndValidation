using StyleAndValidation.ViewModels;

namespace StyleAndValidation.Views;

public partial class LoginPage : ContentPage
{
	
	public LoginPage(LoginPageViewModel vm)
	{
		this.BindingContext = vm;	
		InitializeComponent();
	}
}