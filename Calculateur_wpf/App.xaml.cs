using Calculateur_wpf.View;
using System.Windows;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow();
            TalentsManager.Instance.Initialize();
            RacesManager.Instance.Initialize();
            ClassManager.Instance.Initialize();
            if (e.Args.Length != 0)
                CharacterManager.Instance.Load(e.Args[0]);
            window.Show();
        }
    }
}
