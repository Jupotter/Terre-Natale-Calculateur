using Calculateur.Backend;
using Microsoft.Practices.Prism.Mvvm;
using System;

namespace Calculateur.ViewModel
{
    internal class SecondaryStatsMagic : BindableBase
    {
        private Character character = null;

        public int Incantation
        {
            get
            {
                if (character == null)
                    return 0;
                return Math.Max(6 - character.penPoid, 1);
            }
        }

        public int ManaImpulsion
        {
            get
            {
                if (character == null)
                    return 0;
                return 5 + character.GetAspectValue(Aspect.Vent) + character.GetTalent("Rapidité").Level;
            }
        }

        public int Concentration
        {
            get
            {
                if (character == null)
                    return 0;
                return 4 * character.GetAspectValue(Aspect.Arcane) + character.GetAspectValue(Aspect.Eau);
            }
        }

        public int Intelligence
        {
            get
            {
                if (character == null)
                    return 0;
                return character.GetAspectValue(Aspect.Arcane) + character.GetAspectValue(Aspect.Feu);
            }
        }

        public SecondaryStatsMagic(Character character = null)
        {
            this.character = character;
            if (character != null)
                character.PAChanged += character_PAChanged;
        }

        private void character_PAChanged(Character caller)
        {
            OnPropertyChanged(null);
        }
    }
}