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
            int bF = 0;
            int bC = 0;
            int bM = 0;
            int bE = 0;
            
            #region bordel lutie ....

            if (character.getClasse() != null)
            {
                int tmp = character.Talents.Where(t => t.Type == TalentType.General &&
                        (t.PrimaryAspect == character.getClasse().Primaire
                        || t.PrimaryAspect == character.getClasse().Secondaire
                        || t.SecondaryAspect == character.getClasse().Primaire
                        || t.SecondaryAspect == character.getClasse().Secondaire)).Sum(t => t.Level);
                switch (character.getClasse().MPC)
                {
                    case "W": bC = tmp / 4;

                        break;
                    case "L": bC = tmp / 3;

                        break;
                    case "H": bC = tmp / 2;

                        break;
                    default:
                        break;
                }

                switch (character.getClasse().MPE)
                {
                    case "W": bE = tmp / 5;

                        break;
                    case "L": bE = tmp / 4;

                        break;
                    case "H": bE = tmp / 3;

                        break;
                    default:
                        break;
                }

                switch (character.getClasse().MPF)
                {
                    case "W": bF = tmp / 4;

                        break;
                    case "L": bF = tmp / 3;

                        break;
                    case "H": bF = tmp / 2;

                        break;
                    default:
                        break;
                }

                switch (character.getClasse().MPM)
                {
                    case "W": bM = tmp / 4;

                        break;
                    case "L": bM = tmp / 3;

                        break;
                    case "H": bM = tmp / 2;

                        break;
                    case "N": bM = 0;

                        break;
                    default:
                        break;
                }
            }
            #endregion



           Fatigue.Text = (character.Fatigue + bF).ToString();
            Chi.Text = (character.Chi + bC).ToString();
            Mana.Text = (character.Mana + bM).ToString();
            Karma.Text = (character.Karma()).ToString();
            Endurance.Text = (character.Endurance + bE).ToString();
            Santé.Text = (character.Ps).ToString();
            PeI.Text = (character.Endurance + bE + character.GetTalent("Endurance").Level*5).ToString();
            PEa.Text = (character.Endurance + bE + character.GetTalent("Volonté").Level * 7).ToString();
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
