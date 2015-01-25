using Microsoft.Practices.Prism.Mvvm;
using Calculateur_Backend;
using System.Collections.Generic;
namespace Calculateur.ViewModel
{
    class MainStats : BindableBase
    {
        private Character character;

        public int Arcane
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Arcane); }
        }

        public int Acier
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Acier); }
        }

        public int Eau
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Eau); }
        }

        public int Feu
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Feu); }
        }

        public int Vent
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Vent); }
        }

        public int Terre
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Terre); }
        }

        public int Equilibre
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Equilibre); }
        }

        public int Health
        {
            get { return character == null ? 0 : character.Ps; }
        }

        public int EnduranceIndemne
        {
            get { return character == null ? 0 : character.Endurance + 5 * character.GetTalent("Endurance").Level; }
        }

        public int Endurance
        {
            get { return character == null ? 0 : character.Endurance; }
        }

        public int EnduranceAgonisant
        {
            get { return character == null ? 0 : character.Endurance + 7 * character.GetTalent("Volonté").Level; }
        }

        public int Mana
        {
            get { return character == null ? 0 : character.Mana; }
        }

        public int Chi
        {
            get { return character == null ? 0 : character.Chi; }
        }

        public int Fatigue
        {
            get { return character == null ? 0 : character.Fatigue; }
        }

        public int Karma
        {
            get { return character == null ? 0 : character.Karma(); }
        }

        public string RacialBonuses
        {
            get
            {
                if (character == null || character.Race == null)
                    return null;
                return character.Race.bonusRaciaux.Replace("#", "").Replace(", ","\n");
            }
        }

        public bool CanSetAspectBonus
        {
            get { return character != null; }
        }

        public MainStats()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            character.PAChanged += caller1 => OnPropertyChanged(null);
            OnPropertyChanged(null);
        }
        public  Dictionary<Aspect,int> AspectPoint
        {
            get
            {
                if (character == null) return null;
                Dictionary<Aspect,int> res = new Dictionary<Aspect,int>();
                foreach (var item in new[] { Aspect.Eau, Aspect.Feu, Aspect.Terre, Aspect.Vent, Aspect.Acier, Aspect.Arcane, Aspect.Equilibre })
                {
                    res.Add(item, character.GetAspectPoint(item));
                }
                return res;
            }
        }

    }
}
