using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" || (comboBox2.Text) != "")
            {

                parent.getCharacter().SetBonusMalus((Aspect)Enum.Parse(typeof(Aspect), comboBox1.Text, false), (Aspect)Enum.Parse(typeof(Aspect), comboBox2.Text, false));
                parent.UpdateAspects();
                this.Close();
            }
            else
            {
                
            }
        }
    }
}
