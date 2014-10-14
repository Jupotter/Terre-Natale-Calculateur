using System.Collections.Generic;
using System.Data;

namespace Terre_Natale_Calculateur
{
    internal interface ITalentsManager
    {
        void Initialize();
        DataTable GetTalents();
        void DumpJSON();
        IDictionary<int, Talent> CreateSet();
        Talent GetTalent(int id);
    }
}