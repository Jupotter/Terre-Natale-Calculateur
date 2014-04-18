using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Terre_Natale_Calculateur
{
    internal class TalentsFactory
    {
        public IDictionary<string, Talent> CreateSet()
        {
            var sr = new StreamReader("Talents.json");
            var list = JsonConvert.DeserializeObject<List<Talent>>(sr.ReadToEnd());
            return list.ToDictionary(talent => talent.Name);
        }

        public static void GenerateJSON()
        {
            var ret = new Dictionary<String, Talent>();
            ret.Add("Discretion", new Talent("Discretion", Aspect.Eau) { Level = 2 });
            ret.Add("Intimidation", new Talent("Intimidation", Aspect.Feu));
            ret.Add("Arme à Distance", new Talent("Arme à Distance", Aspect.Acier, Aspect.Vent));
            String json = JsonConvert.SerializeObject(ret.Values);
            Console.Write(json);
        }
    }
}