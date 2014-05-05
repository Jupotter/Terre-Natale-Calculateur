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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Stats = new System.Windows.Forms.TabPage();
            this.XpToAdd = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Karma = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Fatigue = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Endurance = new System.Windows.Forms.TextBox();
            this.Chi = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.Mana = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Santé = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Equilibre = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Acier = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Arcane = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Feu = new System.Windows.Forms.TextBox();
            this.Terre = new System.Windows.Forms.TextBox();
            this.Eau = new System.Windows.Forms.TextBox();
            this.Vent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ExperienceRestante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Experience = new System.Windows.Forms.TextBox();
            this.ExperienceLabel = new System.Windows.Forms.Label();
            this.TalentsG = new System.Windows.Forms.TabPage();
            this.TalentsM = new System.Windows.Forms.TabPage();
            this.TalentsA = new System.Windows.Forms.TabPage();
            this.Global_Personnalité = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.flowLayoutTalentG = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutTalentsM = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.Stats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XpToAdd)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TalentsG.SuspendLayout();
            this.TalentsM.SuspendLayout();
            this.Global_Personnalité.SuspendLayout();
            this.SuspendLayout();
            // 
            // characterName
            // 
            this.characterName.AutoSize = true;
            this.characterName.Dock = System.Windows.Forms.DockStyle.Top;
            this.characterName.Location = new System.Drawing.Point(0, 0);
            this.characterName.Name = "characterName";
            this.characterName.Size = new System.Drawing.Size(84, 13);
            this.characterName.TabIndex = 0;
            this.characterName.Text = "Character Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Stats);
            this.tabControl1.Controls.Add(this.TalentsG);
            this.tabControl1.Controls.Add(this.TalentsM);
            this.tabControl1.Controls.Add(this.TalentsA);
            this.tabControl1.Controls.Add(this.Global_Personnalité);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(593, 427);
            this.tabControl1.TabIndex = 1;
            // 
            // Stats
            // 
            this.Stats.Controls.Add(this.XpToAdd);
            this.Stats.Controls.Add(this.groupBox3);
            this.Stats.Controls.Add(this.groupBox2);
            this.Stats.Controls.Add(this.ExperienceRestante);
            this.Stats.Controls.Add(this.label2);
            this.Stats.Controls.Add(this.button4);
            this.Stats.Controls.Add(this.button3);
            this.Stats.Controls.Add(this.Experience);
            this.Stats.Controls.Add(this.ExperienceLabel);
            this.Stats.Location = new System.Drawing.Point(4, 22);
            this.Stats.Name = "Stats";
            this.Stats.Padding = new System.Windows.Forms.Padding(3);
            this.Stats.Size = new System.Drawing.Size(585, 401);
            this.Stats.TabIndex = 0;
            this.Stats.Text = "Stats";
            this.Stats.UseVisualStyleBackColor = true;
            // 
            // XpToAdd
            // 
            this.XpToAdd.Location = new System.Drawing.Point(188, 58);
            this.XpToAdd.Name = "XpToAdd";
            this.XpToAdd.Size = new System.Drawing.Size(53, 20);
            this.XpToAdd.TabIndex = 31;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Karma);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Fatigue);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.Endurance);
            this.groupBox3.Controls.Add(this.Chi);
            this.groupBox3.Controls.Add(this.label);
            this.groupBox3.Controls.Add(this.Mana);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Santé);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(329, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(147, 190);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // Karma
            // 
            this.Karma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Karma.Location = new System.Drawing.Point(69, 150);
            this.Karma.Name = "Karma";
            this.Karma.Size = new System.Drawing.Size(42, 20);
            this.Karma.TabIndex = 28;
            this.Karma.Text = "0";
            this.Karma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 30;
            // 
            // Fatigue
            // 
            this.Fatigue.Location = new System.Drawing.Point(0, 0);
            this.Fatigue.Name = "Fatigue";
            this.Fatigue.Size = new System.Drawing.Size(100, 20);
            this.Fatigue.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Fatigue :";
            // 
            // Endurance
            // 
            this.Endurance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Endurance.Location = new System.Drawing.Point(69, 50);
            this.Endurance.Name = "Endurance";
            this.Endurance.Size = new System.Drawing.Size(42, 20);
            this.Endurance.TabIndex = 24;
            this.Endurance.Text = "0";
            this.Endurance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Chi
            // 
            this.Chi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Chi.Location = new System.Drawing.Point(69, 100);
            this.Chi.Name = "Chi";
            this.Chi.Size = new System.Drawing.Size(42, 20);
            this.Chi.TabIndex = 22;
            this.Chi.Text = "0";
            this.Chi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(41, 103);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(28, 13);
            this.label.TabIndex = 21;
            this.label.Text = "Chi :";
            this.label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Mana
            // 
            this.Mana.ForeColor = System.Drawing.Color.Blue;
            this.Mana.Location = new System.Drawing.Point(69, 75);
            this.Mana.Name = "Mana";
            this.Mana.Size = new System.Drawing.Size(42, 20);
            this.Mana.TabIndex = 20;
            this.Mana.Text = "0";
            this.Mana.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Mana :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Santé
            // 
            this.Santé.ForeColor = System.Drawing.Color.Red;
            this.Santé.Location = new System.Drawing.Point(69, 25);
            this.Santé.Name = "Santé";
            this.Santé.Size = new System.Drawing.Size(42, 20);
            this.Santé.TabIndex = 18;
            this.Santé.Text = "0";
            this.Santé.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Santé :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Equilibre);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.Acier);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Arcane);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.Feu);
            this.groupBox2.Controls.Add(this.Terre);
            this.groupBox2.Controls.Add(this.Eau);
            this.groupBox2.Controls.Add(this.Vent);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(40, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 190);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // Equilibre
            // 
            this.Equilibre.Location = new System.Drawing.Point(124, 97);
            this.Equilibre.Name = "Equilibre";
            this.Equilibre.Size = new System.Drawing.Size(29, 20);
            this.Equilibre.TabIndex = 18;
            this.Equilibre.Text = "0";
            this.Equilibre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(119, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 17;
            this.label19.Text = "Equilibre";
            // 
            // Acier
            // 
            this.Acier.Location = new System.Drawing.Point(236, 160);
            this.Acier.Name = "Acier";
            this.Acier.Size = new System.Drawing.Size(29, 20);
            this.Acier.TabIndex = 16;
            this.Acier.Text = "0";
            this.Acier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Acier";
            // 
            // Arcane
            // 
            this.Arcane.ForeColor = System.Drawing.Color.Purple;
            this.Arcane.Location = new System.Drawing.Point(22, 30);
            this.Arcane.Name = "Arcane";
            this.Arcane.Size = new System.Drawing.Size(29, 20);
            this.Arcane.TabIndex = 14;
            this.Arcane.Text = "0";
            this.Arcane.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Arcane";
            // 
            // Feu
            // 
            this.Feu.ForeColor = System.Drawing.Color.Red;
            this.Feu.Location = new System.Drawing.Point(124, 160);
            this.Feu.Name = "Feu";
            this.Feu.Size = new System.Drawing.Size(29, 20);
            this.Feu.TabIndex = 11;
            this.Feu.Text = "0";
            this.Feu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Terre
            // 
            this.Terre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Terre.Location = new System.Drawing.Point(235, 97);
            this.Terre.Name = "Terre";
            this.Terre.Size = new System.Drawing.Size(29, 20);
            this.Terre.TabIndex = 12;
            this.Terre.Text = "0";
            this.Terre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Eau
            // 
            this.Eau.ForeColor = System.Drawing.Color.Blue;
            this.Eau.Location = new System.Drawing.Point(124, 30);
            this.Eau.Name = "Eau";
            this.Eau.Size = new System.Drawing.Size(29, 20);
            this.Eau.TabIndex = 11;
            this.Eau.Text = "0";
            this.Eau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Vent
            // 
            this.Vent.ForeColor = System.Drawing.Color.Green;
            this.Vent.Location = new System.Drawing.Point(21, 97);
            this.Vent.Name = "Vent";
            this.Vent.Size = new System.Drawing.Size(29, 20);
            this.Vent.TabIndex = 10;
            this.Vent.Text = "0";
            this.Vent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Feu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Terre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Eau";
            // 
            // ExperienceRestante
            // 
            this.ExperienceRestante.Enabled = false;
            this.ExperienceRestante.Location = new System.Drawing.Point(398, 58);
            this.ExperienceRestante.Name = "ExperienceRestante";
            this.ExperienceRestante.Size = new System.Drawing.Size(53, 20);
            this.ExperienceRestante.TabIndex = 5;
            this.ExperienceRestante.Text = "0";
            this.ExperienceRestante.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Experience disponible :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(247, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 3;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(162, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(20, 20);
            this.button3.TabIndex = 2;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Experience
            // 
            this.Experience.Enabled = false;
            this.Experience.Location = new System.Drawing.Point(109, 58);
            this.Experience.Name = "Experience";
            this.Experience.Size = new System.Drawing.Size(45, 20);
            this.Experience.TabIndex = 1;
            this.Experience.Text = "0";
            // 
            // ExperienceLabel
            // 
            this.ExperienceLabel.AutoSize = true;
            this.ExperienceLabel.Location = new System.Drawing.Point(37, 61);
            this.ExperienceLabel.Name = "ExperienceLabel";
            this.ExperienceLabel.Size = new System.Drawing.Size(66, 13);
            this.ExperienceLabel.TabIndex = 0;
            this.ExperienceLabel.Text = "Experience :";
            // 
            // TalentsG
            // 
            this.TalentsG.Controls.Add(this.flowLayoutTalentG);
            this.TalentsG.Location = new System.Drawing.Point(4, 22);
            this.TalentsG.Name = "TalentsG";
            this.TalentsG.Padding = new System.Windows.Forms.Padding(3);
            this.TalentsG.Size = new System.Drawing.Size(585, 401);
            this.TalentsG.TabIndex = 1;
            this.TalentsG.Text = "Talents Generaux";
            this.TalentsG.UseVisualStyleBackColor = true;
            // 
            // TalentsM
            // 
            this.TalentsM.Controls.Add(this.flowLayoutTalentsM);
            this.TalentsM.Location = new System.Drawing.Point(4, 22);
            this.TalentsM.Name = "TalentsM";
            this.TalentsM.Size = new System.Drawing.Size(585, 401);
            this.TalentsM.TabIndex = 2;
            this.TalentsM.Text = "Talents Martiaux";
            this.TalentsM.UseVisualStyleBackColor = true;
            // 
            // TalentsA
            // 
            this.TalentsA.Location = new System.Drawing.Point(4, 22);
            this.TalentsA.Name = "TalentsA";
            this.TalentsA.Size = new System.Drawing.Size(585, 401);
            this.TalentsA.TabIndex = 3;
            this.TalentsA.Text = "Talents Aptitudes";
            this.TalentsA.UseVisualStyleBackColor = true;
            // 
            // Global_Personnalité
            // 
            this.Global_Personnalité.Controls.Add(this.label18);
            this.Global_Personnalité.Controls.Add(this.comboBox1);
            this.Global_Personnalité.Controls.Add(this.textBox4);
            this.Global_Personnalité.Controls.Add(this.label17);
            this.Global_Personnalité.Controls.Add(this.textBox3);
            this.Global_Personnalité.Controls.Add(this.label16);
            this.Global_Personnalité.Controls.Add(this.textBox2);
            this.Global_Personnalité.Controls.Add(this.label15);
            this.Global_Personnalité.Controls.Add(this.textBox1);
            this.Global_Personnalité.Controls.Add(this.label14);
            this.Global_Personnalité.Location = new System.Drawing.Point(4, 22);
            this.Global_Personnalité.Name = "Global_Personnalité";
            this.Global_Personnalité.Padding = new System.Windows.Forms.Padding(3);
            this.Global_Personnalité.Size = new System.Drawing.Size(585, 401);
            this.Global_Personnalité.TabIndex = 4;
            this.Global_Personnalité.Text = "Global - Personnalité";
            this.Global_Personnalité.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(246, 201);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "Alignement";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Neutre - Neutre",
            "Bon - Neutre",
            "Mauvais - Neutre",
            "Neutre - Loyal",
            "Neutre - Chaotique",
            "Bon - Loyal",
            "Bon - Chaotique",
            "Mauvais - Loyal",
            "Mauvais - Chaotique"});
            this.comboBox1.Location = new System.Drawing.Point(216, 217);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Neutre - Neutre";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(351, 137);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(146, 20);
            this.textBox4.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(408, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Défaut";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(48, 137);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(99, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "Qualité";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(351, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(399, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Faiblesse";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(48, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(103, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Don";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // flowLayoutTalentG
            // 
            this.flowLayoutTalentG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutTalentG.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutTalentG.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutTalentG.Name = "flowLayoutTalentG";
            this.flowLayoutTalentG.Size = new System.Drawing.Size(579, 395);
            this.flowLayoutTalentG.TabIndex = 0;
            // 
            // flowLayoutTalentsM
            // 
            this.flowLayoutTalentsM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutTalentsM.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutTalentsM.Name = "flowLayoutTalentsM";
            this.flowLayoutTalentsM.Size = new System.Drawing.Size(585, 401);
            this.flowLayoutTalentsM.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 440);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.characterName);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Stats.ResumeLayout(false);
            this.Stats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XpToAdd)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TalentsG.ResumeLayout(false);
            this.TalentsM.ResumeLayout(false);
            this.Global_Personnalité.ResumeLayout(false);
            this.Global_Personnalité.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label characterName;
        private TabControl tabControl1;
        private TabPage Stats;
        private TabPage TalentsG;
        private TabPage TalentsM;
        private TabPage TalentsA;
        private Button button4;
        private Button button3;
        private TextBox Experience;
        private Label ExperienceLabel;
        private TextBox Feu;
        private TextBox Terre;
        private TextBox Eau;
        private TextBox Vent;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox ExperienceRestante;
        private Label label2;
        private TextBox Acier;
        private Label label8;
        private TextBox Arcane;
        private Label label7;
        private GroupBox groupBox3;
        private TextBox Karma;
        private Label label13;
        private Label label11;
        private TextBox Fatigue;
        private Label label12;
        private TextBox Endurance;
        private TextBox Chi;
        private Label label;
        private TextBox Mana;
        private Label label10;
        private TextBox Santé;
        private Label label9;
        private GroupBox groupBox2;
        private NumericUpDown XpToAdd;
        private TabPage Global_Personnalité;
        private Label label14;
        private Label label18;
        private ComboBox comboBox1;
        private TextBox textBox4;
        private Label label17;
        private TextBox textBox3;
        private Label label16;
        private TextBox textBox2;
        private Label label15;
        private TextBox textBox1;
        private TextBox Equilibre;
        private Label label19;
        private FlowLayoutPanel flowLayoutTalentG;
        private FlowLayoutPanel flowLayoutTalentsM;
    }
}

