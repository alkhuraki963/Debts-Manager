namespace DebtsManager
{
    partial class FrmSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "الليرة السورية",
            "سوريا",
            "ل.س"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "الليرة السورية",
            "سوريا",
            "ل.س"}, -1);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpPersonalInformation = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tpClassification = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddClassification = new System.Windows.Forms.Button();
            this.imglstButtons = new System.Windows.Forms.ImageList(this.components);
            this.btnEditClassification = new System.Windows.Forms.Button();
            this.btnDeleteClassification = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tpCurrencies = new System.Windows.Forms.TabPage();
            this.btnDefaultCurrency = new System.Windows.Forms.Button();
            this.btnCurrencyRate = new System.Windows.Forms.Button();
            this.btnUnUseCurrency = new System.Windows.Forms.Button();
            this.btnUseCurrency = new System.Windows.Forms.Button();
            this.btnAddCurrency = new System.Windows.Forms.Button();
            this.btnEditCurrency = new System.Windows.Forms.Button();
            this.btnDeleteCurrency = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lvUsedCurrencies = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imglstCurrencies = new System.Windows.Forms.ImageList(this.components);
            this.lvCurrencies = new System.Windows.Forms.ListView();
            this.colCurrencyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrencyCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurrencySuffix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbSecurity = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.imglstTabs = new System.Windows.Forms.ImageList(this.components);
            this.tabControl.SuspendLayout();
            this.tpPersonalInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpClassification.SuspendLayout();
            this.tpCurrencies.SuspendLayout();
            this.tbSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Controls.Add(this.tpPersonalInformation);
            this.tabControl.Controls.Add(this.tpClassification);
            this.tabControl.Controls.Add(this.tpCurrencies);
            this.tabControl.Controls.Add(this.tbSecurity);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ImageList = this.imglstTabs;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(979, 513);
            this.tabControl.TabIndex = 1;
            // 
            // tpPersonalInformation
            // 
            this.tpPersonalInformation.Controls.Add(this.label7);
            this.tpPersonalInformation.Controls.Add(this.textBox3);
            this.tpPersonalInformation.Controls.Add(this.label6);
            this.tpPersonalInformation.Controls.Add(this.textBox2);
            this.tpPersonalInformation.Controls.Add(this.label5);
            this.tpPersonalInformation.Controls.Add(this.linkLabel1);
            this.tpPersonalInformation.Controls.Add(this.label4);
            this.tpPersonalInformation.Controls.Add(this.pictureBox1);
            this.tpPersonalInformation.Controls.Add(this.textBox1);
            this.tpPersonalInformation.Controls.Add(this.label3);
            this.tpPersonalInformation.ImageIndex = 0;
            this.tpPersonalInformation.Location = new System.Drawing.Point(4, 4);
            this.tpPersonalInformation.Name = "tpPersonalInformation";
            this.tpPersonalInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInformation.Size = new System.Drawing.Size(971, 474);
            this.tpPersonalInformation.TabIndex = 0;
            this.tpPersonalInformation.Text = "المعلومات الشخصية";
            this.tpPersonalInformation.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("El Messiri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(371, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(278, 47);
            this.label7.TabIndex = 9;
            this.label7.Text = "المعلومات الشخصية";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(309, 238);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(318, 34);
            this.textBox3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "رقم الهاتف";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(309, 137);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(318, 84);
            this.textBox2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(642, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "العنوان";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(87, 298);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 26);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "تعديل الشعار";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "شعار شركتك";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DebtsManager.Properties.Resources.debts_manager;
            this.pictureBox1.Location = new System.Drawing.Point(33, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(309, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(318, 34);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "اسم شركتك";
            // 
            // tpClassification
            // 
            this.tpClassification.Controls.Add(this.label2);
            this.tpClassification.Controls.Add(this.btnAddClassification);
            this.tpClassification.Controls.Add(this.btnEditClassification);
            this.tpClassification.Controls.Add(this.btnDeleteClassification);
            this.tpClassification.Controls.Add(this.listView1);
            this.tpClassification.ImageIndex = 1;
            this.tpClassification.Location = new System.Drawing.Point(4, 4);
            this.tpClassification.Name = "tpClassification";
            this.tpClassification.Padding = new System.Windows.Forms.Padding(3);
            this.tpClassification.Size = new System.Drawing.Size(971, 474);
            this.tpClassification.TabIndex = 1;
            this.tpClassification.Text = "التصنيفات";
            this.tpClassification.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("El Messiri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 47);
            this.label2.TabIndex = 5;
            this.label2.Text = "التصنيفات";
            // 
            // btnAddClassification
            // 
            this.btnAddClassification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddClassification.ImageIndex = 1;
            this.btnAddClassification.ImageList = this.imglstButtons;
            this.btnAddClassification.Location = new System.Drawing.Point(441, 307);
            this.btnAddClassification.Name = "btnAddClassification";
            this.btnAddClassification.Size = new System.Drawing.Size(117, 36);
            this.btnAddClassification.TabIndex = 8;
            this.btnAddClassification.Text = "إضافة";
            this.btnAddClassification.UseVisualStyleBackColor = true;
            // 
            // imglstButtons
            // 
            this.imglstButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstButtons.ImageStream")));
            this.imglstButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstButtons.Images.SetKeyName(0, "bin.png");
            this.imglstButtons.Images.SetKeyName(1, "plus.png");
            this.imglstButtons.Images.SetKeyName(2, "Edit.png");
            this.imglstButtons.Images.SetKeyName(3, "icons8-currency-exchange-22.png");
            this.imglstButtons.Images.SetKeyName(4, "icons8-currency-24.png");
            // 
            // btnEditClassification
            // 
            this.btnEditClassification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditClassification.ImageIndex = 2;
            this.btnEditClassification.ImageList = this.imglstButtons;
            this.btnEditClassification.Location = new System.Drawing.Point(318, 307);
            this.btnEditClassification.Name = "btnEditClassification";
            this.btnEditClassification.Size = new System.Drawing.Size(117, 36);
            this.btnEditClassification.TabIndex = 7;
            this.btnEditClassification.Text = "تعديل";
            this.btnEditClassification.UseVisualStyleBackColor = true;
            // 
            // btnDeleteClassification
            // 
            this.btnDeleteClassification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteClassification.ImageIndex = 0;
            this.btnDeleteClassification.ImageList = this.imglstButtons;
            this.btnDeleteClassification.Location = new System.Drawing.Point(195, 307);
            this.btnDeleteClassification.Name = "btnDeleteClassification";
            this.btnDeleteClassification.Size = new System.Drawing.Size(117, 36);
            this.btnDeleteClassification.TabIndex = 6;
            this.btnDeleteClassification.Text = "حذف";
            this.btnDeleteClassification.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(134, 68);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(496, 224);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tpCurrencies
            // 
            this.tpCurrencies.Controls.Add(this.btnDefaultCurrency);
            this.tpCurrencies.Controls.Add(this.btnCurrencyRate);
            this.tpCurrencies.Controls.Add(this.btnUnUseCurrency);
            this.tpCurrencies.Controls.Add(this.btnUseCurrency);
            this.tpCurrencies.Controls.Add(this.btnAddCurrency);
            this.tpCurrencies.Controls.Add(this.btnEditCurrency);
            this.tpCurrencies.Controls.Add(this.btnDeleteCurrency);
            this.tpCurrencies.Controls.Add(this.label1);
            this.tpCurrencies.Controls.Add(this.label11);
            this.tpCurrencies.Controls.Add(this.lvUsedCurrencies);
            this.tpCurrencies.Controls.Add(this.lvCurrencies);
            this.tpCurrencies.ImageIndex = 2;
            this.tpCurrencies.Location = new System.Drawing.Point(4, 4);
            this.tpCurrencies.Name = "tpCurrencies";
            this.tpCurrencies.Padding = new System.Windows.Forms.Padding(3);
            this.tpCurrencies.Size = new System.Drawing.Size(971, 474);
            this.tpCurrencies.TabIndex = 2;
            this.tpCurrencies.Text = "العملات";
            this.tpCurrencies.UseVisualStyleBackColor = true;
            // 
            // btnDefaultCurrency
            // 
            this.btnDefaultCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefaultCurrency.ImageIndex = 4;
            this.btnDefaultCurrency.ImageList = this.imglstButtons;
            this.btnDefaultCurrency.Location = new System.Drawing.Point(197, 432);
            this.btnDefaultCurrency.Name = "btnDefaultCurrency";
            this.btnDefaultCurrency.Size = new System.Drawing.Size(159, 36);
            this.btnDefaultCurrency.TabIndex = 22;
            this.btnDefaultCurrency.Text = "العملة الأفتراضية";
            this.btnDefaultCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefaultCurrency.UseVisualStyleBackColor = true;
            this.btnDefaultCurrency.Click += new System.EventHandler(this.btnDefaultCurrency_Click);
            // 
            // btnCurrencyRate
            // 
            this.btnCurrencyRate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrencyRate.ImageIndex = 3;
            this.btnCurrencyRate.ImageList = this.imglstButtons;
            this.btnCurrencyRate.Location = new System.Drawing.Point(56, 432);
            this.btnCurrencyRate.Name = "btnCurrencyRate";
            this.btnCurrencyRate.Size = new System.Drawing.Size(135, 36);
            this.btnCurrencyRate.TabIndex = 21;
            this.btnCurrencyRate.Text = "اسعار الصرف";
            this.btnCurrencyRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCurrencyRate.UseVisualStyleBackColor = true;
            this.btnCurrencyRate.Click += new System.EventHandler(this.btnCurrencyRate_Click);
            // 
            // btnUnUseCurrency
            // 
            this.btnUnUseCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnUseCurrency.ImageList = this.imglstButtons;
            this.btnUnUseCurrency.Location = new System.Drawing.Point(441, 261);
            this.btnUnUseCurrency.Name = "btnUnUseCurrency";
            this.btnUnUseCurrency.Size = new System.Drawing.Size(72, 36);
            this.btnUnUseCurrency.TabIndex = 20;
            this.btnUnUseCurrency.Text = "<--";
            this.btnUnUseCurrency.UseVisualStyleBackColor = true;
            this.btnUnUseCurrency.Click += new System.EventHandler(this.btnUnUseCurrency_Click);
            // 
            // btnUseCurrency
            // 
            this.btnUseCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUseCurrency.ImageList = this.imglstButtons;
            this.btnUseCurrency.Location = new System.Drawing.Point(441, 219);
            this.btnUseCurrency.Name = "btnUseCurrency";
            this.btnUseCurrency.Size = new System.Drawing.Size(72, 36);
            this.btnUseCurrency.TabIndex = 19;
            this.btnUseCurrency.Text = "-->";
            this.btnUseCurrency.UseVisualStyleBackColor = true;
            this.btnUseCurrency.Click += new System.EventHandler(this.btnUseCurrency_Click);
            // 
            // btnAddCurrency
            // 
            this.btnAddCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCurrency.ImageIndex = 1;
            this.btnAddCurrency.ImageList = this.imglstButtons;
            this.btnAddCurrency.Location = new System.Drawing.Point(792, 432);
            this.btnAddCurrency.Name = "btnAddCurrency";
            this.btnAddCurrency.Size = new System.Drawing.Size(117, 36);
            this.btnAddCurrency.TabIndex = 18;
            this.btnAddCurrency.Text = "إضافة";
            this.btnAddCurrency.UseVisualStyleBackColor = true;
            this.btnAddCurrency.Click += new System.EventHandler(this.btnAddNewCurrency_Click);
            // 
            // btnEditCurrency
            // 
            this.btnEditCurrency.Enabled = false;
            this.btnEditCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCurrency.ImageIndex = 2;
            this.btnEditCurrency.ImageList = this.imglstButtons;
            this.btnEditCurrency.Location = new System.Drawing.Point(669, 432);
            this.btnEditCurrency.Name = "btnEditCurrency";
            this.btnEditCurrency.Size = new System.Drawing.Size(117, 36);
            this.btnEditCurrency.TabIndex = 17;
            this.btnEditCurrency.Text = "تعديل";
            this.btnEditCurrency.UseVisualStyleBackColor = true;
            this.btnEditCurrency.Click += new System.EventHandler(this.btnEditCurrency_Click);
            // 
            // btnDeleteCurrency
            // 
            this.btnDeleteCurrency.Enabled = false;
            this.btnDeleteCurrency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteCurrency.ImageIndex = 0;
            this.btnDeleteCurrency.ImageList = this.imglstButtons;
            this.btnDeleteCurrency.Location = new System.Drawing.Point(546, 432);
            this.btnDeleteCurrency.Name = "btnDeleteCurrency";
            this.btnDeleteCurrency.Size = new System.Drawing.Size(117, 36);
            this.btnDeleteCurrency.TabIndex = 16;
            this.btnDeleteCurrency.Text = "حذف";
            this.btnDeleteCurrency.UseVisualStyleBackColor = true;
            this.btnDeleteCurrency.Click += new System.EventHandler(this.btnDeleteCurrency_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "العملات المستخدمة";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(686, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 31);
            this.label11.TabIndex = 14;
            this.label11.Text = "العملات";
            // 
            // lvUsedCurrencies
            // 
            this.lvUsedCurrencies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvUsedCurrencies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvUsedCurrencies.FullRowSelect = true;
            this.lvUsedCurrencies.GridLines = true;
            this.lvUsedCurrencies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUsedCurrencies.HideSelection = false;
            this.lvUsedCurrencies.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvUsedCurrencies.Location = new System.Drawing.Point(19, 61);
            this.lvUsedCurrencies.MultiSelect = false;
            this.lvUsedCurrencies.Name = "lvUsedCurrencies";
            this.lvUsedCurrencies.RightToLeftLayout = true;
            this.lvUsedCurrencies.Size = new System.Drawing.Size(416, 365);
            this.lvUsedCurrencies.SmallImageList = this.imglstCurrencies;
            this.lvUsedCurrencies.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvUsedCurrencies.TabIndex = 13;
            this.lvUsedCurrencies.UseCompatibleStateImageBehavior = false;
            this.lvUsedCurrencies.View = System.Windows.Forms.View.Details;
            this.lvUsedCurrencies.SelectedIndexChanged += new System.EventHandler(this.lvUsedCurrencies_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "العملة";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "الدولة";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "الرمز";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imglstCurrencies
            // 
            this.imglstCurrencies.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstCurrencies.ImageStream")));
            this.imglstCurrencies.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstCurrencies.Images.SetKeyName(0, "icons8-currency-32.png");
            // 
            // lvCurrencies
            // 
            this.lvCurrencies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCurrencyName,
            this.colCurrencyCountry,
            this.colCurrencySuffix});
            this.lvCurrencies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvCurrencies.FullRowSelect = true;
            this.lvCurrencies.GridLines = true;
            this.lvCurrencies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCurrencies.HideSelection = false;
            this.lvCurrencies.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvCurrencies.Location = new System.Drawing.Point(519, 61);
            this.lvCurrencies.MultiSelect = false;
            this.lvCurrencies.Name = "lvCurrencies";
            this.lvCurrencies.RightToLeftLayout = true;
            this.lvCurrencies.Size = new System.Drawing.Size(416, 365);
            this.lvCurrencies.SmallImageList = this.imglstCurrencies;
            this.lvCurrencies.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCurrencies.TabIndex = 12;
            this.lvCurrencies.UseCompatibleStateImageBehavior = false;
            this.lvCurrencies.View = System.Windows.Forms.View.Details;
            this.lvCurrencies.SelectedIndexChanged += new System.EventHandler(this.lvCurrencies_SelectedIndexChanged);
            // 
            // colCurrencyName
            // 
            this.colCurrencyName.Text = "العملة";
            this.colCurrencyName.Width = 200;
            // 
            // colCurrencyCountry
            // 
            this.colCurrencyCountry.Text = "الدولة";
            this.colCurrencyCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCurrencyCountry.Width = 150;
            // 
            // colCurrencySuffix
            // 
            this.colCurrencySuffix.Text = "الرمز";
            this.colCurrencySuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbSecurity
            // 
            this.tbSecurity.Controls.Add(this.label10);
            this.tbSecurity.Controls.Add(this.chkLock);
            this.tbSecurity.Controls.Add(this.pictureBox2);
            this.tbSecurity.Controls.Add(this.tbPassword);
            this.tbSecurity.Controls.Add(this.label8);
            this.tbSecurity.Controls.Add(this.tbUsername);
            this.tbSecurity.Controls.Add(this.label9);
            this.tbSecurity.ImageIndex = 3;
            this.tbSecurity.Location = new System.Drawing.Point(4, 4);
            this.tbSecurity.Name = "tbSecurity";
            this.tbSecurity.Padding = new System.Windows.Forms.Padding(3);
            this.tbSecurity.Size = new System.Drawing.Size(971, 474);
            this.tbSecurity.TabIndex = 3;
            this.tbSecurity.Text = "الأمان";
            this.tbSecurity.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("El Messiri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(562, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 47);
            this.label10.TabIndex = 15;
            this.label10.Text = "الأمان";
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Location = new System.Drawing.Point(333, 260);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(263, 30);
            this.chkLock.TabIndex = 14;
            this.chkLock.Text = "قفل البرنامج باستخدام كلمة مرور";
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DebtsManager.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(37, 111);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 203);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Enabled = false;
            this.tbPassword.Location = new System.Drawing.Point(278, 211);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(318, 34);
            this.tbPassword.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(602, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 26);
            this.label8.TabIndex = 11;
            this.label8.Text = "كلمة المرور";
            // 
            // tbUsername
            // 
            this.tbUsername.Enabled = false;
            this.tbUsername.Location = new System.Drawing.Point(278, 163);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(318, 34);
            this.tbUsername.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(602, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 26);
            this.label9.TabIndex = 9;
            this.label9.Text = "اسم المستخدم";
            // 
            // imglstTabs
            // 
            this.imglstTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTabs.ImageStream")));
            this.imglstTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstTabs.Images.SetKeyName(0, "icons8-name-30.png");
            this.imglstTabs.Images.SetKeyName(1, "icons8-classification-24.png");
            this.imglstTabs.Images.SetKeyName(2, "icons8-currency-24.png");
            this.imglstTabs.Images.SetKeyName(3, "icons8-password-24.png");
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 513);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "FrmSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الأعدادات";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.tabControl.ResumeLayout(false);
            this.tpPersonalInformation.ResumeLayout(false);
            this.tpPersonalInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpClassification.ResumeLayout(false);
            this.tpClassification.PerformLayout();
            this.tpCurrencies.ResumeLayout(false);
            this.tpCurrencies.PerformLayout();
            this.tbSecurity.ResumeLayout(false);
            this.tbSecurity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpPersonalInformation;
        private System.Windows.Forms.TabPage tpClassification;
        private System.Windows.Forms.TabPage tpCurrencies;
        private System.Windows.Forms.ImageList imglstTabs;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteClassification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imglstCurrencies;
        private System.Windows.Forms.Button btnAddClassification;
        private System.Windows.Forms.Button btnEditClassification;
        private System.Windows.Forms.ImageList imglstButtons;
        private System.Windows.Forms.TabPage tbSecurity;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnDefaultCurrency;
        private System.Windows.Forms.Button btnCurrencyRate;
        private System.Windows.Forms.Button btnUnUseCurrency;
        private System.Windows.Forms.Button btnUseCurrency;
        private System.Windows.Forms.Button btnAddCurrency;
        private System.Windows.Forms.Button btnEditCurrency;
        private System.Windows.Forms.Button btnDeleteCurrency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lvUsedCurrencies;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvCurrencies;
        private System.Windows.Forms.ColumnHeader colCurrencyName;
        private System.Windows.Forms.ColumnHeader colCurrencyCountry;
        private System.Windows.Forms.ColumnHeader colCurrencySuffix;
    }
}