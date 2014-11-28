using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
namespace Terre_Natale_Calculateur.View
{
    internal partial class Form1 : Form
    {
        private Character _character;
        private string _currentFilename;
        Classe currentClasse;
        

        public Form1()
        {
            
            InitializeComponent();
            stat_Principal1.setParent(this);
            Tools.AllFather = this;
            CharacterManager.CharacterChanged += SetCharacter;
        }
        #region affichage stats

        public void newcharacterfinish()
        {
            _character.PAChanged += (x => updateXP());
            _character.RecalculateRacialRessources();
            UpdateAspects();
            updateData();
            
            comboBox1.Items.Clear();
            foreach (var dat in ClassManager.Instance._Classes)
            {
                comboBox1.Items.Add(dat.Value.Nom);
            }
            updateXP();
            SetBonusRaciaux();
        }

        private void updateData()
        {
            if (_character.Name != null && _character.Race != null)
            {
                lab_name.Text = _character.Name;
                lab_Race.Text = _character.Race.Name;
                SetBonusRaciaux();
            }
            if (_character.getClasse() != null) comboBox1.Text = _character.getClasse().Nom;
            secondaryStats1.RecomputeStats();
        }

       

       


#endregion

        #region LinkBoutton and event
        #region gen
        

        private void enregistrersousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        #endregion


#region other
        private void talentsIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DumpForm dumpy = new DumpForm();
            dumpy.Show();
        }

        private void dumpTalentsjsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TalentsManager.Instance.DumpJSON();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _character.ExperienceAvailable -= (int)XpToAdd.Value;
            updateXP();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _character.ExperienceAvailable += (int)XpToAdd.Value;
            updateXP();
            }

        public void updateXP()
        {
            Experience.Text = _character.ExperienceAvailable.ToString(CultureInfo.InvariantCulture);
            ExperienceRestante.Text = _character.ExperienceRemaining.ToString(CultureInfo.InvariantCulture);
            level.Text = "Niveau : " + _character.GetLevel();
            stat_Principal1.UpdateAspects();
        }
        private void enregistrerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_currentFilename != null)
                CharacterManager.Instance.Save(_character, _currentFilename);
            else
                saveFileDialog1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TalentsManager.Instance.Initialize();
        }

        private void nouveauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RacesManager.Instance.Initialize();
            CharacterManager.Instance.Create("name");
            RacesManager.Instance.CreateSet();

            NewCharacters nc = new NewCharacters(_character, this);
            nc.Show();
            _currentFilename = null;

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RacesManager.Instance.Initialize();
            string name = openFileDialog1.FileName;
            CharacterManager.Instance.Load(name);
            _currentFilename = name;
        }

        private void ouvrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            CharacterManager.Instance.Save(_character, name);
            _currentFilename = name;
        }

        private void SetCharacter(Character character)
        {
            _character = character;
            Text = String.Format("Terre Natale – {0}", _character.Name);

            InitInventory();

            newcharacterfinish();
        }

        private void SetInventory()
        {
            listBox3.Items.Clear();
            foreach (string item in _character.Inventaire)
            {
                listBox3.Items.Add(item);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ExperienceRestante.ForeColor = Convert.ToInt32(ExperienceRestante.Text) < 0
                ? System.Drawing.Color.Red
                : System.Drawing.Color.Black;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Classe current = ClassManager.Instance.getFormName(comboBox1.Text);
            listBox2.Items.Clear();
            listBox2.Items.Add(current.Nom);
            listBox2.Items.Add(current.Maitrise_de_base);
            listBox2.Items.Add(current.MaitriseSpecial);
            listBox2.Items.Add("MPC : " + current.MPC);
            listBox2.Items.Add("MPM : " + current.MPM);
            listBox2.Items.Add("MPF : " + current.MPF);
            listBox2.Items.Add("MPE : " + current.MPE);
            listBox2.Items.Add("RPC : " + current.RPC);
            listBox2.Items.Add("RPM : " + current.RPM);
            listBox2.Items.Add("RPF : " + current.RPF);
            listBox2.Items.Add("RPE : " + current.RPE);
            listBox2.Items.Add(current.Primaire.ToString());
            listBox2.Items.Add(current.Secondaire.ToString());
            Debloque.Text = current.TalentBonus;
            currentClasse = current;
            _character.SetClasse(current);
            
        }

        #endregion
        #endregion

        public Character getCharacter()
        {
            return _character;
        }

        public void setClasse(string def)
        {
            comboBox1.Text = def;
        }

        private void ajoutDeTalentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajouter_Un_Talent aj = new Ajouter_Un_Talent();
            aj.Show();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox3.Text;
        }

        private void actualiseInventory()
        {
            List<string> nInv = new List<string>();
            foreach (var item in listBox3.Items)
            {
                nInv.Add(item.ToString());
            }

            _character.Inventaire = nInv;
        }

        private void ajouter_inv_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add(textBox1.Text);
            actualiseInventory();
        }

        private void Supprimer_inv_Click(object sender, EventArgs e)
        {
            listBox3.Items.Remove(textBox2.Text);
            actualiseInventory();
        }
        private void InitInventory()
        {
            if (_character.Inventaire == null) _character.Inventaire = new List<string>();
            if (_character.Inventaire.Count == 0) return;
            foreach (string item in _character.Inventaire)
            {
                listBox3.Items.Add(item);
            }
        }
        public void UpdateAspects() { stat_Principal1.UpdateAspects(); }

        private void dumpRaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RacesManager.Instance.DumpJSON();
        }
        public void SetBonusRaciaux()
        {
            BonusRaciauxBox.Items.Clear();
            if (_character.Race == null) return;
            foreach (string item in _character.Race.bonusRaciaux.Split(','))
            {
                
                BonusRaciauxBox.Items.Add(item.Replace('#',' '));

            }

        }
        public Stat_Principal GetPrincipalStats()
        {
            return stat_Principal1;
        }

        private void exporterEnTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(_character.Name + ".txt")) File.Delete(_character.Name + ".txt");
            StreamWriter sw = new StreamWriter(_character.Name + ".txt");
            sw.Write(_character.ExitTxt(this));
            sw.Close();
        }
    }
}