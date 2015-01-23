﻿using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace Calculateur_wpf.View
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
    }
}
