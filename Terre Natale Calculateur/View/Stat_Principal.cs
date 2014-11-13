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
    public partial class Stat_Principal : UserControl
    {
        Form1 parentForm;
        public Stat_Principal(Form papa)
        {
            parentForm = papa as Form1;
            InitializeComponent();
        }

        private void Stat_Principal_Load(object sender, EventArgs e)
        {

        }

        public void UpdateAspects()
        {
            Character _character = CharacterManager.Current;
            Acier.Text = _character.GetAspectValue(Aspect.Acier).ToString();
            Arcane.Text = _character.GetAspectValue(Aspect.Arcane).ToString();
            Eau.Text = _character.GetAspectValue(Aspect.Eau).ToString();
            Terre.Text = _character.GetAspectValue(Aspect.Terre).ToString();
            Feu.Text = _character.GetAspectValue(Aspect.Feu).ToString();
            Vent.Text = _character.GetAspectValue(Aspect.Vent).ToString();
            Equilibre.Text = _character.GetAspectValue(Aspect.Equilibre).ToString();
            ActualiseStats();
        }

        public void ActualiseStats()
        {
            Character _character = CharacterManager.Current;
            int bF = 0;
            int bC = 0;
            int bM = 0;
            int bE = 0;
            
            #region bordel lutie ....

            if (_character.getClasse() != null)
            {
                int tmp = _character.Talents.Where(t => t.Type == TalentType.General &&
                        (t.PrimaryAspect == _character.getClasse().Primaire
                        || t.PrimaryAspect == _character.getClasse().Secondaire
                        || t.SecondaryAspect == _character.getClasse().Primaire
                        || t.SecondaryAspect == _character.getClasse().Secondaire)).Sum(t => t.Level);
                switch (_character.getClasse().MPC)
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

                switch (_character.getClasse().MPE)
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

                switch (_character.getClasse().MPF)
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

                switch (_character.getClasse().MPM)
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



           Fatigue.Text = (_character.Fatigue + bF).ToString();
            Chi.Text = (_character.Chi + bC).ToString();
            Mana.Text = (_character.Mana + bM).ToString();
            Karma.Text = (_character.Karma).ToString();
            Endurance.Text = (_character.Endurance + bE).ToString();
            Santé.Text = (_character.Ps).ToString();
            PeI.Text = (_character.Endurance + bE + _character.GetTalent("Endurance").Level*5).ToString();
            PEa.Text = (_character.Endurance + bE + _character.GetTalent("Volonté").Level * 7).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Character _character = CharacterManager.Current;
            if (listBox1.Visible == false)
            {
                listBox1.Items.Clear();
                foreach (Aspect item in Enum.GetValues(typeof(Aspect)).Cast<Aspect>())
                {
                    if (item != Aspect.None)
                    {
                        listBox1.Items.Add(item.ToString() + ":" + _character.GetAspectPoint(item));
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
