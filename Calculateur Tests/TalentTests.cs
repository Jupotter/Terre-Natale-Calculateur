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
