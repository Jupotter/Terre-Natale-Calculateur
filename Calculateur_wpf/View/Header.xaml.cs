using System.Windows.Controls;
using System.Windows.Media;

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
    }
}
