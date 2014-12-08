using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class TalentsPanel : BindableBase
    {
        private Character character;

        public IEnumerable<Talent> Talents
        {
            get { return character == null ? null : character.Talents; }
        }

        public TalentsPanel()
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
