using System;
using Newtonsoft.Json;

namespace Terre_Natale_Calculateur
{
    internal class Talent
    {
        private string _name;
        private Aspect _primaryAspect;
        private Aspect _secondaryAspect;
        private TalentType _type;
        private int _level;

        public Talent()
        {
            
        }

        public Talent(string name, TalentType type, Aspect primaryAspect, Aspect secondaryAspect = Aspect.None)
        {
            Level = 0;
            _name = name;
            _primaryAspect = primaryAspect;
            _secondaryAspect = secondaryAspect;
            _type = type;
        }

        public event EventHandler LevelChanged;

        private void OnLevelChanged()
        {
            EventHandler handler = LevelChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnLevelChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        [JsonIgnore]
        public int XPCost
        {
            get
            {
                int ret = 0;
                for (int i = 1; i <= Level; i++)
                    ret += 10 * i;
                return ret;
            }
        }

        public TalentType Type
        {
            get { return _type; }
            set { _type = value;  }
        }

        public int Decrement(int number = 1)
        {
            return Increment(-number);
        }

        public int Increment(int number = 1)
        {
            if (Level + number >= 0 && Level + number <= 5)
                Level += number;
            return XPCost;
        }
    }
}