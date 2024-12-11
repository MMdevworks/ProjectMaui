namespace ProjectMaui.Views;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await this.FadeTo(0, 5000);
		await Shell.Current.GoToAsync(nameof(LoginPage));
	}
}