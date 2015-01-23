using System.Windows;

namespace Calculateur_wpf.View
{
    /// <summary>
    /// Logique d'interaction pour AspectBonusForm.xaml
    /// </summary>
    public partial class AspectBonusForm : Window
    {
        public AspectBonusForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AspectBonusForm_OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ViewModel.AspectBonusForm;

            if (viewModel != null)
                viewModel.CloseWindow = Close;
            else
                Close();
        }
    }
}
