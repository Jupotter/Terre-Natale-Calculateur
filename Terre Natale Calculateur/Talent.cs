namespace Terre_Natale_Calculateur
{
    internal class Talent
    {
        private readonly string _name;
        private readonly Aspect _primaryAspect;
        private readonly Aspect _secondaryAspect;

        public Talent(string name, Aspect primaryAspect, Aspect secondaryAspect = Aspect.None)
        {
            Level = 0;
            _name = name;
            _primaryAspect = primaryAspect;
            _secondaryAspect = secondaryAspect;
        }

        public string Name
        {
            get { return _name; }
        }

        public Aspect PrimaryAspect
        {
            get { return _primaryAspect; }
        }

        public int XPCost
        {
            get
            {
                int ret = 0;
                for (int i = 1; i <= Level; i++)
                    ret += 10*i;
                return ret;
            }
        }

        public int Increment(int number = 1)
        {
            Level += number;
            return XPCost;
        }

        public int Decrement(int number = 1)
        {
            return Increment(-number);
        }

        public Aspect SecondaryAspect
        {
            get { return _secondaryAspect; }
        }

        public int Level { get; private set; }
    }
}