namespace DebtsManager
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAboutPage = new System.Windows.Forms.Button();
            this.btnSettingsPage = new System.Windows.Forms.Button();
            this.btnMainPage = new System.Windows.Forms.Button();
            this.btnReportPage = new System.Windows.Forms.Button();
            this.btnAccountPage = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlAccounts = new System.Windows.Forms.Panel();
            this.lvAccounts = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.عرضToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTableView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLargIconView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSmallIconView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTielsView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFilterAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOutcomeAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIncomeAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.imglstAccount = new System.Windows.Forms.ImageList(this.components);
            this.pnlAccountFunctions = new System.Windows.Forms.Panel();
            this.lblAccountsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOnYou = new System.Windows.Forms.Label();
            this.lblForYou = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbClassifications = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCompanyInfo = new System.Windows.Forms.Panel();
            this.pbCompanyIcon = new System.Windows.Forms.PictureBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pnlProgramData = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlCurrentDate = new System.Windows.Forms.Panel();
            this.lblCurrentDay = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlNavigation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlAccounts.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlAccountFunctions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlCompanyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyIcon)).BeginInit();
            this.pnlProgramData.SuspendLayout();
            this.pnlCurrentDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.panel1);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavigation.Location = new System.Drawing.Point(275, 0);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(987, 37);
            this.pnlNavigation.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnAboutPage);
            this.panel1.Controls.Add(this.btnSettingsPage);
            this.panel1.Controls.Add(this.btnMainPage);
            this.panel1.Controls.Add(this.btnReportPage);
            this.panel1.Controls.Add(this.btnAccountPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(405, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 37);
            this.panel1.TabIndex = 5;
            // 
            // btnAboutPage
            // 
            this.btnAboutPage.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAboutPage.Image = global::DebtsManager.Properties.Resources.icons8_about_24;
            this.btnAboutPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAboutPage.Location = new System.Drawing.Point(10, 3);
            this.btnAboutPage.Name = "btnAboutPage";
            this.btnAboutPage.Size = new System.Drawing.Size(109, 32);
            this.btnAboutPage.TabIndex = 6;
            this.btnAboutPage.Text = "حول";
            this.btnAboutPage.UseVisualStyleBackColor = true;
            this.btnAboutPage.Click += new System.EventHandler(this.btnAboutPage_Click);
            // 
            // btnSettingsPage
            // 
            this.btnSettingsPage.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingsPage.Image = global::DebtsManager.Properties.Resources.icons8_settings_24;
            this.btnSettingsPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettingsPage.Location = new System.Drawing.Point(125, 3);
            this.btnSettingsPage.Name = "btnSettingsPage";
            this.btnSettingsPage.Size = new System.Drawing.Size(109, 32);
            this.btnSettingsPage.TabIndex = 5;
            this.btnSettingsPage.Text = "إعدادات";
            this.btnSettingsPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettingsPage.UseVisualStyleBackColor = true;
            this.btnSettingsPage.Click += new System.EventHandler(this.btnSettingsPage_Click);
            // 
            // btnMainPage
            // 
            this.btnMainPage.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainPage.Image = global::DebtsManager.Properties.Resources.icons8_home_24;
            this.btnMainPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainPage.Location = new System.Drawing.Point(470, 3);
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.Size = new System.Drawing.Size(109, 32);
            this.btnMainPage.TabIndex = 3;
            this.btnMainPage.Text = "الرئيسة";
            this.btnMainPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainPage.UseVisualStyleBackColor = true;
            this.btnMainPage.Click += new System.EventHandler(this.btnMainPage_Click);
            // 
            // btnReportPage
            // 
            this.btnReportPage.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportPage.Image = global::DebtsManager.Properties.Resources.icons8_reports_24;
            this.btnReportPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportPage.Location = new System.Drawing.Point(240, 3);
            this.btnReportPage.Name = "btnReportPage";
            this.btnReportPage.Size = new System.Drawing.Size(109, 32);
            this.btnReportPage.TabIndex = 4;
            this.btnReportPage.Text = "تقارير";
            this.btnReportPage.UseVisualStyleBackColor = true;
            this.btnReportPage.Click += new System.EventHandler(this.btnReportPage_Click);
            // 
            // btnAccountPage
            // 
            this.btnAccountPage.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountPage.Image = global::DebtsManager.Properties.Resources.icons8_accounts_24;
            this.btnAccountPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountPage.Location = new System.Drawing.Point(355, 3);
            this.btnAccountPage.Name = "btnAccountPage";
            this.btnAccountPage.Size = new System.Drawing.Size(109, 32);
            this.btnAccountPage.TabIndex = 2;
            this.btnAccountPage.Text = "الحسابات";
            this.btnAccountPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccountPage.UseVisualStyleBackColor = true;
            this.btnAccountPage.Click += new System.EventHandler(this.btnAccountPage_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlAccounts);
            this.pnlMain.Controls.Add(this.pnlCompanyInfo);
            this.pnlMain.Controls.Add(this.pnlNavigation);
            this.pnlMain.Controls.Add(this.pnlProgramData);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1262, 513);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlAccounts
            // 
            this.pnlAccounts.Controls.Add(this.lvAccounts);
            this.pnlAccounts.Controls.Add(this.pnlAccountFunctions);
            this.pnlAccounts.Controls.Add(this.panel2);
            this.pnlAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccounts.Location = new System.Drawing.Point(275, 37);
            this.pnlAccounts.Name = "pnlAccounts";
            this.pnlAccounts.Size = new System.Drawing.Size(987, 476);
            this.pnlAccounts.TabIndex = 0;
            this.pnlAccounts.Visible = false;
            // 
            // lvAccounts
            // 
            this.lvAccounts.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lvAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.balance});
            this.lvAccounts.ContextMenuStrip = this.contextMenuStrip1;
            this.lvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAccounts.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAccounts.HideSelection = false;
            this.lvAccounts.LargeImageList = this.imglstAccount;
            this.lvAccounts.Location = new System.Drawing.Point(0, 43);
            this.lvAccounts.Name = "lvAccounts";
            this.lvAccounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvAccounts.RightToLeftLayout = true;
            this.lvAccounts.Size = new System.Drawing.Size(987, 390);
            this.lvAccounts.SmallImageList = this.imglstAccount;
            this.lvAccounts.TabIndex = 1;
            this.lvAccounts.UseCompatibleStateImageBehavior = false;
            this.lvAccounts.View = System.Windows.Forms.View.Tile;
            this.lvAccounts.SelectedIndexChanged += new System.EventHandler(this.lvAccounts_SelectedIndexChanged);
            this.lvAccounts.DoubleClick += new System.EventHandler(this.lvAccounts_DoubleClick);
            // 
            // name
            // 
            this.name.Text = "الأسم";
            // 
            // balance
            // 
            this.balance.Text = "الرصيد";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.عرضToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmiEdit,
            this.tsmiDelete,
            this.toolStripMenuItem1,
            this.tsmiFilterAccounts});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // عرضToolStripMenuItem
            // 
            this.عرضToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTableView,
            this.tsmiLargIconView,
            this.tsmiSmallIconView,
            this.tsmiTielsView});
            this.عرضToolStripMenuItem.Name = "عرضToolStripMenuItem";
            this.عرضToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.عرضToolStripMenuItem.Text = "عرض";
            // 
            // tsmiTableView
            // 
            this.tsmiTableView.Name = "tsmiTableView";
            this.tsmiTableView.Size = new System.Drawing.Size(186, 26);
            this.tsmiTableView.Text = "جدول";
            this.tsmiTableView.Click += new System.EventHandler(this.tsmiTableView_Click);
            // 
            // tsmiLargIconView
            // 
            this.tsmiLargIconView.Name = "tsmiLargIconView";
            this.tsmiLargIconView.Size = new System.Drawing.Size(186, 26);
            this.tsmiLargIconView.Text = "أيقونات كبيرة";
            this.tsmiLargIconView.Click += new System.EventHandler(this.tsmiLargIconView_Click);
            // 
            // tsmiSmallIconView
            // 
            this.tsmiSmallIconView.Name = "tsmiSmallIconView";
            this.tsmiSmallIconView.Size = new System.Drawing.Size(186, 26);
            this.tsmiSmallIconView.Text = "أيقونات صغيرة";
            this.tsmiSmallIconView.Click += new System.EventHandler(this.tsmiSmallIconView_Click);
            // 
            // tsmiTielsView
            // 
            this.tsmiTielsView.Name = "tsmiTielsView";
            this.tsmiTielsView.Size = new System.Drawing.Size(186, 26);
            this.tsmiTielsView.Text = "تفاصيل";
            this.tsmiTielsView.Click += new System.EventHandler(this.tsmiTielsView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = global::DebtsManager.Properties.Resources.Edit;
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(123, 26);
            this.tsmiEdit.Text = "تعديل";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::DebtsManager.Properties.Resources.bin;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(123, 26);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // tsmiFilterAccounts
            // 
            this.tsmiFilterAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOutcomeAccounts,
            this.tsmiIncomeAccounts});
            this.tsmiFilterAccounts.Name = "tsmiFilterAccounts";
            this.tsmiFilterAccounts.Size = new System.Drawing.Size(123, 26);
            this.tsmiFilterAccounts.Text = "تصفية";
            // 
            // tsmiOutcomeAccounts
            // 
            this.tsmiOutcomeAccounts.Name = "tsmiOutcomeAccounts";
            this.tsmiOutcomeAccounts.Size = new System.Drawing.Size(198, 26);
            this.tsmiOutcomeAccounts.Text = "الحسابات الدائنة";
            // 
            // tsmiIncomeAccounts
            // 
            this.tsmiIncomeAccounts.Name = "tsmiIncomeAccounts";
            this.tsmiIncomeAccounts.Size = new System.Drawing.Size(198, 26);
            this.tsmiIncomeAccounts.Text = "الحسابات المدينة";
            // 
            // imglstAccount
            // 
            this.imglstAccount.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstAccount.ImageStream")));
            this.imglstAccount.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstAccount.Images.SetKeyName(0, "accountant.png");
            this.imglstAccount.Images.SetKeyName(1, "icons8-add-48.png");
            // 
            // pnlAccountFunctions
            // 
            this.pnlAccountFunctions.Controls.Add(this.lblAccountsCount);
            this.pnlAccountFunctions.Controls.Add(this.label3);
            this.pnlAccountFunctions.Controls.Add(this.lblOnYou);
            this.pnlAccountFunctions.Controls.Add(this.lblForYou);
            this.pnlAccountFunctions.Controls.Add(this.label2);
            this.pnlAccountFunctions.Controls.Add(this.label1);
            this.pnlAccountFunctions.Controls.Add(this.btnAddAccount);
            this.pnlAccountFunctions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccountFunctions.Location = new System.Drawing.Point(0, 433);
            this.pnlAccountFunctions.Name = "pnlAccountFunctions";
            this.pnlAccountFunctions.Size = new System.Drawing.Size(987, 43);
            this.pnlAccountFunctions.TabIndex = 0;
            // 
            // lblAccountsCount
            // 
            this.lblAccountsCount.BackColor = System.Drawing.Color.Gray;
            this.lblAccountsCount.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountsCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAccountsCount.Location = new System.Drawing.Point(9, 12);
            this.lblAccountsCount.Name = "lblAccountsCount";
            this.lblAccountsCount.Size = new System.Drawing.Size(61, 23);
            this.lblAccountsCount.TabIndex = 15;
            this.lblAccountsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "عدد الحسابات";
            // 
            // lblOnYou
            // 
            this.lblOnYou.BackColor = System.Drawing.Color.Salmon;
            this.lblOnYou.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnYou.Location = new System.Drawing.Point(201, 12);
            this.lblOnYou.Name = "lblOnYou";
            this.lblOnYou.Size = new System.Drawing.Size(141, 23);
            this.lblOnYou.TabIndex = 13;
            this.lblOnYou.Text = "0";
            // 
            // lblForYou
            // 
            this.lblForYou.BackColor = System.Drawing.Color.PaleGreen;
            this.lblForYou.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForYou.Location = new System.Drawing.Point(404, 12);
            this.lblForYou.Name = "lblForYou";
            this.lblForYou.Size = new System.Drawing.Size(141, 23);
            this.lblForYou.TabIndex = 12;
            this.lblForYou.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "عليك";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(551, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "لك";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.AutoSize = true;
            this.btnAddAccount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAccount.Location = new System.Drawing.Point(907, 7);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(141, 33);
            this.btnAddAccount.TabIndex = 9;
            this.btnAddAccount.Text = "إضافة حساب";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbClassifications);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 43);
            this.panel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(175, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "التصنيف";
            // 
            // cbClassifications
            // 
            this.cbClassifications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassifications.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClassifications.FormattingEnabled = true;
            this.cbClassifications.Items.AddRange(new object[] {
            "عام",
            "موردين",
            "عملاء"});
            this.cbClassifications.Location = new System.Drawing.Point(6, 8);
            this.cbClassifications.Name = "cbClassifications";
            this.cbClassifications.Size = new System.Drawing.Size(163, 34);
            this.cbClassifications.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearSearch);
            this.panel3.Controls.Add(this.tbSearch);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(592, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 41);
            this.panel3.TabIndex = 0;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearSearch.Location = new System.Drawing.Point(106, 5);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(34, 32);
            this.btnClearSearch.TabIndex = 19;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(106, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(199, 34);
            this.tbSearch.TabIndex = 16;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::DebtsManager.Properties.Resources.icons8_search_24;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(311, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "البحث";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // pnlCompanyInfo
            // 
            this.pnlCompanyInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCompanyInfo.Controls.Add(this.pbCompanyIcon);
            this.pnlCompanyInfo.Controls.Add(this.lblCompanyName);
            this.pnlCompanyInfo.Location = new System.Drawing.Point(615, 99);
            this.pnlCompanyInfo.Name = "pnlCompanyInfo";
            this.pnlCompanyInfo.Size = new System.Drawing.Size(333, 330);
            this.pnlCompanyInfo.TabIndex = 4;
            // 
            // pbCompanyIcon
            // 
            this.pbCompanyIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCompanyIcon.Image = global::DebtsManager.Properties.Resources.debts_manager;
            this.pbCompanyIcon.Location = new System.Drawing.Point(23, 30);
            this.pbCompanyIcon.Name = "pbCompanyIcon";
            this.pbCompanyIcon.Size = new System.Drawing.Size(278, 221);
            this.pbCompanyIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCompanyIcon.TabIndex = 1;
            this.pbCompanyIcon.TabStop = false;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("El Messiri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(42, 265);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(278, 36);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "شعار شركتك يمكنك تغييره";
            // 
            // pnlProgramData
            // 
            this.pnlProgramData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlProgramData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProgramData.Controls.Add(this.btnLogout);
            this.pnlProgramData.Controls.Add(this.pnlCurrentDate);
            this.pnlProgramData.Controls.Add(this.lblUserName);
            this.pnlProgramData.Controls.Add(this.label5);
            this.pnlProgramData.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProgramData.Location = new System.Drawing.Point(0, 0);
            this.pnlProgramData.Name = "pnlProgramData";
            this.pnlProgramData.Size = new System.Drawing.Size(275, 513);
            this.pnlProgramData.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(0, 456);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(271, 53);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "تسجيل الخروج";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // pnlCurrentDate
            // 
            this.pnlCurrentDate.BackColor = System.Drawing.Color.DarkCyan;
            this.pnlCurrentDate.Controls.Add(this.lblCurrentDay);
            this.pnlCurrentDate.Controls.Add(this.lblCurrentDate);
            this.pnlCurrentDate.Font = new System.Drawing.Font("Diwani Simple Outline 2", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pnlCurrentDate.Location = new System.Drawing.Point(12, 123);
            this.pnlCurrentDate.Name = "pnlCurrentDate";
            this.pnlCurrentDate.Size = new System.Drawing.Size(234, 220);
            this.pnlCurrentDate.TabIndex = 2;
            // 
            // lblCurrentDay
            // 
            this.lblCurrentDay.AutoSize = true;
            this.lblCurrentDay.Font = new System.Drawing.Font("Diwani Simple Outline 2", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCurrentDay.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDay.Location = new System.Drawing.Point(44, 9);
            this.lblCurrentDay.Name = "lblCurrentDay";
            this.lblCurrentDay.Size = new System.Drawing.Size(176, 125);
            this.lblCurrentDay.TabIndex = 1;
            this.lblCurrentDay.Text = "الثلاثاء";
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Diwani Simple Outline 2", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDate.Location = new System.Drawing.Point(18, 125);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(195, 84);
            this.lblCurrentDate.TabIndex = 0;
            this.lblCurrentDate.Text = "2026/01/06";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblUserName.Location = new System.Drawing.Point(56, 64);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(143, 31);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "اسم المستخدم";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("El Messiri SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(144, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "اهلا بك يا";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 513);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1280, 560);
            this.Name = "FrmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "مدير الحسابات";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlAccounts.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlAccountFunctions.ResumeLayout(false);
            this.pnlAccountFunctions.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlCompanyInfo.ResumeLayout(false);
            this.pnlCompanyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyIcon)).EndInit();
            this.pnlProgramData.ResumeLayout(false);
            this.pnlProgramData.PerformLayout();
            this.pnlCurrentDate.ResumeLayout(false);
            this.pnlCurrentDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnAccountPage;
        private System.Windows.Forms.Button btnMainPage;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlAccounts;
        private System.Windows.Forms.Panel pnlAccountFunctions;
        private System.Windows.Forms.ImageList imglstAccount;
        private System.Windows.Forms.ListView lvAccounts;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader balance;
        private System.Windows.Forms.Label lblAccountsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOnYou;
        private System.Windows.Forms.Label lblForYou;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem عرضToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiTableView;
        private System.Windows.Forms.ToolStripMenuItem tsmiLargIconView;
        private System.Windows.Forms.ToolStripMenuItem tsmiSmallIconView;
        private System.Windows.Forms.ToolStripMenuItem tsmiTielsView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFilterAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiOutcomeAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiIncomeAccounts;
        private System.Windows.Forms.Button btnAboutPage;
        private System.Windows.Forms.Button btnSettingsPage;
        private System.Windows.Forms.Button btnReportPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.PictureBox pbCompanyIcon;
        private System.Windows.Forms.Panel pnlProgramData;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlCurrentDate;
        private System.Windows.Forms.Label lblCurrentDay;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Panel pnlCompanyInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbClassifications;
    }
}

