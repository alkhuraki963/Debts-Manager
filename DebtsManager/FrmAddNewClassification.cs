using DebtsManagerBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtsManager
{
    public partial class FrmAddNewClassification : Form
    {
        enMode Mode;
        clsClassification classification;
        public FrmAddNewClassification()
        {
            InitializeComponent();
            Mode = enMode.ADD;
            classification = new clsClassification();
        }
        public FrmAddNewClassification(clsClassification classification)
        {
            InitializeComponent();
            Mode = enMode.UPDATE;
            this.classification = classification;
        }

        private void FrmAddNewClassification_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.ADD)
            {
                tbClassification.Clear();
                this.Text = "إضافة صنف";
            }
            if (Mode == enMode.UPDATE)
            {
                tbClassification.Text = classification.Name;
                this.Text = "تعديل صنف";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbClassification.Text))
            {
                return;
            }
            if (tbClassification.Text.Length > 50)
            {
                errorProvider1.SetError(tbClassification, "اسم الصنف كبير جداً حاول جعله أقصر");
                return;
            }

            classification.Name = tbClassification.Text;
            classification.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tbClassification_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbClassification.Text))
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
    }
}
