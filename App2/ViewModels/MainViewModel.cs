using App2.Data;
using App2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App2.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IClientDataProvider _clientDataProvider;
        private Random _random = new Random();
        private ClientViewModel _clientselectionne;
        public ObservableCollection<ClientViewModel> Clients { get; }
        public ClientViewModel NouveauClient { get; }
        public ClientViewModel? ClientSelectionne
        {
            get => _clientselectionne;
            set
            {
                if (_clientselectionne != value)
                {
                    _clientselectionne = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(ClientEstSelectionne));
                }
            }
        }

        public bool ClientEstSelectionne => ClientSelectionne != null;


        public MainViewModel(IClientDataProvider clientDataProvider)
        {
            _clientDataProvider = clientDataProvider;
            Clients = new ObservableCollection<ClientViewModel>();
            NouveauClient = new ClientViewModel(new Models.Client(_random.Next(10000, 99999), "", ""));
        }

        public void ChargerClients()
        {
            Clients.Clear();
            List<Client> clientsData = _clientDataProvider.GetClients();
            foreach (Client client in clientsData)
            {
                Clients.Add(new ClientViewModel(client));
            }
        }

        public void ChargerDonnees()
        {
            ChargerClients();
        }

        public void AjouterClient()
        {
            Clients.Add(NouveauClient);
            _clientDataProvider.AjoutClient(NouveauClient.Client);
        }

        public void SupprimerClientSelectionne()
        {
            _clientDataProvider.RetirerClient(ClientSelectionne.Client);
            Clients.Remove(ClientSelectionne);
        }
    }
}
