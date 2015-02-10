using System;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Calculateur.Backend;

namespace Calculateur.ViewModel
{
    class TalentBox : BindableBase
    {
        private readonly Talent talent;
        private readonly Character character;

        public int Level
        {
            get { return talent.Level; }
        }

        public string Name
        {
            get { return talent.Name; }
        }

        public DelegateCommand AddLevelCommand
        {
            get { return new DelegateCommand(AddLevel, () => CanLevelUp); }
        }

        public DelegateCommand RemoveLevelCommand
        {
            get { return new DelegateCommand(RemoveLevel, () => CanLevelDown);}
        }

        public TalentBox(Talent talent, Character character)
        {
            this.talent = talent;
            this.character = character;
            character.ExperienceChanged += CharacterOnExperienceChanged;
            character.PAChanged += CharacterOnExperienceChanged;
        }

        private void CharacterOnExperienceChanged(Character caller)
        {
            OnPropertyChanged(null);
        }

        private void AddLevel()
        {
            talent.Increment();
            OnPropertyChanged(null);
        }

        private void RemoveLevel()
        {
            talent.Decrement();
            OnPropertyChanged(null);
        }

        private bool CanLevelUp
        {
            get { return talent.Level <= 5 && character.ExperienceRemaining >= (talent.GetXpNeeded() - talent.XPCost); }
        }

        private bool CanLevelDown
        {
            get
            {
                if ((talent.Level > 1 && talent.HaveBonus))
                {
                    return true;
                }
                return talent.Level > 0 && !talent.HaveBonus;
            }
        }
    }
}
