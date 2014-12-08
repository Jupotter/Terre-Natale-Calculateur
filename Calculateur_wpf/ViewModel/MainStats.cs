using Microsoft.Practices.Prism.Mvvm;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class MainStats : BindableBase
    {
        private Character character;

        public int Arcane
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Arcane); }
        }

        public int Acier
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Acier); }
        }

        public int Eau
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Eau); }
        }

        public int Feu
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Feu); }
        }

        public int Vent
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Vent); }
        }

        public int Terre
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Terre); }
        }

        public MainStats()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            character.PAChanged += caller1 => OnPropertyChanged(null);
            OnPropertyChanged(null);
        }
    }
}
