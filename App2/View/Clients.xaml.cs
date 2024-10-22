using App2.Data;
using App2.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

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
            ViewModel = new MainViewModel(new ClientDataProvider());
            root.Loaded += Root_Loaded;
        }

        private void Root_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ChargerDonnees();
        }

        private void VoirAjout(object sender, RoutedEventArgs e)
        {
            ViewModel.AjouterClient();
            this.listeClients.Visibility = Visibility.Collapsed;
            this.ajout.Visibility = Visibility.Visible;
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            ViewModel.AjouterClient();
            this.listeClients.Visibility = Visibility.Visible;
            this.ajout.Visibility = Visibility.Collapsed;
        }
    }
}
