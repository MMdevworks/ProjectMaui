using ProjectMaui.ViewModels;
namespace ProjectMaui.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}