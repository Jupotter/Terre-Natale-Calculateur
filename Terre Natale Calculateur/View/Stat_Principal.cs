using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    internal partial class Stat_Principal : UserControl
    {
        private Character character;

        Form1 parentForm;
        public Stat_Principal()
        {
            CharacterManager.CharacterChanged += OnCharacterChanged;
            InitializeComponent();
        }

        private void OnCharacterChanged(Character caller)
        {
            character = caller;
            character.PAChanged += caller1 => UpdateAspects();
            UpdateAspects();
        }

        public void setParent(Form1 papa)
        {
            parentForm = papa;
        }
        private void Stat_Principal_Load(object sender, EventArgs e)
        {

        }

        public void UpdateAspects()
        {
            Acier.Text = character.GetAspectValue(Aspect.Acier).ToString();
            Arcane.Text = character.GetAspectValue(Aspect.Arcane).ToString();
            Eau.Text = character.GetAspectValue(Aspect.Eau).ToString();
            Terre.Text = character.GetAspectValue(Aspect.Terre).ToString();
            Feu.Text = character.GetAspectValue(Aspect.Feu).ToString();
            Vent.Text = character.GetAspectValue(Aspect.Vent).ToString();
            Equilibre.Text = character.GetAspectValue(Aspect.Equilibre).ToString();
            ActualiseStats();
        }

        public void ActualiseStats()
        {
          



           Fatigue.Text = (character.Fatigue ).ToString();
            Chi.Text = (character.Chi ).ToString();
            Mana.Text = (character.Mana).ToString();
            Karma.Text = (character.Karma()).ToString();
            Endurance.Text = (character.Endurance).ToString();
            Santé.Text = (character.Ps).ToString();
            PeI.Text = (character.PeIndem).ToString();
            PEa.Text = (character.Endurance + character.GetTalent("Volonté").Level * 7).ToString();
        }

        public string getPeI()
        {
            return PeI.Text;
        }
        public string getPeA()
        {
            return PEa.Text;
        }
        public string getChi()
        {
            return Chi.Text;
        }
        public string getMana()
        {
            return Mana.Text;
        }
        public string getFatigue()
        {
            return Fatigue.Text;
        }
        public string getEndurance()
        {
            return Endurance.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
            {
                listBox1.Items.Clear();
                foreach (Aspect item in Enum.GetValues(typeof(Aspect)).Cast<Aspect>())
                {
                    if (item != Aspect.None)
                    {
                        listBox1.Items.Add(item.ToString() + ":" + character.GetAspectPoint(item));
                    }
                }
                button2.Text = "Masquer les PA";
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Items.Clear();
                button2.Text = "Afficher les PA";
                listBox1.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StatsBonusForm sbf = new StatsBonusForm(parentForm);
            sbf.ShowDialog();
        }

    }
}
