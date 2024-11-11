using App2.Data;
using App2.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Foundation.Metadata;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Clients : Page
    {
        public MainViewModel ViewModel { get; }
        public Clients()
        {
            this.InitializeComponent();
            ViewModel = new MainViewModel(new DBClientDataProvider());
            root.Loaded += Root_Loaded;
        }

        private void Root_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ChargerDonnees();
        }

        private void VoirAjout(object sender, RoutedEventArgs e)
        {
            this.listeClients.Visibility = Visibility.Collapsed;
            this.ajout.Visibility = Visibility.Visible;
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            ViewModel.AjouterClient();
            this.listeClients.Visibility = Visibility.Visible;
            this.ajout.Visibility = Visibility.Collapsed;
        }

        private async void ConfirmerSuppressionClient()
        {
            ContentDialog dialogueSuppression = new ContentDialog
            {
                Title = "Supprimer le Client",
                Content = $"Voulez-vous vraiment supprimer le client {ViewModel.ClientSelectionne.Prenom} {ViewModel.ClientSelectionne.Nom}?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler"
            };

            if(ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
            {
                dialogueSuppression.XamlRoot = this.XamlRoot;
            }

            ContentDialogResult result = await dialogueSuppression.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.SupprimerClientSelectionne();
            }
        }
        private void SupprimerClient(object sender, RoutedEventArgs e)
        {
            ConfirmerSuppressionClient();
        }
    }
}
