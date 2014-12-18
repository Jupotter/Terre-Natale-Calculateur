using Microsoft.Practices.Prism.Mvvm;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class TalentBox : BindableBase
    {
        private readonly Talent talent;
        private readonly Character character;

        public int Level
        {
            get { return talent.Level; }
        }

        public string Name
        {
            get { return talent.Name; }
        }

        public TalentBox(Talent talent, Character character)
        {
            this.talent = talent;
            this.character = character;
        }

        public bool CanLevelUp
        {
            get { return character.ExperienceRemaining > talent.GetXpNeeded() - talent.XPCost && talent.Level <= 5; }
        }

        public bool CanLevelDown
        {
            get
            {
                if ((talent.Level > 1 && talent.HaveBonus))
                {
                    return true;
                }
                return talent.Level > 0 && !talent.HaveBonus;
            }
        }
    }
}
