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
            this.dgvDebts = new System.Windows.Forms.DataGridView();
            this.pnlFunctions = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).BeginInit();
            this.pnlFunctions.SuspendLayout();
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
            this.dgvDebts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDebts.Location = new System.Drawing.Point(0, 0);
            this.dgvDebts.Name = "dgvDebts";
            this.dgvDebts.ReadOnly = true;
            this.dgvDebts.RowHeadersWidth = 51;
            this.dgvDebts.RowTemplate.Height = 24;
            this.dgvDebts.Size = new System.Drawing.Size(1291, 559);
            this.dgvDebts.TabIndex = 0;
            this.dgvDebts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDebts_CellFormatting);
            this.dgvDebts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDebts_DataError);
            this.dgvDebts.Sorted += new System.EventHandler(this.dgvDebts_Sorted);
            // 
            // pnlFunctions
            // 
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
            this.pnlFunctions.Location = new System.Drawing.Point(0, 520);
            this.pnlFunctions.Name = "pnlFunctions";
            this.pnlFunctions.Size = new System.Drawing.Size(1291, 39);
            this.pnlFunctions.TabIndex = 1;
            // 
            // lblBalance
            // 
            this.lblBalance.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBalance.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(193, 8);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(253, 23);
            this.lblBalance.TabIndex = 8;
            this.lblBalance.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(452, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "الرصيد";
            // 
            // lblTransactionsCount
            // 
            this.lblTransactionsCount.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTransactionsCount.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionsCount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTransactionsCount.Location = new System.Drawing.Point(17, 8);
            this.lblTransactionsCount.Name = "lblTransactionsCount";
            this.lblTransactionsCount.Size = new System.Drawing.Size(61, 23);
            this.lblTransactionsCount.TabIndex = 6;
            this.lblTransactionsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "عدد العمليات";
            // 
            // lblOnYou
            // 
            this.lblOnYou.BackColor = System.Drawing.Color.Salmon;
            this.lblOnYou.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnYou.Location = new System.Drawing.Point(513, 7);
            this.lblOnYou.Name = "lblOnYou";
            this.lblOnYou.Size = new System.Drawing.Size(156, 23);
            this.lblOnYou.TabIndex = 4;
            this.lblOnYou.Text = "0";
            // 
            // lblForYou
            // 
            this.lblForYou.BackColor = System.Drawing.Color.PaleGreen;
            this.lblForYou.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForYou.Location = new System.Drawing.Point(729, 8);
            this.lblForYou.Name = "lblForYou";
            this.lblForYou.Size = new System.Drawing.Size(168, 23);
            this.lblForYou.TabIndex = 3;
            this.lblForYou.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(675, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "عليك";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(903, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "لك";
            // 
            // btnAddDebts
            // 
            this.btnAddDebts.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDebts.Location = new System.Drawing.Point(1178, 3);
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
            this.lblNoTransaction.Location = new System.Drawing.Point(0, 0);
            this.lblNoTransaction.Name = "lblNoTransaction";
            this.lblNoTransaction.Size = new System.Drawing.Size(1291, 520);
            this.lblNoTransaction.TabIndex = 2;
            this.lblNoTransaction.Text = "لا يوجد اي عمليات على هذا الحساب";
            this.lblNoTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoTransaction.Visible = false;
            // 
            // FrmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 559);
            this.Controls.Add(this.lblNoTransaction);
            this.Controls.Add(this.pnlFunctions);
            this.Controls.Add(this.dgvDebts);
            this.Name = "FrmAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAccount";
            this.Load += new System.EventHandler(this.FrmAccount_Load);
            this.SizeChanged += new System.EventHandler(this.FrmAccount_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).EndInit();
            this.pnlFunctions.ResumeLayout(false);
            this.pnlFunctions.PerformLayout();
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
    }
}