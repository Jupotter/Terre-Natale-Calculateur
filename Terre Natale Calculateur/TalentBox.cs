using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    [HelpKeyword(typeof(UserControl))]
    [ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design")]
    class TalentBox : UserControl
    {
        private readonly Label _label;
        private readonly Button _plusButton;
        private readonly Button _minusButton;
        private readonly ProgressBar _progress;

        public event EventHandler TextModified;

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
        }

        private void OnTextModified(object sender, EventArgs eventArgs)
        {
            _label.Text = Text;
            ChangeSize();
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

        void _minusButton_Click(object sender, System.EventArgs e)
        {
            _progress.Value -= 20;
        }

        void _plusButton_Click(object sender, System.EventArgs e)
        {
            _progress.Value += 20;
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
    }
}
