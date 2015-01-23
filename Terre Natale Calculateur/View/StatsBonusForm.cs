using System;
using System.Linq;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    internal partial class StatsBonusForm : Form
    {
        private readonly Character character;

        public StatsBonusForm()
        {
            character = CharacterManager.Current;
            if (character == null)
                return;
            InitializeComponent();
        }

        private void StatsBonusForm_Load(object sender, EventArgs e )
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();


            comboBox1.Items.Add(Aspect.None);
            comboBox1.Items.Add(Aspect.Acier);
            comboBox1.Items.Add(Aspect.Arcane);
            comboBox1.Items.Add(Aspect.Eau);
            comboBox1.Items.Add(Aspect.Feu);
            comboBox1.Items.Add(Aspect.Terre);
            comboBox1.Items.Add(Aspect.Vent);

            comboBox2.Items.Add(Aspect.None);
            comboBox2.Items.Add(Aspect.Acier);
            comboBox2.Items.Add(Aspect.Arcane);
            comboBox2.Items.Add(Aspect.Eau);
            comboBox2.Items.Add(Aspect.Feu);
            comboBox2.Items.Add(Aspect.Terre);
            comboBox2.Items.Add(Aspect.Vent);

            comboBox3.Items.Add(Aspect.None);
            comboBox3.Items.Add(Aspect.Acier);
            comboBox3.Items.Add(Aspect.Arcane);
            comboBox3.Items.Add(Aspect.Eau);
            comboBox3.Items.Add(Aspect.Feu);
            comboBox3.Items.Add(Aspect.Terre);
            comboBox3.Items.Add(Aspect.Vent);

            comboBox4.Items.Add(Aspect.None);
            comboBox4.Items.Add(Aspect.Acier);
            comboBox4.Items.Add(Aspect.Arcane);
            comboBox4.Items.Add(Aspect.Eau);
            comboBox4.Items.Add(Aspect.Feu);
            comboBox4.Items.Add(Aspect.Terre);
            comboBox4.Items.Add(Aspect.Vent);

            if(character.haveBonus())
            {
                comboBox1.SelectedItem = character.getBonusAspect().ElementAt(0);
                comboBox3.SelectedItem = character.getBonusAspect().ElementAt(1);
                comboBox2.SelectedItem = character.getMalusAspect().ElementAt(0);
                comboBox4.SelectedItem = character.getMalusAspect().ElementAt(1);
            }
            else
            {
                comboBox1.SelectedItem = Aspect.None;
                comboBox2.SelectedItem = Aspect.None;
                comboBox3.SelectedItem = Aspect.None;
                comboBox4.SelectedItem = Aspect.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedText != "None" && (comboBox2.Text) == "None") ||
                (comboBox3.Text != "None" && (comboBox4.Text) == "None"))
            {
            }
            else
            {
                character.SetBonusMalus(
                    (Aspect) comboBox1.SelectedItem,
                    (Aspect) comboBox2.SelectedItem,
                    (Aspect) comboBox3.SelectedItem,
                    (Aspect) comboBox4.SelectedItem);
                this.Close();
            }
        }
    }
}
