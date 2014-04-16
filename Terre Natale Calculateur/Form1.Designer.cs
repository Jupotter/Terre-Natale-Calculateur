using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.characterName = new System.Windows.Forms.Label();
            this.talentsBox = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // characterName
            // 
            this.characterName.AutoSize = true;
            this.characterName.Location = new System.Drawing.Point(12, 9);
            this.characterName.Dock = DockStyle.Top;
            this.characterName.Name = "characterName";
            this.characterName.Size = new System.Drawing.Size(84, 13);
            this.characterName.TabIndex = 0;
            this.characterName.Text = "Character Name";
            // 
            // talentsBox
            // 
            this.talentsBox.AutoSize = true;
            this.talentsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.talentsBox.Dock = DockStyle.Fill;
            this.talentsBox.Location = new System.Drawing.Point(15, 25);
            this.talentsBox.Name = "talentsBox";
            this.talentsBox.Size = new System.Drawing.Size(0, 0);
            this.talentsBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 315);
            this.Controls.Add(this.talentsBox);
            this.Controls.Add(this.characterName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label characterName;
        private System.Windows.Forms.FlowLayoutPanel talentsBox;
    }
}

