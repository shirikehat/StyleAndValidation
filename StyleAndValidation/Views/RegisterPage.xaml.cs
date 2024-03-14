using StyleAndValidation.ViewModels;

namespace StyleAndValidation.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		this.BindingContext = vm;	
		InitializeComponent();
	}
}