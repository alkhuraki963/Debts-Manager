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
            this.btnAboutPage = new System.Windows.Forms.Button();
            this.btnSettingsPage = new System.Windows.Forms.Button();
            this.btnReportPage = new System.Windows.Forms.Button();
            this.btnAccountPage = new System.Windows.Forms.Button();
            this.btnMainPage = new System.Windows.Forms.Button();
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
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAccountsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOnYou = new System.Windows.Forms.Label();
            this.lblForYou = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.pnlNavigation.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlAccounts.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlAccountFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.btnAboutPage);
            this.pnlNavigation.Controls.Add(this.btnSettingsPage);
            this.pnlNavigation.Controls.Add(this.btnReportPage);
            this.pnlNavigation.Controls.Add(this.btnAccountPage);
            this.pnlNavigation.Controls.Add(this.btnMainPage);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 0);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(1093, 41);
            this.pnlNavigation.TabIndex = 0;
            // 
            // btnAboutPage
            // 
            this.btnAboutPage.Image = global::DebtsManager.Properties.Resources.icons8_accounts_24;
            this.btnAboutPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAboutPage.Location = new System.Drawing.Point(512, 3);
            this.btnAboutPage.Name = "btnAboutPage";
            this.btnAboutPage.Size = new System.Drawing.Size(109, 32);
            this.btnAboutPage.TabIndex = 6;
            this.btnAboutPage.Text = "حول";
            this.btnAboutPage.UseVisualStyleBackColor = true;
            // 
            // btnSettingsPage
            // 
            this.btnSettingsPage.Image = global::DebtsManager.Properties.Resources.icons8_accounts_24;
            this.btnSettingsPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettingsPage.Location = new System.Drawing.Point(627, 3);
            this.btnSettingsPage.Name = "btnSettingsPage";
            this.btnSettingsPage.Size = new System.Drawing.Size(109, 32);
            this.btnSettingsPage.TabIndex = 5;
            this.btnSettingsPage.Text = "إعدادات";
            this.btnSettingsPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettingsPage.UseVisualStyleBackColor = true;
            // 
            // btnReportPage
            // 
            this.btnReportPage.Image = global::DebtsManager.Properties.Resources.icons8_accounts_24;
            this.btnReportPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportPage.Location = new System.Drawing.Point(742, 3);
            this.btnReportPage.Name = "btnReportPage";
            this.btnReportPage.Size = new System.Drawing.Size(109, 32);
            this.btnReportPage.TabIndex = 4;
            this.btnReportPage.Text = "تقارير";
            this.btnReportPage.UseVisualStyleBackColor = true;
            // 
            // btnAccountPage
            // 
            this.btnAccountPage.Image = global::DebtsManager.Properties.Resources.icons8_accounts_24;
            this.btnAccountPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountPage.Location = new System.Drawing.Point(857, 3);
            this.btnAccountPage.Name = "btnAccountPage";
            this.btnAccountPage.Size = new System.Drawing.Size(109, 32);
            this.btnAccountPage.TabIndex = 2;
            this.btnAccountPage.Text = "الحسابات";
            this.btnAccountPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccountPage.UseVisualStyleBackColor = true;
            this.btnAccountPage.Click += new System.EventHandler(this.btnAccountPage_Click);
            // 
            // btnMainPage
            // 
            this.btnMainPage.Image = global::DebtsManager.Properties.Resources.icons8_home_24;
            this.btnMainPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainPage.Location = new System.Drawing.Point(972, 3);
            this.btnMainPage.Name = "btnMainPage";
            this.btnMainPage.Size = new System.Drawing.Size(109, 32);
            this.btnMainPage.TabIndex = 3;
            this.btnMainPage.Text = "الرئيسة";
            this.btnMainPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainPage.UseVisualStyleBackColor = true;
            this.btnMainPage.Click += new System.EventHandler(this.btnMainPage_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlAccounts);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 41);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1093, 472);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlAccounts
            // 
            this.pnlAccounts.Controls.Add(this.lvAccounts);
            this.pnlAccounts.Controls.Add(this.pnlAccountFunctions);
            this.pnlAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccounts.Location = new System.Drawing.Point(0, 0);
            this.pnlAccounts.Name = "pnlAccounts";
            this.pnlAccounts.Size = new System.Drawing.Size(1093, 472);
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
            this.lvAccounts.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAccounts.HideSelection = false;
            this.lvAccounts.LargeImageList = this.imglstAccount;
            this.lvAccounts.Location = new System.Drawing.Point(0, 0);
            this.lvAccounts.Name = "lvAccounts";
            this.lvAccounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvAccounts.RightToLeftLayout = true;
            this.lvAccounts.Size = new System.Drawing.Size(1093, 429);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 148);
            // 
            // عرضToolStripMenuItem
            // 
            this.عرضToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTableView,
            this.tsmiLargIconView,
            this.tsmiSmallIconView,
            this.tsmiTielsView});
            this.عرضToolStripMenuItem.Name = "عرضToolStripMenuItem";
            this.عرضToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = global::DebtsManager.Properties.Resources.Edit;
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(214, 26);
            this.tsmiEdit.Text = "تعديل";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::DebtsManager.Properties.Resources.bin;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(214, 26);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // tsmiFilterAccounts
            // 
            this.tsmiFilterAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOutcomeAccounts,
            this.tsmiIncomeAccounts});
            this.tsmiFilterAccounts.Name = "tsmiFilterAccounts";
            this.tsmiFilterAccounts.Size = new System.Drawing.Size(214, 26);
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
            // 
            // pnlAccountFunctions
            // 
            this.pnlAccountFunctions.Controls.Add(this.label4);
            this.pnlAccountFunctions.Controls.Add(this.textBox1);
            this.pnlAccountFunctions.Controls.Add(this.lblAccountsCount);
            this.pnlAccountFunctions.Controls.Add(this.label3);
            this.pnlAccountFunctions.Controls.Add(this.lblOnYou);
            this.pnlAccountFunctions.Controls.Add(this.lblForYou);
            this.pnlAccountFunctions.Controls.Add(this.label2);
            this.pnlAccountFunctions.Controls.Add(this.label1);
            this.pnlAccountFunctions.Controls.Add(this.btnAddAccount);
            this.pnlAccountFunctions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccountFunctions.Location = new System.Drawing.Point(0, 429);
            this.pnlAccountFunctions.Name = "pnlAccountFunctions";
            this.pnlAccountFunctions.Size = new System.Drawing.Size(1093, 43);
            this.pnlAccountFunctions.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(802, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "البحث";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(592, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 28);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblAccountsCount
            // 
            this.lblAccountsCount.BackColor = System.Drawing.Color.Gray;
            this.lblAccountsCount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "عدد الحسابات:";
            // 
            // lblOnYou
            // 
            this.lblOnYou.BackColor = System.Drawing.Color.Salmon;
            this.lblOnYou.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnYou.Location = new System.Drawing.Point(201, 12);
            this.lblOnYou.Name = "lblOnYou";
            this.lblOnYou.Size = new System.Drawing.Size(141, 23);
            this.lblOnYou.TabIndex = 13;
            this.lblOnYou.Text = "0";
            // 
            // lblForYou
            // 
            this.lblForYou.BackColor = System.Drawing.Color.PaleGreen;
            this.lblForYou.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForYou.Location = new System.Drawing.Point(404, 12);
            this.lblForYou.Name = "lblForYou";
            this.lblForYou.Size = new System.Drawing.Size(141, 23);
            this.lblForYou.TabIndex = 12;
            this.lblForYou.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "عليك:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(551, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "لك:";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAccount.Location = new System.Drawing.Point(956, 7);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(125, 33);
            this.btnAddAccount.TabIndex = 9;
            this.btnAddAccount.Text = "إضافة حساب";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 513);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlNavigation);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(999, 560);
            this.Name = "FrmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "مدير الحسابات";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlAccounts.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlAccountFunctions.ResumeLayout(false);
            this.pnlAccountFunctions.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox1;
    }
}

