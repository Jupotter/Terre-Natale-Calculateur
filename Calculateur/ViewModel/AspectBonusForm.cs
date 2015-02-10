using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using Calculateur.Backend;

namespace Calculateur.ViewModel
{
    class AspectBonusForm : BindableBase
    {
        public static IEnumerable<Aspect> Aspects
        {
            get
            {
                return new[]
                {Aspect.None, Aspect.Eau, Aspect.Feu, Aspect.Terre, Aspect.Vent, Aspect.Acier, Aspect.Arcane,};
            }
        }

        public Action CloseWindow { get; set; }

        private Character character;
        private Aspect bonus1;
        private Aspect bonus2;
        private Aspect malus1;
        private Aspect malus2;

        public Aspect Bonus1
        {
            get { return bonus1; }
            set
            {
                SetProperty(ref bonus1, value);
                OnPropertyChanged(null);
            }
        }

        public bool CanSetBonus2 
        {
            get { return CanSetMalus1 && Malus1 != Aspect.None; }
        }

        public Aspect Bonus2
        {
            get { return bonus2; }
            set
            {
                SetProperty(ref bonus2, value);
                OnPropertyChanged(null);
            }
        }

        public bool CanSetMalus1
        {
            get { return Bonus1 != Aspect.None; }
        }

        public Aspect Malus1
        {
            get { return malus1; }
            set
            {
                SetProperty(ref malus1, value);
                OnPropertyChanged(null);
            }
        }

        public bool CanSetMalus2
        {
            get { return CanSetBonus2 && Bonus2 != Aspect.None; }
        }

        public Aspect Malus2
        {
            get { return malus2; }
            set
            {
                SetProperty(ref malus2, value);
                OnPropertyChanged(null);
            }
        }

        public DelegateCommand AcceptCommand
        { get { return new DelegateCommand(Accept, CanAccept);} }

        private bool CanAccept()
        {
            if (CanSetMalus2)
                return Malus2 != Aspect.None;
            if (CanSetMalus1)
                return Malus1 != Aspect.None;
            return true;
        }

        private void Accept()
        {
            if (character == null)
            {
                return;
            }
            character.SetBonusMalus(Bonus1, Malus1, Bonus2, Malus2);
            CloseWindow();
        }

        public AspectBonusForm()
        {
            if (CharacterManager.Current == null)
                return;
            character = CharacterManager.Current;
            if (character.haveBonus())
            {
                Bonus1 = character.getBonusAspect()[0];
                Bonus2 = character.getBonusAspect()[1];
                Malus1 = character.getMalusAspect()[0];
                Malus2 = character.getMalusAspect()[1];
            }
            else
            {
                Bonus1 = Aspect.None;
                Bonus2 = Aspect.None;
                Malus1 = Aspect.None;
                Malus2 = Aspect.None;
            }
        }
    }
}
