using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    [HelpKeyword(typeof(UserControl))]
    [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design")]
    internal partial class TalentBox : UserControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label _label;
        private Button _minusButton;
        private Button _plusButton;
        private ProgressBar _progress;
        private Character _character;
        private Talent _linkedTalent;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;


        public TalentBox()
        {
            InitializeComponent();

            _plusButton.Click += _plusButton_Click;
            _minusButton.Click += _minusButton_Click;
            TextModified = OnTextModified;
           
        }

        public TalentBox(Character character)
            : this()
        {
            _character = character;
            _character.ExperienceChanged += _character_ExperienceChanged;
           
            //_character.PAChanged += talent_LevelChanged;
        }

        void _character_ExperienceChanged(Character sender)
        {
            
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

        }

        public event EventHandler TextModified;

        public override sealed bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
        public Talent LinkedTalent
        {
            set
            {
                _linkedTalent = value;
                Text = value.Name;
                if (_linkedTalent.SecondaryAspect != Aspect.None)
                    Text += string.Format(" ({0})", _linkedTalent.SecondaryAspect);
                value.LevelChanged += talent_LevelChanged;
                actuButton();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                TextModified.Invoke(this, new EventArgs());
            }
        }

        public void UpdateValue()
        {
                _progress.Value = _linkedTalent.Level * 20;
        }

        private void _minusButton_Click(object sender, EventArgs e)
        {
            if (_linkedTalent != null && _character != null)
            {
                _linkedTalent.Decrement();
            }
            actuButton();
        }

        private void _plusButton_Click(object sender, EventArgs e)
        {
            if (_linkedTalent != null && _character != null)
            {
                
                    _linkedTalent.Increment();
                
            }
            actuButton();
        }

        private void ChangeSize()
        {
            SuspendLayout();
            //ChangeLayout();
            //Width = _plusButton.Right;
        }

        private void ChangeLayout()
        {
        }

        private void OnTextModified(object sender, EventArgs eventArgs)
        {
            _label.Text = Text;
        }

        private void talent_LevelChanged(object sender, EventArgs e)
        {
            UpdateValue();
            actuButton();
        }

        private void actuButton()
        {
            if( (_linkedTalent.Level >1 && _linkedTalent.HaveBonus))
            {
                _minusButton.Enabled=true;
            }
            else if(_linkedTalent.Level > 0)
            {
                _minusButton.Enabled=true;
            }else
            {
                _minusButton.Enabled=false;
            }

            int val = _linkedTalent.GetXpNeeded()-_linkedTalent.XPCost;
            if (_character.ExperienceRemaining >= val )
            {
                _plusButton.Enabled = true;
            }
            else
            {
                _plusButton.Enabled = false;
            }
        }
    }
}