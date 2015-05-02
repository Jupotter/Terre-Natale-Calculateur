using System.Windows;
using System.Windows.Controls;
using Calculateur.Backend;

namespace Calculateur.View
{
    /// <summary>
    /// Logique d'interaction pour TalentGroupBox.xaml
    /// </summary>
    public partial class TalentGroupBox : UserControl
    {
        public TalentGroupBox()
        {
            InitializeComponent();
        }

        private void OnContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var context = DataContext as ViewModel.TalentGroupBox;
            if (context == null || context.Aspect == Aspect.None)
            {
                AjustmentPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                AjustmentPanel.Visibility = Visibility.Visible;
            }

        }
    }
}
