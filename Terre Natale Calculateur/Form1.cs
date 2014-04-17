using System;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void resizeHandler(object sender, EventArgs eventArgs)
        {
            PerformAutoScale();
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bar_discretion.Value > 0)
            {
                bar_discretion.Value = bar_discretion.Value - 20;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bar_discretion.Value < bar_discretion.Maximum)
            {
                bar_discretion.Value = bar_discretion.Value+20;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ExperienceRestante.Text) < 0)
            {
                ExperienceRestante.ForeColor = System.Drawing.Color.Red;
            }
            else { ExperienceRestante.ForeColor = System.Drawing.Color.Black; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Experience.Text =Convert.ToString ( (Convert.ToInt32(Experience.Text) + XpToAdd.Value));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (((Convert.ToInt32(Experience.Text) - XpToAdd.Value) >= 0))
            {
                Experience.Text = Convert.ToString((Convert.ToInt32(Experience.Text) - XpToAdd.Value)); 
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

       
    }
}
