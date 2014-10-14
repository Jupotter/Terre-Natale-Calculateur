﻿using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    partial class Form1
    {
        private TextBox Acier;

        private TextBox Arcane;

        private Button button3;

        private Button button4;

        private TextBox Chi;

        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TextBox Eau;

        private TextBox Endurance;

        private ToolStripMenuItem enregistrersousToolStripMenuItem;

        private ToolStripMenuItem enregistrerToolStripMenuItem1;

        private TextBox Equilibre;

        private TextBox Experience;

        private Label ExperienceLabel;

        private TextBox ExperienceRestante;

        private TextBox Fatigue;

        private TextBox Feu;

        private ToolStripMenuItem fichierToolStripMenuItem1;

        private FlowLayoutPanel flowLayoutTalentG;

        private FlowLayoutPanel flowLayoutTalentsM;

        private GroupBox groupBox2;

        private GroupBox groupBox3;

        private TextBox Karma;

        private Label label;

        private Label label10;

        private Label label11;

        private Label label12;

        private Label label13;

        private Label label19;

        private Label label2;

        private Label label3;

        private Label label4;

        private Label label5;

        private Label label6;

        private Label label7;

        private Label label8;

        private Label label9;

        private TextBox Mana;

        private MenuStrip menuStrip1;

        private ToolStripMenuItem nouveauToolStripMenuItem1;

        private OpenFileDialog openFileDialog1;

        private ToolStripMenuItem ouvrirToolStripMenuItem1;

        private ToolStripMenuItem quitterToolStripMenuItem;

        private TextBox Santé;

        private SaveFileDialog saveFileDialog1;

        private TabPage Stats;

        private TabControl tabControl1;

        private TabPage TalentsA;

        private TabPage TalentsG;

        private TabPage TalentsM;

        private TextBox Terre;

        private ToolStripSeparator toolStripSeparator;

        private ToolStripSeparator toolStripSeparator1;

        private TextBox Vent;

        private NumericUpDown XpToAdd;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Stats = new System.Windows.Forms.TabPage();
            this.lab_Race = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.XpToAdd = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Karma = new System.Windows.Forms.TextBox();
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.flowLayoutTalentG = new System.Windows.Forms.FlowLayoutPanel();
            this.Savoirs = new System.Windows.Forms.TabPage();
            this.TalentsM = new System.Windows.Forms.TabPage();
            this.flowLayoutTalentsM = new System.Windows.Forms.FlowLayoutPanel();
            this.TalentsA = new System.Windows.Forms.TabPage();
            this.flowLayoutTalentsA = new System.Windows.Forms.FlowLayoutPanel();
            this.TalentsP = new System.Windows.Forms.TabPage();
            this.flowLayoutTalentsP = new System.Windows.Forms.FlowLayoutPanel();
            this.stats_secondaire = new System.Windows.Forms.TabPage();
            this.secondaryStats1 = new Terre_Natale_Calculateur.View.SecondaryStats();
            this.ClasseTab = new System.Windows.Forms.TabPage();
            this.Debloque = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.enregistrerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrersousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpTalentsjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talentsIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutSavoir = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.Stats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XpToAdd)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TalentsG.SuspendLayout();
            this.Savoirs.SuspendLayout();
            this.TalentsM.SuspendLayout();
            this.TalentsA.SuspendLayout();
            this.TalentsP.SuspendLayout();
            this.stats_secondaire.SuspendLayout();
            this.ClasseTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Stats);
            this.tabControl1.Controls.Add(this.TalentsG);
            this.tabControl1.Controls.Add(this.Savoirs);
            this.tabControl1.Controls.Add(this.TalentsM);
            this.tabControl1.Controls.Add(this.TalentsA);
            this.tabControl1.Controls.Add(this.TalentsP);
            this.tabControl1.Controls.Add(this.stats_secondaire);
            this.tabControl1.Controls.Add(this.ClasseTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 460);
            this.tabControl1.TabIndex = 1;
            // 
            // Stats
            // 
            this.Stats.Controls.Add(this.lab_Race);
            this.Stats.Controls.Add(this.label20);
            this.Stats.Controls.Add(this.lab_name);
            this.Stats.Controls.Add(this.label1);
            this.Stats.Controls.Add(this.listBox1);
            this.Stats.Controls.Add(this.button2);
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
            this.Stats.Size = new System.Drawing.Size(627, 434);
            this.Stats.TabIndex = 0;
            this.Stats.Text = "Stats";
            this.Stats.UseVisualStyleBackColor = true;
            this.Stats.Click += new System.EventHandler(this.Stats_Click);
            // 
            // lab_Race
            // 
            this.lab_Race.AutoSize = true;
            this.lab_Race.Location = new System.Drawing.Point(324, 26);
            this.lab_Race.Name = "lab_Race";
            this.lab_Race.Size = new System.Drawing.Size(0, 13);
            this.lab_Race.TabIndex = 37;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(278, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 13);
            this.label20.TabIndex = 36;
            this.label20.Text = "Race :";
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_name.Location = new System.Drawing.Point(109, 26);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(0, 13);
            this.lab_name.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Nom :";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(500, 151);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(110, 160);
            this.listBox1.TabIndex = 33;
            this.listBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(500, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Afficher les PA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.Karma);
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
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(25, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 23);
            this.label13.TabIndex = 29;
            this.label13.Text = "Karma :";
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
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(13, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "PE :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Fatigue
            // 
            this.Fatigue.Location = new System.Drawing.Point(69, 125);
            this.Fatigue.Name = "Fatigue";
            this.Fatigue.Size = new System.Drawing.Size(42, 20);
            this.Fatigue.TabIndex = 31;
            this.Fatigue.Text = "0";
            this.Fatigue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.groupBox2.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Bonus";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.ExperienceRestante.Location = new System.Drawing.Point(398, 58);
            this.ExperienceRestante.Name = "ExperienceRestante";
            this.ExperienceRestante.ReadOnly = true;
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
            this.Experience.Location = new System.Drawing.Point(109, 58);
            this.Experience.Name = "Experience";
            this.Experience.ReadOnly = true;
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
            this.TalentsG.Size = new System.Drawing.Size(627, 434);
            this.TalentsG.TabIndex = 1;
            this.TalentsG.Text = "Talents Generaux";
            this.TalentsG.UseVisualStyleBackColor = true;
            // 
            // flowLayoutTalentG
            // 
            this.flowLayoutTalentG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutTalentG.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutTalentG.Name = "flowLayoutTalentG";
            this.flowLayoutTalentG.Size = new System.Drawing.Size(627, 434);
            this.flowLayoutTalentG.TabIndex = 0;
            // 
            // Savoirs
            // 
            this.Savoirs.Controls.Add(this.flowLayoutSavoir);
            this.Savoirs.Location = new System.Drawing.Point(4, 22);
            this.Savoirs.Name = "Savoirs";
            this.Savoirs.Size = new System.Drawing.Size(627, 434);
            this.Savoirs.TabIndex = 8;
            this.Savoirs.Text = "Savoirs";
            this.Savoirs.UseVisualStyleBackColor = true;
            // 
            // TalentsM
            // 
            this.TalentsM.Controls.Add(this.flowLayoutTalentsM);
            this.TalentsM.Location = new System.Drawing.Point(4, 22);
            this.TalentsM.Name = "TalentsM";
            this.TalentsM.Size = new System.Drawing.Size(627, 434);
            this.TalentsM.TabIndex = 2;
            this.TalentsM.Text = "Talents Martiaux";
            this.TalentsM.UseVisualStyleBackColor = true;
            // 
            // flowLayoutTalentsM
            // 
            this.flowLayoutTalentsM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutTalentsM.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutTalentsM.Name = "flowLayoutTalentsM";
            this.flowLayoutTalentsM.Size = new System.Drawing.Size(627, 434);
            this.flowLayoutTalentsM.TabIndex = 0;
            // 
            // TalentsA
            // 
            this.TalentsA.Controls.Add(this.flowLayoutTalentsA);
            this.TalentsA.Location = new System.Drawing.Point(4, 22);
            this.TalentsA.Name = "TalentsA";
            this.TalentsA.Size = new System.Drawing.Size(627, 434);
            this.TalentsA.TabIndex = 3;
            this.TalentsA.Text = "Talents Aptitudes";
            this.TalentsA.UseVisualStyleBackColor = true;
            // 
            // flowLayoutTalentsA
            // 
            this.flowLayoutTalentsA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutTalentsA.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutTalentsA.Name = "flowLayoutTalentsA";
            this.flowLayoutTalentsA.Size = new System.Drawing.Size(627, 434);
            this.flowLayoutTalentsA.TabIndex = 0;
            // 
            // TalentsP
            // 
            this.TalentsP.Controls.Add(this.flowLayoutTalentsP);
            this.TalentsP.Location = new System.Drawing.Point(4, 22);
            this.TalentsP.Name = "TalentsP";
            this.TalentsP.Size = new System.Drawing.Size(627, 434);
            this.TalentsP.TabIndex = 5;
            this.TalentsP.Text = "Talents Prouesse";
            this.TalentsP.UseVisualStyleBackColor = true;
            // 
            // flowLayoutTalentsP
            // 
            this.flowLayoutTalentsP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutTalentsP.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutTalentsP.Name = "flowLayoutTalentsP";
            this.flowLayoutTalentsP.Size = new System.Drawing.Size(627, 434);
            this.flowLayoutTalentsP.TabIndex = 0;
            // 
            // stats_secondaire
            // 
            this.stats_secondaire.Controls.Add(this.secondaryStats1);
            this.stats_secondaire.Location = new System.Drawing.Point(4, 22);
            this.stats_secondaire.Name = "stats_secondaire";
            this.stats_secondaire.Size = new System.Drawing.Size(627, 434);
            this.stats_secondaire.TabIndex = 7;
            this.stats_secondaire.Text = "Stats secondaire";
            this.stats_secondaire.UseVisualStyleBackColor = true;
            // 
            // secondaryStats1
            // 
            this.secondaryStats1.AutoSize = true;
            this.secondaryStats1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondaryStats1.Location = new System.Drawing.Point(0, 0);
            this.secondaryStats1.Name = "secondaryStats1";
            this.secondaryStats1.Size = new System.Drawing.Size(627, 434);
            this.secondaryStats1.TabIndex = 0;
            // 
            // ClasseTab
            // 
            this.ClasseTab.Controls.Add(this.Debloque);
            this.ClasseTab.Controls.Add(this.label29);
            this.ClasseTab.Controls.Add(this.label28);
            this.ClasseTab.Controls.Add(this.listBox2);
            this.ClasseTab.Controls.Add(this.comboBox1);
            this.ClasseTab.Location = new System.Drawing.Point(4, 22);
            this.ClasseTab.Name = "ClasseTab";
            this.ClasseTab.Padding = new System.Windows.Forms.Padding(3);
            this.ClasseTab.Size = new System.Drawing.Size(627, 434);
            this.ClasseTab.TabIndex = 6;
            this.ClasseTab.Text = "Classe";
            this.ClasseTab.UseVisualStyleBackColor = true;
            // 
            // Debloque
            // 
            this.Debloque.AutoSize = true;
            this.Debloque.Location = new System.Drawing.Point(131, 148);
            this.Debloque.Name = "Debloque";
            this.Debloque.Size = new System.Drawing.Size(0, 13);
            this.Debloque.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(35, 148);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 13);
            this.label29.TabIndex = 3;
            this.label29.Text = "Débloque :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(32, 35);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(44, 13);
            this.label28.TabIndex = 2;
            this.label28.Text = "Classe :";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(295, 60);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(326, 264);
            this.listBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(32, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem1,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem1
            // 
            this.fichierToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem1,
            this.ouvrirToolStripMenuItem1,
            this.toolStripSeparator,
            this.enregistrerToolStripMenuItem1,
            this.enregistrersousToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem1.Name = "fichierToolStripMenuItem1";
            this.fichierToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem1.Text = "&Fichier";
            // 
            // nouveauToolStripMenuItem1
            // 
            this.nouveauToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("nouveauToolStripMenuItem1.Image")));
            this.nouveauToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nouveauToolStripMenuItem1.Name = "nouveauToolStripMenuItem1";
            this.nouveauToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nouveauToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.nouveauToolStripMenuItem1.Text = "&Nouveau";
            this.nouveauToolStripMenuItem1.Click += new System.EventHandler(this.nouveauToolStripMenuItem1_Click);
            // 
            // ouvrirToolStripMenuItem1
            // 
            this.ouvrirToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ouvrirToolStripMenuItem1.Image")));
            this.ouvrirToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ouvrirToolStripMenuItem1.Name = "ouvrirToolStripMenuItem1";
            this.ouvrirToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.ouvrirToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.ouvrirToolStripMenuItem1.Text = "&Ouvrir";
            this.ouvrirToolStripMenuItem1.Click += new System.EventHandler(this.ouvrirToolStripMenuItem1_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(167, 6);
            // 
            // enregistrerToolStripMenuItem1
            // 
            this.enregistrerToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("enregistrerToolStripMenuItem1.Image")));
            this.enregistrerToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enregistrerToolStripMenuItem1.Name = "enregistrerToolStripMenuItem1";
            this.enregistrerToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.enregistrerToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.enregistrerToolStripMenuItem1.Text = "&Enregistrer";
            this.enregistrerToolStripMenuItem1.Click += new System.EventHandler(this.enregistrerToolStripMenuItem1_Click);
            // 
            // enregistrersousToolStripMenuItem
            // 
            this.enregistrersousToolStripMenuItem.Name = "enregistrersousToolStripMenuItem";
            this.enregistrersousToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.enregistrersousToolStripMenuItem.Text = "Enregistrer &sous";
            this.enregistrersousToolStripMenuItem.Click += new System.EventHandler(this.enregistrersousToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dumpTalentsjsonToolStripMenuItem,
            this.talentsIdToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // dumpTalentsjsonToolStripMenuItem
            // 
            this.dumpTalentsjsonToolStripMenuItem.Name = "dumpTalentsjsonToolStripMenuItem";
            this.dumpTalentsjsonToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dumpTalentsjsonToolStripMenuItem.Text = "Dump Talents.json";
            this.dumpTalentsjsonToolStripMenuItem.Click += new System.EventHandler(this.dumpTalentsjsonToolStripMenuItem_Click);
            // 
            // talentsIdToolStripMenuItem
            // 
            this.talentsIdToolStripMenuItem.Name = "talentsIdToolStripMenuItem";
            this.talentsIdToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.talentsIdToolStripMenuItem.Text = "Talents Id";
            this.talentsIdToolStripMenuItem.Click += new System.EventHandler(this.talentsIdToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Feuille de personnage | *.chr";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Feuille de personnage |*.chr|Tous les fichier |*.*";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // flowLayoutSavoir
            // 
            this.flowLayoutSavoir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutSavoir.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutSavoir.Name = "flowLayoutSavoir";
            this.flowLayoutSavoir.Size = new System.Drawing.Size(627, 434);
            this.flowLayoutSavoir.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 484);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Terre Natale";
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
            this.Savoirs.ResumeLayout(false);
            this.TalentsM.ResumeLayout(false);
            this.TalentsA.ResumeLayout(false);
            this.TalentsP.ResumeLayout(false);
            this.stats_secondaire.ResumeLayout(false);
            this.stats_secondaire.PerformLayout();
            this.ClasseTab.ResumeLayout(false);
            this.ClasseTab.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutTalentsA;
        private TabPage TalentsP;
        private FlowLayoutPanel flowLayoutTalentsP;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem dumpTalentsjsonToolStripMenuItem;
        private ToolStripMenuItem talentsIdToolStripMenuItem;
        private Button button1;
        private ListBox listBox1;
        private Button button2;
        private Label lab_Race;
        private Label label20;
        private Label lab_name;
        private Label label1;
        private TabPage stats_secondaire;
        private TabPage ClasseTab;
        private Label Debloque;
        private Label label29;
        private Label label28;
        private ListBox listBox2;
        private ComboBox comboBox1;
        private View.SecondaryStats secondaryStats1;
        private TabPage Savoirs;
        private FlowLayoutPanel flowLayoutSavoir;
    }
}

