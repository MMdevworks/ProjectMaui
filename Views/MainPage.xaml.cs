using ProjectMaui.ViewModels;
namespace ProjectMaui.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}