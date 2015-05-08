using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Linq;
using Calculateur.Backend;

namespace Calculateur.ViewModel
{
    internal class SecondaryStats : BindableBase
    {
        private Character character;


        public int RecoverPC
        {
            get
            {
                if (character == null || character.getClasse() == null)
                    return 0;
                return 4 + character.getClasse().RPC;
            }
        }

        public int RecoverPE
        {
            get
            {
                if (character == null || character.getClasse() == null)
                    return 0;
                return (int) Math.Floor((4 + character.getClasse().RPE)*1.5);
            }
        }

        public int RecoverPS
        {
            get
            {
                if (character == null || character.getClasse() == null)
                    return 0;
                return 4 + character.getClasse().RPE;
            }
        }

        public int RecoverPM
        {
            get
            {
                if (character == null || character.getClasse() == null)
                    return 0;
                return 4 + character.getClasse().RPM;
            }
        }

        public int RecoverPF
        {
            get
            {
                if (character == null || character.getClasse() == null)
                    return 0;
                return 4 + character.getClasse().RPF;
            }
        }

        public int Speed
        {
            get
            {
                if (character == null)
                    return 0;
                var val = 4
                          + (character.GetTalent("Athléthisme").Level
                             + character.GetAspectValue(Aspect.Vent)
                             - character.penPoid)/3;
                return Math.Max(3, val);
            }
        }

        public int Initiative
        {
            get
            {
                if (character == null)
                    return 0;
                return character.GetAspectValue(Aspect.Vent)
                    + character.GetTalent("Rapidité").Level
                    - character.penPoid;
            }
        }

        public int MaxInitiative
        {
            get
            {
                if (character == null)
                    return 0;
                return Initiative + 15;
            }
        }

        public int WeightPenalty
        {
            get
            {
                if (character == null)
                    return 0;
                return character.penPoid;
            }
            set
            {
                if (character == null)
                    return;
                character.penPoid = value;
                OnPropertyChanged(() => Speed);
                OnPropertyChanged(() => Initiative);
                OnPropertyChanged(() => MaxInitiative);
                OnPropertyChanged(() => MagicStats);
            }
        }

        public int MartialMemory
        {
            get
            {
                if (character == null)
                    return 0;
                int martial = character.Talents
                    .Where(talent => talent.Type == TalentType.Aptitude && talent.PrimaryAspect == Aspect.Acier)
                    .Sum(talent => talent.Level);
                return character.GetAspectValue(Aspect.Acier) 
                    + character.GetAspectValue(Aspect.Arcane)
                    + 2*character.GetTalent("Intelligence").Level
                    + 2*martial;
            }
        }

        public int SpellMemory
        {
            get
            {
                if (character == null)
                    return 0;
                int spell = character.Talents
                    .Where(talent => talent.Type == TalentType.Aptitude && talent.PrimaryAspect == Aspect.Arcane)
                    .Sum(talent => talent.Level);
                return character.GetAspectValue(Aspect.Terre)*2
                       + character.GetAspectValue(Aspect.Arcane)*4
                       + character.GetTalent("Intelligence").Level*4
                       + spell*4;
            }
        }

        public SecondaryStatsMagic MagicStats
        {
            get
            {
                return new SecondaryStatsMagic(character);
            }
        }

        public SecondaryStats()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            if (character != null)
                character.PAChanged += CharacterOnPAChanged;
            OnPropertyChanged(null);
        }

        private void CharacterOnPAChanged(Character caller)
        {
            OnPropertyChanged(null);
        }
    }
}
