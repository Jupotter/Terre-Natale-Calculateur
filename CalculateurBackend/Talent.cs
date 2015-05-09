using System.Diagnostics;
using Calculateur.Backend.Annotations;
using Newtonsoft.Json;
using System;

namespace Calculateur.Backend
{
    public class Talent : ICloneable
    {
        private bool _haveBonus;
        private int _id;
        private int _level;
        private string _name;
        private bool _savoir;
        private Aspect _primaryAspect;
        private Aspect _secondaryAspect;
        private TalentType _type;
// ReSharper disable MemberCanBePrivate.Global
        public Talent()
        {
        }

        [UsedImplicitly]
        public Talent(string name, TalentType type, Aspect primaryAspect, Aspect secondaryAspect = Aspect.None, bool savoir = false)
        {
            Level = 0;
            _name = name;
            _primaryAspect = primaryAspect;
            _secondaryAspect = secondaryAspect;
            _type = type;
            _savoir = savoir;
        }
// ReSharper restore MemberCanBePrivate.Global

        public event EventHandler LevelChanged;

        public bool HaveBonus
        {
            get { return _haveBonus; }
            set
            {
                if (HaveBonus && value == false)
                {
                    Decrement();
                }
                else if (HaveBonus == false && value)
                {
                    Increment();
                }
                _haveBonus = value;
            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool Savoir
        {
            get { return _savoir; }
            set { _savoir = value; }
        }

        public int Level
        {
            get { return _level; }
            private set
            {
                _level = value;
                OnLevelChanged();
            }
        }

        public int SpeLevel
        {
            get { return speLevel; }
            set
            {
                speLevel = value;
                OnLevelChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TalentType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Aspect PrimaryAspect
        {
            get { return _primaryAspect; }
            set { _primaryAspect = value; }
        }

        public Aspect SecondaryAspect
        {
            get { return _secondaryAspect; }
            set { _secondaryAspect = value; }
        }
        #region Experience

        private int? _xpStore;
        private int speLevel;

        [JsonIgnore]
        public int XPCost
        {
            get
            {
                if (!_xpStore.HasValue)
                {
                    int ret = 0;
                    for (int i = 1; i <= Level; i++)
                        ret += 10 * i;
                    _xpStore = ret;
                    ret = 0;
                    for (int i = 1; i <= SpeLevel; i++)
                        ret += 5 * i;
                    _xpStore += ret;
                }
                Debug.Assert(_xpStore != null, "_xpStore != null");
                return _xpStore.Value;
            }
        }

        public int GetXpNeeded()
        {
            int ret = 0;
            for (int i = 1; i <= Level + 1; i++)
                ret += 10 * i;
            return ret;
        }

        public int SpeGetXpNeeded()
        {
            int ret = 0;
            for (int i = 1; i <= SpeLevel + 1; i++)
                ret += 10 * i;
            return ret;
        }

        #endregion

        public object Clone()
        {
            return new Talent
            {
                _id = Id,
                _name = Name,
                _primaryAspect = PrimaryAspect,
                _secondaryAspect = SecondaryAspect,
                _type = Type,
                _savoir = Savoir,
            };
        }

        public int Decrement(int number = 1, bool Spe = false)
        {
            return Increment(-number, Spe);
        }

        public int Increment(int number = 1, bool spe = false)
        {
            if (spe)
            {
                if (SpeLevel + number >= 0
                    && SpeLevel + number <= 5)
                    SpeLevel += number;
            }
            else
            {
                if (Level + number >= (_haveBonus ? 1 : 0)
                    && Level + number <= 5)
                    Level += number;
            }
            return XPCost;
        }

        private void OnLevelChanged()
        {
            _xpStore = null;
            EventHandler handler = LevelChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public void Reset()
        {
            _level = 0;
            speLevel = 0;
            _haveBonus = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}