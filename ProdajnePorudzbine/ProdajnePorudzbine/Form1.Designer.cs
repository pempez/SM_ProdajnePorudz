namespace ProdajnePorudzbine
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblUkupnoEvroBez = new System.Windows.Forms.Label();
            this.lblStraniEvro = new System.Windows.Forms.Label();
            this.lblUkuponoEvroDomaci = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.lblU = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblUkupnoEvroPDV = new System.Windows.Forms.Label();
            this.lblStraniEvroPDV = new System.Windows.Forms.Label();
            this.lblDomaciEvroPDV = new System.Windows.Forms.Label();
            this.lblDomaciPDV = new System.Windows.Forms.Label();
            this.lblPDV = new System.Windows.Forms.Label();
            this.lblStraniPDV = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSalesHeader = new System.Windows.Forms.DataGridView();
            this.dgvSalesLine = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnStampa = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbKurs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnPronadji = new System.Windows.Forms.Button();
            this.cbKupac = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDomaciStrani = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.CheckBox();
            this.cbNalog = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbIzbaceni = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesLine)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(-2, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1184, 628);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dgvSalesHeader);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSalesLine);
            this.splitContainer1.Size = new System.Drawing.Size(1178, 609);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.lblUkupnoEvroBez);
            this.groupBox4.Controls.Add(this.lblStraniEvro);
            this.groupBox4.Controls.Add(this.lblUkuponoEvroDomaci);
            this.groupBox4.Controls.Add(this.lblD);
            this.groupBox4.Controls.Add(this.lblS);
            this.groupBox4.Controls.Add(this.lblU);
            this.groupBox4.Location = new System.Drawing.Point(243, 312);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 66);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bez PDV";
            // 
            // lblUkupnoEvroBez
            // 
            this.lblUkupnoEvroBez.AutoSize = true;
            this.lblUkupnoEvroBez.Location = new System.Drawing.Point(147, 46);
            this.lblUkupnoEvroBez.Name = "lblUkupnoEvroBez";
            this.lblUkupnoEvroBez.Size = new System.Drawing.Size(0, 13);
            this.lblUkupnoEvroBez.TabIndex = 9;
            // 
            // lblStraniEvro
            // 
            this.lblStraniEvro.AutoSize = true;
            this.lblStraniEvro.Location = new System.Drawing.Point(147, 33);
            this.lblStraniEvro.Name = "lblStraniEvro";
            this.lblStraniEvro.Size = new System.Drawing.Size(0, 13);
            this.lblStraniEvro.TabIndex = 8;
            // 
            // lblUkuponoEvroDomaci
            // 
            this.lblUkuponoEvroDomaci.AutoSize = true;
            this.lblUkuponoEvroDomaci.Location = new System.Drawing.Point(147, 19);
            this.lblUkuponoEvroDomaci.Name = "lblUkuponoEvroDomaci";
            this.lblUkuponoEvroDomaci.Size = new System.Drawing.Size(0, 13);
            this.lblUkuponoEvroDomaci.TabIndex = 7;
            // 
            // lblD
            // 
            this.lblD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(6, 20);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(0, 13);
            this.lblD.TabIndex = 4;
            this.lblD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblS
            // 
            this.lblS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblS.AutoSize = true;
            this.lblS.Location = new System.Drawing.Point(6, 33);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(0, 13);
            this.lblS.TabIndex = 5;
            this.lblS.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblU
            // 
            this.lblU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblU.AutoSize = true;
            this.lblU.Location = new System.Drawing.Point(6, 46);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(0, 13);
            this.lblU.TabIndex = 6;
            this.lblU.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lblUkupnoEvroPDV);
            this.groupBox3.Controls.Add(this.lblStraniEvroPDV);
            this.groupBox3.Controls.Add(this.lblDomaciEvroPDV);
            this.groupBox3.Controls.Add(this.lblDomaciPDV);
            this.groupBox3.Controls.Add(this.lblPDV);
            this.groupBox3.Controls.Add(this.lblStraniPDV);
            this.groupBox3.Location = new System.Drawing.Point(520, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 66);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sa PDV";
            // 
            // lblUkupnoEvroPDV
            // 
            this.lblUkupnoEvroPDV.AutoSize = true;
            this.lblUkupnoEvroPDV.Location = new System.Drawing.Point(158, 46);
            this.lblUkupnoEvroPDV.Name = "lblUkupnoEvroPDV";
            this.lblUkupnoEvroPDV.Size = new System.Drawing.Size(0, 13);
            this.lblUkupnoEvroPDV.TabIndex = 12;
            // 
            // lblStraniEvroPDV
            // 
            this.lblStraniEvroPDV.AutoSize = true;
            this.lblStraniEvroPDV.Location = new System.Drawing.Point(158, 33);
            this.lblStraniEvroPDV.Name = "lblStraniEvroPDV";
            this.lblStraniEvroPDV.Size = new System.Drawing.Size(0, 13);
            this.lblStraniEvroPDV.TabIndex = 11;
            // 
            // lblDomaciEvroPDV
            // 
            this.lblDomaciEvroPDV.AutoSize = true;
            this.lblDomaciEvroPDV.Location = new System.Drawing.Point(158, 19);
            this.lblDomaciEvroPDV.Name = "lblDomaciEvroPDV";
            this.lblDomaciEvroPDV.Size = new System.Drawing.Size(0, 13);
            this.lblDomaciEvroPDV.TabIndex = 10;
            // 
            // lblDomaciPDV
            // 
            this.lblDomaciPDV.AutoSize = true;
            this.lblDomaciPDV.Location = new System.Drawing.Point(6, 20);
            this.lblDomaciPDV.Name = "lblDomaciPDV";
            this.lblDomaciPDV.Size = new System.Drawing.Size(0, 13);
            this.lblDomaciPDV.TabIndex = 7;
            // 
            // lblPDV
            // 
            this.lblPDV.AutoSize = true;
            this.lblPDV.Location = new System.Drawing.Point(6, 46);
            this.lblPDV.Name = "lblPDV";
            this.lblPDV.Size = new System.Drawing.Size(0, 13);
            this.lblPDV.TabIndex = 9;
            // 
            // lblStraniPDV
            // 
            this.lblStraniPDV.AutoSize = true;
            this.lblStraniPDV.Location = new System.Drawing.Point(6, 33);
            this.lblStraniPDV.Name = "lblStraniPDV";
            this.lblStraniPDV.Size = new System.Drawing.Size(0, 13);
            this.lblStraniPDV.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ukupno:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ukupno Strani:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ukupno Domaci:";
            // 
            // dgvSalesHeader
            // 
            this.dgvSalesHeader.AllowUserToAddRows = false;
            this.dgvSalesHeader.AllowUserToDeleteRows = false;
            this.dgvSalesHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesHeader.Location = new System.Drawing.Point(11, 22);
            this.dgvSalesHeader.Name = "dgvSalesHeader";
            this.dgvSalesHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesHeader.Size = new System.Drawing.Size(1158, 284);
            this.dgvSalesHeader.TabIndex = 0;
            this.dgvSalesHeader.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesHeader_CellContentClick);
            this.dgvSalesHeader.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSalesHeader_CellMouseClick);
            this.dgvSalesHeader.SelectionChanged += new System.EventHandler(this.dgvSalesHeader_SelectionChanged);
            this.dgvSalesHeader.Click += new System.EventHandler(this.dgvSalesHeader_Click);
            this.dgvSalesHeader.MouseEnter += new System.EventHandler(this.dgvSalesHeader_MouseEnter);
            // 
            // dgvSalesLine
            // 
            this.dgvSalesLine.AllowUserToAddRows = false;
            this.dgvSalesLine.AllowUserToDeleteRows = false;
            this.dgvSalesLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSalesLine.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSalesLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesLine.Location = new System.Drawing.Point(9, 17);
            this.dgvSalesLine.Name = "dgvSalesLine";
            this.dgvSalesLine.ReadOnly = true;
            this.dgvSalesLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesLine.Size = new System.Drawing.Size(1158, 194);
            this.dgvSalesLine.TabIndex = 1;
            this.dgvSalesLine.MouseEnter += new System.EventHandler(this.dgvSalesLine_MouseEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbIzbaceni);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnPDF);
            this.groupBox2.Controls.Add(this.btnStampa);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbKurs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbType);
            this.groupBox2.Controls.Add(this.btnPronadji);
            this.groupBox2.Controls.Add(this.cbKupac);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbDomaciStrani);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtpDatum);
            this.groupBox2.Controls.Add(this.dtpDatumDo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbPeriod);
            this.groupBox2.Controls.Add(this.cbNalog);
            this.groupBox2.Location = new System.Drawing.Point(1, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1183, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnPDF
            // 
            this.btnPDF.Enabled = false;
            this.btnPDF.Location = new System.Drawing.Point(902, 65);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(75, 23);
            this.btnPDF.TabIndex = 47;
            this.btnPDF.Text = "PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnStampa
            // 
            this.btnStampa.Enabled = false;
            this.btnStampa.Location = new System.Drawing.Point(821, 64);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(75, 23);
            this.btnStampa.TabIndex = 46;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(737, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Kurs";
            // 
            // tbKurs
            // 
            this.tbKurs.Location = new System.Drawing.Point(740, 29);
            this.tbKurs.Name = "tbKurs";
            this.tbKurs.Size = new System.Drawing.Size(75, 20);
            this.tbKurs.TabIndex = 44;
            this.tbKurs.Leave += new System.EventHandler(this.tbKurs_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Vrsta naloga";
            // 
            // cbType
            // 
            this.cbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(6, 28);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(171, 21);
            this.cbType.TabIndex = 42;
            this.cbType.SelectedValueChanged += new System.EventHandler(this.cbType_SelectedValueChanged);
            // 
            // btnPronadji
            // 
            this.btnPronadji.Location = new System.Drawing.Point(740, 66);
            this.btnPronadji.Name = "btnPronadji";
            this.btnPronadji.Size = new System.Drawing.Size(75, 23);
            this.btnPronadji.TabIndex = 41;
            this.btnPronadji.Text = "Pronadji";
            this.btnPronadji.UseVisualStyleBackColor = true;
            this.btnPronadji.Click += new System.EventHandler(this.btnPronadji_Click);
            // 
            // cbKupac
            // 
            this.cbKupac.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbKupac.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbKupac.FormattingEnabled = true;
            this.cbKupac.Location = new System.Drawing.Point(183, 68);
            this.cbKupac.Name = "cbKupac";
            this.cbKupac.Size = new System.Drawing.Size(171, 21);
            this.cbKupac.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Kupac";
            // 
            // cbDomaciStrani
            // 
            this.cbDomaciStrani.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbDomaciStrani.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDomaciStrani.FormattingEnabled = true;
            this.cbDomaciStrani.Items.AddRange(new object[] {
            "Domaci",
            "Strani"});
            this.cbDomaciStrani.Location = new System.Drawing.Point(360, 67);
            this.cbDomaciStrani.Name = "cbDomaciStrani";
            this.cbDomaciStrani.Size = new System.Drawing.Size(171, 21);
            this.cbDomaciStrani.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(357, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Domaci-strani";
            // 
            // dtpDatum
            // 
            this.dtpDatum.CustomFormat = "dd.MM.yyyy";
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatum.Location = new System.Drawing.Point(540, 67);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(78, 20);
            this.dtpDatum.TabIndex = 30;
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.CustomFormat = "dd.MM.yyyy";
            this.dtpDatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatumDo.Location = new System.Drawing.Point(624, 67);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(78, 20);
            this.dtpDatumDo.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Nalog";
            // 
            // cbPeriod
            // 
            this.cbPeriod.AutoSize = true;
            this.cbPeriod.Location = new System.Drawing.Point(540, 45);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(56, 17);
            this.cbPeriod.TabIndex = 36;
            this.cbPeriod.Text = "Period";
            this.cbPeriod.UseVisualStyleBackColor = true;
            // 
            // cbNalog
            // 
            this.cbNalog.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbNalog.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNalog.FormattingEnabled = true;
            this.cbNalog.Location = new System.Drawing.Point(6, 69);
            this.cbNalog.Name = "cbNalog";
            this.cbNalog.Size = new System.Drawing.Size(171, 21);
            this.cbNalog.TabIndex = 32;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 17);
            this.button1.TabIndex = 48;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbIzbaceni
            // 
            this.rtbIzbaceni.Enabled = false;
            this.rtbIzbaceni.Location = new System.Drawing.Point(996, 12);
            this.rtbIzbaceni.Name = "rtbIzbaceni";
            this.rtbIzbaceni.Size = new System.Drawing.Size(175, 78);
            this.rtbIzbaceni.TabIndex = 49;
            this.rtbIzbaceni.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stampa";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesLine)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvSalesHeader;
        private System.Windows.Forms.DataGridView dgvSalesLine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPronadji;
        private System.Windows.Forms.ComboBox cbKupac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDomaciStrani;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.DateTimePicker dtpDatumDo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbPeriod;
        private System.Windows.Forms.ComboBox cbNalog;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblU;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPDV;
        private System.Windows.Forms.Label lblStraniPDV;
        private System.Windows.Forms.Label lblDomaciPDV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbKurs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblUkupnoEvroBez;
        private System.Windows.Forms.Label lblStraniEvro;
        private System.Windows.Forms.Label lblUkuponoEvroDomaci;
        private System.Windows.Forms.Label lblUkupnoEvroPDV;
        private System.Windows.Forms.Label lblStraniEvroPDV;
        private System.Windows.Forms.Label lblDomaciEvroPDV;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnStampa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbIzbaceni;
    }
}

