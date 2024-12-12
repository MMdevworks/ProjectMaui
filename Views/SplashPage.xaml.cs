namespace ProjectMaui.Views;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
	}
	// fade splash and goto login
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		//await this.FadeTo(0, 2000);
		await Shell.Current.GoToAsync(nameof(LoginPage), false);
	}
}