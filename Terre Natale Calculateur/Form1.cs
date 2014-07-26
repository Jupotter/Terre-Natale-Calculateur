﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    internal partial class Form1 : Form
    {
        private Character _character;
        private string _currentFilename;
        
        public Form1()
        {
            InitializeComponent();

            //SetCharacter(CharacterManager.Instance.Create("Name"));

            //CharacterManager.Instance.Save(_character, "Name");
        }

        private void ActualiseStats()
        {
            ExperienceRestante.Text = (int.Parse(Experience.Text) - _character.TotalXP).ToString(CultureInfo.InvariantCulture);
            Fatigue.Text = _character.Fatigue.ToString(CultureInfo.InvariantCulture);
            Chi.Text = _character.Chi.ToString(CultureInfo.InvariantCulture);
            Mana.Text = _character.Mana.ToString(CultureInfo.InvariantCulture);
            Karma.Text = _character.Karma.ToString(CultureInfo.InvariantCulture);
            Endurance.Text = _character.Endurance.ToString(CultureInfo.InvariantCulture);
            Santé.Text = @"4";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Experience.Text = Convert.ToString((Convert.ToInt32(Experience.Text) + XpToAdd.Value));
            ExperienceRestante.Text = (int.Parse(Experience.Text) - _character.TotalXP).ToString(CultureInfo.InvariantCulture);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (((Convert.ToInt32(Experience.Text) - XpToAdd.Value) >= 0))
            {
                Experience.Text = Convert.ToString((Convert.ToInt32(Experience.Text) - XpToAdd.Value));
                ExperienceRestante.Text = (int.Parse(Experience.Text) - _character.TotalXP).ToString(CultureInfo.InvariantCulture);
            }
        }

        private FlowLayoutPanel CreateAspectBox(Predicate<Talent> predicate, string name)
        {
            var tpanel = new AspectTalentBox(_character);
            tpanel.Initialize(predicate, name);
            return tpanel;
        }

        private void CreateTalentBoxes()
        {
            flowLayoutTalentG.Controls.Clear();
            flowLayoutTalentsM.Controls.Clear();
            flowLayoutTalentsA.Controls.Clear();

            int size = 0;

            FlowLayoutPanel box;
            foreach (var aspect in from aspect in (Aspect[])Enum.GetValues(typeof(Aspect))
                                   where aspect != Aspect.None
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

        private void enregistrersousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
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

        private void label14_Click(object sender, EventArgs e)
        {
            SetCharacter(CharacterManager.Instance.Create("name"));
            RacesManager.Instance.CreateSet();
        }

        private void nouveauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetCharacter(CharacterManager.Instance.Create("name"));
            RacesManager.Instance.CreateSet();

            NewCharacters nc = new NewCharacters(_character, this);
            nc.Show();
            _currentFilename = null;

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Activate();
            string name = openFileDialog1.FileName;
            SetCharacter(CharacterManager.Instance.Load(name));
            _currentFilename = name;
        }

        private void ouvrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void PAChangedHandler(object sender, EventArgs e)
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
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ExperienceRestante.ForeColor = Convert.ToInt32(ExperienceRestante.Text) < 0
                ? System.Drawing.Color.Red
                : System.Drawing.Color.Black;
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

        private void dumpTalentsjsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TalentsManager.Instance.DumpJSON();
        }

        private void talentsIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DumpForm dumpy = new DumpForm();
            dumpy.Show();
        }

        public Character getCharacter()
        {
            return _character;
        }

        public void newcharacterfinish()
        {
            UpdateAspects();
            update_Talents();
        }

        public void update_Talents()
        {
            
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatsBonusForm sbf = new StatsBonusForm(this);
            sbf.ShowDialog();
        }
    }
}