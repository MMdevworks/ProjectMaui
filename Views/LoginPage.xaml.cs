namespace ProjectMaui.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        Console.WriteLine("register clicked");
    }

}