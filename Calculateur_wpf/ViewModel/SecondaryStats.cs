using Microsoft.Practices.Prism.Mvvm;
using System;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    internal class SecondaryStats : BindableBase
    {
        private Character character;

        public int Willpower 
        {
            get
            {
                return character == null ? 0 : character.Willpower;
            }
        }

        public int Robustesse
        {
            get
            {
                return character == null ? 0 : character.Robustesse;
            }
        }

        public int Reflex
        {
            get
            {
                return character == null ? 0 : character.Reflex;
            }
        }

        public int WillAjust
        {
            get
            {
                if (character == null)
                    return 0;
                return 1 + Math.Max(character.GetAspectValue(Aspect.Arcane), character.GetAspectValue(Aspect.Feu));
            }
        }

        public int ReflexAjust
        {
            get
            {
                if (character == null)
                    return 0;
                return 1 + Math.Max(character.GetAspectValue(Aspect.Eau), character.GetAspectValue(Aspect.Vent));
            }
        }

        public int RobustAjust
        {
            get
            {
                if (character == null)
                    return 0;
                return 1 + Math.Max(character.GetAspectValue(Aspect.Acier), character.GetAspectValue(Aspect.Terre));
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

        public SecondaryStats()
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
