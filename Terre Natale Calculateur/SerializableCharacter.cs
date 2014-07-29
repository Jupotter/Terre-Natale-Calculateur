using System;
using System.Collections.Generic;

namespace Terre_Natale_Calculateur
{
    internal struct SerializableCharacter
    {
        public String Name;
        public IEnumerable<SerialisableTalent> Talents;
        public Aspect AspectBonus;
        public Aspect AspectMalus;
        public int Race;
    }
}