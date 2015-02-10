using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculateur.Backend
{
    class Arme
    {
        string nom;
        Type type;
        int qual;
        int dégatBase;
        int NbDee;
        Dictionary<TypeArmure, int> Difficulte;
    }
}
