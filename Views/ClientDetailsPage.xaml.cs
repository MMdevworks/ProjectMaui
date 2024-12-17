using ProjectMaui.ViewModels;

namespace ProjectMaui.Views;

public partial class ClientDetailsPage : ContentPage
{
	public ClientDetailsPage(CombinedClientExerciseViewModel combinedvm)
    {
		InitializeComponent();
        BindingContext = combinedvm;
        //BindingContext = exvm;
        //BindingContext = clientvm;

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