using System.Collections.Generic;
using System.Data;

namespace Terre_Natale_Calculateur
{
    internal interface IRacesManager
    {
        void Initialize();
        void DumpJSON();
        Race GetRace(int Id);
        IDictionary<int, Race> CreateSet();
        DataTable GetTalents();
    }
}