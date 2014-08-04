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
        private int _experienceAvailable;
        private int _expUtilise = 0;
        private Aspect _aspectBonus;
        private Aspect _aspectMalus;
        public Character(SerializableCharacter serializableCharacter)
            : this(serializableCharacter.Name, TalentsManager.Instance)
        {



            foreach (var item in serializableCharacter.Talents)
            {
                if (item.bonus)
                {
                    GetTalent(item.id).Increment(item.level - 1);
                }
                else
                {
                   GetTalent(item.id).Increment(item.level);
                }
                GetTalent(item.id).HaveBonus = item.bonus;
            }
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

        public event EventHandler ExperienceChanged;

        public event EventHandler PAChanged;

        private void OnPAchanged()
        {
            EventHandler handler = PAChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public string Name { get;  set; }

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


        private List<SerialisableTalent> getSerialisableListTalent()
        {
            List<SerialisableTalent> res = new List<SerialisableTalent>();
            foreach (var tal in _talents.Values)
            {
                if (tal.Level > 0)
                {
                    res.Add
                        (new SerialisableTalent
                    {
                        id=tal.Id,
                        level = tal.Level,
                        bonus = tal.HaveBonus,
                    }
                        );
                }
            }
            return res;
        }

        public SerializableCharacter GetSerializableCharacter()
        {
            return new SerializableCharacter
            {
                Name = Name,
                Talents = getSerialisableListTalent(),
                AspectBonus = _aspectBonus,
                AspectMalus = _aspectMalus,
                Race = _race.Id,
            };
        }

        public Talent GetTalent(String name)
        {
            return _talents.Values.First(talent => talent.Name == name);
        }


        public Talent GetTalent(int id)
        {
            return _talents.First(talent => talent.Value.Id == id).Value;
        }


        private void RecomputePA()
        {
            _chiStore = null;
            _enduranceStore = null;
            _fatigueStore = null;
            _karmaStore = null;
            _manaStore = null;
            _totalXpStore = null;

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

        private int? _totalXpStore;

        public int TotalXP
        {
            get
            {
                if (!_totalXpStore.HasValue)
                    _totalXpStore = _talents.Values.Sum(talent => talent.XPCost) - 20;
                return _totalXpStore.Value;
            }
        }

        private int? _fatigueStore;

        public int Fatigue
        {
            get
            {
                if (!_fatigueStore.HasValue)
                {
                    List<int> maxTalent = (from item in _talents.Values
                        where item.Type == TalentType.Aptitude && item.PrimaryAspect == Aspect.Acier
                        select item.Level).ToList();

                    maxTalent.Sort();
                    _fatigueStore = Math.Max(GetAspectValue(Aspect.Feu), GetAspectValue(Aspect.Acier))
                                    + GetAspectValue(Aspect.Equilibre)
                                    + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2])*2;
                }
                return _fatigueStore.Value;
            }
        }

        private int? _manaStore;

        public int Mana
        {
            get
            {
                if (!_manaStore.HasValue)
                {
                    List<int> maxTalent = (from item in _talents.Values
                        where
                            item.Type == TalentType.Aptitude ||
                            item.Type == TalentType.Martial && item.PrimaryAspect == Aspect.Arcane
                        select item.Level).ToList();
                    maxTalent.Sort();
                    _manaStore = Math.Max(GetAspectValue(Aspect.Feu), GetAspectValue(Aspect.Terre)) +
                                 GetAspectValue(Aspect.Arcane)
                                 + GetAspectValue(Aspect.Equilibre)
                                 + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2])*2;
                }
                return _manaStore.Value;
            }
        }

        private int? _enduranceStore;

        public int Endurance
        {
            get
            {
                if (!_enduranceStore.HasValue)
                    _enduranceStore = GetAspectValue(Aspect.Acier) +   GetAspectValue(Aspect.Equilibre) + 5 + GetTalent("Endurance").Level;
                return _enduranceStore.Value;
            }
        }

        private int? _karmaStore;

        public int Karma
        {
            get
            {
                if (!_karmaStore.HasValue)
                    _karmaStore = GetAspectValue(Aspect.Equilibre);
                return _karmaStore.Value;
            }
        }

        private int? _chiStore;

        public int Chi
        {
            get
            {
                if (!_chiStore.HasValue)
                {
                    List<int> maxTalent = (from item in _talents.Values
                        where item.Type == TalentType.Prouesse
                        select item.Level).ToList();
                    maxTalent.Sort();
                    _chiStore = Math.Max(GetAspectValue(Aspect.Eau), GetAspectValue(Aspect.Vent))
                           + GetAspectValue(Aspect.Equilibre)
                           + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2])*2;
                }
                return _chiStore.Value;
            }
        }

        public int ExperienceAvailable
        {
            get { return _experienceAvailable; }
            set
            {
               
                _experienceAvailable = value;
                if (_experienceAvailable < 0)
                    _experienceAvailable = 0;

                ExperienceChanged.Invoke(this, null);
            }
        }

        public int ExperienceRemaining
        {
            get { return _experienceAvailable - TotalXP; }
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

        public void SetBonusMalus(Aspect bonus , Aspect malus)
        {
            _aspectBonus = bonus;
            _aspectMalus = malus;
            RecomputePA();
        }
        
    }
}