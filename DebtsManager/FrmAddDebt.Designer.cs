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
            this.components = new System.ComponentModel.Container();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDebtDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.btnAddOutcomeDebt = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddIncomeDebt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(125, 131);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(365, 90);
            this.tbNotes.TabIndex = 13;
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("El Messiri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Location = new System.Drawing.Point(75, 9);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(197, 63);
            this.lbltitle.TabIndex = 11;
            this.lbltitle.Text = "مبلغ جديد";
            // 
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.Location = new System.Drawing.Point(125, 86);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(365, 39);
            this.tbAmount.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 31);
            this.label4.TabIndex = 19;
            this.label4.Text = "التاريخ";
            // 
            // dtpDebtDate
            // 
            this.dtpDebtDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDebtDate.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDebtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDebtDate.Location = new System.Drawing.Point(125, 227);
            this.dtpDebtDate.Name = "dtpDebtDate";
            this.dtpDebtDate.RightToLeftLayout = true;
            this.dtpDebtDate.Size = new System.Drawing.Size(365, 39);
            this.dtpDebtDate.TabIndex = 20;
            this.dtpDebtDate.Value = new System.DateTime(2026, 1, 7, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 276);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 31);
            this.label5.TabIndex = 23;
            this.label5.Text = "العملة";
            // 
            // cbCurrency
            // 
            this.cbCurrency.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Items.AddRange(new object[] {
            "ليرة سورية",
            "دولار امريكي",
            "جنيه مصري",
            "ريال سعودي"});
            this.cbCurrency.Location = new System.Drawing.Point(125, 272);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(365, 39);
            this.cbCurrency.TabIndex = 24;
            // 
            // btnAddOutcomeDebt
            // 
            this.btnAddOutcomeDebt.BackColor = System.Drawing.Color.Tomato;
            this.btnAddOutcomeDebt.Font = new System.Drawing.Font("El Messiri Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOutcomeDebt.Image = global::DebtsManager.Properties.Resources.icons8_expense_24;
            this.btnAddOutcomeDebt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOutcomeDebt.Location = new System.Drawing.Point(589, 271);
            this.btnAddOutcomeDebt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddOutcomeDebt.Name = "btnAddOutcomeDebt";
            this.btnAddOutcomeDebt.Size = new System.Drawing.Size(85, 41);
            this.btnAddOutcomeDebt.TabIndex = 22;
            this.btnAddOutcomeDebt.Text = "عليه";
            this.btnAddOutcomeDebt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddOutcomeDebt.UseVisualStyleBackColor = false;
            this.btnAddOutcomeDebt.Click += new System.EventHandler(this.btnAddOutcomeDebt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DebtsManager.Properties.Resources.pricesMenu;
            this.pictureBox1.Location = new System.Drawing.Point(511, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddIncomeDebt
            // 
            this.btnAddIncomeDebt.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddIncomeDebt.Font = new System.Drawing.Font("El Messiri Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIncomeDebt.Image = global::DebtsManager.Properties.Resources.icons8_income_24;
            this.btnAddIncomeDebt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddIncomeDebt.Location = new System.Drawing.Point(501, 271);
            this.btnAddIncomeDebt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddIncomeDebt.Name = "btnAddIncomeDebt";
            this.btnAddIncomeDebt.Size = new System.Drawing.Size(85, 41);
            this.btnAddIncomeDebt.TabIndex = 16;
            this.btnAddIncomeDebt.Text = "له";
            this.btnAddIncomeDebt.UseVisualStyleBackColor = false;
            this.btnAddIncomeDebt.Click += new System.EventHandler(this.btnAddIncomeDebt_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DebtsManager.Properties.Resources.icons8_bill_24;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 31);
            this.label3.TabIndex = 12;
            this.label3.Text = "التفاصيل";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("El Messiri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DebtsManager.Properties.Resources.icons8_cash_24;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(24, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "المبلغ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAddDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 333);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddOutcomeDebt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtpDebtDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddIncomeDebt);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmAddDebt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة مبلغ";
            this.Load += new System.EventHandler(this.FrmAddDebt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddIncomeDebt;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDebtDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddOutcomeDebt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}