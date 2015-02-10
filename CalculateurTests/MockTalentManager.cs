using Calculateur.Backend;
using System;
using System.Collections.Generic;
using System.Data;

namespace Calculateur.Tests
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
