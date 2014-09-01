namespace Terre_Natale_Calculateur.View
{
    partial class SecondaryStats
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.willLabel = new System.Windows.Forms.Label();
            this.robusLabel = new System.Windows.Forms.Label();
            this.reflexLabel = new System.Windows.Forms.Label();
            this.weightPenaltyLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.initLabel = new System.Windows.Forms.Label();
            this.manaLabel = new System.Windows.Forms.Label();
            this.willBox = new System.Windows.Forms.TextBox();
            this.robusBox = new System.Windows.Forms.TextBox();
            this.reflexBox = new System.Windows.Forms.TextBox();
            this.speedBox = new System.Windows.Forms.TextBox();
            this.initBox = new System.Windows.Forms.TextBox();
            this.manaBox = new System.Windows.Forms.TextBox();
            this.PenDePoid = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PenDePoid)).BeginInit();
            this.SuspendLayout();
            // 
            // willLabel
            // 
            this.willLabel.AutoSize = true;
            this.willLabel.Location = new System.Drawing.Point(49, 10);
            this.willLabel.Name = "willLabel";
            this.willLabel.Size = new System.Drawing.Size(52, 13);
            this.willLabel.TabIndex = 0;
            this.willLabel.Text = "Volonté : ";
            // 
            // robusLabel
            // 
            this.robusLabel.AutoSize = true;
            this.robusLabel.Location = new System.Drawing.Point(29, 37);
            this.robusLabel.Name = "robusLabel";
            this.robusLabel.Size = new System.Drawing.Size(72, 13);
            this.robusLabel.TabIndex = 1;
            this.robusLabel.Text = "Robustesse : ";
            // 
            // reflexLabel
            // 
            this.reflexLabel.AutoSize = true;
            this.reflexLabel.Location = new System.Drawing.Point(52, 64);
            this.reflexLabel.Name = "reflexLabel";
            this.reflexLabel.Size = new System.Drawing.Size(49, 13);
            this.reflexLabel.TabIndex = 3;
            this.reflexLabel.Text = "Reflexe :";
            // 
            // weightPenaltyLabel
            // 
            this.weightPenaltyLabel.AutoSize = true;
            this.weightPenaltyLabel.Location = new System.Drawing.Point(7, 91);
            this.weightPenaltyLabel.Name = "weightPenaltyLabel";
            this.weightPenaltyLabel.Size = new System.Drawing.Size(94, 13);
            this.weightPenaltyLabel.TabIndex = 7;
            this.weightPenaltyLabel.Text = "Penalité de poids :";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(25, 118);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(76, 13);
            this.speedLabel.TabIndex = 9;
            this.speedLabel.Text = "Deplacement :";
            // 
            // initLabel
            // 
            this.initLabel.AutoSize = true;
            this.initLabel.Location = new System.Drawing.Point(15, 145);
            this.initLabel.Name = "initLabel";
            this.initLabel.Size = new System.Drawing.Size(86, 13);
            this.initLabel.TabIndex = 11;
            this.initLabel.Text = "Base d\'initiative :";
            // 
            // manaLabel
            // 
            this.manaLabel.AutoSize = true;
            this.manaLabel.Location = new System.Drawing.Point(4, 172);
            this.manaLabel.Name = "manaLabel";
            this.manaLabel.Size = new System.Drawing.Size(97, 13);
            this.manaLabel.TabIndex = 13;
            this.manaLabel.Text = "Réunion de mana :";
            // 
            // willBox
            // 
            this.willBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.willBox.Location = new System.Drawing.Point(107, 6);
            this.willBox.Name = "willBox";
            this.willBox.ReadOnly = true;
            this.willBox.Size = new System.Drawing.Size(42, 20);
            this.willBox.TabIndex = 29;
            this.willBox.Text = "0";
            this.willBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // robusBox
            // 
            this.robusBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.robusBox.Location = new System.Drawing.Point(107, 33);
            this.robusBox.Name = "robusBox";
            this.robusBox.ReadOnly = true;
            this.robusBox.Size = new System.Drawing.Size(42, 20);
            this.robusBox.TabIndex = 30;
            this.robusBox.Text = "0";
            this.robusBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // reflexBox
            // 
            this.reflexBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.reflexBox.Location = new System.Drawing.Point(107, 60);
            this.reflexBox.Name = "reflexBox";
            this.reflexBox.ReadOnly = true;
            this.reflexBox.Size = new System.Drawing.Size(42, 20);
            this.reflexBox.TabIndex = 31;
            this.reflexBox.Text = "0";
            this.reflexBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // speedBox
            // 
            this.speedBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.speedBox.Location = new System.Drawing.Point(107, 114);
            this.speedBox.Name = "speedBox";
            this.speedBox.ReadOnly = true;
            this.speedBox.Size = new System.Drawing.Size(42, 20);
            this.speedBox.TabIndex = 33;
            this.speedBox.Text = "0";
            this.speedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // initBox
            // 
            this.initBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.initBox.Location = new System.Drawing.Point(107, 141);
            this.initBox.Name = "initBox";
            this.initBox.ReadOnly = true;
            this.initBox.Size = new System.Drawing.Size(42, 20);
            this.initBox.TabIndex = 34;
            this.initBox.Text = "0";
            this.initBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // manaBox
            // 
            this.manaBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.manaBox.Location = new System.Drawing.Point(107, 168);
            this.manaBox.Name = "manaBox";
            this.manaBox.ReadOnly = true;
            this.manaBox.Size = new System.Drawing.Size(42, 20);
            this.manaBox.TabIndex = 35;
            this.manaBox.Text = "0";
            this.manaBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PenDePoid
            // 
            this.PenDePoid.Location = new System.Drawing.Point(107, 87);
            this.PenDePoid.Name = "PenDePoid";
            this.PenDePoid.Size = new System.Drawing.Size(42, 20);
            this.PenDePoid.TabIndex = 36;
            this.PenDePoid.ValueChanged += new System.EventHandler(this.PenDePoid_ValueChanged);
            // 
            // SecondaryStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PenDePoid);
            this.Controls.Add(this.manaBox);
            this.Controls.Add(this.initBox);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.reflexBox);
            this.Controls.Add(this.robusBox);
            this.Controls.Add(this.willBox);
            this.Controls.Add(this.manaLabel);
            this.Controls.Add(this.initLabel);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.weightPenaltyLabel);
            this.Controls.Add(this.reflexLabel);
            this.Controls.Add(this.robusLabel);
            this.Controls.Add(this.willLabel);
            this.Name = "SecondaryStats";
            this.Size = new System.Drawing.Size(346, 302);
            ((System.ComponentModel.ISupportInitialize)(this.PenDePoid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label willLabel;
        private System.Windows.Forms.Label robusLabel;
        private System.Windows.Forms.Label reflexLabel;
        private System.Windows.Forms.Label weightPenaltyLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label initLabel;
        private System.Windows.Forms.Label manaLabel;
        private System.Windows.Forms.TextBox willBox;
        private System.Windows.Forms.TextBox robusBox;
        private System.Windows.Forms.TextBox reflexBox;
        private System.Windows.Forms.TextBox speedBox;
        private System.Windows.Forms.TextBox initBox;
        private System.Windows.Forms.TextBox manaBox;
        private System.Windows.Forms.NumericUpDown PenDePoid;
    }
}
