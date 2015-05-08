using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur.Backend;
using Xunit;

namespace Calculateur.Tests
{
    public class Cyrus0Test
    {
        private Character character;

        public Cyrus0Test()
        {
            TalentsManager.Instance.Initialize();
            ClassManager.Instance.Initialize();
            RacesManager.Instance.Initialize();

            character = CharacterManager.Instance.Create("Cyrus");

            character.SetBonus(
                RacesManager.Instance.GetRace(1).AspectBonus,
                new[]
                {
                    character.GetTalent(3),
                    character.GetTalent(22)
                },
                RacesManager.Instance.GetRace(1)
                );

        }

        [Fact]
        public void AspectTest()
        {
            Assert.Equal(2, character.GetAspectValue(Aspect.Acier));
            Assert.Equal(2, character.GetAspectValue(Aspect.Arcane));
            Assert.Equal(2, character.GetAspectValue(Aspect.Feu));
            Assert.Equal(2, character.GetAspectValue(Aspect.Eau));
            Assert.Equal(2, character.GetAspectValue(Aspect.Vent));
            Assert.Equal(2, character.GetAspectValue(Aspect.Terre));
            Assert.Equal(3, character.GetAspectValue(Aspect.Equilibre));
        }

        [Fact]
        public void PSTest()
        {
            Assert.Equal(16, character.Ps);
        }

        [Fact]
        public void PETest()
        {
            Assert.Equal(40, character.Endurance);
        }

        [Fact]
        public void PCTest()
        {
            Assert.Equal(5, character.Chi);
        }

        [Fact]
        public void PFTest()
        {
            Assert.Equal(5, character.Fatigue);
        }

        [Fact]
        public void PMTest()
        {
            Assert.Equal(10, character.Chi);
        }

        [Fact]
        public void PKTest()
        {
            Assert.Equal(4, character.Karma());
        }
    }
}
