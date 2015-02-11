using System;
using System.Collections.Generic;

namespace Calculateur.Backend
{
    class Arme
    {
        string nom;
        Type type;
        int qual;
        int dégatBase;
        int NbDee;
        Dictionary<int, int> Difficulte;
    }
}
