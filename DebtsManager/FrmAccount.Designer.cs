namespace DebtsManager
{
    partial class FrmAccount
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
            this.dgvDebts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFilterIncomeDebts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFilterOutcomeDebts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFilterDate = new System.Windows.Forms.ToolStripMenuItem();
            this.خياراتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowInOtherCurrencies = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFunctions = new System.Windows.Forms.Panel();
            this.lblAllAccountsBalance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTransactionsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOnYou = new System.Windows.Forms.Label();
            this.lblForYou = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddDebts = new System.Windows.Forms.Button();
            this.lblNoTransaction = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCurrencies = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlFunctions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDebts
            // 
            this.dgvDebts.AllowUserToAddRows = false;
            this.dgvDebts.AllowUserToDeleteRows = false;
            this.dgvDebts.AllowUserToOrderColumns = true;
            this.dgvDebts.AllowUserToResizeColumns = false;
            this.dgvDebts.AllowUserToResizeRows = false;
            this.dgvDebts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDebts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDebts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDebts.Location = new System.Drawing.Point(0, 46);
            this.dgvDebts.Name = "dgvDebts";
            this.dgvDebts.ReadOnly = true;
            this.dgvDebts.RowHeadersWidth = 51;
            this.dgvDebts.RowTemplate.Height = 24;
            this.dgvDebts.Size = new System.Drawing.Size(1291, 513);
            this.dgvDebts.TabIndex = 0;
            this.dgvDebts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDebts_CellFormatting);
            this.dgvDebts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDebts_DataError);
            this.dgvDebts.Sorted += new System.EventHandler(this.dgvDebts_Sorted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("El Messiri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiDelete,
            this.toolStripMenuItem1,
            this.tsmiFilter,
            this.خياراتToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 122);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = global::DebtsManager.Properties.Resources.Edit;
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(123, 28);
            this.tsmiEdit.Text = "تعديل";
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::DebtsManager.Properties.Resources.bin;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(123, 28);
            this.tsmiDelete.Text = "حذف";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // tsmiFilter
            // 
            this.tsmiFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFilterIncomeDebts,
            this.tsmiFilterOutcomeDebts,
            this.tsmiFilterDate});
            this.tsmiFilter.Name = "tsmiFilter";
            this.tsmiFilter.Size = new System.Drawing.Size(123, 28);
            this.tsmiFilter.Text = "تصفية";
            // 
            // tsmiFilterIncomeDebts
            // 
            this.tsmiFilterIncomeDebts.Image = global::DebtsManager.Properties.Resources.icons8_income_24;
            this.tsmiFilterIncomeDebts.Name = "tsmiFilterIncomeDebts";
            this.tsmiFilterIncomeDebts.Size = new System.Drawing.Size(169, 28);
            this.tsmiFilterIncomeDebts.Text = "له";
            this.tsmiFilterIncomeDebts.Click += new System.EventHandler(this.tsmiFilterIncomeDebts_Click);
            // 
            // tsmiFilterOutcomeDebts
            // 
            this.tsmiFilterOutcomeDebts.Image = global::DebtsManager.Properties.Resources.icons8_expense_24;
            this.tsmiFilterOutcomeDebts.Name = "tsmiFilterOutcomeDebts";
            this.tsmiFilterOutcomeDebts.Size = new System.Drawing.Size(169, 28);
            this.tsmiFilterOutcomeDebts.Text = "عليه";
            this.tsmiFilterOutcomeDebts.Click += new System.EventHandler(this.tsmiFilterOutcomeDebts_Click);
            // 
            // tsmiFilterDate
            // 
            this.tsmiFilterDate.Name = "tsmiFilterDate";
            this.tsmiFilterDate.Size = new System.Drawing.Size(169, 28);
            this.tsmiFilterDate.Text = "حسب التاريخ";
            this.tsmiFilterDate.Click += new System.EventHandler(this.tsmiFilterDate_Click);
            // 
            // خياراتToolStripMenuItem
            // 
            this.خياراتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowInOtherCurrencies});
            this.خياراتToolStripMenuItem.Name = "خياراتToolStripMenuItem";
            this.خياراتToolStripMenuItem.Size = new System.Drawing.Size(123, 28);
            this.خياراتToolStripMenuItem.Text = "خيارات";
            // 
            // tsmiShowInOtherCurrencies
            // 
            this.tsmiShowInOtherCurrencies.Image = global::DebtsManager.Properties.Resources.icons8_currency_32;
            this.tsmiShowInOtherCurrencies.Name = "tsmiShowInOtherCurrencies";
            this.tsmiShowInOtherCurrencies.Size = new System.Drawing.Size(199, 28);
            this.tsmiShowInOtherCurrencies.Text = "عرض بعملة اخرى";
            // 
            // pnlFunctions
            // 
            this.pnlFunctions.BackColor = System.Drawing.Color.White;
            this.pnlFunctions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFunctions.Controls.Add(this.lblAllAccountsBalance);
            this.pnlFunctions.Controls.Add(this.label8);
            this.pnlFunctions.Controls.Add(this.lblBalance);
            this.pnlFunctions.Controls.Add(this.label5);
            this.pnlFunctions.Controls.Add(this.lblTransactionsCount);
            this.pnlFunctions.Controls.Add(this.label3);
            this.pnlFunctions.Controls.Add(this.lblOnYou);
            this.pnlFunctions.Controls.Add(this.lblForYou);
            this.pnlFunctions.Controls.Add(this.label2);
            this.pnlFunctions.Controls.Add(this.label1);
            this.pnlFunctions.Controls.Add(this.btnAddDebts);
            this.pnlFunctions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFunctions.Font = new System.Drawing.Font("El Messiri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFunctions.Location = new System.Drawing.Point(0, 484);
            this.pnlFunctions.Name = "pnlFunctions";
            this.pnlFunctions.Size = new System.Drawing.Size(1291, 75);
            this.pnlFunctions.TabIndex = 1;
            // 
            // lblAllAccountsBalance
            // 
            this.lblAllAccountsBalance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAllAccountsBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllAccountsBalance.ForeColor = System.Drawing.Color.White;
            this.lblAllAccountsBalance.Location = new System.Drawing.Point(17, 41);
            this.lblAllAccountsBalance.Name = "lblAllAccountsBalance";
            this.lblAllAccountsBalance.Size = new System.Drawing.Size(346, 29);
            this.lblAllAccountsBalance.TabIndex = 10;
            this.lblAllAccountsBalance.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(369, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 26);
            this.label8.TabIndex = 9;
            this.label8.Text = "الرصيد الكلي";
            // 
            // lblBalance
            // 
            this.lblBalance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(17, 8);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(346, 30);
            this.lblBalance.TabIndex = 8;
            this.lblBalance.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(369, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "رصيد الحساب";
            // 
            // lblTransactionsCount
            // 
            this.lblTransactionsCount.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTransactionsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionsCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTransactionsCount.Location = new System.Drawing.Point(776, 10);
            this.lblTransactionsCount.Name = "lblTransactionsCount";
            this.lblTransactionsCount.Size = new System.Drawing.Size(121, 26);
            this.lblTransactionsCount.TabIndex = 6;
            this.lblTransactionsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(903, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "عدد العمليات";
            // 
            // lblOnYou
            // 
            this.lblOnYou.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOnYou.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnYou.ForeColor = System.Drawing.Color.White;
            this.lblOnYou.Location = new System.Drawing.Point(486, 10);
            this.lblOnYou.Name = "lblOnYou";
            this.lblOnYou.Size = new System.Drawing.Size(230, 28);
            this.lblOnYou.TabIndex = 4;
            this.lblOnYou.Text = "0";
            // 
            // lblForYou
            // 
            this.lblForYou.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(161)))), ((int)(((byte)(105)))));
            this.lblForYou.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForYou.ForeColor = System.Drawing.Color.White;
            this.lblForYou.Location = new System.Drawing.Point(486, 42);
            this.lblForYou.Name = "lblForYou";
            this.lblForYou.Size = new System.Drawing.Size(230, 30);
            this.lblForYou.TabIndex = 3;
            this.lblForYou.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(722, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "عليك";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(722, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "لك";
            // 
            // btnAddDebts
            // 
            this.btnAddDebts.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDebts.Location = new System.Drawing.Point(1178, 39);
            this.btnAddDebts.Name = "btnAddDebts";
            this.btnAddDebts.Size = new System.Drawing.Size(101, 33);
            this.btnAddDebts.TabIndex = 0;
            this.btnAddDebts.Text = "إضافة مبلغ";
            this.btnAddDebts.UseVisualStyleBackColor = true;
            this.btnAddDebts.Click += new System.EventHandler(this.btnAddDebts_Click);
            // 
            // lblNoTransaction
            // 
            this.lblNoTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoTransaction.Font = new System.Drawing.Font("El Messiri Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTransaction.Location = new System.Drawing.Point(0, 46);
            this.lblNoTransaction.Name = "lblNoTransaction";
            this.lblNoTransaction.Size = new System.Drawing.Size(1291, 438);
            this.lblNoTransaction.TabIndex = 2;
            this.lblNoTransaction.Text = "لا يوجد اي عمليات على هذا الحساب بهذه العملة";
            this.lblNoTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoTransaction.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbCurrencies);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("El Messiri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1291, 46);
            this.panel1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(172, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 26);
            this.label6.TabIndex = 15;
            this.label6.Text = "العملة";
            // 
            // cbCurrencies
            // 
            this.cbCurrencies.BackColor = System.Drawing.Color.White;
            this.cbCurrencies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrencies.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrencies.FormattingEnabled = true;
            this.cbCurrencies.Items.AddRange(new object[] {
            "عام",
            "موردين",
            "عملاء"});
            this.cbCurrencies.Location = new System.Drawing.Point(3, 5);
            this.cbCurrencies.Name = "cbCurrencies";
            this.cbCurrencies.Size = new System.Drawing.Size(163, 34);
            this.cbCurrencies.TabIndex = 14;
            this.cbCurrencies.SelectedIndexChanged += new System.EventHandler(this.cbCurrencies_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearSearch);
            this.panel3.Controls.Add(this.tbSearch);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(847, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(442, 44);
            this.panel3.TabIndex = 13;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearSearch.Location = new System.Drawing.Point(158, 7);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(34, 32);
            this.btnClearSearch.TabIndex = 19;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(158, 6);
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
            this.label4.Location = new System.Drawing.Point(363, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 26);
            this.label4.TabIndex = 18;
            this.label4.Text = "البحث";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 559);
            this.Controls.Add(this.lblNoTransaction);
            this.Controls.Add(this.pnlFunctions);
            this.Controls.Add(this.dgvDebts);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccount";
            this.Load += new System.EventHandler(this.FrmAccount_Load);
            this.SizeChanged += new System.EventHandler(this.FrmAccount_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlFunctions.ResumeLayout(false);
            this.pnlFunctions.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDebts;
        private System.Windows.Forms.Panel pnlFunctions;
        private System.Windows.Forms.Button btnAddDebts;
        private System.Windows.Forms.Label lblForYou;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTransactionsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOnYou;
        private System.Windows.Forms.Label lblNoTransaction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCurrencies;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiFilterIncomeDebts;
        private System.Windows.Forms.ToolStripMenuItem tsmiFilterOutcomeDebts;
        private System.Windows.Forms.ToolStripMenuItem tsmiFilterDate;
        private System.Windows.Forms.ToolStripMenuItem خياراتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowInOtherCurrencies;
        private System.Windows.Forms.Label lblAllAccountsBalance;
        private System.Windows.Forms.Label label8;
    }
}