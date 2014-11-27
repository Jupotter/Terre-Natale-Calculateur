using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    internal partial class AspectTalentBox : TableLayoutPanel
    {
        private readonly Character _character;

        public AspectTalentBox(Character character)
        {
            _character = character;
            InitializeComponent();

            BorderStyle = BorderStyle.FixedSingle;
        }

        public void Initialize(Predicate<Talent> predicate, string name)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;
            ColumnCount = 1;
            ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            Controls.Add(new Label
            {
                Text = name,
                Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                AutoSize=true,
            }, 0, 0);
            
            foreach (TalentBox tbox in
                from talent in _character.Talents
                where predicate(talent)
                select new TalentBox(_character) {LinkedTalent = talent})
            {
                tbox.UpdateValue();
                tbox.Dock = DockStyle.Fill;
                Controls.Add(tbox);
            }
        }
    }
}
