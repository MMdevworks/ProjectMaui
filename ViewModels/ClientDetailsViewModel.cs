using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectMaui.Models;
using ProjectMaui.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace ProjectMaui.ViewModels
{
    [QueryProperty(nameof(ClientId), "clientId")]
    public partial class ClientDetailsViewModel : BaseViewModel
    {
        private readonly LocalDbService localDbService;

        [ObservableProperty]
        private Client client;

        private int clientId;

        public int ClientId
        {
            get => clientId;
            set
            {
                clientId = value;
                // Load client details after setting the clientId
                Task.Run(() => LoadClientDetailsAsync());
            }
        }
        public ClientDetailsViewModel(LocalDbService localDbService)
        {
            //Title = client.Name;
            this.localDbService = localDbService;
        }

        public async Task LoadClientDetailsAsync()
        {
            try
            {
                if (clientId != 0)
                {
                    Client = await localDbService.GetClientById(clientId);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Debug.WriteLine($"Error loading client details: {ex.Message}");
            }
        }
    }
}

