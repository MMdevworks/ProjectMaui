using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectMaui.Models;
using ProjectMaui.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Linq;


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
            if (clientId != 0)
            {
                Client = await localDbService.GetClientById(clientId);
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