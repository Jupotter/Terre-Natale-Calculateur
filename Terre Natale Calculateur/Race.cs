using System.Collections.Generic;
namespace Terre_Natale_Calculateur
{
    class Race
    {
        public int Id;
        public readonly string Name;
        public readonly List<int> Talents = new List<int>();
        public readonly Dictionary<Aspect, int> AspectBonus = new Dictionary<Aspect,int>();
        public string bonusRaciaux="";
        public Race(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    
}
