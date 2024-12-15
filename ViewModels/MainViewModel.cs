using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectMaui.Models;
using ProjectMaui.Services;
using ProjectMaui.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaui.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly LocalDbService localService;

        [ObservableProperty]
        private int clientId;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;
        
        [ObservableProperty]
        private string mobile;

        //[ObservableProperty]
        //private bool isEdit;

        private Client selectedClient;

        public ObservableCollection<Client> Clients { get; } = new();

        public MainViewModel(LocalDbService localDbService)
        {
            this.localService = localDbService;
            Task.Run(LoadClientsAsync);
        }

        [RelayCommand]
        private async Task LoadClientsAsync()
        {
            var clients = await localService.GetClients();
            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }

        [RelayCommand]
        private async Task SaveClientAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                if (ClientId == 0) // create
                {
                    await localService.CreateClient(new Client
                    {
                        Name = Name,
                        Email = Email,
                        Mobile = Mobile
                    });
                }
                else
                {
                    await localService.UpdateClient(new Client //else edit by id
                    {
                        Id = ClientId,
                        Name = Name,
                        Email = Email,
                        Mobile = Mobile
                    });

                    ClientId = 0;
                }
                //clear fields
                Name = string.Empty;
                Email = string.Empty;
                Mobile = string.Empty;
                //reload clients
                await LoadClientsAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task OnClientTapped(Client client)
        {
            {
                if (client != null)
                {
                    await Shell.Current.GoToAsync("/ClientDetailsPage");
                }
            }
        }

        [RelayCommand]
        private void EditClient(Client client)
        {
            if (client != null)
            {
                ClientId = client.Id;
                Name = client.Name;
                Email = client.Email;
                Mobile = client.Mobile;
                //IsEdit = true;
            }
        }

        [RelayCommand]
        private async Task DeleteClient(Client client)
        {
            if (client != null)
            {
                bool userConfirm = await App.Current.MainPage.DisplayAlert(
                    "Delete Client",$"Are you sure you want to delete {client.Name}?",
                    "Yes",
                    "No");

                if (userConfirm)
                {
                    await localService.DeleteClient(client);

                    Clients.Remove(client);
                }
            }
        }

        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                if (selectedClient != value)
                {
                    selectedClient = value;
                    OnPropertyChanged();

                    // Perform tapped action, e.g., navigate to a details page
                    if (selectedClient != null)
                    {
                        OnClientTapped(selectedClient);
                    }
                }
            }
        }
    }
}
