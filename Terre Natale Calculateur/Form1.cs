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

            character = new Character("Name", new TalentsFactory());

            foreach (var box in (from aspect in (Aspect[])Enum.GetValues(typeof(Aspect))
                                 where aspect != Aspect.None
                                 select aspect).Select(CreateAspectBox))
            {
                flowLayoutTalentG.Controls.Add(box);
            }
        }

        private FlowLayoutPanel CreateAspectBox(Aspect aspect)
        {
            var box = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle
            };
            box.Controls.Add(new Label { Text = String.Format("Talents de {0}", aspect) });
            Aspect aspect1 = aspect;
            foreach (TalentBox tbox in
                from talent in character.Talents
                where talent.SecondaryAspect == Aspect.None && talent.PrimaryAspect == aspect1
                select new TalentBox { Text = talent.Name })
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
    }
}