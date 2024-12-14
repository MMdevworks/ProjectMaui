using ProjectMaui.Models;
using ProjectMaui.Services;
using ProjectMaui.ViewModels;
using System.Reflection;
using System.Xml.Linq;

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

			editClientId = 0;
        }

		nameEntryField.Text = string.Empty;
		emailEntryField.Text = string.Empty;
		mobileEntryField.Text = string.Empty;
		listView.ItemsSource = await localDbService.GetClients();
	}

	//move to clientpage
	private async void listViewItemTapped(object sender, ItemTappedEventArgs e)
	{

        await Shell.Current.GoToAsync("/ClientDetailsPage");
    
		//var client = (Client)e.Item;
		//var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

		//switch (action)
		//{
		//	case "Edit": 
		//		editClientId = client.Id;
  //              nameEntryField.Text = client.Name;
  //              emailEntryField.Text = client.Email;
  //              mobileEntryField.Text = client.Mobile;

		//		break;
		//	case "Delete":

		//		await localDbService.DeleteClient(client);
		//		listView.ItemsSource = await localDbService.GetClients();
		//		break;

        //}
	}

    private void DebugOnFrameTapped(object sender, EventArgs e)
    {
        Console.WriteLine("Frame tapped");
    }
}