using System;
using System.Collections.Generic;

namespace Calculateur_Backend
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
