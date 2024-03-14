using StyleAndValidation.ViewModels;

namespace StyleAndValidation.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel vm)
	{
		this.BindingContext = vm;	
		InitializeComponent();
	}
}