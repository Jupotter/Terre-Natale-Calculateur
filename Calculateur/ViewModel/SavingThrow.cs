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

        public int WillpowerAjustBase
        {
            get
            {
                if (character == null)
                    return 0;
                return Math.Max(character.GetAspectValue(Aspect.Arcane), character.GetAspectValue(Aspect.Feu));
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

        public int ReflexeAjustBase
        {
            get
            {
                if (character == null)
                    return 0;
                return Math.Max(character.GetAspectValue(Aspect.Eau), character.GetAspectValue(Aspect.Vent));
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

        public int RobustAjustBase
        {
            get
            {
                if (character == null)
                    return 0;
                return Math.Max(character.GetAspectValue(Aspect.Acier), character.GetAspectValue(Aspect.Terre));
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