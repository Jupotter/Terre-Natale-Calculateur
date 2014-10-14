using System.Collections.Generic;
using Terre_Natale_Calculateur;
using Xunit;

namespace Calculateur_Tests
{
    
    public class CharacterTest
    {
        readonly ITalentsManager talentsManager = new MockTalentManager();

        [Fact]
        public void CharacterSimpleConstructorTest()
        {
            string name = "TestName";
            var character = new Character(name, talentsManager);

            Assert.Equal(name, character.Name);
            Assert.Equal(null, character.Race);
            Assert.Equal(null, character.getClasse());
            Assert.Equal(0, character.ExperienceAvailable);
            Assert.Equal(20, character.ExperienceRemaining);
            Assert.Equal(-20, character.ExperienceUsed);
            /*Assert.Equal(20, character.Fatigue);
            Assert.Equal(20, character.Chi);
            Assert.Equal(20, character.Mana);
            Assert.Equal(20, character.Endurance);*/
        }

        [Fact]
        public void CharacterSerializedConstructorTest()
        {
            var serializedCharacter = new SerializableCharacter
            {
                Name = "Name",
                Experience = 50,
                AspectMalus = new List<Aspect> {Aspect.Arcane, Aspect.Feu},
                AspectBonus = new List<Aspect> {Aspect.Acier, Aspect.Eau}
            };

            var character = new Character(serializedCharacter, talentsManager);

            Assert.Equal("Name", character.Name);
            Assert.Equal(200, character.ExperienceAvailable);
            Assert.Equal(220, character.ExperienceRemaining);
            Assert.Equal(180, character.ExperienceUsed);
        }
    }
}
