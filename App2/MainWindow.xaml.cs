using App2.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ContentFrame_NavigationFailed(
                        object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Impossible de charger la page " +
                e.SourcePageType.FullName);
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigated += On_Navigated;
            // Au chargement de la page, charger la première page du menu
            NavView.SelectedItem = NavView.MenuItems[3];
        }

        private void NavView_SelectionChanged(
            NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.SelectedItemContainer.Tag.ToString());
                NavView_Navigate(navPageType, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(
            Type navPageType, NavigationTransitionInfo transitionInfo)
        {
            if (navPageType is not null)
            {
                ContentFrame.Navigate(navPageType, null, transitionInfo);
            }
        }

        private void NavView_BackRequested(NavigationView sender,
            NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private bool TryGoBack()
        {
            if (!ContentFrame.CanGoBack)
            {
                return false;
            }
            else
            {
                ContentFrame.GoBack();
                return true;
            }
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType != null)
            {
                // Trouver la page à charger
                NavView.SelectedItem = NavView.MenuItems
                            .OfType<NavigationViewItem>()
                            .First(i => i.Tag.Equals(ContentFrame.SourcePageType.
                                                                    FullName.ToString()));

                // Afficher dans l'entête le titre de la page
                NavView.Header = ((NavigationViewItem)NavView.SelectedItem)?.
                                                        Content?.ToString();
            }
        }
    }
}
