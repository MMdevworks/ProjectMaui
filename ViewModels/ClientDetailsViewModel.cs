using CommunityToolkit.Mvvm.ComponentModel;
using ProjectMaui.Models;
using ProjectMaui.Services;
using System.Diagnostics;


namespace ProjectMaui.ViewModels
{
    [QueryProperty(nameof(ClientId), "clientId")]
    public partial class ClientDetailsViewModel : BaseViewModel
    {
        private readonly LocalDbService localDbService;

        public ClientDetailsViewModel(LocalDbService localDbService)
        {
            this.localDbService = localDbService;
        }

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
        //public int ClientId
        //{
        //    get => clientId;
        //    set
        //    {
        //        clientId = value;
        //        LoadClientDetailsAsync(value);
        //    }           
        //}
        //public async void LoadClientDetailsAsync(int clientId)
        //{
        //    Client = await localDbService.GetClientById(clientId);
        //}
    } 
}