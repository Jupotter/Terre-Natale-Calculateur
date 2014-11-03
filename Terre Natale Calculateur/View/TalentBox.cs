using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    [HelpKeyword(typeof(UserControl))]
    [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design")]
    internal class TalentBox : UserControl
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
            actuButton();
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

        private void InitializeComponent()
        {
            this._label = new System.Windows.Forms.Label();
            this._minusButton = new System.Windows.Forms.Button();
            this._progress = new System.Windows.Forms.ProgressBar();
            this._plusButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.AutoSize = true;
            this._label.Location = new System.Drawing.Point(3, 8);
            this._label.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(68, 13);
            this._label.TabIndex = 0;
            this._label.Text = "Talent Name";
            this._label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _minusButton
            // 
            this._minusButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._minusButton.AutoSize = true;
            this._minusButton.Location = new System.Drawing.Point(3, 3);
            this._minusButton.Name = "_minusButton";
            this._minusButton.Size = new System.Drawing.Size(23, 23);
            this._minusButton.TabIndex = 1;
            this._minusButton.Text = "-";
            // 
            // _progress
            // 
            this._progress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._progress.Location = new System.Drawing.Point(32, 3);
            this._progress.Name = "_progress";
            this._progress.Size = new System.Drawing.Size(100, 23);
            this._progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._progress.TabIndex = 2;
            // 
            // _plusButton
            // 
            this._plusButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._plusButton.Location = new System.Drawing.Point(138, 3);
            this._plusButton.Name = "_plusButton";
            this._plusButton.Size = new System.Drawing.Size(23, 23);
            this._plusButton.TabIndex = 3;
            this._plusButton.Text = "+";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._label, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 29);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this._plusButton);
            this.flowLayoutPanel1.Controls.Add(this._progress);
            this.flowLayoutPanel1.Controls.Add(this._minusButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(74, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 29);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // TalentBox
            // 
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TalentBox";
            this.Size = new System.Drawing.Size(238, 29);
            this.Load += new System.EventHandler(this.TalentBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TalentBox_Load(object sender, EventArgs e)
        {

        }
    }
}