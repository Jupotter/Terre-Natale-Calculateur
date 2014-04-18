using System;
using System.Collections.Generic;

namespace Terre_Natale_Calculateur
{
    internal class TalentsFactory
    {
        public IDictionary<string, Talent> CreateSet()
        {
            var ret = new Dictionary<String, Talent>();
            ret.Add("Discretion", new Talent("Discretion", Aspect.Eau) {Level = 2});
            ret.Add("Intimidation", new Talent("Intimidation", Aspect.Feu));
            ret.Add("Arme à Distance", new Talent("Arme à Distance", Aspect.Acier, Aspect.Vent));
            return ret;
        }
    }
}