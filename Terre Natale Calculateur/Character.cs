using System.Collections;
using System.Collections.Generic;

namespace Terre_Natale_Calculateur
{
    internal class Character
    {
        private readonly IDictionary<String, Talent> _talents;

        public Character(string name, TalentsFactory talentsFactory)
        {
            Name = name;
            _talents = talentsFactory.CreateSet();
        }

        public string Name { get; set; }

        public IEnumerable<Talent> Talents
        {
            get { return _talents.Values; }
        }

        public Talent GetTalent(String name)
        {
            return _talents[name];
        }
    }
}