using System;
using System.Windows.Threading;
using Calculateur.View;
using System.Windows;
using Calculateur.Backend;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Calculateur
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(App));

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            TalentsManager.Instance.Initialize();
            RacesManager.Instance.Initialize();
            ClassManager.Instance.Initialize();
            Bijouxmanager.Instance.Initialize();

            this.DispatcherUnhandledException += OnUnhandledException;

            Log.Info("Application started");

            var window = new MainWindow();
            if (e.Args.Length != 0)
                CharacterManager.Instance.Load(e.Args[0]);
            window.Show();
        }

        private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs dispatcherUnhandledExceptionEventArgs)
        {
            Log.Fatal(dispatcherUnhandledExceptionEventArgs.Exception);

            Shutdown(1);
        }
    }
}
