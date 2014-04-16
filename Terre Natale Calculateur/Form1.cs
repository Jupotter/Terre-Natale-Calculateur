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

       
    }
}
