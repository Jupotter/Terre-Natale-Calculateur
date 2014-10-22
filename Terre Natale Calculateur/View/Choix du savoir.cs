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
    internal partial class Choix_du_savoir : Form
    {
        NewCharacters papa;
        internal Choix_du_savoir(NewCharacters parent)
        {
            papa = parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Text != "")
            {
                papa.SetSavoir(listBox1.Text);
                Close();


            }
        }

        private void Choix_du_savoir_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in TalentsManager.Instance.GetAllSavoir())
            {
                listBox1.Items.Add(item.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
