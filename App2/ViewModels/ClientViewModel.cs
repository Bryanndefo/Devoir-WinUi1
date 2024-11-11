using App2.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace App2.ViewModels
{
    public class ClientViewModel : ViewModelValidable
    {
        public Client _client;

        public ClientViewModel(Client client)
        {
            ObservableCollection<ValidationResult> listeVide = new ObservableCollection<ValidationResult>();
            _client = client;
            _errors.Add("Prenom", listeVide);

        }

        public Client Client
        {
            get => _client; 
        }

        public int Id
        {
            get => _client.Id;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le prenom est requis")]
        [MinLength(2, ErrorMessage = " Le prenom doit comprendre au moins 2 caracteres.")]
        [MaxLength(254, ErrorMessage = "Le prenom doit comprendre moins de 255 caracteres")]
        [DeniedValues(["Bob", "Ginette"], ErrorMessage = "Soyez Creatif")]
        [RegularExpression(@"[A-Z].*", ErrorMessage = "Le prenom doit commencer par une majuscule.")]

        public string Prenom
        {
            get => _client.Prenom;
            set
            {
                if (_client.Prenom != value & Validate(value))
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

        public new ObservableCollection<ValidationResult> GetErrors(string propriete)
        {
            return (ObservableCollection<ValidationResult>)base.GetErrors(propriete);
        }
    }
}
