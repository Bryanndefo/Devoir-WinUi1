using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App2.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propriete = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propriete));
        }
    }
}
