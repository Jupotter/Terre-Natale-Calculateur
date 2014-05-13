using System;

namespace Terre_Natale_Calculateur
{
    internal class Talent
    {
        private readonly string _name;
        private readonly Aspect _primaryAspect;
        private readonly Aspect _secondaryAspect;
        private readonly TalentType _type;
        private int _level;

        public Talent(string name, TalentType type, Aspect primaryAspect, Aspect secondaryAspect = Aspect.None)
        {
            Level = 0;
            _name = name;
            _primaryAspect = primaryAspect;
            _secondaryAspect = secondaryAspect;
            _type = type;
        }

        public event EventHandler LevelChanged;

        protected virtual void OnLevelChanged()
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
        }

        public Aspect PrimaryAspect
        {
            get { return _primaryAspect; }
        }

        public Aspect SecondaryAspect
        {
            get { return _secondaryAspect; }
        }

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