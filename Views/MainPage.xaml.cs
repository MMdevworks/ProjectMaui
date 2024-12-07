using ProjectMaui.ViewModels;

namespace ProjectMaui.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ExerciseViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}