namespace ProjectMaui.Views;
using ProjectMaui.Models;
public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}

    //private void OnRegisterClicked()
    //{
    //	Console.WriteLine("register clicked");
    //}



    //go back swipe (can add to baseview model for reusability)
    private async void OnSwipeBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}