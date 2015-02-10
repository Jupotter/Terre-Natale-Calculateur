using Calculateur.Backend;
using System;

namespace Calculateur.Tests
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
