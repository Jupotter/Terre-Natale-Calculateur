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
        private Race _race;
        private int _exp;
        private int _expUtilise = 0;
        private Aspect _aspectBonus;
        private Aspect _aspectMalus;



        public Character(SerializableCharacter serializableCharacter)
        {
            Name = serializableCharacter.Name;
            _talents = serializableCharacter.Talents.ToDictionary(talent => talent.Id);
            _aspectBonus = serializableCharacter.AspectBonus;
            _aspectMalus = serializableCharacter.AspectMalus;
            _race = RacesManager.Instance.GetRace(serializableCharacter.Race);

            _bonusAspect = _race.AspectBonus;

            RecomputePA();
        }

        public Character(string name, TalentsManager talentsManager)
        {
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
            for (int i = 0; i <= 10; i++)
            {
                n += i * 10;
                if (_aspectPoint[aspect] >= n && _aspectPoint[aspect]< (i+1)*10+n)
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
                AspectBonus = _aspectBonus,
                AspectMalus = _aspectMalus,
                Race = _race.Id,
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

            if(_aspectBonus != Aspect.None)
            {
                _aspectPoint[_aspectBonus] = 60;
            }

            if (_aspectMalus != Aspect.None)
            {
                _aspectPoint[_aspectMalus] = 10;
            }
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
                return _talents.Values.Sum(talent => talent.XPCost) - 20;
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
            foreach (var talent in talbonus)
            {
                _talents[talent.Id].HaveBonus = true;
            }
            _race = r;
            _bonusAspect = bonAspect;
            PAChanged(this, null);
        }

        public void addExp(int value)
        {
            _exp += value;
        }
        public int getExp()
        {
            return _exp;
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
            return _exp >= _expUtilise + value;
        }

        public void SetBonusMalus(Aspect bonus , Aspect malus)
        {
            _aspectBonus = bonus;
            _aspectMalus = malus;
            RecomputePA();
        }
        
    }
}