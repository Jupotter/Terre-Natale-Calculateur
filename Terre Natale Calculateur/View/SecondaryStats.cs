﻿using System;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    public partial class SecondaryStats : UserControl
    {
        public SecondaryStats()
        {
            InitializeComponent();
            CharacterManager.CharacterChanged += caller => RecomputeStats();
        }

        public void RecomputeStats()
        {
            if (CharacterManager.Current != null)
            {
                Character character = CharacterManager.Current;
                willBox.Text = character.Willpower.ToString();
                robusBox.Text = character.Robustesse.ToString();
                reflexBox.Text = character.Reflex.ToString();

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
            CharacterManager.Current.penPoid =Convert.ToInt16 (PenDePoid.Value);
            RecomputeStats();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void setPendePoid(int value)
        {
            PenDePoid.Value = value;
        }
    }
}