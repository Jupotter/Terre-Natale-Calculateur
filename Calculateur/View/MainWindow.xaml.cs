using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace Calculateur.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public DelegateCommand NewCharacterCommand
        {
            get { return new DelegateCommand(() => NewCharacterOnClick(this, null)); }
        }

        private void NewCharacterOnClick(object sender, RoutedEventArgs e)
        {
            new NewCharacter().ShowDialog();
        }

        public DelegateCommand ExitCommand
        {
            get { return new DelegateCommand(() => ExitOnClick(this, null)); }
        }

        private void ExitOnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void AboutOnClick(object sender, RoutedEventArgs e)
        {
            new AboutDialog().ShowDialog();
        }

        private void OpenMagic(object sender, RoutedEventArgs e)
        {
            new MagicCreator().Show();
        }
    }
}
