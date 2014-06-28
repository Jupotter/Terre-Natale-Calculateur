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
        public DumpForm()
        {
            InitializeComponent();
        }

        public void setContent(String text)
        {
            textBox1.Text = text;
        }
    }
}
