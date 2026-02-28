namespace DebtsManager
{
    partial class FrmCurrencyRate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrencyName = new System.Windows.Forms.Label();
            this.lblCurrencySuffix = new System.Windows.Forms.Label();
            this.dgvCurrenciesRates = new System.Windows.Forms.DataGridView();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrenciesRates)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "العملة الأفتراضية";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "الرمز";
            // 
            // lblCurrencyName
            // 
            this.lblCurrencyName.AutoSize = true;
            this.lblCurrencyName.ForeColor = System.Drawing.Color.Maroon;
            this.lblCurrencyName.Location = new System.Drawing.Point(146, 20);
            this.lblCurrencyName.Name = "lblCurrencyName";
            this.lblCurrencyName.Size = new System.Drawing.Size(104, 26);
            this.lblCurrencyName.TabIndex = 1;
            this.lblCurrencyName.Text = "الليرة السورية";
            this.lblCurrencyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrencySuffix
            // 
            this.lblCurrencySuffix.ForeColor = System.Drawing.Color.Maroon;
            this.lblCurrencySuffix.Location = new System.Drawing.Point(67, 46);
            this.lblCurrencySuffix.Name = "lblCurrencySuffix";
            this.lblCurrencySuffix.Size = new System.Drawing.Size(90, 26);
            this.lblCurrencySuffix.TabIndex = 3;
            this.lblCurrencySuffix.Text = "ل.س";
            // 
            // dgvCurrenciesRates
            // 
            this.dgvCurrenciesRates.AllowUserToAddRows = false;
            this.dgvCurrenciesRates.AllowUserToDeleteRows = false;
            this.dgvCurrenciesRates.AllowUserToResizeColumns = false;
            this.dgvCurrenciesRates.AllowUserToResizeRows = false;
            this.dgvCurrenciesRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrenciesRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.currency,
            this.currencyRate});
            this.dgvCurrenciesRates.Location = new System.Drawing.Point(17, 149);
            this.dgvCurrenciesRates.Name = "dgvCurrenciesRates";
            this.dgvCurrenciesRates.RowHeadersWidth = 51;
            this.dgvCurrenciesRates.RowTemplate.Height = 24;
            this.dgvCurrenciesRates.Size = new System.Drawing.Size(607, 439);
            this.dgvCurrenciesRates.TabIndex = 4;
            // 
            // currency
            // 
            this.currency.HeaderText = "العملة";
            this.currency.MinimumWidth = 6;
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            this.currency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.currency.Width = 350;
            // 
            // currencyRate
            // 
            this.currencyRate.HeaderText = "سعر الصرف";
            this.currencyRate.MinimumWidth = 6;
            this.currencyRate.Name = "currencyRate";
            this.currencyRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.currencyRate.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(523, 601);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(271, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "أسعار الصرف";
            // 
            // btnInfo
            // 
            this.btnInfo.Image = global::DebtsManager.Properties.Resources.icons8_info_16;
            this.btnInfo.Location = new System.Drawing.Point(597, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(34, 28);
            this.btnInfo.TabIndex = 7;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // FrmCurrencyRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 646);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvCurrenciesRates);
            this.Controls.Add(this.lblCurrencySuffix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurrencyName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "FrmCurrencyRate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "أسعار الصرف";
            this.Load += new System.EventHandler(this.FrmCurrencyRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrenciesRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrencyName;
        private System.Windows.Forms.Label lblCurrencySuffix;
        private System.Windows.Forms.DataGridView dgvCurrenciesRates;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInfo;
    }
}