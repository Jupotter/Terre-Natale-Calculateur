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
    public partial class DumpForm : Form
    {
        Dictionary<int, string> talents;
        public DumpForm()
        {
            InitializeComponent();
        }

        public void setContent(String text)
        {

        }

        private void DumpForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = TalentsManager.Instance.GetTalents();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Update();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
         
        }
    }
}
