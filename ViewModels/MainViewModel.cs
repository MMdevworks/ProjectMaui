using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectMaui.Models;
using ProjectMaui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        [ObservableProperty]
        private string notes;

        [ObservableProperty]
        private bool isFormVisible;
        [ObservableProperty]
        private bool isAddBtnVisible = true;
        [ObservableProperty]
        private bool isEdit;

        private Client selectedClient;

        public ObservableCollection<Client> Clients { get; } = new();

        public ICommand EditCommand => new RelayCommand<Client>(EditClient);
        public ICommand DeleteCommand => new RelayCommand<Client>(async (client) => await DeleteClient(client));

        public MainViewModel(LocalDbService localDbService)
        {
            this.localService = localDbService;
            Task.Run(LoadClientsAsync);
        }

        [RelayCommand]
        private void AddClient()
        {
            IsFormVisible = true;
            IsAddBtnVisible = false;
            IsEdit = false;
            Name = string.Empty;
            Email = string.Empty;
            Mobile = string.Empty; 
            Notes = string.Empty;
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
                if (IsEdit) //edit
                {
                    await localService.UpdateClient(new Client
                    {
                        Id = selectedClient.Id,
                        Name = Name,
                        Email = Email,
                        Mobile = Mobile,
                        Notes = Notes
                    });
                }
                else //add
                {
                    await localService.CreateClient(new Client
                    {
                        Name = Name,
                        Email = Email,
                        Mobile = Mobile,
                        Notes = Notes
                    });
                }

                // hide form and reload
                IsFormVisible = false;
                IsAddBtnVisible = true;
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
            try
            {
                if (client != null)
                {
                    Debug.WriteLine($"==============>  On Tapped go to details page for: {client.Name} {client.Id}");
                    await Shell.Current.GoToAsync($"/ClientDetailsPage?clientId={client.Id}");
                    await Task.CompletedTask;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error navigating: {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void EditClient(Client client)
        {
            if (client != null)
            {
                Debug.WriteLine($"===================>  Editing client: {client.Name}");
                selectedClient = client;
                IsFormVisible = true;
                IsAddBtnVisible = false;
                IsEdit = true;
                Name = client.Name;
                Email = client.Email;
                Mobile = client.Mobile;
                Notes = client.Notes;
            }
        }

        private async Task DeleteClient(Client client)
        {
            if (client != null)
            {
                Debug.WriteLine($"===================>  Deleting client: {client.Name}");
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

                    // Perform tapped action
                    if (selectedClient != null)
                    {
                        OnClientTapped(selectedClient);
                    }
                }
            }
        }
    }
}
