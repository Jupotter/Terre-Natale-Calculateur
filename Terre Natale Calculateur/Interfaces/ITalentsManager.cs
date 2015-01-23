using System.Collections.Generic;
using System.Data;

namespace Calculateur_Backend
{
    public interface ITalentsManager
    {
        void Initialize();
        DataTable GetTalentsDataTable();
        void DumpJSON();
        IDictionary<int, Talent> CreateSet();
        Talent GetTalent(int id);
    }
}