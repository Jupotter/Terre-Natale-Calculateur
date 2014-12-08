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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf
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
            CharacterManager.Instance.Create("Test");
        }
    }
}
