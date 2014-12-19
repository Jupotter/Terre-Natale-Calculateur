using Microsoft.Win32;
using System.Windows;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Character character;

        public MainWindow()
        {
            TalentsManager.Instance.Initialize();
            RacesManager.Instance.Initialize();
            ClassManager.Instance.Initialize();
            CharacterManager.CharacterChanged += CharacterManager_CharacterChanged;
            InitializeComponent();

            this.DataContext = this;
        }

        void CharacterManager_CharacterChanged(Character caller)
        {
            DataContext = caller;
            character = caller;
            Title = caller.Name;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            new NewCharacter().ShowDialog();
        }

        private void OpenMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            RacesManager.Instance.Initialize();
            var openFileDialog = new OpenFileDialog {Filter = "Feuille de personnage |*.chr|Tous les fichier |*.*"};
            if (openFileDialog.ShowDialog() == true)
                CharacterManager.Instance.Load(openFileDialog.FileName);
        }
    }
}
