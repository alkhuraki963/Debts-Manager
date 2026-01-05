namespace DebtsManager
{
    partial class FrmAddDebt
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
            this.btnAddDebt = new System.Windows.Forms.Button();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDebtType = new System.Windows.Forms.GroupBox();
            this.rbOutcome = new System.Windows.Forms.RadioButton();
            this.rbIncome = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDebtDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbDebtType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddDebt
            // 
            this.btnAddDebt.BackColor = System.Drawing.Color.Moccasin;
            this.btnAddDebt.Location = new System.Drawing.Point(369, 439);
            this.btnAddDebt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddDebt.Name = "btnAddDebt";
            this.btnAddDebt.Size = new System.Drawing.Size(153, 41);
            this.btnAddDebt.TabIndex = 16;
            this.btnAddDebt.Text = "إضافة";
            this.btnAddDebt.UseVisualStyleBackColor = false;
            this.btnAddDebt.Click += new System.EventHandler(this.btnAddDebt_Click);
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(149, 194);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(365, 90);
            this.tbNotes.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "التفاصيل:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "مبلغ جديد";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(149, 140);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(365, 32);
            this.tbAmount.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "المبلغ:";
            // 
            // gbDebtType
            // 
            this.gbDebtType.Controls.Add(this.rbOutcome);
            this.gbDebtType.Controls.Add(this.rbIncome);
            this.gbDebtType.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDebtType.Location = new System.Drawing.Point(149, 360);
            this.gbDebtType.Name = "gbDebtType";
            this.gbDebtType.Size = new System.Drawing.Size(365, 60);
            this.gbDebtType.TabIndex = 18;
            this.gbDebtType.TabStop = false;
            // 
            // rbOutcome
            // 
            this.rbOutcome.AutoSize = true;
            this.rbOutcome.Location = new System.Drawing.Point(88, 27);
            this.rbOutcome.Name = "rbOutcome";
            this.rbOutcome.Size = new System.Drawing.Size(67, 25);
            this.rbOutcome.TabIndex = 1;
            this.rbOutcome.Text = "عليك";
            this.rbOutcome.UseVisualStyleBackColor = true;
            // 
            // rbIncome
            // 
            this.rbIncome.AutoSize = true;
            this.rbIncome.Checked = true;
            this.rbIncome.Location = new System.Drawing.Point(243, 27);
            this.rbIncome.Name = "rbIncome";
            this.rbIncome.Size = new System.Drawing.Size(50, 25);
            this.rbIncome.TabIndex = 0;
            this.rbIncome.TabStop = true;
            this.rbIncome.Text = "لك";
            this.rbIncome.UseVisualStyleBackColor = true;
            this.rbIncome.CheckedChanged += new System.EventHandler(this.rbIncome_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "التاريخ:";
            // 
            // dtpDebtDate
            // 
            this.dtpDebtDate.Location = new System.Drawing.Point(149, 306);
            this.dtpDebtDate.Name = "dtpDebtDate";
            this.dtpDebtDate.Size = new System.Drawing.Size(365, 32);
            this.dtpDebtDate.TabIndex = 20;
            this.dtpDebtDate.Value = new System.DateTime(2026, 1, 3, 0, 0, 0, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DebtsManager.Properties.Resources.pricesMenu;
            this.pictureBox1.Location = new System.Drawing.Point(109, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAddDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 492);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtpDebtDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbDebtType);
            this.Controls.Add(this.btnAddDebt);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAddDebt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة مبلغ";
            this.gbDebtType.ResumeLayout(false);
            this.gbDebtType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddDebt;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDebtType;
        private System.Windows.Forms.RadioButton rbOutcome;
        private System.Windows.Forms.RadioButton rbIncome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDebtDate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}