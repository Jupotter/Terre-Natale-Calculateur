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
                return 4 + character.GetAspectValue(Aspect.Vent) + character.GetTalent("Rapidité").Level;
            }
        }

        public int Concentration
        {
            get
            {
                if (character == null)
                    return 0;
                return 2*character.GetAspectValue(Aspect.Arcane)
                       + 4*character.GetAspectValue(Aspect.Eau)
                       + character.GetTalent("Méditation").Level;
            }
        }

        public double Amplification
        {
            get
            {
                if (character == null)
                    return 0;
                return Math.Floor(0.25*character.GetAspectValue(Aspect.Arcane) 
                    + 0.5*character.GetAspectValue(Aspect.Feu)
                    + 0.5*character.GetTalent("Intelligence").Level);
            }
        }

        public double Focus
        {
            get
            {
                if (character == null)
                    return 0;
                return Math.Floor(0.5 * character.GetAspectValue(Aspect.Arcane)
                    + 0.5 * character.GetAspectValue(Aspect.Terre)
                    + 0.5 * character.GetTalent("Méditation").Level);
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