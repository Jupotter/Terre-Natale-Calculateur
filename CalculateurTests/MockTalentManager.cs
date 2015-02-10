using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur_Backend;

namespace Calculateur_Tests
{
    class MockTalentManager : ITalentsManager
    {
        public void Initialize()
        {
        }

        public DataTable GetTalentsDataTable()
        {
            throw new NotImplementedException();
        }

        public void DumpJSON()
        {;
        }

        public IDictionary<int, Talent> CreateSet()
        {
            return new Dictionary<int, Talent> {{1, new Talent("TestTalent", TalentType.General, Aspect.Acier)}};
        }

        public Talent GetTalent(int id)
        {
            return new Talent("TestTalent", TalentType.General, Aspect.Acier);
        }
    }
}
