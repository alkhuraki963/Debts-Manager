using DebtsManagerBusinessLayer;
using DebtsManagerUtility;
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
    public partial class FrmAddDebt : Form
    {
        enMode Mode;
        clsDebt Debt;
        int PersonId;

        public FrmAddDebt(int PersonId)
        {
            InitializeComponent();
            Debt = new clsDebt();
            this.PersonId = PersonId;
            Mode = enMode.ADD;
        }

        public FrmAddDebt(clsDebt Debt)
        {
            InitializeComponent();
            this.Debt = Debt;
            this.PersonId = clsAccount.FindAccount(Debt.AccountId).PersonId;
            Mode = enMode.UPDATE;
        }

        private void FrmAddDebt_Load(object sender, EventArgs e)
        {
            _LoadCurreciesComboBox();
            btnAddIncomeDebt.Text = clsSettings.GetIncomeText();
            btnAddOutcomeDebt.Text = clsSettings.GetOutcomeText();
            if (Mode == enMode.ADD)
            {
                tbNotes.Clear();
                tbAmount.Clear();
                dtpDebtDate.Value = DateTime.Now;
                cbCurrency.SelectedIndex = 0;
            }
            else if (Mode == enMode.UPDATE)
            {
                clsPerson person = clsPerson.FindPerson(this.PersonId);
                this.Text = "تعديل مبلغ";
                lbltitle.Text = $"{person.FullName} - {_GetDebtType()}";

                tbNotes.Text = this.Debt.Notes;
                tbAmount.Text = this.Debt.Amount.ToString(clsSettings.GetNumberFormat());
                dtpDebtDate.Value = this.Debt.DebtDate;
                cbCurrency.SelectedIndex = _GetCurrencyIndex();
            }
        }

        private string _GetDebtType()
        {
            if (Debt.DebtType == enDebtType.INCOME)
            {
                return clsSettings.GetIncomeText();
            }
            else
            {
                return clsSettings.GetOutcomeText();
            }
        }

        private int _GetCurrencyIndex()
        {
            if (Debt == null)
            {
                return 0;
            }

            string CurrencyName = clsCurrency.FindCurrency(clsAccount.FindAccount(Debt.AccountId).CurrencyId).Name;

            int i = 0;
            foreach (string item in cbCurrency.Items)
            {
                if (item.Equals(CurrencyName))
                {
                    return i;
                }
                i++;
            }

            return 0;
        }

        private void btnAddOutcomeDebt_Click(object sender, EventArgs e)
        {
            if (_SaveDept(enDebtType.OUTCOME))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAddIncomeDebt_Click(object sender, EventArgs e)
        {
            if (_SaveDept(enDebtType.INCOME))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool _SaveDept(enDebtType debtType)
        {
            if (!_IsInputValid())
            {
                return false;
            }

            Debt.Amount = Convert.ToDecimal(tbAmount.Text);
            Debt.Notes = tbNotes.Text;
            Debt.DebtDate = dtpDebtDate.Value;
            Debt.DebtType = debtType;
            Debt.CurrencyId = clsCurrency.GetCurrencyId(cbCurrency.Text);
            clsAccount Account = clsAccount.FindAccount(this.PersonId, Debt.CurrencyId);

            // Creating account if not exists
            if (Account == null)
            {
                Account = new clsAccount
                {
                    PersonId = this.PersonId,
                    CurrencyId = Debt.CurrencyId
                };
                Account.Save();
            }

            Debt.AccountId = Account.AccountId;
            return Debt.Save();
        }

        private void _LoadCurreciesComboBox()
        {
            cbCurrency.Items.Clear();

            foreach (DataRow item in clsCurrency.GetUsedCurrencies().Rows)
            {
                cbCurrency.Items.Add(item["CurrencyName"]);
            }
        }

        private bool _IsInputValid()
        {

            bool IsValid = true;

            errorProvider1.Clear();


            if (string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                errorProvider1.SetError(tbAmount, "لا يمكنك ترك هذا الحقل فارغاً");
                IsValid = false;
            }
            if (!tbAmount.Text.All(Char.IsDigit))
            {
                errorProvider1.SetError(tbAmount, "هذا الحقل يجب ان يحوي أرقاماً فقط");
                IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(tbNotes.Text))
            {
                errorProvider1.SetError(tbNotes, "لا يمكنك ترك هذا الحقل فارغاً");
                IsValid = false;
            }


            return IsValid;
        }

    }
}
