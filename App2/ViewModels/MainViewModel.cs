using App2.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App2.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IClientDataProvider _clientDataProvider;
        public ObservableCollection<ClientViewModel> Clients { get; }
        public ClientViewModel NouveauClient { get; }

        public MainViewModel(IClientDataProvider clientDataProvider)
        {
            _clientDataProvider = clientDataProvider;
            Clients = new ObservableCollection<ClientViewModel>();
            Random rnd = new Random();
            NouveauClient = new ClientViewModel(new Models.Client(rnd.Next(10000, 99999), "", ""));
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

        public void ChargerDonnes()
        {
            ChargerClients();
        }

        public void AjouterClient()
        {
            Clients.Add(NouveauClient);
        }
    }
}
