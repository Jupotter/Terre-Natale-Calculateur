using Microsoft.Practices.Prism.Commands;
using System.Windows;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TalentsManager.Instance.Initialize();
            RacesManager.Instance.Initialize();
            ClassManager.Instance.Initialize();
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
    }
}
