using ProjectMaui.ViewModels;
using System.Diagnostics;

namespace ProjectMaui.Views;

public partial class ClientDetailsPage : ContentPage
{
	public ClientDetailsPage(ExerciseViewModel exvm)//ClientDetailsViewModel clientvm //ExerciseViewModel exvm
    {
		InitializeComponent();
		//BindingContext = clientvm;
        BindingContext = exvm;

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