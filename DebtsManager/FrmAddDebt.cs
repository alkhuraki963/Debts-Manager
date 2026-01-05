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

        private void btnAddDebt_Click(object sender, EventArgs e)
        {
            this.Amount = Convert.ToDecimal(tbAmount.Text);
            this.Notes = tbNotes.Text;
            this.DebtDate = dtpDebtDate.Value;

            clsDebt debt = new clsDebt();
            debt.Amount = this.Amount;
            debt.Notes = this.Notes;
            debt.DebtType = this.DebtType;
            debt.DebtDate = this.DebtDate;
            debt.PersonID = PersonId;
            debt.Save();
            this.Close();
        }

        private void rbIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIncome.Checked)
            {
                this.DebtType = enDebtType.INCOME;
            }
            else
            {
                this.DebtType = enDebtType.OUTCOME;
            }
        }
    }
}
