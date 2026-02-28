namespace DebtsManager
{
    partial class FrmAddNewCurrency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddNewCurrency));
            this.imglstButtons = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbCurrenySuffix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCurrencyCountry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCurrencyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DebtsManager.Properties.Resources.icons8_currency_32;
            this.pictureBox1.Location = new System.Drawing.Point(484, 101);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(521, 266);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 35);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbCurrenySuffix
            // 
            this.tbCurrenySuffix.Location = new System.Drawing.Point(155, 201);
            this.tbCurrenySuffix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCurrenySuffix.Name = "tbCurrenySuffix";
            this.tbCurrenySuffix.Size = new System.Drawing.Size(299, 34);
            this.tbCurrenySuffix.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 26);
            this.label4.TabIndex = 29;
            this.label4.Text = "الرمز";
            // 
            // tbCurrencyCountry
            // 
            this.tbCurrencyCountry.Location = new System.Drawing.Point(155, 151);
            this.tbCurrencyCountry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCurrencyCountry.Name = "tbCurrencyCountry";
            this.tbCurrencyCountry.Size = new System.Drawing.Size(299, 34);
            this.tbCurrencyCountry.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 26);
            this.label3.TabIndex = 30;
            this.label3.Text = "الدولة";
            // 
            // tbCurrencyName
            // 
            this.tbCurrencyName.Location = new System.Drawing.Point(155, 101);
            this.tbCurrencyName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCurrencyName.Name = "tbCurrencyName";
            this.tbCurrencyName.Size = new System.Drawing.Size(299, 34);
            this.tbCurrencyName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 26);
            this.label1.TabIndex = 31;
            this.label1.Text = "اسم العملة";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("El Messiri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(31, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 63);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "عملة جديدة";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAddNewCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 318);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbCurrenySuffix);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCurrencyCountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tbCurrencyName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("El Messiri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddNewCurrency";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عملة جديدة";
            this.Load += new System.EventHandler(this.FrmAddNewCurrency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imglstButtons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbCurrenySuffix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCurrencyCountry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCurrencyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}