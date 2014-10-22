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
    public partial class Ajouter_Un_Talent : Form
    {
        public Ajouter_Un_Talent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || comboBox1.Text != "" || comboBox2.Text != "" || comboBox3.Text != "")
            {
                Talent t = new Talent(textBox1.Text,
                (TalentType)Enum.Parse(typeof(TalentType), (comboBox1.Text), true),
                        (Aspect)Enum.Parse(typeof(Aspect), (comboBox2.Text), true),
                            (Aspect)Enum.Parse(typeof(Aspect), (comboBox3.Text), true));
                if (checkBox1.Checked) t.Savoir = true;
                TalentsManager.Instance.AddTalent(t);
                this.Close();
            }
         //   
        }

        private void Ajouter_Un_Talent_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof( TalentType)))
            {
                comboBox1.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(Aspect)))
            {
                comboBox2.Items.Add(item);
                comboBox3.Items.Add(item);
            }
        }
    }
}
