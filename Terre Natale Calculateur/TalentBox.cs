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
        private Talent _linkedTalent;

        public TalentBox()
        {
            SuspendLayout();

            _label = new Label
            {
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
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

            _plusButton.Click += _plusButton_Click;
            _minusButton.Click += _minusButton_Click;
            TextModified = OnTextModified;
            AutoSize = true;
            Margin = new Padding(0);
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
            _progress.Value = Math.Max(0, Math.Min(100, _linkedTalent.Level * 100 / 5));
        }

        private void _minusButton_Click(object sender, EventArgs e)
        {
            if (_linkedTalent != null)
                _linkedTalent.Decrement();
        }

        private void _plusButton_Click(object sender, EventArgs e)
        {
            if (_linkedTalent != null)
                _linkedTalent.Increment();
        }

        private void ChangeSize()
        {
            SuspendLayout();
            _minusButton.Left = _label.Right;
            _progress.Left = _minusButton.Right;
            _plusButton.Left = _progress.Right;

            _label.Height = _progress.Height;
            _label.Top = _progress.Height / 2 - _label.Height / 2;
            _label.TextAlign = ContentAlignment.MiddleCenter;
            Width = _plusButton.Right;
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