using System;
using System.Collections.Generic;
using System.Linq;

namespace Terre_Natale_Calculateur
{
    internal sealed class Character
    {
        private IDictionary<Aspect, int> _aspectPoint;
        private readonly IDictionary<int, Talent> _talents;
        private Dictionary<Aspect, int> _bonusAspect = new Dictionary<Aspect, int>();
        private List<Talent> _talentBonus = new List<Talent>();
        private Race _race;
        private int exp=0;
        private int expUtilise = 0;
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
            _talentBonus = new List<Talent>
            {
                new Talent(),
                new Talent(),
            };
            _bonusAspect = new Dictionary<Aspect, int>
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
                {Aspect.Equilibre,30},
            };
        }

        public event EventHandler PAChanged;

        private void OnPAchanged()
        {
            EventHandler handler = PAChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public string Name { get; private set; }

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
                    return i + _bonusAspect[aspect];
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
                {Aspect.Equilibre, 30},
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

        public int TotalXP
        {
            get
            {
                return _talents.Values.Sum(talent => talent.XPCost);
            }
        }

        public int Fatigue
        {
            get
            {
                List<int> maxTalent = (from item in _talents.Values 
                                 where item.Type == TalentType.Aptitude && item.PrimaryAspect == Aspect.Acier
                                   select item.Level).ToList() ;

                maxTalent.Sort();
                return Math.Max(GetAspectValue(Aspect.Feu), GetAspectValue(Aspect.Acier)) 
                    + GetAspectValue(Aspect.Equilibre) 
                    +( maxTalent[maxTalent.Count-1]+ maxTalent[maxTalent.Count-2]) * 2;
            }
        }

        public int Mana
        {
            get
            {
                List<int> maxTalent = (from item in _talents.Values 
                                 where item.Type == TalentType.Aptitude || item.Type == TalentType.Martial && item.PrimaryAspect == Aspect.Arcane
                                       select item.Level).ToList();
                maxTalent.Sort();
                return Math.Max(GetAspectValue(Aspect.Feu), GetAspectValue(Aspect.Terre)) + GetAspectValue(Aspect.Arcane) 
                    + GetAspectValue(Aspect.Equilibre)
                    + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2]) * 2;
            }
        }

        public int Endurance
        {
            get
            {
                return GetAspectValue(Aspect.Acier) +   GetAspectValue(Aspect.Equilibre) + 5 + GetTalent("Endurance").Level;
            }
        }

        public int Karma
        {
            get
            {
                return GetAspectValue(Aspect.Equilibre);
            }
        }

        public int Chi
        {
            get
            {
                List<int> maxTalent = (from item in _talents.Values 
                                 where item.Type == TalentType.Prouesse
                                 select item.Level).ToList();
                maxTalent.Sort();
                return Math.Max(GetAspectValue(Aspect.Eau), GetAspectValue(Aspect.Vent)) 
                    + GetAspectValue(Aspect.Equilibre)
                    + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2]) * 2; 
            }
        }

        public void SetBonus(Dictionary<Aspect, int> bonAspect, List<Talent> talbonus,Race r)
        {
            _talentBonus = talbonus;
            _race = r;
            _bonusAspect = bonAspect;
            PAChanged(this, null);
        }

        public bool HaveBonus(Talent quest)
        {
            return (_talentBonus[0] == quest || _talentBonus[1] == quest);
        }

        public void addExp(int value)
        {
            exp += value;
        }
        public int getExp()
        {
            return exp;
        }
        public int getExpRestant()
        {
            int tt = 0;
            foreach (var item in _talents)
            {
                int expinvest = 0;
                for (int i = 0; i <= item.Value.Level; i++)
                {
                    expinvest += 10 * i;
                }
                tt += expinvest;
            }
            return tt;
        }

        public bool canInvest(int value)
        {
            return exp >= expUtilise + value;
        }
        
    }
}