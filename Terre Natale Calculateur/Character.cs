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

        public int Karma()
        {
            int res = GetLevel() + GetAspectValue(Aspect.Equilibre);
            if (Race == null) return res;
            switch (Race.Name)
            {
                case "Empérien": res += 1 + Convert.ToInt16(Math.Truncate((double)GetLevel() / 3));
                    break;
                case "Keldanien": res += 1 + Convert.ToInt16(Math.Truncate((double)GetLevel() / 3));
                    break;
                case "Attilien": res += 1 + Convert.ToInt16(Math.Truncate((double)GetLevel() / 3));
                    break;
                case "Rosalien": res += 1 + Convert.ToInt16(Math.Truncate((double)GetLevel() / 3));
                    break;
                case "Titanien": res += 1 + Convert.ToInt16(Math.Truncate((double)GetLevel() / 3));
                    break;
                default:
                    break;
            }
            return res;
        }

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

        public int GetLevel()
        {
            for (int i = 0; i < 15; i++)
            {

                if ((15 * (i - 1) * i) > ExperienceAvailable) return i - 1;

            }
            return 15;
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
                int b = 0;
                if (classeChar != null)
                {
                    if (classeChar.StatBonus.Contains("PC"))
                    {
                        b = GetBonusStatValue("PC");
                    }
                }
                return _chiStore.Value + RacialRessources[Ressource.PC] + b;
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

                int b = 0;
                if (classeChar != null)
                {
                    if (classeChar.StatBonus.Contains("PF"))
                    {
                        b = GetBonusStatValue("PF");
                    }
                }
                return _fatigueStore.Value + RacialRessources[Ressource.PF] + b ;
            }
        }

        public int PeIndem
        {
            get 
            {
                int b = 0;
                if (classeChar != null)
                {
                    if (classeChar.StatBonus.Contains("PE"))
                    {
                        b = GetBonusStatValue("PE");
                    }
                }

                return Endurance+GetTalent("Endurance").Level*5+b;
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
                int b = 0;
                if (classeChar != null)
                {
                    if (classeChar.StatBonus.Contains("PM"))
                    {
                        b = GetBonusStatValue("PM");
                    }
                }
                return _manaStore.Value + RacialRessources[Ressource.PM]+b; 
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

        public int GetBonusStatValue(string name)
        {
            int b = 0;
            if (classeChar.StatBonus.Count() == 1)
            { b = GetLevel() + 4; }
            if (classeChar.StatBonus.Count() == 2)
            {
                switch (classeChar.StatBonus.IndexOf(name))
                {
                    case 1: b = Convert.ToInt32(Math.Truncate((double)(5 + GetLevel()) / 2));
                        break;
                    case 2: b = Convert.ToInt32(Math.Truncate((double)(4 + GetLevel()) / 2));
                        break;
                }
            }
            if (classeChar.StatBonus.Count() == 3)
            {
                switch (classeChar.StatBonus.IndexOf(name))
                {
                    case 1: b = Convert.ToInt32(Math.Truncate((double)(6 + GetLevel()) / 3));
                        break;
                    case 2: b = Convert.ToInt32(Math.Truncate((double)(5 + GetLevel()) / 3));
                        break;
                    case 3: b = Convert.ToInt32(Math.Truncate((double)(4 + GetLevel()) / 3));
                        break;
                }
            }
            if (classeChar.StatBonus.Count() == 4)
            {
                switch (classeChar.StatBonus.IndexOf(name))
                {
                    case 1: b = Convert.ToInt32(Math.Truncate((double)(7 + GetLevel()) / 4));
                        break;
                    case 2: b = Convert.ToInt32(Math.Truncate((double)(6 + GetLevel()) / 4));
                        break;
                    case 3: b = Convert.ToInt32(Math.Truncate((double)(5 + GetLevel()) / 4));
                        break;
                    case 4: b = Convert.ToInt32(Math.Truncate((double)(4 + GetLevel()) / 4));
                        break;
                }
            }
            return b;
        }

        #endregion Ressources

        #region stats

        public int Willpower
        {
            get
            {
                return GetTalent("Volonté").Level;
            }
        }

        public int Robustesse
        {
            get
            {
                return GetTalent("Endurance").Level;
            }
        }

        public int Reflex
        {
            get
            {
                return GetTalent("Esquive").Level;
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


         
        public string ExitTxt(View.Form1 Caller)
        {
            string fiche = "";
            fiche += "Nom : " + Name + Environment.NewLine ;
            fiche += "Race : " + Race.Name + Environment.NewLine;
            fiche += "Classe : " + classeChar.Nom + Environment.NewLine;
            fiche += "Niveau : " + GetLevel().ToString() + Environment.NewLine;
            fiche +=  Environment.NewLine+"---------------------------------------------------------" 
                      + Environment.NewLine;

            foreach (Aspect item in Enum.GetValues(typeof(Aspect)))
            {
              if(Aspect.None != item)  fiche += item.ToString() + " : " + GetAspectValue(item) + Environment.NewLine;
            }
            fiche += Environment.NewLine + "---------------------------------------------------------"
                      + Environment.NewLine;

            fiche += "Ps : " + Ps.ToString() + Environment.NewLine;
            fiche += "Pe (Indemne) : " + Caller.GetPrincipalStats().getPeI()+ Environment.NewLine;
            fiche += "Pe : " + Caller.GetPrincipalStats().getEndurance() + Environment.NewLine;
            fiche += "Pe (Agonie) : " + Caller.GetPrincipalStats().getPeA() + Environment.NewLine;
            fiche += "Pf : " + Caller.GetPrincipalStats().getFatigue() + Environment.NewLine;
            fiche += "Pc : " + Caller.GetPrincipalStats().getChi() + Environment.NewLine;
            fiche += "Pm : " + Caller.GetPrincipalStats().getMana() + Environment.NewLine;
            fiche += "Pk : " + Karma().ToString() + Environment.NewLine;

            fiche += Environment.NewLine + "---------------------------------------------------------"
                       + Environment.NewLine;
            fiche += "Talents : " + Environment.NewLine;
            foreach (Talent item in Talents)
            {
                if (item.Level > 0 || item.HaveBonus) fiche += item.Name+" niveau : " + item.Level.ToString() + Environment.NewLine;
            }

            fiche += Environment.NewLine + "---------------------------------------------------------"
                     + Environment.NewLine;
            fiche += "Sauvegarde : " + Environment.NewLine;
            fiche += "Robustesse : " + Robustesse + Environment.NewLine;
            fiche += "Reflex : " + Reflex + Environment.NewLine;
            fiche += "Volonté : " + Willpower + Environment.NewLine;
            fiche += Environment.NewLine + "---------------------------------------------------------"
                     + Environment.NewLine;
            fiche += "Recupération : " + Environment.NewLine;
            fiche += "RPE -> " + (4 + classeChar.RPE).ToString() + Environment.NewLine;
            fiche += "RPF -> " + (4 + classeChar.RPF).ToString() + Environment.NewLine;
            fiche += "RPC -> " + (4 + classeChar.RPC).ToString() + Environment.NewLine;
            fiche += "RPM -> " + (4 + classeChar.RPM).ToString() + Environment.NewLine;
            fiche += Environment.NewLine + "---------------------------------------------------------"
                     + Environment.NewLine;
            fiche += "Stats Secondaire : " + Environment.NewLine;
            fiche += "Penalité de poid : " + penPoid.ToString() + Environment.NewLine;
            fiche += "Impultion de mot : " +  (6-penPoid).ToString() + Environment.NewLine;
            fiche += "Déplacement : " + (GetAspectValue(Aspect.Vent) - penPoid).ToString() + Environment.NewLine;
            fiche += "Base Initiative : " + (Math.Max(2, 3 + GetAspectValue(Aspect.Vent)/3) -penPoid).ToString() + Environment.NewLine;
            
            fiche += Environment.NewLine + "---------------------------------------------------------"
                     + Environment.NewLine;
            fiche += "Inventaire : " + Environment.NewLine;
            foreach (string item in Inventaire)
            {
                fiche += item + Environment.NewLine;
            }

            return fiche;
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
                    try
                    {
                        Talent talent = GetTalent(item.id);

                        if (item.bonus)
                        {
                            talent.Increment(item.level - 1);
                        }
                        else
                        {
                            talent.Increment(item.level);
                        }
                        talent.HaveBonus = item.bonus;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            _aspectBonus = serializableCharacter.AspectBonus;
            _aspectMalus = serializableCharacter.AspectMalus;
            _race = racesManager.GetRace(serializableCharacter.Race);
            if (serializableCharacter.Classe != null && !serializableCharacter.Classe.Equals(""))
                classeChar = classManager.getFormName(serializableCharacter.Classe);
            else
                classeChar = null;
            ExperienceAvailable = serializableCharacter.Experience;
            Inventaire = serializableCharacter.Inventaire;
            if (_race != null)
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
                Classe = classeChar != null ? classeChar.Nom : "",
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