using System;
using System.Collections.Generic;

namespace Calculateur_Backend
{
    public struct SerializableCharacter
    {
        public String Name;
        public IEnumerable<SerialisableTalent> Talents;
        public List<Aspect> AspectBonus;
        public List<Aspect> AspectMalus;
        public int Race;
        public int Experience;
        public string Classe;
        public List<string> Inventaire;
        public int penPoid;
    }
}