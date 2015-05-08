using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur.Backend;
using Xunit;

namespace Calculateur.Tests
{
    public class CyrusTest
    {
        private readonly Character character;

        #region Source
        private readonly SerializableCharacter source = 
            new SerializableCharacter()
            {
                AspectBonus = new List<Aspect>(new[] { Aspect.Eau, Aspect.Vent }),
                AspectMalus = new List<Aspect>(new[] { Aspect.Terre, Aspect.Feu }),
                Classe = "Spadassin",
                Experience = 450,
                Inventaire =  new List<string>(),
                Inventory = new Inventory() { 
                    Armor = new ArmorSet() { 
                        Arms = new ArmorPiece()
                        {
                            Quality = 2, 
                            Type = ArmorPiece.ArmorType.Leger
                        },
                        Chest = new ArmorPiece()
                        {
                            Quality = 2,
                            Type = ArmorPiece.ArmorType.Leger
                        },
                        Head = new ArmorPiece()
                        {
                            Quality = 2,
                            Type = ArmorPiece.ArmorType.Leger
                        },
                        Legs = new ArmorPiece()
                        {
                            Quality = 2,
                            Type = ArmorPiece.ArmorType.Leger
                        }, 
                    },
                },
                Race = 1,
                penPoid = 4,
                Talents = new[]
                {
                    new SerialisableTalent()
                    {
                        id = 3,
                        level = 2,
                        bonus = true,
                    },
                    new SerialisableTalent()
                    {
                        id = 4,
                        level = 2,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 6,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 10,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 14,
                        level = 2,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 15,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 16,
                        level = 2,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 17,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 19,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 20,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 22,
                        level = 1,
                        bonus = true,
                    },
                    new SerialisableTalent()
                    {
                        id = 27,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 36,
                        level = 3,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 42,
                        level = 3,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 46,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 51,
                        level = 1,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 56,
                        level = 2,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 57,
                        level = 3,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 74,
                        level = 2,
                        bonus = false,
                    },
                    new SerialisableTalent()
                    {
                        id = 75,
                        level = 1,
                        bonus = false,
                    },
                }
            };
#endregion

        public CyrusTest()
        {
            TalentsManager.Instance.Initialize();
            ClassManager.Instance.Initialize();
            RacesManager.Instance.Initialize();
            Bijouxmanager.Instance.Initialize();

            character = new Character(source);
            CharacterManager.Current = character;

            character.SetBonus(
                RacesManager.Instance.GetRace(1).AspectBonus,
                new[]
                {
                    character.GetTalent(3),
                    character.GetTalent(22)
                },
                RacesManager.Instance.GetRace(1)
                );
            character.Inventory.Ring1.Material = Bijouxmanager.Instance.getFromName("Spinelle");
            character.Inventory.Ring1.Quality = 3;
            
        }

        [Fact]
        public void AspectTest()
        {
            Assert.Equal(5, character.GetAspectValue(Aspect.Acier));
            Assert.Equal(2, character.GetAspectValue(Aspect.Arcane));
            Assert.Equal(1, character.GetAspectValue(Aspect.Feu));
            Assert.Equal(4, character.GetAspectValue(Aspect.Eau));
            Assert.Equal(6, character.GetAspectValue(Aspect.Vent));
            Assert.Equal(1, character.GetAspectValue(Aspect.Terre));
            Assert.Equal(6, character.GetAspectValue(Aspect.Equilibre));
        }

        [Fact]
        public void ExperienceTest()
        {
            Assert.Equal(0, character.ExperienceRemaining);
        }

        [Fact]
        public void PSTest()
        {
            Assert.Equal(45, character.Ps);
        }

        [Fact]
        public void PETest()
        {
            Assert.Equal(128, character.Endurance);
        }

        [Fact]
        public void PCTest()
        {
            Assert.Equal(30, character.Chi);
        }

        [Fact]
        public void PFTest()
        {
            Assert.Equal(22, character.Fatigue);
        }

        [Fact]
        public void PMTest()
        {
            Assert.Equal(20, character.Mana);
        }

        [Fact]
        public void PKTest()
        {
            Assert.Equal(15, character.Karma());
        }

    }
}
