using System.Collections;
using System.Collections.Generic;

namespace Terre_Natale_Calculateur
{
    internal class Character
    {
        private ICollection<Talent> _talents; 

        public Character(string name, TalentsFactory talentsFactory)
        {
            Name = name;
            _talents = talentsFactory.CreateSet();
        }

        public string Name { get; set; }

        public IEnumerable<Talent> Talents
        {
            get { return _talents; }
        }
    }
}