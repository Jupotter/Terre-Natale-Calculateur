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
    internal partial class NewCharacters : Form
    {
        private Character _character;
        IDictionary<int, Race> races;
        Form1 parent;
        internal NewCharacters( Character chara , Form1 caller)
        {
            parent = caller;
            _character = chara;
            InitializeComponent();
        }
        
        private void NewCharacters_Load(object sender, EventArgs e )
        {
           
            races = RacesManager.Instance.CreateSet();
            foreach (var item in races)
            {
                comboBox1.Items.Add(item.Value.Name);
            }
            comboBox1.SelectedIndex = 0;
            
            comboBox1.Update();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            foreach (var item in races)
            {
                if (item.Value.Name == comboBox1.Text)
                {
                    comboBox2.Items.Clear();
                    comboBox3.Items.Clear();
                    listBox1.Items.Clear();
                    foreach (var stats in item.Value.AspectBonus)
                    {
                        listBox1.Items.Add(stats.Key + " : " + stats.Value);
                    }
                    foreach (var talent in item.Value.Talents)
                    {
                        comboBox2.Items.Add(TalentsManager.Instance.GetTalent(talent).Name);
                        comboBox3.Items.Add(TalentsManager.Instance.GetTalent(talent).Name);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text== "" || (comboBox3.Text)=="")
            {
                MessageBox.Show("Selectionnez un bonus.");
                return;
            }
             Dictionary<Aspect, int> resAsp = new Dictionary<Aspect, int>();
             resAsp.Add(Aspect.Feu,Convert.ToInt16(listBox1.Items[0].ToString().Split(':')[1].Trim()));
             resAsp.Add(Aspect.Eau,Convert.ToInt16(listBox1.Items[1].ToString().Split(':')[1].Trim()));
             resAsp.Add(Aspect.Vent,Convert.ToInt16(listBox1.Items[2].ToString().Split(':')[1].Trim()));
             resAsp.Add(Aspect.Terre,Convert.ToInt16(listBox1.Items[3].ToString().Split(':')[1].Trim()));
             resAsp.Add(Aspect.Arcane,Convert.ToInt16(listBox1.Items[4].ToString().Split(':')[1].Trim()));
             resAsp.Add(Aspect.Acier,Convert.ToInt16(listBox1.Items[5].ToString().Split(':')[1].Trim()));
             resAsp.Add(Aspect.Equilibre,Convert.ToInt16(listBox1.Items[6].ToString().Split(':')[1].Trim()));
            
             List<Talent> rsTal = new List<Talent>();
             
             rsTal.Add(_character.GetTalent(comboBox2.Text));
             rsTal.Add(_character.GetTalent(comboBox3.Text));
             _character.SetBonus(resAsp, rsTal, races[comboBox1.SelectedIndex+1]);
             _character.Name = NameC.Text;
             parent.newcharacterfinish();

             this.Close();
        }
    }
}
