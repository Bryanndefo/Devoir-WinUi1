using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace App2.ViewModels
{
    public abstract class ViewModelValidable : ViewModelBase, INotifyDataErrorInfo

    {
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        protected Dictionary<string, ObservableCollection<ValidationResult>> _errors =
            new Dictionary<string, ObservableCollection<ValidationResult>>();

        public bool HasErrors
        {
            get => _errors.Any();
        }

        public IEnumerable GetErrors(string propriete)
        {
            if (_errors.ContainsKey(propriete))
            {
                return _errors[propriete];
            }
            else
            {
                return new ObservableCollection<ValidationResult>();
            }
        }

        private void AjoutErreurs(List<ValidationResult> erreursValidation, [CallerMemberName] string propriete = "")
        {
            if (!_errors.ContainsKey(propriete))
            {
                _errors.Add(propriete, new ObservableCollection<ValidationResult>());
            }
            foreach (ValidationResult erreur in erreursValidation)
            {
                _errors[propriete].Add(erreur);
            }
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propriete));
        }

        private void EffacerErreurs([CallerMemberName] string propriete = "")
        {
            if (_errors.ContainsKey(propriete))
            {
                _errors[propriete].Clear();
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propriete));
            }
        }

        public bool Validate<T>(T value, [CallerMemberName] string propriete = "")
        {
            EffacerErreurs(propriete);
            List<ValidationResult> erreursValidation = new List<ValidationResult>();
            ValidationContext contexte =
                new ValidationContext(this, null, null) { MemberName = propriete };
            bool proprieteValide =
                Validator.TryValidateProperty(value, contexte, erreursValidation);

            if (!proprieteValide)
            {
                AjoutErreurs(erreursValidation, propriete);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
