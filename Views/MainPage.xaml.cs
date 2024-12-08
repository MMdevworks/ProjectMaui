using ProjectMaui.Models;
using ProjectMaui.Services;
using ProjectMaui.ViewModels;

namespace ProjectMaui.Views;

public partial class MainPage : ContentPage
{
	private readonly LocalDbService localDbService;
	private int editClientId;
	public MainPage(ExerciseViewModel vm, LocalDbService db)
	{
		InitializeComponent();
		BindingContext = vm;
		localDbService = db;
		Task.Run(async () => listView.ItemsSource = await localDbService.GetClients());
	}

	private async void saveButtonClicked(object sender, EventArgs e)
	{
		if (editClientId == 0)
		{
			await localDbService.CreateClient(new Client //create
			{
				Name = nameEntryField.Text,
				Email = emailEntryField.Text,
				Mobile = mobileEntryField.Text
			});
		}
		else
		{
			await localDbService.UpdateClient(new Client //else edit by id
			{
				Id = editClientId,
				Name = nameEntryField.Text,
				Email = emailEntryField.Text,
				Mobile = mobileEntryField.Text
			});
		}
	}

}