using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur.Backend;
using Xunit;

namespace Calculateur.Tests
{
    class CyrusTest
    {
        private Character character;

        public CyrusTest()
        {
            TalentsManager.Instance.Initialize();
            ClassManager.Instance.Initialize();
            RacesManager.Instance.Initialize();

            character = CharacterManager.Instance.Create("Cyrus");
        }

        [Fact]
        public void RaceTest()
        {
            character.SetBonus(
                RacesManager.Instance.GetRace(1).AspectBonus,
                new[]
                {
                    character.GetTalent(3),
                    character.GetTalent(22)
                },
                RacesManager.Instance.GetRace(1)
                );

            Assert.Equal(2, character.GetAspectValue(Aspect.Acier));
            Assert.Equal(2, character.GetAspectValue(Aspect.Arcane));
            Assert.Equal(2, character.GetAspectValue(Aspect.Feu));
            Assert.Equal(2, character.GetAspectValue(Aspect.Eau));
            Assert.Equal(2, character.GetAspectValue(Aspect.Vent));
            Assert.Equal(2, character.GetAspectValue(Aspect.Terre));
        }


    }
}
