using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    internal partial class Form1 : Form
    {
        private Character _character;
        private string _currentFilename;
        Classe currentClasse;
        

        public Form1()
        {
            InitializeComponent();

            //SetCharacter(CharacterManager.Instance.Create("Name"));

            //CharacterManager.Instance.Save(_character, "Name");
        }
        #region affichage stats
        //private void recomputeStatsSecond()
        //{

        //    volonte.Text = (Math.Max(Convert.ToInt32((Convert.ToInt16(Arcane.Text) + Convert.ToInt16(Terre.Text))) / 4, _character.GetTalent("Volonté").Level)).ToString();
        //    robustesse.Text = (Math.Max(Convert.ToInt32((Convert.ToInt16(Acier.Text) + Convert.ToInt16(Feu.Text))) / 4, _character.GetTalent("Endurance").Level)).ToString();
        //    reflexe.Text = (Math.Max(
        //                            Math.Max(Convert.ToInt32((Convert.ToInt16(Eau.Text) + Convert.ToInt16(Vent.Text))) / 4, _character.GetTalent("Esquive").Level)
        //                            , _character.GetTalent("Discipline").Level
        //                            )).ToString();

        //    deplacement.Text = (Math.Max(2, 3 + Convert.ToInt32(Vent.Text) / 3 - Convert.ToInt32(PenDePoid.Value))).ToString();
        //    Base_ini.Text = (Convert.ToInt32(Vent.Text) - Convert.ToInt32(PenDePoid.Value)).ToString();
        //    ReuMana.Text = (6 - Convert.ToInt32(PenDePoid.Value)).ToString();

        //    if (currentClasse != null)
        //    {

        //        RPC.Text = (4 + currentClasse.RPC).ToString();
        //        RPF.Text = (4 + currentClasse.RPF).ToString();
        //        RPE.Text = (4 + currentClasse.RPE).ToString();
        //        RPM.Text = (4 + currentClasse.RPM).ToString();
        //    }

        //}

        public void newcharacterfinish()
        {
            UpdateAspects();
            updateData();
            comboBox1.Items.Clear();
            foreach (var dat in ClassManager.Instance._Classes)
            {
                comboBox1.Items.Add(dat.Value.Nom);
            }
            //recomputeStatsSecond();
        }

        private void updateData()
        {
            if (_character.Name != null && _character.Race != null)
            {
                lab_name.Text = _character.Name;
                lab_Race.Text = _character.Race.Name;
            }
        }

        public void UpdateAspects()
        {
            Acier.Text = _character.GetAspectValue(Aspect.Acier).ToString(CultureInfo.InvariantCulture);
            Arcane.Text = _character.GetAspectValue(Aspect.Arcane).ToString(CultureInfo.InvariantCulture);
            Eau.Text = _character.GetAspectValue(Aspect.Eau).ToString(CultureInfo.InvariantCulture);
            Terre.Text = _character.GetAspectValue(Aspect.Terre).ToString(CultureInfo.InvariantCulture);
            Feu.Text = _character.GetAspectValue(Aspect.Feu).ToString(CultureInfo.InvariantCulture);
            Vent.Text = _character.GetAspectValue(Aspect.Vent).ToString(CultureInfo.InvariantCulture);
            Equilibre.Text = _character.GetAspectValue(Aspect.Equilibre).ToString(CultureInfo.InvariantCulture);
            ActualiseStats();
        }

        private void ActualiseStats()
        {
            int bF = 0;
            int bC = 0;
            int bM = 0;
            int bE = 0;

            #region bordel lutie ....

            if (currentClasse != null)
            {
                int tmp = _character.Talents.Where(t => t.Type == TalentType.General &&
                        (t.PrimaryAspect == currentClasse.Primaire
                        || t.PrimaryAspect == currentClasse.Secondaire
                        || t.SecondaryAspect == currentClasse.Primaire
                        || t.SecondaryAspect == currentClasse.Secondaire)).Sum(t => t.Level);
                switch (currentClasse.MPC)
                {
                    case "W": bC = tmp / 4;

                        break;
                    case "L": bC = tmp / 3;

                        break;
                    case "H": bC = tmp / 2;

                        break;
                    default:
                        break;
                }

                switch (currentClasse.MPE)
                {
                    case "W": bE = tmp / 5;

                        break;
                    case "L": bE = tmp / 4;

                        break;
                    case "H": bE = tmp / 3;

                        break;
                    default:
                        break;
                }

                switch (currentClasse.MPF)
                {
                    case "W": bF = tmp / 4;

                        break;
                    case "L": bF = tmp / 3;

                        break;
                    case "H": bF = tmp / 2;

                        break;
                    default:
                        break;
                }

                switch (currentClasse.MPM)
                {
                    case "W": bM = tmp / 4;

                        break;
                    case "L": bM = tmp / 3;

                        break;
                    case "H": bM = tmp / 2;

                        break;
                    case "N": bM = 0;

                        break;
                    default:
                        break;
                }
            }
            #endregion



            ExperienceRestante.Text = (int.Parse(Experience.Text) - _character.ExperienceUsed).ToString(CultureInfo.InvariantCulture);
            Fatigue.Text = (_character.Fatigue + bF).ToString(CultureInfo.InvariantCulture);
            Chi.Text = (_character.Chi + bC).ToString(CultureInfo.InvariantCulture);
            Mana.Text = (_character.Mana + bM).ToString(CultureInfo.InvariantCulture);
            Karma.Text = (_character.Karma).ToString(CultureInfo.InvariantCulture);
            Endurance.Text = (_character.Endurance + bE).ToString(CultureInfo.InvariantCulture);
            Santé.Text = @"4";
            if (_character.getClasse() != null) comboBox1.Text = _character.getClasse().Nom;
            //recomputeStatsSecond();
        }


#endregion

        #region LinkBoutton and event
        #region gen
        private void CreateTalentBoxes()
        {
            flowLayoutTalentG.Controls.Clear();
            flowLayoutTalentsM.Controls.Clear();
            flowLayoutTalentsA.Controls.Clear();

            int size = 0;

            FlowLayoutPanel box;
            foreach (var aspect in from aspect in (Aspect[])Enum.GetValues(typeof(Aspect))
                                  
                                   select aspect)
            {
                Aspect aspect1 = aspect;
                box = CreateAspectBox(t => t.Type == TalentType.General && t.PrimaryAspect == aspect1,
                    String.Format("Talents de {0}", aspect));
                if (box.Width > size)
                    size = box.Width;
                flowLayoutTalentG.Controls.Add(box);
            }
            foreach (AspectTalentBox aspectTalentBox in flowLayoutTalentG.Controls)
            {
                //aspectTalentBox.AutoSize = false;
                aspectTalentBox.Width = size;
            }

            box = CreateAspectBox(t => t.Type == TalentType.Martial && t.PrimaryAspect == Aspect.Acier, "Talents d'Acier");
            flowLayoutTalentsM.Controls.Add(box);
            box = CreateAspectBox(t => t.Type == TalentType.Martial && t.PrimaryAspect == Aspect.Arcane, "Talents d'Arcane");
            flowLayoutTalentsM.Controls.Add(box);

            box = CreateAspectBox(t => t.Type == TalentType.Aptitude && t.PrimaryAspect == Aspect.Acier, "Aptitude d'Acier");
            flowLayoutTalentsA.Controls.Add(box);
            box = CreateAspectBox(t => t.Type == TalentType.Aptitude && t.PrimaryAspect == Aspect.Arcane, "Aptitude d'Arcane");
            flowLayoutTalentsA.Controls.Add(box);

            foreach (var aspect in from aspect in (Aspect[])Enum.GetValues(typeof(Aspect))
                                   where aspect != Aspect.None && aspect != Aspect.Equilibre
                                   select aspect)
            {
                Aspect aspect1 = aspect;
                box = CreateAspectBox(t => t.Type == TalentType.Prouesse && t.PrimaryAspect == aspect1,
                    String.Format("Prouesse de {0}", aspect));
                flowLayoutTalentsP.Controls.Add(box);
            }
        }

        private FlowLayoutPanel CreateAspectBox(Predicate<Talent> predicate, string name)
        {
            var tpanel = new AspectTalentBox(_character);
            tpanel.Initialize(predicate, name);
            return tpanel;
        }

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
            Experience.Text = _character.ExperienceAvailable.ToString(CultureInfo.InvariantCulture);
            ExperienceRestante.Text = _character.ExperienceRemaining.ToString(CultureInfo.InvariantCulture);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _character.ExperienceAvailable += (int)XpToAdd.Value;
            Experience.Text = _character.ExperienceAvailable.ToString(CultureInfo.InvariantCulture);
            ExperienceRestante.Text = _character.ExperienceRemaining.ToString(CultureInfo.InvariantCulture);
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

        }

        private void nouveauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RacesManager.Instance.Initialize();
            SetCharacter(CharacterManager.Instance.Create("name"));
            RacesManager.Instance.CreateSet();

            NewCharacters nc = new NewCharacters(_character, this);
            nc.Show();
            _currentFilename = null;

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RacesManager.Instance.Initialize();
            string name = openFileDialog1.FileName;
            SetCharacter(CharacterManager.Instance.Load(name));
            _currentFilename = name;
            UpdateAspects();
        }

        private void ouvrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void PAChangedHandler(Character sender)
        {
            UpdateAspects();
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

            CreateTalentBoxes();
            UpdateAspects();
            _character.PAChanged += PAChangedHandler;

            newcharacterfinish();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ExperienceRestante.ForeColor = Convert.ToInt32(ExperienceRestante.Text) < 0
                ? System.Drawing.Color.Red
                : System.Drawing.Color.Black;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StatsBonusForm sbf = new StatsBonusForm(this);
            sbf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
            {
                listBox1.Items.Clear();
                foreach (Aspect item in Enum.GetValues(typeof(Aspect)).Cast<Aspect>())
                {
                    if (item != Aspect.None)
                    {
                        listBox1.Items.Add(item.ToString() + ":" + _character.GetAspectPoint(item));
                    }
                }
                button2.Text = "Masquer les PA";
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Items.Clear();
                button2.Text = "Afficher les PA";
                listBox1.Visible = false;
            }
        }

        private void Stats_Click(object sender, EventArgs e)
        {

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
            ActualiseStats();
        }
        private void PenDePoid_ValueChanged(object sender, EventArgs e)
        {
            //recomputeStatsSecond();
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
    }
}