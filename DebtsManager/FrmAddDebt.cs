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
        string Notes;
        decimal Amount;
        DateTime DebtDate;
        enDebtType DebtType;
        decimal BalanceChange;
        int PersonId;

        public FrmAddDebt(int personId)
        {
            InitializeComponent();
            this.Notes = string.Empty;
            this.Amount = decimal.Zero;
            this.DebtDate = DateTime.MinValue;
            this.DebtType = enDebtType.INCOME;
            this.BalanceChange = decimal.Zero;
            this.PersonId = personId;
        }

        private void btnAddOutcomeDebt_Click(object sender, EventArgs e)
        {
            _AddDept(enDebtType.OUTCOME);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAddIncomeDebt_Click(object sender, EventArgs e)
        {
            _AddDept(enDebtType.INCOME);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void _AddDept(enDebtType debtType)
        {
            _VerifyInput();
            this.Amount = Convert.ToDecimal(tbAmount.Text);
            this.Notes = tbNotes.Text;
            this.DebtDate = dtpDebtDate.Value;
            this.DebtType = debtType;

            clsDebt debt = new clsDebt();
            debt.Amount = this.Amount;
            debt.Notes = this.Notes;
            debt.DebtType = this.DebtType;
            debt.DebtDate = this.DebtDate;
            debt.PersonID = PersonId;
            debt.Save();
        }

        private void _VerifyInput()
        {
            
        }
    }
}
