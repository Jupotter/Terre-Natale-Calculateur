using System;
using System.Linq;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    public partial class Form1 : Form
    {
        private Character character;

        public Form1()
        {
            InitializeComponent();

            character = CharacterManager.Instance.Create("Name");

            FlowLayoutPanel box;
            foreach (var aspect in from aspect in (Aspect[])Enum.GetValues(typeof(Aspect))
                                 where aspect != Aspect.None
                                 select aspect)
            {
                Aspect aspect1 = aspect;
                box = CreateAspectBox(t => t.Type == TalentType.General && t.PrimaryAspect == aspect1,
                    String.Format("Talents de {0}", aspect));
                flowLayoutTalentG.Controls.Add(box);
            }

            box = CreateAspectBox(t => t.Type == TalentType.Martial && t.PrimaryAspect == Aspect.Acier, "Talents d'Acier");
            flowLayoutTalentsM.Controls.Add(box);
            box = CreateAspectBox(t => t.Type == TalentType.Martial && t.PrimaryAspect == Aspect.Arcane, "Talents d'Arcane");
            flowLayoutTalentsM.Controls.Add(box);

            this.Text = character.Name;
            character.PAChanged += PAChangedHandler;


            CharacterManager.Instance.Save(character, "Name");
        }

        private FlowLayoutPanel CreateAspectBox(Predicate<Talent> predicate, string name)
        {
            var box = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            box.Controls.Add(new Label { Text = name });
            foreach (TalentBox tbox in
                from talent in character.Talents
                where predicate(talent)
                select new TalentBox { LinkedTalent = talent })
            {
                tbox.Margin = new Padding(0);
                box.Controls.Add(tbox);
            }
            return box;
        }

        private void resizeHandler(object sender, EventArgs eventArgs)
        {
            PerformAutoScale();
            PerformLayout();
        }

        void PAChangedHandler(object sender, EventArgs e)
        {

            Acier.Text = character.GetAspectValue(Aspect.Acier).ToString();
            Arcane.Text = character.GetAspectValue(Aspect.Arcane).ToString();
            Eau.Text = character.GetAspectValue(Aspect.Eau).ToString();
            Terre.Text = character.GetAspectValue(Aspect.Terre).ToString();
            Feu.Text = character.GetAspectValue(Aspect.Feu).ToString();
            Vent.Text = character.GetAspectValue(Aspect.Vent).ToString();
            actualiseStats();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ExperienceRestante.Text) < 0)
            {
                ExperienceRestante.ForeColor = System.Drawing.Color.Red;
            }
            else { ExperienceRestante.ForeColor = System.Drawing.Color.Black; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Experience.Text = Convert.ToString((Convert.ToInt32(Experience.Text) + XpToAdd.Value));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (((Convert.ToInt32(Experience.Text) - XpToAdd.Value) >= 0))
            {
                Experience.Text = Convert.ToString((Convert.ToInt32(Experience.Text) - XpToAdd.Value));
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();

        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        void actualiseStats()
        {
            Fatigue.Text = character.Fatigue.ToString();
            Chi.Text = character.Chi.ToString();
            Mana.Text = character.Mana.ToString();
            Karma.Text = character.Karma.ToString();
            Endurance.Text = character.Endurance.ToString();
            Santé.Text = "4";
            
        }
    }
}