using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
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
    }

    
}
