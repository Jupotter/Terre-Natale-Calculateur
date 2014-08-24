using System;
using System.Collections.Generic;

namespace Terre_Natale_Calculateur
{
    internal struct SerializableCharacter
    {
        public String Name;
        public IEnumerable<SerialisableTalent> Talents;
        public List<Aspect> AspectBonus;
        public List<Aspect> AspectMalus;
        public int Race;
        public int Experience;
        public string Classe;
    }
}