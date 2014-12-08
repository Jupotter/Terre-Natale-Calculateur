using Microsoft.Practices.Prism.Mvvm;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class Header : BindableBase
    {
        private Character character;

        public int ExperienceAvailable
        {
            get { return character == null ? 0 : character.ExperienceAvailable; }
            set
            {
                if (character == null) return;
                character.ExperienceAvailable = value;
                OnPropertyChanged(() => ExperienceAvailable);
                OnPropertyChanged(() => ExperienceRemaining);
            }
        }

        public int ExperienceRemaining
        {
            get { return character == null ? 0 : character.ExperienceRemaining; }
        }

        public string Name
        {
            get { return character == null ? "No Character" : character.Name; }
        }

        public string Race
        {
            get
            {
                if (character == null || character.Race == null) return "";
                return character.Race.Name;
            }
        }

        public Header()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            character.ExperienceChanged += caller1 =>
            {
                OnPropertyChanged(() => ExperienceAvailable);
                OnPropertyChanged(() => ExperienceRemaining);
            };
            OnPropertyChanged(null);
        }
    }
}
