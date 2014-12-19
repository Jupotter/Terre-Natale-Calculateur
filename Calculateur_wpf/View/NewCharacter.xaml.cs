using System.Windows;

namespace Calculateur_wpf.View
{
    /// <summary>
    /// Logique d'interaction pour NewCharacter.xaml
    /// </summary>
    public partial class NewCharacter : Window
    {
        public NewCharacter()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewCharacter_OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ViewModel.NewCharacter;

            if (viewModel != null) viewModel.CloseWindow = Close;
            else
                Close();
        }
    }
}
