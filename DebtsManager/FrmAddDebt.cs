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
                tbAmount.Text = this.Debt.Amount.ToString(clsSettings.NumberFormat);
                dtpDebtDate.Value = this.Debt.DebtDate;
                cbCurrency.SelectedIndex = _GetCurrencyIndex();
            }
        }

        private string _GetDebtType()
        {
            if(Debt.DebtType == enDebtType.INCOME)
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
            _SaveDept(enDebtType.OUTCOME);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddIncomeDebt_Click(object sender, EventArgs e)
        {
            _SaveDept(enDebtType.INCOME);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void _SaveDept(enDebtType debtType)
        {
            _VerifyInput();
            Debt.Amount = Convert.ToDecimal(tbAmount.Text);
            Debt.Notes = tbNotes.Text;
            Debt.DebtDate = dtpDebtDate.Value;
            Debt.DebtType = debtType;
            Debt.CurrencyId = clsCurrency.GetCurrencyId(cbCurrency.Text);
            clsAccount Account = clsAccount.FindAccount(this.PersonId, Debt.CurrencyId);

            // Creating account if not exists
            if (Account == null)
            {
                Account = new clsAccount();
                Account.PersonId = this.PersonId;
                Account.CurrencyId = Debt.CurrencyId;
                Account.Save();
            }

            Debt.AccountId = Account.AccountId;
            Debt.Save();          
        }

        private void _LoadCurreciesComboBox()
        {
            cbCurrency.Items.Clear();

            foreach (DataRow item in clsCurrency.GetUsedCurrencies().Rows)
            {
                cbCurrency.Items.Add(item["CurrencyName"]);
            }
        }

        private void _VerifyInput()
        {
            
        }


    }
}
