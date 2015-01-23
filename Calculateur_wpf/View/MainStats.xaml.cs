using System.Windows;
using System.Windows.Controls;

namespace Calculateur.View
{
    /// <summary>
    /// Logique d'interaction pour MainStats.xaml
    /// </summary>
    public partial class MainStats : UserControl
    {
        public MainStats()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AspectBonusForm().ShowDialog();
        }
    }
}
