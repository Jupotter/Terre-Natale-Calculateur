using Microsoft.Practices.Prism.Mvvm;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class MainWindow : BindableBase
    {
        private Character character;

        public string Name
        {
            get { return character == null ? "No Character" : character.Name; }
        }

        public MainWindow()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            OnPropertyChanged(null);
        }
    }
}
