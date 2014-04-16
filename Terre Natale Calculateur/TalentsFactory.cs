using System.Collections.Generic;

namespace Terre_Natale_Calculateur
{
    internal class TalentsFactory
    {
        public ICollection<Talent> CreateSet()
        {
            var ret = new HashSet<Talent>();
            ret.Add(new Talent("Discretion", Aspect.Eau) {Level = 2});
            ret.Add(new Talent("Intimidation", Aspect.Feu));
            ret.Add(new Talent("Arme à Distance", Aspect.Acier, Aspect.Vent));
            return ret;
        }
    }
}