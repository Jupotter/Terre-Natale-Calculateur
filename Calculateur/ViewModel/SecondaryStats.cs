using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Linq;
using Calculateur.Backend;

namespace Calculateur.ViewModel
{
    internal class SecondaryStats : BindableBase
    {
        private Character character;

        public int Willpower 
        {
            get
            {
                return character == null ? 0 : character.Willpower + 1;
            }
        }

        public int Robustesse
        {
            get
            {
                return character == null ? 0 : character.Robustesse + 1;
            }
        }

        public int Reflex
        {
            get
            {
                return character == null ? 0 : character.Reflex + 1;
            }
        }

        public int WillAjust
        {
            get
            {
                if (character == null)
                    return 0;
                return  Math.Max(character.GetAspectValue(Aspect.Arcane), character.GetAspectValue(Aspect.Feu));
            }
        }

        public int ReflexAjust
        {
            get
            {
                if (character == null)
                    return 0;
                return Math.Max(character.GetAspectValue(Aspect.Eau), character.GetAspectValue(Aspect.Vent));
            }
        }

        public int RobustAjust
        {
            get
            {
                if (character == null)
                    return 0;
                return  Math.Max(character.GetAspectValue(Aspect.Acier), character.GetAspectValue(Aspect.Terre));
            }
        }

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
                var val = 3 + character.GetAspectValue(Aspect.Vent)/3 - character.penPoid;
                return Math.Max(2, val);
            }
        }

        public int Initiative
        {
            get
            {
                if (character == null)
                    return 0;
                return character.GetAspectValue(Aspect.Vent) - character.penPoid;
            }
        }

        public int ManaImpulsion
        {
            get
            {
                if (character == null)
                    return 0;
                return 6 - character.penPoid;
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
                OnPropertyChanged(() => ManaImpulsion);
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
                return character.GetAspectValue(Aspect.Acier) + character.GetAspectValue(Aspect.Arcane) + martial*2;
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
                return character.GetAspectValue(Aspect.Terre)*2 + character.GetAspectValue(Aspect.Arcane)*4 + spell*4;
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
