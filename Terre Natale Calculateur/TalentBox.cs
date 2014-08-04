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
        private readonly Label _label;
        private readonly Button _minusButton;
        private readonly Button _plusButton;
        private readonly ProgressBar _progress;
        private readonly Character _character;
        private Talent _linkedTalent;
        private int _controlsWidth;

        public TalentBox(Character character)
        {
            _character = character;
            _character.PAChanged += talent_LevelChanged;
            SuspendLayout();

            _label = new Label
            {
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Margin = new Padding(2),
            };
            Controls.Add(_label);

            _minusButton = new Button
            {
                Text = @"-",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
            };
            _minusButton.Width = _minusButton.Height;
            Controls.Add(_minusButton);

            _progress = new ProgressBar
            {
                Style = ProgressBarStyle.Continuous,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Width = 5 * 20,
            };
            Controls.Add(_progress);

            _plusButton = new Button
            {
                Text = @"+",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Left = _progress.Right,
            };
            _plusButton.Width = _plusButton.Height;
            Controls.Add(_plusButton);

            ResumeLayout();

            ChangeSize();

            _controlsWidth = _plusButton.Right - _minusButton.Left;

            _plusButton.Click += _plusButton_Click;
            _minusButton.Click += _minusButton_Click;
            TextModified = OnTextModified;
            AutoSize = true;
            Margin = new Padding(0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            _label.AutoSize = false;
            _label.Width = Width - _controlsWidth - _label.Margin.Right;
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
                _linkedTalent.Increment();
        }

        private void ChangeSize()
        {
            SuspendLayout();
            ChangeLayout();
            Width = _plusButton.Right;
        }

        private void ChangeLayout()
        {
            _minusButton.Left = _label.Right;
            _progress.Left = _minusButton.Right;
            _plusButton.Left = _progress.Right;

            _label.Height = _progress.Height;
            _label.Top = _progress.Height/2 - _label.Height/2;
            _label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void OnTextModified(object sender, EventArgs eventArgs)
        {
            _label.Text = Text;
            ChangeSize();
        }

        private void talent_LevelChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }
    }
}