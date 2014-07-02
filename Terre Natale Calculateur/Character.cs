using System;
using System.Collections.Generic;
using System.Linq;

namespace Terre_Natale_Calculateur
{
    internal sealed class Character
    {
        private int _equilibre = 4;
        private IDictionary<Aspect, int> _aspectPoint;
        private readonly IDictionary<int, Talent> _talents;
        private Dictionary<Aspect, int> bonusaspect = new Dictionary<Aspect, int>();
        private List<Talent> talentbonus = new List<Talent>();
        private Race _race;

        public Character(SerializableCharacter serializableCharacter)
        {
            Name = serializableCharacter.Name;
            _talents = serializableCharacter.Talents.ToDictionary(talent => talent.Id);
            _aspectPoint = new Dictionary<Aspect, int>
            {
                {Aspect.Acier, 30},
                {Aspect.Arcane, 30},
                {Aspect.Eau, 30},
                {Aspect.Feu, 30},
                {Aspect.Terre, 30},
                {Aspect.Vent, 30},
            };
            RecomputePA();
        }

        public Character(string name, TalentsManager talentsManager)
        {
            talentbonus = new List<Talent>()
            {
                new Talent(),
                new Talent(),
            };
            bonusaspect = new Dictionary<Aspect, int>()
            {
                 {Aspect.Acier, 0},
                {Aspect.Arcane, 0},
                {Aspect.Eau, 0},
                {Aspect.Feu, 0},
                {Aspect.Terre, 0},
                {Aspect.Vent, 0},
                {Aspect.Equilibre, 0},
            };
            Name = name;
            _talents = talentsManager.CreateSet();
            foreach (var talent in _talents.Values)
            {
                talent.LevelChanged += (sender, args) => RecomputePA();
            }
            _aspectPoint = new Dictionary<Aspect, int>
            {
                {Aspect.Acier, 30},
                {Aspect.Arcane, 30},
                {Aspect.Eau, 30},
                {Aspect.Feu, 30},
                {Aspect.Terre, 30},
                {Aspect.Vent, 30},
            };
        }

        public event EventHandler PAChanged;

        private void OnPAchanged()
        {
            EventHandler handler = PAChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public string Name { get; set; }

        public Race Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public IEnumerable<Talent> Talents
        {
            get { return _talents.Values; }
        }

        public int GetAspectPoint(Aspect aspect)
        {
            return _aspectPoint[aspect];
        }

        public int GetAspectValue(Aspect aspect)
        {
            int n = 0;
            for (int i = 1; i <= 10; i++)
            {
                n += i * 10;
                if (_aspectPoint[aspect] < n)
                    return i + bonusaspect[aspect];
            }
            return 10;
        }

        public SerializableCharacter GetSerializableCharacter()
        {
            return new SerializableCharacter
            {
                Name = Name,
                Talents = Talents,
            };
        }

        [Obsolete]
        public Talent GetTalent(String name)
        {
            return _talents.Values.First(talent => talent.Name == name);
        }

        private void RecomputePA()
        {
            _aspectPoint = new Dictionary<Aspect, int>(6)
            {
                {Aspect.Acier, 30},
                {Aspect.Arcane, 30},
                {Aspect.Eau, 30},
                {Aspect.Feu, 30},
                {Aspect.Terre, 30},
                {Aspect.Vent, 30},
            };

            foreach (var talent in _talents.Values.Where(talent => talent.SecondaryAspect != Aspect.Equilibre))
            {
                if (Aspect.None == talent.SecondaryAspect)
                {
                    _aspectPoint[talent.PrimaryAspect] += talent.XPCost;
                }
                else
                {
                    _aspectPoint[talent.PrimaryAspect] += talent.XPCost / 2;
                    _aspectPoint[talent.SecondaryAspect] += talent.XPCost / 2;
                }
            }

            OnPAchanged();
        }

        public int Fatigue
        {
            get
            {
                int maxTalent = (from item in _talents.Values 
                                 where item.Type == TalentType.Aptitude && item.PrimaryAspect == Aspect.Acier 
                                 select item.Level).Concat(new[] {0}).Max();
                return Math.Max(GetAspectValue(Aspect.Feu), GetAspectValue(Aspect.Acier)) + _equilibre + maxTalent * 2;
            }
        }

        public int Mana
        {
            get
            {
                int maxTalent = (from item in _talents.Values 
                                 where item.Type == TalentType.Aptitude || item.Type == TalentType.Martial && item.PrimaryAspect == Aspect.Arcane 
                                 select item.Level).Concat(new[] {0}).Max();

                return Math.Max(GetAspectValue(Aspect.Feu), GetAspectValue(Aspect.Terre)) + _equilibre + GetAspectValue(Aspect.Arcane) + maxTalent * 2;
            }
        }

        public int Endurance
        {
            get
            {
                return GetAspectValue(Aspect.Acier) + _equilibre + 5 + GetTalent("Endurance").Level;
            }
        }

        public int Karma
        {
            get
            {
                return _equilibre;
            }
        }

        public int Chi
        {
            get
            {
                int maxTalent = (from item in _talents.Values 
                                 where item.Type == TalentType.Aptitude && item.PrimaryAspect != Aspect.Acier && item.PrimaryAspect != Aspect.Arcane 
                                 select item.Level).Concat(new[] {0}).Max();

                return Math.Max(GetAspectValue(Aspect.Eau), GetAspectValue(Aspect.Vent)) + _equilibre + maxTalent * 2;
            }
        }

        public void setBonus(Dictionary<Aspect, int> bonAspect, List<Talent> talbonus,Race r)
        {
            talentbonus = talbonus;
            _race = r;
            bonusaspect = bonAspect;
            PAChanged(this, null);
        }

        public bool havebonus(Talent quest)
        {
            return (talentbonus[0] == quest || talentbonus[1] == quest);
        }
    }
}