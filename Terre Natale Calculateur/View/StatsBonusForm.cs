using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    internal partial class StatsBonusForm : Form
    {
        Form1 parent;

       

        public StatsBonusForm(Form1 caller)
        {
            parent = caller;
            InitializeComponent();
        }

        private void StatsBonusForm_Load(object sender, EventArgs e )
        {
           

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            comboBox1.Items.Add(Aspect.Acier);
            comboBox1.Items.Add(Aspect.Arcane);
            comboBox1.Items.Add(Aspect.Eau);
            comboBox1.Items.Add(Aspect.Feu);
            comboBox1.Items.Add(Aspect.Terre);
            comboBox1.Items.Add(Aspect.Vent);

            comboBox2.Items.Add(Aspect.Acier);
            comboBox2.Items.Add(Aspect.Arcane);
            comboBox2.Items.Add(Aspect.Eau);
            comboBox2.Items.Add(Aspect.Feu);
            comboBox2.Items.Add(Aspect.Terre);
            comboBox2.Items.Add(Aspect.Vent);


            comboBox3.Items.Add(Aspect.Acier);
            comboBox3.Items.Add(Aspect.Arcane);
            comboBox3.Items.Add(Aspect.Eau);
            comboBox3.Items.Add(Aspect.Feu);
            comboBox3.Items.Add(Aspect.Terre);
            comboBox3.Items.Add(Aspect.Vent);

            comboBox4.Items.Add(Aspect.Acier);
            comboBox4.Items.Add(Aspect.Arcane);
            comboBox4.Items.Add(Aspect.Eau);
            comboBox4.Items.Add(Aspect.Feu);
            comboBox4.Items.Add(Aspect.Terre);
            comboBox4.Items.Add(Aspect.Vent);

            if(parent.getCharacter().haveBonus())
            {
                comboBox1.Text = parent.getCharacter().getBonusAspect().ElementAt(0).ToString();
                comboBox3.Text = parent.getCharacter().getBonusAspect().ElementAt(1).ToString();
                comboBox2.Text = parent.getCharacter().getMalusAspect().ElementAt(0).ToString();
                comboBox4.Text = parent.getCharacter().getMalusAspect().ElementAt(1).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && (comboBox2.Text) != "" && comboBox3.Text != "" && (comboBox4.Text) != "")
            {

                parent.getCharacter().SetBonusMalus(
                    (Aspect)Enum.Parse(typeof(Aspect), comboBox1.Text, false),
                    (Aspect)Enum.Parse(typeof(Aspect), comboBox2.Text, false), 
                    (Aspect)Enum.Parse(typeof(Aspect),comboBox3.Text, false),
                    (Aspect)Enum.Parse(typeof(Aspect), comboBox4.Text, false));
                parent.UpdateAspects();
                this.Close();
            }
            else
            {
                
            }
        }
    }
}
