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

    //go back swipe
    private async void OnSwipeBack(object sender, EventArgs e)
    {
        //await this.TranslateTo(-this.Width, 0, 500, Easing.CubicOut);
        await Shell.Current.GoToAsync("..");
        //await Shell.Current.GoToAsync("///LoginPage");
    }
}