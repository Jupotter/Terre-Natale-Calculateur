using System;
using System.Linq;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    public partial class SecondaryStats : UserControl
    {
        private Character character;

        public SecondaryStats()
        {
            InitializeComponent();
            CharacterManager.CharacterChanged += CharacterChanged;
        }

        private void CharacterChanged(Character caller)
        {
            character = caller;
            PenDePoid.Value = caller.penPoid;
            RecomputeStats();
        }

        public void RecomputeStats()
        {
            if (character != null)
            {
                willBox.Text = character.Willpower.ToString();
                robusBox.Text = character.Robustesse.ToString();
                reflexBox.Text = character.Reflex.ToString();

                willAjust.Text = (1 + Math.Max(character.GetAspectValue(Aspect.Arcane), character.GetAspectValue(Aspect.Feu))).ToString();
                robusAjust.Text = (1 + Math.Max(character.GetAspectValue(Aspect.Acier), character.GetAspectValue(Aspect.Terre))).ToString();
                reflexAjust.Text = (1 + Math.Max(character.GetAspectValue(Aspect.Eau), character.GetAspectValue(Aspect.Vent))).ToString();

                speedBox.Text =
                    (Math.Max(2, 3 + character.GetAspectValue(Aspect.Vent)/3 - PenDePoid.Value)).ToString();
                initBox.Text = (character.GetAspectValue(Aspect.Vent) - PenDePoid.Value).ToString();
                manaBox.Text = (6 - PenDePoid.Value).ToString();

                if (character.getClasse() != null)
                {
                    Classe currentClasse = character.getClasse();
                    RPC.Text = (4 + currentClasse.RPC).ToString();
                    RPF.Text = (4 + currentClasse.RPF).ToString();
                    RPE.Text = (4 + currentClasse.RPE).ToString();
                    RPM.Text = (4 + currentClasse.RPM).ToString();
                }

                int martial = character.Talents
                    .Where(talent => talent.Type == TalentType.Aptitude && talent.PrimaryAspect == Aspect.Acier)
                    .Sum(talent => talent.Level);
                martialBox.Text = (character.GetAspectValue(Aspect.Acier) + character.GetAspectValue(Aspect.Arcane) + martial*2).ToString();

                int spell = character.Talents
                    .Where(talent => talent.Type == TalentType.Aptitude && talent.PrimaryAspect == Aspect.Arcane)
                    .Sum(talent => talent.Level);
                spellbox.Text =
                    (character.GetAspectValue(Aspect.Terre)*2 + character.GetAspectValue(Aspect.Arcane)*4 + spell*4)
                        .ToString();

            }

            else
            {
                willBox.Text = "0";
                robusBox.Text = "0";
                reflexBox.Text = "0";

                speedBox.Text = "0";
                initBox.Text = "0";
                manaBox.Text = "0";
            }

        }

        private void PenDePoid_ValueChanged(object sender, EventArgs e)
        {
            character.penPoid = Decimal.ToInt32(PenDePoid.Value);
            RecomputeStats();
        }
    }
}
