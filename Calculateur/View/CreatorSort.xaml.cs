using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Calculateur.ViewModel;
namespace Calculateur.View
{
    /// <summary>
    /// Logique d'interaction pour Sort.xaml
    /// </summary>
    
    
    public partial class CreatorSort : Window
    {
        bool loiA = false;
        bool chaosA = false;
        bool ventA = false;
        bool terreA = false;
        bool feuA = false;
        bool eauA = false;
        bool arcaneA = false;
        Calculateur.ViewModel.CreatorSort crea = new ViewModel.CreatorSort();
       
        public CreatorSort()
        {
            
            InitializeComponent();
        }

        public void switchLoi(Object sender,RoutedEventArgs e)
        {
            loiA= !loiA;
            if (loiA) eauA = terreA = chaosA = arcaneA = ventA = feuA = false;
            actuimage();
        }
        public void switchArcane(Object sender, RoutedEventArgs e)
        {
            arcaneA = !arcaneA;
            if (arcaneA) eauA = terreA = chaosA = loiA = ventA = feuA = false;
            actuimage();
        }
        public void switchChaos(Object sender,RoutedEventArgs e)
        {

            chaosA = !chaosA;
            if (chaosA) eauA = terreA = arcaneA = loiA = ventA = feuA = false;
            actuimage();
        }
        public void switchFeu(Object sender, RoutedEventArgs e)
        {

            feuA = !feuA;
            if (feuA) eauA = terreA = arcaneA = loiA = ventA = chaosA = false;
            actuimage();
           
        }
        public void switchTerre(Object sender, RoutedEventArgs e)
        {

            terreA = !terreA;
            if (terreA) eauA = feuA = arcaneA = loiA = ventA = chaosA = false;
            actuimage();
        }
        public void switchEau(Object sender, RoutedEventArgs e)
        {

            eauA = !eauA;
            if (eauA) terreA = feuA = arcaneA = loiA = ventA = chaosA = false;
            actuimage();
        }
        public void switchVent(Object sender, RoutedEventArgs e)
        {

            ventA = !ventA;
            if (ventA) terreA = feuA = arcaneA = loiA = eauA = chaosA = false;
            actuimage();
        }

        public void actuimage()
        {
            
            if (ventA)
            {
                (VentButton.Content as Image).Source = Application.Current.Resources["VentA"] as ImageSource;
                VentButton.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                (VentButton.Content as Image).Source = Application.Current.Resources["Vent"] as ImageSource;
            }
            if (eauA)
            {
                (EauButton.Content as Image).Source = Application.Current.Resources["EauA"] as ImageSource;
                EauButton.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                (EauButton.Content as Image).Source = Application.Current.Resources["Eau"] as ImageSource;
            }
            if (terreA)
            {
                (TerreButton.Content as Image).Source = Application.Current.Resources["TerreA"] as ImageSource;
                TerreButton.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                (TerreButton.Content as Image).Source = Application.Current.Resources["Terre"] as ImageSource;
            }

            if (chaosA)
            {
                (ChaosButton.Content as Image).Source = Application.Current.Resources["ChaosA"] as ImageSource;
                ChaosButton.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                (ChaosButton.Content as Image).Source = Application.Current.Resources["Chaos"] as ImageSource;
            }

            if (loiA)
            {
                (LoiButton.Content as Image).Source = Application.Current.Resources["LoiA"] as ImageSource;
                LoiButton.Background = new SolidColorBrush(Colors.White);

            }
            else
            {
                (LoiButton.Content as Image).Source = Application.Current.Resources["Loi"] as ImageSource;
            }

            if (arcaneA)
            {
                (ArcaneButton.Content as Image).Source = Application.Current.Resources["ArcaneA"] as ImageSource;
                ArcaneButton.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                (ArcaneButton.Content as Image).Source = Application.Current.Resources["Arcane"] as ImageSource;
            }
            if (feuA)
            {
                (FeuButton.Content as Image).Source = Application.Current.Resources["FeuA"] as ImageSource;
                FeuButton.Background = new SolidColorBrush(Colors.White);
            }
            else
            {
                (FeuButton.Content as Image).Source = Application.Current.Resources["Feu"] as ImageSource;
            }
        }

        public List<string> getList()
        {
            

            return crea.getList();
        }

        private void Effet1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    
       
    }
}
