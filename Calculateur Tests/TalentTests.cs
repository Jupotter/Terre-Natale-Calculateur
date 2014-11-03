using System;
using System.Collections.Generic;
using System.Linq;
using Terre_Natale_Calculateur;
using Xunit;

namespace Calculateur_Tests
{
    public class TalentTests
    {
        [Fact]
        public void ContructorSimpleTest()
        {
            var talent = new Talent();

            Assert.Equal(Aspect.None, talent.PrimaryAspect);
            Assert.Equal(Aspect.None, talent.SecondaryAspect);
            Assert.Equal(0, talent.XPCost);
            Assert.Equal(false, talent.HaveBonus);
        }

        [Theory, MemberData("TypeAspectData")]
        private void ConstructorParametersTest(TalentType type, Aspect primary, Aspect secondary)
        {
            Talent talent;
            if (secondary == Aspect.None)
                talent = new Talent("Test",
                    type,
                    primary);
            else
            {
                talent = new Talent("Test",
                    type,
                    primary,
                    secondary);
            }

            Assert.Equal("Test", talent.Name);
            Assert.Equal(type, talent.Type);
            Assert.Equal(primary, talent.PrimaryAspect);
            Assert.Equal(secondary, talent.SecondaryAspect);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 10)]
        [InlineData(2, 30)]
        [InlineData(3, 60)]
        [InlineData(4, 100)]
        [InlineData(5, 150)]
        private void SimpleLevelTest(int level, int xp)
        {
            Talent talent = new Talent(
                "Test",
                TalentType.General,
                Aspect.Acier);

            talent.Increment(level);

            Assert.Equal(level, talent.Level);
            Assert.Equal(xp, talent.XPCost);
        }

        [Fact]
        private void LevelLowBoundTest()
        {
            Talent talent = new Talent(
                "Test",
                TalentType.General,
                Aspect.Acier);

            talent.Decrement();

            Assert.Equal(0, talent.Level);
        }

        [Fact]
        private void LevelHighBoundTest()
        {
            Talent talent = new Talent(
                "Test",
                TalentType.General,
                Aspect.Acier);

            talent.Increment(5);

            talent.Increment();

            Assert.Equal(5, talent.Level);
        }

        /// <summary>
        /// All combination of type and two aspects. The first aspect is never None
        /// </summary>
        public static IEnumerable<object[]> TypeAspectData
        {

            get
            {
                return (from aspect1 in 
                               (from aspect in (Aspect[]) Enum.GetValues(typeof (Aspect)) select aspect)
                           from aspect2 in 
                               (from aspect in (Aspect[]) Enum.GetValues(typeof (Aspect)) select aspect)
                           from type in 
                               (from type in (TalentType[]) Enum.GetValues(typeof (TalentType)) select type)
                           where Aspect.None != aspect1 
                        select new object[] {type, aspect1, aspect2})
                    .ToArray();
            }
        }
    }
}
