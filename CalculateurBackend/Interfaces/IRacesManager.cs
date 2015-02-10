using System.Collections.Generic;
using System.Data;

namespace Calculateur.Backend
{
    public interface IRacesManager
    {
        void Initialize();
        void DumpJSON();
        Race GetRace(int Id);
        IDictionary<int, Race> CreateSet();
        DataTable GetTalents();
    }
}