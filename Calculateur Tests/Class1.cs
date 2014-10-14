using System;
using Terre_Natale_Calculateur;
using Xunit;

namespace Calculateur_Tests
{
    public class Class1
    {
        readonly ITalentsManager talentsManager = new MockTalentManager();

        [Fact]
        public void CharacterConstructorTest()
        {
            string name = "TestName";
            var character = new Character(name, talentsManager);

            Assert.Equal(name, character.Name);
            Assert.Equal(null, character.Race);
        }
    }
}
