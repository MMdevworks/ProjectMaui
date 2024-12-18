using ProjectMaui.ViewModels;

namespace ProjectMaui.Views;

public partial class ClientDetailsPage : ContentPage
{
    public ClientDetailsPage(ExerciseViewModel exercisevm)
    {
        InitializeComponent();
      
        BindingContext = exercisevm;


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