using System.Windows.Forms;

namespace Terre_Natale_Calculateur.View
{
    partial class Form1
    {

        private Button button3;

        private Button button4;

        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ToolStripMenuItem enregistrersousToolStripMenuItem;

        private ToolStripMenuItem enregistrerToolStripMenuItem1;

        private TextBox Experience;

        private Label ExperienceLabel;

        private TextBox ExperienceRestante;

        private ToolStripMenuItem fichierToolStripMenuItem1;

        private TableLayoutPanel layoutTalentG;

        private TableLayoutPanel layoutTalentsM;

        private Label label2;

        private MenuStrip menuStrip1;

        private ToolStripMenuItem nouveauToolStripMenuItem1;

        private OpenFileDialog openFileDialog1;

        private ToolStripMenuItem ouvrirToolStripMenuItem1;

        private ToolStripMenuItem quitterToolStripMenuItem;

        private SaveFileDialog saveFileDialog1;

        private TabPage Stats;

        private TabControl tabControl1;

        private TabPage TalentsA;

        private TabPage TalentsG;

        private TabPage TalentsM;

        private ToolStripSeparator toolStripSeparator;

        private ToolStripSeparator toolStripSeparator1;

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
            this.level = new System.Windows.Forms.Label();
            this.BonusRaciauxBox = new System.Windows.Forms.ListBox();
            this.stat_Principal1 = new Terre_Natale_Calculateur.View.Stat_Principal();
            this.lab_Race = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lab_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.XpToAdd = new System.Windows.Forms.NumericUpDown();
            this.ExperienceRestante = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Experience = new System.Windows.Forms.TextBox();
            this.ExperienceLabel = new System.Windows.Forms.Label();
            this.TalentsG = new System.Windows.Forms.TabPage();
            this.layoutTalentG = new System.Windows.Forms.TableLayoutPanel();
            this.Savoirs = new System.Windows.Forms.TabPage();
            this.layoutSavoir = new System.Windows.Forms.TableLayoutPanel();
            this.TalentsM = new System.Windows.Forms.TabPage();
            this.layoutTalentsM = new System.Windows.Forms.TableLayoutPanel();
            this.TalentsA = new System.Windows.Forms.TabPage();
            this.layoutTalentsA = new System.Windows.Forms.TableLayoutPanel();
            this.TalentsP = new System.Windows.Forms.TabPage();
            this.layoutTalentsP = new System.Windows.Forms.TableLayoutPanel();
            this.stats_secondaire = new System.Windows.Forms.TabPage();
            this.secondaryStats1 = new Terre_Natale_Calculateur.View.SecondaryStats();
            this.ClasseTab = new System.Windows.Forms.TabPage();
            this.Debloque = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Inventaire = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Supprimer_inv = new System.Windows.Forms.Button();
            this.ajouter_inv = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.enregistrerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrersousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterEnTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpTalentsjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talentsIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajoutDeTalentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.Stats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XpToAdd)).BeginInit();
            this.TalentsG.SuspendLayout();
            this.Savoirs.SuspendLayout();
            this.TalentsM.SuspendLayout();
            this.TalentsA.SuspendLayout();
            this.TalentsP.SuspendLayout();
            this.stats_secondaire.SuspendLayout();
            this.ClasseTab.SuspendLayout();
            this.Inventaire.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.Inventaire);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(708, 593);
            this.tabControl1.TabIndex = 1;
            // 
            // Stats
            // 
            this.Stats.Controls.Add(this.level);
            this.Stats.Controls.Add(this.BonusRaciauxBox);
            this.Stats.Controls.Add(this.stat_Principal1);
            this.Stats.Controls.Add(this.lab_Race);
            this.Stats.Controls.Add(this.label20);
            this.Stats.Controls.Add(this.lab_name);
            this.Stats.Controls.Add(this.label1);
            this.Stats.Controls.Add(this.XpToAdd);
            this.Stats.Controls.Add(this.ExperienceRestante);
            this.Stats.Controls.Add(this.label2);
            this.Stats.Controls.Add(this.button4);
            this.Stats.Controls.Add(this.button3);
            this.Stats.Controls.Add(this.Experience);
            this.Stats.Controls.Add(this.ExperienceLabel);
            this.Stats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stats.Location = new System.Drawing.Point(4, 22);
            this.Stats.Name = "Stats";
            this.Stats.Padding = new System.Windows.Forms.Padding(3);
            this.Stats.Size = new System.Drawing.Size(700, 567);
            this.Stats.TabIndex = 0;
            this.Stats.Text = "Stats";
            this.Stats.UseVisualStyleBackColor = true;
            this.Stats.Click += new System.EventHandler(this.Stats_Click);
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level.Location = new System.Drawing.Point(37, 92);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(77, 16);
            this.level.TabIndex = 40;
            this.level.Text = "Niveau : 1";
            // 
            // BonusRaciauxBox
            // 
            this.BonusRaciauxBox.FormattingEnabled = true;
            this.BonusRaciauxBox.Location = new System.Drawing.Point(40, 368);
            this.BonusRaciauxBox.Name = "BonusRaciauxBox";
            this.BonusRaciauxBox.Size = new System.Drawing.Size(440, 95);
            this.BonusRaciauxBox.TabIndex = 39;
            // 
            // stat_Principal1
            // 
            this.stat_Principal1.Location = new System.Drawing.Point(40, 111);
            this.stat_Principal1.Name = "stat_Principal1";
            this.stat_Principal1.Size = new System.Drawing.Size(586, 251);
            this.stat_Principal1.TabIndex = 38;
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
            // XpToAdd
            // 
            this.XpToAdd.Location = new System.Drawing.Point(188, 58);
            this.XpToAdd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XpToAdd.Name = "XpToAdd";
            this.XpToAdd.Size = new System.Drawing.Size(53, 20);
            this.XpToAdd.TabIndex = 31;
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
            this.TalentsG.Controls.Add(this.layoutTalentG);
            this.TalentsG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentsG.Location = new System.Drawing.Point(4, 22);
            this.TalentsG.Name = "TalentsG";
            this.TalentsG.Size = new System.Drawing.Size(666, 567);
            this.TalentsG.TabIndex = 1;
            this.TalentsG.Text = "Talents Generaux";
            this.TalentsG.UseVisualStyleBackColor = true;
            // 
            // layoutTalentG
            // 
            this.layoutTalentG.AutoSize = true;
            this.layoutTalentG.ColumnCount = 2;
            this.layoutTalentG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentG.Location = new System.Drawing.Point(0, 0);
            this.layoutTalentG.Name = "layoutTalentG";
            this.layoutTalentG.RowCount = 1;
            this.layoutTalentG.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTalentG.Size = new System.Drawing.Size(415, 346);
            this.layoutTalentG.TabIndex = 0;
            // 
            // Savoirs
            // 
            this.Savoirs.Controls.Add(this.layoutSavoir);
            this.Savoirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savoirs.Location = new System.Drawing.Point(4, 22);
            this.Savoirs.Name = "Savoirs";
            this.Savoirs.Size = new System.Drawing.Size(666, 567);
            this.Savoirs.TabIndex = 8;
            this.Savoirs.Text = "Talent multiple";
            this.Savoirs.UseVisualStyleBackColor = true;
            // 
            // layoutSavoir
            // 
            this.layoutSavoir.AutoSize = true;
            this.layoutSavoir.ColumnCount = 2;
            this.layoutSavoir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutSavoir.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutSavoir.Location = new System.Drawing.Point(0, 0);
            this.layoutSavoir.Name = "layoutSavoir";
            this.layoutSavoir.RowCount = 1;
            this.layoutSavoir.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSavoir.Size = new System.Drawing.Size(431, 148);
            this.layoutSavoir.TabIndex = 1;
            // 
            // TalentsM
            // 
            this.TalentsM.Controls.Add(this.layoutTalentsM);
            this.TalentsM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentsM.Location = new System.Drawing.Point(4, 22);
            this.TalentsM.Name = "TalentsM";
            this.TalentsM.Size = new System.Drawing.Size(666, 567);
            this.TalentsM.TabIndex = 2;
            this.TalentsM.Text = "Talents Martiaux";
            this.TalentsM.UseVisualStyleBackColor = true;
            this.TalentsM.Click += new System.EventHandler(this.TalentsM_Click);
            // 
            // layoutTalentsM
            // 
            this.layoutTalentsM.AutoSize = true;
            this.layoutTalentsM.ColumnCount = 2;
            this.layoutTalentsM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentsM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentsM.Location = new System.Drawing.Point(0, 0);
            this.layoutTalentsM.Name = "layoutTalentsM";
            this.layoutTalentsM.RowCount = 1;
            this.layoutTalentsM.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTalentsM.Size = new System.Drawing.Size(352, 182);
            this.layoutTalentsM.TabIndex = 0;
            // 
            // TalentsA
            // 
            this.TalentsA.Controls.Add(this.layoutTalentsA);
            this.TalentsA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentsA.Location = new System.Drawing.Point(4, 22);
            this.TalentsA.Name = "TalentsA";
            this.TalentsA.Size = new System.Drawing.Size(666, 567);
            this.TalentsA.TabIndex = 3;
            this.TalentsA.Text = "Talents Aptitudes";
            this.TalentsA.UseVisualStyleBackColor = true;
            // 
            // layoutTalentsA
            // 
            this.layoutTalentsA.AutoSize = true;
            this.layoutTalentsA.ColumnCount = 2;
            this.layoutTalentsA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentsA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentsA.Location = new System.Drawing.Point(0, 0);
            this.layoutTalentsA.Name = "layoutTalentsA";
            this.layoutTalentsA.RowCount = 1;
            this.layoutTalentsA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTalentsA.Size = new System.Drawing.Size(312, 138);
            this.layoutTalentsA.TabIndex = 0;
            // 
            // TalentsP
            // 
            this.TalentsP.Controls.Add(this.layoutTalentsP);
            this.TalentsP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TalentsP.Location = new System.Drawing.Point(4, 22);
            this.TalentsP.Name = "TalentsP";
            this.TalentsP.Size = new System.Drawing.Size(666, 567);
            this.TalentsP.TabIndex = 5;
            this.TalentsP.Text = "Talents Prouesse";
            this.TalentsP.UseVisualStyleBackColor = true;
            // 
            // layoutTalentsP
            // 
            this.layoutTalentsP.AutoSize = true;
            this.layoutTalentsP.ColumnCount = 2;
            this.layoutTalentsP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentsP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutTalentsP.Location = new System.Drawing.Point(0, 0);
            this.layoutTalentsP.Name = "layoutTalentsP";
            this.layoutTalentsP.RowCount = 1;
            this.layoutTalentsP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTalentsP.Size = new System.Drawing.Size(453, 131);
            this.layoutTalentsP.TabIndex = 0;
            // 
            // stats_secondaire
            // 
            this.stats_secondaire.Controls.Add(this.secondaryStats1);
            this.stats_secondaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stats_secondaire.Location = new System.Drawing.Point(4, 22);
            this.stats_secondaire.Name = "stats_secondaire";
            this.stats_secondaire.Size = new System.Drawing.Size(666, 567);
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
            this.secondaryStats1.Size = new System.Drawing.Size(666, 567);
            this.secondaryStats1.TabIndex = 0;
            // 
            // ClasseTab
            // 
            this.ClasseTab.Controls.Add(this.Debloque);
            this.ClasseTab.Controls.Add(this.label29);
            this.ClasseTab.Controls.Add(this.label28);
            this.ClasseTab.Controls.Add(this.listBox2);
            this.ClasseTab.Controls.Add(this.comboBox1);
            this.ClasseTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClasseTab.Location = new System.Drawing.Point(4, 22);
            this.ClasseTab.Name = "ClasseTab";
            this.ClasseTab.Padding = new System.Windows.Forms.Padding(3);
            this.ClasseTab.Size = new System.Drawing.Size(666, 567);
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
            // Inventaire
            // 
            this.Inventaire.Controls.Add(this.splitContainer1);
            this.Inventaire.Location = new System.Drawing.Point(4, 40);
            this.Inventaire.Name = "Inventaire";
            this.Inventaire.Padding = new System.Windows.Forms.Padding(3);
            this.Inventaire.Size = new System.Drawing.Size(666, 549);
            this.Inventaire.TabIndex = 9;
            this.Inventaire.Text = "Inventaire";
            this.Inventaire.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox2);
            this.splitContainer1.Panel2.Controls.Add(this.Supprimer_inv);
            this.splitContainer1.Panel2.Controls.Add(this.ajouter_inv);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(660, 543);
            this.splitContainer1.SplitterDistance = 414;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBox3
            // 
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(0, 0);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(660, 414);
            this.listBox3.TabIndex = 0;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(17, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(358, 20);
            this.textBox2.TabIndex = 3;
            // 
            // Supprimer_inv
            // 
            this.Supprimer_inv.Location = new System.Drawing.Point(392, 55);
            this.Supprimer_inv.Name = "Supprimer_inv";
            this.Supprimer_inv.Size = new System.Drawing.Size(75, 23);
            this.Supprimer_inv.TabIndex = 2;
            this.Supprimer_inv.Text = "Supprimer";
            this.Supprimer_inv.UseVisualStyleBackColor = true;
            this.Supprimer_inv.Click += new System.EventHandler(this.Supprimer_inv_Click);
            // 
            // ajouter_inv
            // 
            this.ajouter_inv.Location = new System.Drawing.Point(392, 16);
            this.ajouter_inv.Name = "ajouter_inv";
            this.ajouter_inv.Size = new System.Drawing.Size(75, 23);
            this.ajouter_inv.TabIndex = 1;
            this.ajouter_inv.Text = "Ajouter";
            this.ajouter_inv.UseVisualStyleBackColor = true;
            this.ajouter_inv.Click += new System.EventHandler(this.ajouter_inv_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 20);
            this.textBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem1,
            this.debugToolStripMenuItem,
            this.editionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 24);
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
            this.exporterEnTxtToolStripMenuItem,
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
            // exporterEnTxtToolStripMenuItem
            // 
            this.exporterEnTxtToolStripMenuItem.Name = "exporterEnTxtToolStripMenuItem";
            this.exporterEnTxtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exporterEnTxtToolStripMenuItem.Text = "Exporter en .Txt";
            this.exporterEnTxtToolStripMenuItem.Click += new System.EventHandler(this.exporterEnTxtToolStripMenuItem_Click);
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
            this.talentsIdToolStripMenuItem,
            this.dumpRaceToolStripMenuItem});
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
            // dumpRaceToolStripMenuItem
            // 
            this.dumpRaceToolStripMenuItem.Name = "dumpRaceToolStripMenuItem";
            this.dumpRaceToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dumpRaceToolStripMenuItem.Text = "Dump Race";
            this.dumpRaceToolStripMenuItem.Click += new System.EventHandler(this.dumpRaceToolStripMenuItem_Click);
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajoutDeTalentToolStripMenuItem});
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editionToolStripMenuItem.Text = "Edition";
            // 
            // ajoutDeTalentToolStripMenuItem
            // 
            this.ajoutDeTalentToolStripMenuItem.Name = "ajoutDeTalentToolStripMenuItem";
            this.ajoutDeTalentToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ajoutDeTalentToolStripMenuItem.Text = "Ajout de Talent";
            this.ajoutDeTalentToolStripMenuItem.Click += new System.EventHandler(this.ajoutDeTalentToolStripMenuItem_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(708, 617);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Terre Natale";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.Stats.ResumeLayout(false);
            this.Stats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XpToAdd)).EndInit();
            this.TalentsG.ResumeLayout(false);
            this.TalentsG.PerformLayout();
            this.Savoirs.ResumeLayout(false);
            this.Savoirs.PerformLayout();
            this.TalentsM.ResumeLayout(false);
            this.TalentsM.PerformLayout();
            this.TalentsA.ResumeLayout(false);
            this.TalentsA.PerformLayout();
            this.TalentsP.ResumeLayout(false);
            this.TalentsP.PerformLayout();
            this.stats_secondaire.ResumeLayout(false);
            this.stats_secondaire.PerformLayout();
            this.ClasseTab.ResumeLayout(false);
            this.ClasseTab.PerformLayout();
            this.Inventaire.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel layoutTalentsA;
        private TabPage TalentsP;
        private TableLayoutPanel layoutTalentsP;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem dumpTalentsjsonToolStripMenuItem;
        private ToolStripMenuItem talentsIdToolStripMenuItem;
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
        private TableLayoutPanel layoutSavoir;
        private ToolStripMenuItem editionToolStripMenuItem;
        private ToolStripMenuItem ajoutDeTalentToolStripMenuItem;
        private TabPage Inventaire;
        private SplitContainer splitContainer1;
        private ListBox listBox3;
        private TextBox textBox2;
        private Button Supprimer_inv;
        private Button ajouter_inv;
        private TextBox textBox1;
        private View.Stat_Principal stat_Principal1;
        private ToolStripMenuItem dumpRaceToolStripMenuItem;
        private ListBox BonusRaciauxBox;
        private Label level;
        private ToolStripMenuItem exporterEnTxtToolStripMenuItem;
    }
}

