using System;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var character = new Character("Cyrus", new TalentsFactory());
            characterName.Text = character.Name;

            SuspendLayout();

            foreach (Talent talent in character.Talents)
            {
                var talentLabel = new Label();
                talentLabel.Text = string.Format("{0}: {1} ({2})", talent.Name, talent.Level, talent.XPCost);
                talentLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                talentsBox.Controls.Add(talentLabel);
                Console.WriteLine("Added talent: {0}", talent.Name);
            }
            ResumeLayout(false);
            PerformLayout();

            this.Resize += resizeHandler;
        }

        private void resizeHandler(object sender, EventArgs eventArgs)
        {
            PerformAutoScale();
            PerformLayout();
        }
    }
}
