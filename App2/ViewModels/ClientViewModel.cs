using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        public Client _client;

        public ClientViewModel(Client client)
        {
            _client = client;
        }

        public int Id
        {
            get => _client.Id;
        }

        public string Prenom
        {
            get => _client.Prenom;
            set
            {
                if (_client.Prenom != value)
                {
                    _client.Prenom = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Nom
        {
            get => _client.Nom;
            set
            {
                if (_client.Nom != value)
                {
                    _client.Nom = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EstClientRegulier
        {
            get => _client.EstClientRegulier;
            set
            {
                if (_client.EstClientRegulier != value)
                {
                    _client.EstClientRegulier = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateOnly DateCreation
        {
            get => _client.DateCreation;
        }

        public string TartePrefere
        {
            get => _client.TartePreferee;
            set
            {
                if (_client.TartePreferee != value)
                {
                    _client.TartePreferee = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string DateToString(DateOnly date, string format)
        {
            return Utilities.DateToString(date, format);
        }
    }
}
