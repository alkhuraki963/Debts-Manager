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
    public partial class FrmAddNewCurrency : Form
    {
        enMode Mode;
        clsCurrency Currency;
        public FrmAddNewCurrency()
        {
            InitializeComponent();
            Currency = new clsCurrency();
            this.Mode = enMode.ADD;
        }
        public FrmAddNewCurrency(clsCurrency currency)
        {
            InitializeComponent();
            this.Currency = currency;
            this.Mode = enMode.UPDATE;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsInputValid())
            {
                return;
            }

            Currency.Name = tbCurrencyName.Text;
            Currency.Country = tbCurrencyCountry.Text;
            Currency.Suffix = tbCurrenySuffix.Text;
            Currency.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool _IsInputValid()
        {
            bool isvalid = true;

            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(tbCurrencyName.Text))
            {
                errorProvider1.SetError(tbCurrencyName, "لا يمكنك ترك هذا الحقل فارغاً");
                isvalid = false;
            }
            if(tbCurrencyName.Text.Length > 30)
            {
                errorProvider1.SetError(tbCurrencyName, "اسم العملة طويل جداً حاول جعله أقصر");
                isvalid = false;
            }

            if (string.IsNullOrWhiteSpace(tbCurrencyCountry.Text))
            {
                errorProvider1.SetError(tbCurrencyCountry, "لا يمكنك ترك هذا الحقل فارغاً");
                isvalid = false;
            }
            if (tbCurrencyCountry.Text.Length > 50)
            {
                errorProvider1.SetError(tbCurrencyCountry, "اسم الدولة طويل جداً حاول جعله أقصر");
                isvalid = false;
            }

            if (string.IsNullOrWhiteSpace(tbCurrenySuffix.Text))
            {
                errorProvider1.SetError(tbCurrenySuffix, "لا يمكنك ترك هذا الحقل فارغاً");
                isvalid = false;
            }
            if (tbCurrenySuffix.Text.Length > 5)
            {
                errorProvider1.SetError(tbCurrenySuffix, "رمز العملة طويل جداً حاول جعله أقصر");
                isvalid = false;
            }

            return isvalid;
        }

        private void FrmAddNewCurrency_Load(object sender, EventArgs e)
        {
            if (this.Mode == enMode.ADD)
            {
                tbCurrencyName.Clear();
                tbCurrencyCountry.Clear();
                tbCurrenySuffix.Clear();
                lblTitle.Text = "عملة جديدة";
                this.Text = "عملة جديدة";
            }
            else 
            {
                tbCurrencyName.Text = Currency.Name;
                tbCurrencyCountry.Text = Currency.Country;
                tbCurrenySuffix.Text = Currency.Suffix;
                lblTitle.Text = "تعديل عملة";
                this.Text = "تعديل عملة";
            }
        }
    }
}
