using System;
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
        public DumpForm()
        {
            InitializeComponent();
        }

        private void DumpForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = TalentsManager.Instance.GetTalents();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Update();
        }
    }
}
