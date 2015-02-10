using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Calculateur.Backend;

namespace Calculateur.ViewModel
{
    class Header : BindableBase
    {
        private Character character;

        public int ExperienceAvailable
        {
            get { return character == null ? 0 : character.ExperienceAvailable; }
            set
            {
                if (character == null)
                    return;
                character.ExperienceAvailable = value;
                OnPropertyChanged(() => ExperienceAvailable);
                OnPropertyChanged(() => ExperienceRemaining);
            }
        }

        public int ExperienceRemaining
        {
            get { return character == null ? 0 : character.ExperienceRemaining; }
        }

        public DelegateCommand<int?> AddExperienceCommand
        {
            get
            {
                return new DelegateCommand<int?>(
                  i => { if (i.HasValue) AddExperience(i.Value); },
                  CanAddExperience);
            }
        }

        private bool CanAddExperience(int? i)
        {
            return character != null && i.HasValue && i != 0;
        }

        private void AddExperience(int i)
        {
            character.ExperienceAvailable += i;
        }

        public DelegateCommand<int?> RemoveExperienceCommand
        {
            get
            {
                return new DelegateCommand<int?>(
                    i => { if (i.HasValue) RemoveExperience(i.Value); },
                    CanRemoveExperience);
            }
        }

        private bool CanRemoveExperience(int? i)
        {
            return character != null 
                && i.HasValue && i != 0
                && character.ExperienceAvailable - i >= 0
                && character.ExperienceRemaining - i >= 0;
        }

        private void RemoveExperience(int i)
        {
            character.ExperienceAvailable -= i;
        }

        public string Name
        {
            get { return character == null ? "No Character" : character.Name; }
        }

        public string Race
        {
            get
            {
                if (character == null || character.Race == null)
                    return "";
                return character.Race.Name;
            }
        }

        public int Level
        {
            get
            {
                if (character == null)
                    return 0;
                return character.GetLevel();
            }
        }

        public Header()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            character.ExperienceChanged += CharacterOnXpChanged;
            character.PAChanged += CharacterOnXpChanged;
            OnPropertyChanged(null);
        }

        private void CharacterOnXpChanged(Character caller)
        {
            OnPropertyChanged(() => Race);
            OnPropertyChanged(() => ExperienceAvailable);
            OnPropertyChanged(() => ExperienceRemaining);
            OnPropertyChanged(() => AddExperienceCommand);
            OnPropertyChanged(() => RemoveExperienceCommand);
            OnPropertyChanged(() => Level);
        }
    }
}
