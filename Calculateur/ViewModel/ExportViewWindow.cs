using Calculateur;
using Calculateur_Backend;
using Microsoft.Practices.Prism.Mvvm;

namespace Calculateur_wpf.ViewModel
{
    class ExportViewWindow : BindableBase
    {
        private Character character;

        public string ExportedCharacter
        {
            get
            {
                if (character == null)
                    return null;
                return TextExporter.ExportCharacter(character);
            }
        }

        public ExportViewWindow()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
            character = CharacterManager.Current;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            OnPropertyChanged(null);
        }
    }
}
