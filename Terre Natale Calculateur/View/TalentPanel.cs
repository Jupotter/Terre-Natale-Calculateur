using System;
using System.Linq;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    public partial class TalentPanel : UserControl
    {
        public TalentPanel()
        {
            TalentsManager.TalentsLoaded += CreateTalentBoxes;
            CharacterManager.CharacterChanged += CharacterChanged;
            InitializeComponent();
        }

        void CharacterChanged(Character caller)
        {
            character = caller;

            CreateTalentBoxes();
        }

        private Character character;

        private void CreateTalentBoxes()
        {
            layoutTalentG.Controls.Clear();
            layoutTalentsM.Controls.Clear();
            layoutTalentsA.Controls.Clear();
            layoutSavoir.Controls.Clear();
            layoutTalentsP.Controls.Clear();

            TableLayoutPanel box;
            foreach (var aspect in from aspect in ((Aspect[])Enum.GetValues(typeof(Aspect)))
                                   where aspect != Aspect.None && aspect != Aspect.Equilibre
                                   select aspect)
            {
                box = CreateAspectBox(t => t.Type == TalentType.General && t.PrimaryAspect == aspect && !t.Savoir,
                    String.Format("Talents de {0}", aspect));
                box.Dock = DockStyle.Fill;
                layoutTalentG.Controls.Add(box);
            }

            box = CreateAspectBox(t => t.Type == TalentType.General
                && (t.PrimaryAspect == Aspect.None || t.PrimaryAspect == Aspect.Equilibre)
                && !t.Name.StartsWith("Savoir"),
                    String.Format("Talents de classe"));
            box.Dock = DockStyle.Fill;
            layoutTalentG.Controls.Add(box);


            box = CreateAspectBox(t => t.Type == TalentType.General && t.Savoir,
                   "Talent multiple");
            box.Dock = DockStyle.Fill;
            layoutSavoir.Controls.Add(box);

            box = CreateAspectBox(t => t.Type == TalentType.Martial && t.PrimaryAspect == Aspect.Acier, "Talents d'Acier");
            box.Dock = DockStyle.Fill;
            layoutTalentsM.Controls.Add(box);
            box = CreateAspectBox(t => t.Type == TalentType.Martial && t.PrimaryAspect == Aspect.Arcane, "Talents d'Arcane");
            box.Dock = DockStyle.Fill;
            layoutTalentsM.Controls.Add(box);

            box = CreateAspectBox(t => t.Type == TalentType.Aptitude && t.PrimaryAspect == Aspect.Acier, "Aptitude d'Acier");
            box.Dock = DockStyle.Fill;
            layoutTalentsA.Controls.Add(box);
            box = CreateAspectBox(t => t.Type == TalentType.Aptitude && t.PrimaryAspect == Aspect.Arcane, "Aptitude d'Arcane");
            box.Dock = DockStyle.Fill;
            layoutTalentsA.Controls.Add(box);

            foreach (var aspect in from aspect in (Aspect[])Enum.GetValues(typeof(Aspect))
                                   where aspect != Aspect.None && aspect != Aspect.Equilibre
                                   select aspect)
            {
                Aspect aspect1 = aspect;
                box = CreateAspectBox(t => t.Type == TalentType.Prouesse && t.PrimaryAspect == aspect1,
                    String.Format("Prouesse de {0}", aspect));
                box.Dock = DockStyle.Fill;
                layoutTalentsP.Controls.Add(box);
            }
        }

        private TableLayoutPanel CreateAspectBox(Predicate<Talent> predicate, string name)
        {
            var tpanel = new AspectTalentBox(character);
            tpanel.Initialize(predicate, name);
            return tpanel;
        }
    }
}
