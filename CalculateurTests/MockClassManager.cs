using System;
using Calculateur_Backend;

namespace Calculateur_Tests
{
    class MockClassManager : IClassManager
    {
        public void Initialize()
        {
        }

        public void DumpJSON()
        {
        }

        public void createbase()
        {
            throw new NotImplementedException();
        }

        public Classe getFormName(string search)
        {
            return null;
        }
    }
}
