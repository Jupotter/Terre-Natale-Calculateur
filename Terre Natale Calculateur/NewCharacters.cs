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
    public partial class NewCharacters : Form
    {
        IDictionary<int, Race> races;
        public NewCharacters()
        {
            InitializeComponent();
        }

        private void NewCharacters_Load(object sender, EventArgs e)
        {
            RacesManager.Instance.Initialize();
            races = RacesManager.Instance.CreateSet();
            foreach (var item in races)
            {
                comboBox1.Items.Add(item.Value.name);
            }
            comboBox1.SelectedIndex = 0;
            
            comboBox1.Update();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            foreach (var item in races)
            {
                if (item.Value.name == comboBox1.Text)
                {
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    listBox1.Items.Clear();
                    foreach (var stats in item.Value.aspectBonus)
                    {
                        listBox1.Items.Add(stats.Key + " : " + stats.Value);
                    }
                    foreach (var talent in item.Value.talents)
                    {
                        comboBox2.Items.Add(TalentsManager.Instance.GetTalent(talent).Name);
                        comboBox3.Items.Add(TalentsManager.Instance.GetTalent(talent).Name);
                    }
                }
            }
        }
    }
}
