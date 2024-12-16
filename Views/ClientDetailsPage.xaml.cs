using ProjectMaui.ViewModels;

namespace ProjectMaui.Views;

public partial class ClientDetailsPage : ContentPage
{
	public ClientDetailsPage(ClientDetailsViewModel clientvm)//ClientDetailsViewModel clientvm //ExerciseViewModel exvm
    {
		InitializeComponent();
		BindingContext = clientvm;
        //ExerciseSection.BindingContext = exvm;
    }
    //protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    //{
    //    base.OnNavigatedTo(args);
    //    if (BindingContext is ClientDetailsViewModel viewModel)
    //    {
    //        await viewModel.LoadClientDetailsAsync();
    //    }
    //}

}