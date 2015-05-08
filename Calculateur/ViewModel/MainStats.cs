using Calculateur.Backend;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
namespace Calculateur.ViewModel
{
    class MainStats : BindableBase
    {
        private Character character;

        private MainStatsAspects mainStatsAspects;

        public int Health
        {
            get { return character == null ? 0 : character.Ps; }
        }

        public int EnduranceIndemne
        {
            get { return character == null ? 0 : character.PeIndem; }
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

        public int Speed
        {
            get { return character == null ? 0 : 10 + character.GetTalent("Rapidité").Level; }
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
            mainStatsAspects = new MainStatsAspects(character);
            character.PAChanged += caller1 => OnPropertyChanged(null);
            character.Inventory.TrinketChanged += () => OnPropertyChanged(null);
            character.ClassChanged += (var) => OnPropertyChanged(null);
            OnPropertyChanged(null);
        }
        public Dictionary<Aspect,int> AspectPoint
        {
            get
            {
                if (character == null) return null;
                return
                    new[]
                    {Aspect.Eau, Aspect.Feu, Aspect.Terre, Aspect.Vent, Aspect.Acier, Aspect.Arcane, Aspect.Equilibre}
                        .ToDictionary(item => item, item => character.GetAspectPoint(item));
            }
        }

        public MainStatsAspects Aspects
        {
            get { return mainStatsAspects; }
        }
    }
}
