using ProjectMaui.ViewModels;

namespace ProjectMaui.Views;

public partial class ClientDetailsPage : ContentPage
{
	public ClientDetailsPage(ExerciseViewModel exvm)//ClientDetailsViewModel clientvm //ExerciseViewModel exvm
    {
		InitializeComponent();
		//BindingContext = clientvm;
        BindingContext = exvm;

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // clear any exercises when page appears
        if (BindingContext is ExerciseViewModel viewModel)
        {
            viewModel.Exercises.Clear();
            viewModel.Muscle = null;
        }
    }
}