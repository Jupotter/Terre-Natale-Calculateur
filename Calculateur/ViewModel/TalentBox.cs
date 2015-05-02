using System;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Calculateur.Backend;
using Xceed.Wpf.DataGrid.Converters;

namespace Calculateur.ViewModel
{
    class TalentBox : BindableBase
    {
        private readonly Talent talent;
        private readonly Character character;

        public int Level
        {
            get
            {
                if (talent == null)
                    return 3;
                return talent.Level;
            }
        }

        public string Name
        {
            get
            {
                if (talent == null)
                    return "Talent name";
                return talent.Name;
            }
        }

        public int Throw
        {
            get
            {
                if (talent == null)
                    return 0;
                return 2
                       + Level
                       + character.GetAspectValue(talent.PrimaryAspect)/2;
            }

        }

        public DelegateCommand AddLevelCommand
        {
            get { return new DelegateCommand(AddLevel, () => CanLevelUp); }
        }

        public DelegateCommand RemoveLevelCommand
        {
            get { return new DelegateCommand(RemoveLevel, () => CanLevelDown);}
        }

        public TalentBox()
            : this(null, null)
        {

        }

        public TalentBox(Talent talent, Character character)
        {
            if (character == null)
                return;
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
            get
            {
                if (talent == null)
                    return false;
                return talent.Level <= 5 && character.ExperienceRemaining >= (talent.GetXpNeeded() - talent.XPCost);
            }
        }

        private bool CanLevelDown
        {
            get
            {
                if (talent == null)
                    return false;
                if ((talent.Level > 1 && talent.HaveBonus))
                {
                    return true;
                }
                return talent.Level > 0 && !talent.HaveBonus;
            }
        }
    }
}
