using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Linq;
using Calculateur.Backend;

namespace Calculateur.ViewModel
{
    internal class SavingThrow : BindableBase
    {
        private Character character;

        public int Willpower
        {
            get
            {
                if (character == null) 
                    return 0;
                return 2
                       + character.GetTalent("Volonté").Level
                       + Math.Max(character.GetAspectValue(Aspect.Arcane), character.GetAspectValue(Aspect.Feu))/2;
            }
        }

        public int Robustesse
        {
            get
            {
                if (character == null)
                    return 0;
                return 2
                       + character.GetTalent("Endurance").Level
                       + Math.Max(character.GetAspectValue(Aspect.Acier), character.GetAspectValue(Aspect.Terre)) / 2;
            }
        }

        public int Reflex
        {
            get
            {
                if (character == null)
                    return 0;
                return 2
                       + character.GetTalent("Esquive").Level
                       + Math.Max(character.GetAspectValue(Aspect.Eau), character.GetAspectValue(Aspect.Vent)) / 2;
            }
        }

        public int WillpowerAjust
        {
            get { return WillpowerAjustBase + WillpowerAjustBonus; }
        }

        public int WillpowerAjustBase
        {
            get
            {
                if (character == null)
                    return 0;
                return (Math.Max(character.GetAspectValue(Aspect.Arcane), character.GetAspectValue(Aspect.Feu))
                        + 1)/2;
            }
        }

        public int WillpowerAjustBonus
        {
            get
            {
                if (character == null)
                    return 0;
                int bonus = 0;
                if (character.getClasse() != null)
                    bonus = character.getClasse().GetSaveBonus(character.GetLevel(), "Volonté");
                return bonus;
            }
        }

        public int ReflexeAjust
        {
            get { return ReflexeAjustBase + ReflexeAjustBonus; }
        }

        public int ReflexeAjustBase
        {
            get
            {
                if (character == null)
                    return 0;
                return (Math.Max(character.GetAspectValue(Aspect.Eau), character.GetAspectValue(Aspect.Vent))
                    +1)/2;
            }
        }

        public int ReflexeAjustBonus
        {
            get
            {
                if (character == null)
                    return 0;
                int bonus = 0;
                if (character.getClasse() != null)
                    bonus = character.getClasse().GetSaveBonus(character.GetLevel(), "Réflexe");
                return bonus;
            }
        }

        public int RobustAjust
        {
            get { return RobustAjustBase + RobustAjustBonus; }
        }

        public int RobustAjustBase
        {
            get
            {
                if (character == null)
                    return 0;
                return (Math.Max(character.GetAspectValue(Aspect.Acier), character.GetAspectValue(Aspect.Terre))
                    +1)/2;
            }
        }

        public int RobustAjustBonus
        {
            get
            {
                if (character == null)
                    return 0;
                int bonus = 0;
                if (character.getClasse() != null)
                    bonus = character.getClasse().GetSaveBonus(character.GetLevel(), "Robustesse");
                return bonus;
            }
        }

        public SavingThrow()
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