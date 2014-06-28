using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terre_Natale_Calculateur
{
    class Race
    {
        private int _id;
        private string _name;
        private IList<int> _talentsBonus;
        private Dictionary<Aspect, int> _aspectBonus;
    }
}
