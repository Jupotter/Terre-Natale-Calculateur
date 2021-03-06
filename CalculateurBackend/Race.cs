﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calculateur.Backend
{
    public class Race
    {
        public int Id;
        public readonly string Name;
        public readonly List<int> Talents = new List<int>();
        public readonly Dictionary<Aspect, int> AspectBonus = new Dictionary<Aspect,int>();
        public string bonusRaciaux="";

        public int Mass = 2;
        public int Vitality = 5;

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
