using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Practices.Prism.Commands;

namespace Calculateur_wpf.View
{
    /// <summary>
    /// Logique d'interaction pour Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                this.Background = Brushes.White;
            }
        }

        private void Exp3Collapsed(object sender, RoutedEventArgs e)
        {
            var r = exp3.Template.FindName("ExpandSite", exp3) as UIElement;
            r.Visibility = System.Windows.Visibility.Visible;

            var sb1 = (Storyboard)exp3.FindResource("SbCollapse");
            sb1.Begin();
        }

        private void ExperienceBoxChanged(object sender, RoutedEventArgs e)
        {
            if (XpMinusButton == null || XpPlusButton == null)
                return;
            var delegateCommand = XpMinusButton.Command as DelegateCommand<int?>;
            if (delegateCommand != null)
                delegateCommand.RaiseCanExecuteChanged();
            delegateCommand = XpPlusButton.Command as DelegateCommand<int?>;
            if (delegateCommand != null)
                delegateCommand.RaiseCanExecuteChanged();
        }
    }
}
