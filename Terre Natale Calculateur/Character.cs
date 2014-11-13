using System;
using System.Collections.Generic;
using System.Linq;

namespace Terre_Natale_Calculateur
{
    public enum Ressource{PS,PE,PM,PC,PF,PK,NONE}
    internal sealed class Character
    {
        private readonly IDictionary<int, Talent> _talents;
        private List<Aspect> _aspectBonus = new List<Aspect>();
        private List<Aspect> _aspectMalus= new List<Aspect>();
        private IDictionary<Aspect, int> _aspectPoint;
        private Dictionary<Aspect, int> _bonusAspect = new Dictionary<Aspect, int>();
        private int _experienceAvailable;
        private Race _race;
        private Classe classeChar;

        private Dictionary<Ressource, int> RacialRessources = new Dictionary<Ressource, int>(); 
        public Character(string name, ITalentsManager talentsManager)
        {
            foreach (Ressource item in Enum.GetValues(typeof(Ressource)))
            {
                RacialRessources.Add(item, 0);
            }
            Inventaire = new List<string>();
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

        #region Events

        public delegate void CharacterEventHandler(Character caller);

        public event CharacterEventHandler ExperienceChanged;

        public event CharacterEventHandler PAChanged;

        public event CharacterEventHandler CharacterLoad;

        private void OnExperienceChanged()
        {
            CharacterEventHandler handler = ExperienceChanged;
            if (handler != null)
                handler(this);
        }

        private void OnPAchanged()
        {
            CharacterEventHandler handler = PAChanged;
            if (handler != null)
                handler(this);
        }

        private void OnCharacterLoad()
        {
            CharacterEventHandler handler = CharacterLoad;
            if (handler != null)
                handler(this);
        }
        #endregion Events

        public int ExperienceAvailable
        {
            get { return _experienceAvailable; }
            set
            {
                _experienceAvailable = value;
                if (_experienceAvailable < 0)
                    _experienceAvailable = 0;

                OnExperienceChanged();
            }
        }

        public int ExperienceRemaining
        {
            get { return _experienceAvailable - ExperienceUsed; }
        }

        public int ExperienceUsed
        {
            get
            {
                if (!_totalXpStore.HasValue)
                    _totalXpStore = _talents.Values.Sum(talent => talent.XPCost) - 20;
                return _totalXpStore.Value;
            }
        }

        public string Name { get; set; }

        public int penPoid{ get; set; }

        public List<string> Inventaire { get; set; }

        public Race Race
        {
            get { return _race; }
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
                if (_aspectPoint[aspect] >= n && _aspectPoint[aspect] < (i + 1) * 10 + n)
                    return i + _bonusAspect[aspect];
            }
            return 10;
        }

        public Talent GetTalent(String name)
        {
            return _talents.Values.First(talent => talent.Name == name);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public Talent GetTalent(int id)
        {
            return _talents.First(talent => talent.Value.Id == id).Value;
        }

        public void SetBonus(Dictionary<Aspect, int> bonAspect, IEnumerable<Talent> talbonus, Race r)
        {
            foreach (var talent in talbonus)
            {
                _talents[talent.Id].HaveBonus = true;
            }
            _race = r;
            _bonusAspect = bonAspect;
            PAChanged(this);
            OnExperienceChanged();
        }

        public void SetBonusMalus(Aspect bonus, Aspect malus, Aspect bonus2, Aspect malus2)
        {
            _aspectBonus.Add(bonus);
            _aspectMalus.Add(malus);

            _aspectBonus.Add(bonus2);
            _aspectMalus.Add(malus2);
            RecomputePA();
        }

        #region Ressources

        private int? _chiStore;
        private int? _enduranceStore;
        private int? _fatigueStore;
        private int? _karmaStore;
        private int? _manaStore;
        private int? _totalXpStore;

        public int Ps
        { get { return 4 + RacialRessources[Ressource.PS]; } }

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
                           + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2]) * 2;
                }
                return _chiStore.Value + RacialRessources[Ressource.PC];
            }
        }

        public int Endurance
        {
            get
            {
                if (!_enduranceStore.HasValue)
                    _enduranceStore = GetAspectValue(Aspect.Acier) + GetAspectValue(Aspect.Equilibre) + 5 ;
                return _enduranceStore.Value + RacialRessources[Ressource.PE];
            }
        }

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
                                    + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2]) * 2;
                }
                return _fatigueStore.Value + RacialRessources[Ressource.PF]; ;
            }
        }

        public int Karma
        {
            get
            {
                if (!_karmaStore.HasValue)
                    _karmaStore = GetAspectValue(Aspect.Equilibre);
                return _karmaStore.Value + RacialRessources[Ressource.PK];;
            }
        }

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
                                 + (maxTalent[maxTalent.Count - 1] + maxTalent[maxTalent.Count - 2]) * 2;
                }
                return _manaStore.Value + RacialRessources[Ressource.PM]; 
            }
        }

        public void RecalculateRacialRessources()
        {
            if (_race== null) return;
            string[] toparse = _race.bonusRaciaux.Split(',');
            string towork;
            foreach (string st in toparse)
            {
                if (st.StartsWith("#"))
                {
                    towork=st.Remove(0, 1);
                    if (Enum.GetNames(typeof(Ressource)).Contains(towork.Split(' ').First().Trim()))
                    {
                        Ressource target = Ressource.NONE;

                        foreach (Ressource item in Enum.GetValues(typeof(Ressource)))
                        {
                            if (towork.Split(' ').First() == item.ToString()) target = item;
                        }

                        if (target == Ressource.NONE) return;
                        RacialRessources[target] = Convert.ToInt32(towork.Split(' ').Last());
                        //if (st.Split(' ').Last().Contains('+')) RacialRessources[target] = Convert.ToInt32(st.Split(' ').Last());
                        //if (st.Split(' ').Last().Contains('-')) RacialRessources[target] = Convert.ToInt32(st.Split(' ').Last());
                    }
                }
            }

        }
        #endregion Ressources

        #region stats

        public int Willpower
        {
            get
            {
                return Math.Max((GetAspectValue(Aspect.Arcane) + GetAspectValue(Aspect.Terre))/4,
                    GetTalent("Volonté").Level);
            }
        }

        public int Robustesse
        {
            get
            {
                return Math.Max((GetAspectValue(Aspect.Acier) + GetAspectValue(Aspect.Feu)) / 4,
                    GetTalent("Endurance").Level);
            }
        }

        public int Reflex
        {
            get
            {
                return Math.Max(
                    Math.Max(
                    (GetAspectValue(Aspect.Eau) + GetAspectValue(Aspect.Vent))/4,
                    GetTalent("Esquive").Level),
                    GetTalent("Discipline").Level);
            }
        }

        #endregion

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

            if (_aspectBonus.Count > 0 && _aspectMalus.Count > 0)
            {
                if (_aspectBonus.First() != Aspect.None)
                {
                    _aspectPoint[_aspectBonus.First()] = 60;
                }

                if (_aspectMalus.First() != Aspect.None)
                {
                    _aspectPoint[_aspectMalus.First()] = 10;
                }
                if (_aspectBonus.Last() != Aspect.None)
                {
                    _aspectPoint[_aspectBonus.Last()] = 60;
                }

                if (_aspectMalus.Last() != Aspect.None)
                {
                    _aspectPoint[_aspectMalus.Last()] = 10;
                }

            }

            foreach (var talent in _talents.Values)
            {
                if (Aspect.None == talent.SecondaryAspect)
                {
                    if (Aspect.None != talent.PrimaryAspect) _aspectPoint[talent.PrimaryAspect] += talent.XPCost;
                    
                }
                else
                {
                    _aspectPoint[talent.PrimaryAspect] += talent.XPCost / 2;
                    _aspectPoint[talent.SecondaryAspect] += talent.XPCost / 2;
                }
            }
         
            OnPAchanged();
        }

        #region Serialization

        public Character(SerializableCharacter serializableCharacter)
            : this(serializableCharacter, TalentsManager.Instance)
        { }

        public Character(
            SerializableCharacter serializableCharacter,
            ITalentsManager manager,
            IRacesManager racesManager = null,
            IClassManager classManager = null
            )
            : this(serializableCharacter.Name, manager)
        {
            if (racesManager == null)
                racesManager = RacesManager.Instance;
            if (classManager == null)
                classManager = ClassManager.Instance;

            if (serializableCharacter.Talents != null)
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
            }
            _aspectBonus = serializableCharacter.AspectBonus;
            _aspectMalus = serializableCharacter.AspectMalus;
            _race = racesManager.GetRace(serializableCharacter.Race);
            classeChar = classManager.getFormName(serializableCharacter.Classe);
            ExperienceAvailable = serializableCharacter.Experience;
            Inventaire = serializableCharacter.Inventaire;
            _bonusAspect = _race.AspectBonus;
            penPoid = serializableCharacter.penPoid;
            RecomputePA();
            
        }

        public SerializableCharacter GetSerializableCharacter()
        {
            return new SerializableCharacter
            {
                Name = Name,
                Talents = GetSerialisableListTalent(),
                AspectBonus = _aspectBonus,
                AspectMalus = _aspectMalus,
                Race = _race.Id,
                Experience = ExperienceAvailable,
                Classe=classeChar.Nom,
                Inventaire=Inventaire,
                penPoid=penPoid,
            };
        }
        public void SetClasse(Classe def)
        {
            classeChar = def;
        }
        public Classe getClasse()
        {
            return classeChar;
        }
        private IEnumerable<SerialisableTalent> GetSerialisableListTalent()
        {
            return (from tal in _talents.Values
                    where tal.Level > 0
                    select new SerialisableTalent
                    {
                        id = tal.Id,
                        level = tal.Level,
                        bonus = tal.HaveBonus,
                    }).ToList();
        }

        public bool haveBonus()
        {
            if (_aspectBonus.Count > 0) return true;
            return false;
        }
        public List<Aspect> getBonusAspect()
        {
            return _aspectBonus;
        }
        public List<Aspect> getMalusAspect()
        {
            return _aspectMalus;
        }
        #endregion Serialization

    
    }
}