using DebtsManagerBusinessLayer;
using DebtsManagerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtsManager
{
    public partial class FrmAccount : Form
    {
        clsPerson CurrentPerson;
        clsAccount PersonAccount;
        clsCurrency CurrentCurrency;

        public FrmAccount(int PersonId)
        {
            InitializeComponent();
            this.CurrentPerson = clsPerson.FindPerson(PersonId);
        }

        #region Events Handlers

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            _LoadCurrenciesComboBox();
            btnAddDebts.Location = new Point(this.Size.Width - 100, 3);
            this.Text = CurrentPerson.FullName;
        }

        private void dgvDebts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                // Skip if row index is invalid
                if (e.RowIndex < 0 || e.RowIndex >= dgvDebts.Rows.Count)
                    return;

                DataGridViewRow row = dgvDebts.Rows[e.RowIndex];

                // Skip the new row
                if (row.IsNewRow)
                    return;

                // Format BalanceChange column
                if (dgvDebts.Columns[e.ColumnIndex].Name == "BalanceChange" && e.Value != null)
                {
                    if (decimal.TryParse(e.Value.ToString(), out decimal value))
                    {
                        // Format with + sign for positive values, - for negative
                        e.Value = value >= 0 ? $"+{value:N2}" : $"{value:N2}";
                        e.FormattingApplied = true;
                    }
                }

                // Get DebtType value
                object debtTypeValue = row.Cells["DebtType"].Value;

                if (debtTypeValue != null)
                {
                    string debtType = debtTypeValue.ToString().ToUpper();

                    if (debtType == "INCOME")
                    {
                        // Apply formatting to the current cell
                        e.CellStyle.BackColor = Color.FromArgb(230, 255, 230);
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionBackColor = Color.FromArgb(180, 230, 180);
                        e.CellStyle.SelectionForeColor = Color.DarkGreen;

                        // Also update the row's default style for consistency
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230);
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                    else if (debtType == "OUTCOME")
                    {
                        // Apply formatting to the current cell
                        e.CellStyle.BackColor = Color.FromArgb(255, 230, 230);
                        e.CellStyle.ForeColor = Color.DarkRed;
                        e.CellStyle.SelectionBackColor = Color.FromArgb(230, 180, 180);
                        e.CellStyle.SelectionForeColor = Color.DarkRed;

                        // Also update the row's default style for consistency
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error if needed
                Debug.WriteLine($"CellFormatting error: {ex.Message}");
            }
        }

        private void dgvDebts_Sorted(object sender, EventArgs e)
        {
            // Force refresh to reapply formatting after sorting
            dgvDebts.Refresh();
        }

        private void dgvDebts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Suppress the error to prevent the default error dialog
            e.ThrowException = false;

            // Optional: Log the error
            Console.WriteLine($"DataError at row {e.RowIndex}, column {e.ColumnIndex}: {e.Exception.Message}");

            // Optional: Show user-friendly message
            // MessageBox.Show("حدث خطأ في عرض البيانات. الرجاء المحاولة مرة أخرى.", "خطأ", 
            //                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddDebts_Click(object sender, EventArgs e)
        {
            FrmAddDebt Frm = new FrmAddDebt(CurrentPerson.Id);

            if (Frm.ShowDialog() == DialogResult.OK)
            {
                _LoadCurrency();
                _LoadAccount();
                _LoadDebts();
            }
        }

        private void FrmAccount_SizeChanged(object sender, EventArgs e)
        {
            btnAddDebts.Location = new Point(this.Size.Width - 100, 3);
        }

        private void cbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadCurrency();
            _LoadAccount();
            _LoadDebts();
            decimal TotalPersonBalance = clsPerson.CalculateTotalBalance(CurrentPerson.Id);
            decimal ConvertedBalance = clsCurrency.ConvertCurrency(TotalPersonBalance, clsCurrency.GetDefaultCurrency().Name, CurrentCurrency.Name);
            _LoadAllAccountsBalanceLabel(ConvertedBalance,CurrentCurrency.Suffix);

            if (PersonAccount != null)
            {
                PersonAccount.SetAsDefaultAccount();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            _LoadCurrenciesInMenuStrip();
            if (dgvDebts.SelectedRows.Count == 0)
            {
                tsmiDelete.Enabled = false;
                tsmiEdit.Enabled = false;
            }
            else
            {
                tsmiDelete.Enabled = true;
                tsmiEdit.Enabled = true;
            }

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if(PersonAccount == null) return;

            string SearchWord = ((TextBox)sender).Text;
            DataTable SearchResults = clsDebt.Search(SearchWord,PersonAccount.AccountId);

            dgvDebts.DataSource = SearchResults;
            _ConfigureDebtsGridView();
            dgvDebts.AutoResizeRows();
        }

        private void btnClearSearch_Click(object sender, EventArgs e) => tbSearch.Clear();

        private void Item_Click(object sender, EventArgs e)
        {
            DataTable dt = clsDebt.GetAllDebts(PersonAccount.AccountId);

            decimal amount, balanceChange;
            string fromCurrency = CurrentCurrency.Name;
            string toCurrency = (sender as ToolStripMenuItem).Text;

            clsCurrency ToCurrency = clsCurrency.FindCurrency(toCurrency);

            foreach (DataRow item in dt.Rows)
            {
                amount = Convert.ToDecimal(item["Amount"]);
                item["Amount"] = clsCurrency.ConvertCurrency(amount, fromCurrency, toCurrency);

                balanceChange = Convert.ToDecimal(item["BalanceChange"]);
                item["BalanceChange"] = clsCurrency.ConvertCurrency(balanceChange, fromCurrency, toCurrency);
            }

            decimal ConvertedAccountBalance = clsCurrency.ConvertCurrency(PersonAccount.Balance, fromCurrency, toCurrency);
            decimal ConvertedAllAccountsBalance = clsCurrency.ConvertCurrency(clsPerson.CalculateTotalBalance(CurrentPerson.Id),
                clsCurrency.GetDefaultCurrency().Name, toCurrency);

            _LoadDebts(dt, ToCurrency.Suffix, ConvertedAccountBalance, ConvertedAllAccountsBalance);
            _LoadAllAccountsBalanceLabel(ConvertedAllAccountsBalance, ToCurrency.Suffix);
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow DebtRow = dgvDebts.SelectedRows[0];
            if (DebtRow == null)
            {
                return;
            }

            int DebtId = Convert.ToInt32(DebtRow.Cells["DebtId"].Value);
            clsDebt debt = clsDebt.FindDebt(DebtId);
            FrmAddDebt frm = new FrmAddDebt(debt);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                clsUtility.NotifyUser("تم التعديل", "تم تعديل السجل بنجاح");
                _LoadDebts();
            }

        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow DebtRow = dgvDebts.SelectedRows[0];

            if (MessageBox.Show("سيتم حذف هذا السجل نهائياً، هل أنت متأكد؟", "تأكيد الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
            , MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading) != DialogResult.OK)
            {
                return;
            }


            if (DebtRow == null)
            {
                return;
            }

            int DebtId = Convert.ToInt32(DebtRow.Cells["DebtId"].Value);

            if (clsDebt.DeleteDebt(DebtId))
            {
                clsUtility.NotifyUser("تم الحذف", "تم حذف السجل بنجاح");
                _LoadDebts();
            }
        }

        private void tsmiFilterIncomeDebts_Click(object sender, EventArgs e)
        {
            if (PersonAccount == null)
            {
                return;
            }

            dgvDebts.DataSource = clsDebt.GetIncomeDebts(PersonAccount.AccountId);
            _ConfigureDebtsGridView();
        }

        private void tsmiFilterOutcomeDebts_Click(object sender, EventArgs e)
        {
            if (PersonAccount == null)
            {
                return;
            }

            dgvDebts.DataSource = clsDebt.GetOutComeDebts(PersonAccount.AccountId);
            _ConfigureDebtsGridView();
        }

        private void tsmiFilterDate_Click(object sender, EventArgs e)
        {
            if (PersonAccount == null)
            {
                return;
            }

            FrmChooseFilterDates frm = new FrmChooseFilterDates();
            DateTime fromDate;
            DateTime toDate;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                fromDate = frm.FromDate;
                toDate = frm.ToDate;
            }
            else
            {
                return;
            }

            dgvDebts.DataSource = clsDebt.FilterByDates(PersonAccount.AccountId, fromDate, toDate);
            _ConfigureDebtsGridView();
        }

        #endregion

        #region Helpers

        private void _LoadCurrenciesComboBox()
        {
            cbCurrencies.Items.Clear();
            DataTable UsedCurrencies = clsCurrency.GetUsedCurrencies();

            foreach (DataRow Currency in UsedCurrencies.Rows)
            {
                cbCurrencies.Items.Add(Currency["CurrencyName"]);
            }
            _SelectDefaultAccountCurrency();
        }

        private void _SelectDefaultAccountCurrency()
        {
            int CurrencyId = clsAccount.GetDefaultAccount(CurrentPerson.Id).CurrencyId;
            clsCurrency Currency = clsCurrency.FindCurrency(CurrencyId);

            int i = 0;
            foreach (var item in cbCurrencies.Items)
            {
                if (Currency.Name.Equals(item))
                {
                    break;
                }
                i++;
            }
            cbCurrencies.SelectedIndex = i;
        }

        private void _LoadBalanceLabel(decimal Balance, string CurrencySuffix)
        {

            decimal AccountBalance = Balance;

            if (AccountBalance < 0)
            {
                lblBalance.Text = (-AccountBalance).ToString(clsSettings.GetNumberFormat()) + " " + CurrencySuffix + " لك";
                lblBalance.BackColor = Color.FromArgb(56, 161, 105);
            }
            else if (AccountBalance > 0)
            {
                lblBalance.Text = AccountBalance.ToString(clsSettings.GetNumberFormat()) + " " + CurrencySuffix + " عليك";
                lblBalance.BackColor = Color.FromArgb(231, 76, 60);
            }
            else
            {
                lblBalance.Text = decimal.Zero.ToString() + " " + CurrencySuffix;
                lblBalance.BackColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void _LoadOutComeDebtsLabel(DataTable AllDebts, string CurrencySuffix)
        {
            try
            {
                decimal OutcomeDebts = Convert.ToDecimal(AllDebts.Compute("SUM(Amount)", "DebtType = 'OUTCOME'"));
                lblForYou.Text = OutcomeDebts.ToString(clsSettings.GetNumberFormat()) + " " + CurrencySuffix;
                lblForYou.Refresh();
            }
            catch
            {
                lblForYou.Text = decimal.Zero + " " + CurrencySuffix;
            }
        }

        private void _LoadIncomeDebtsLabel(DataTable AllDebts, string CurrencySuffix)
        {
            try
            {
                decimal IncomeDebts = Convert.ToDecimal(AllDebts.Compute("SUM(Amount)", "DebtType = 'INCOME'"));
                lblOnYou.Text = IncomeDebts.ToString(clsSettings.GetNumberFormat()) + " " + CurrencySuffix;
                lblOnYou.Refresh();
            }
            catch
            {
                lblOnYou.Text = decimal.Zero + " " + CurrencySuffix;
            }

        }

        private void _LoadDebts(DataTable data, string CurrencySuffix, 
            decimal AccountBalance, decimal allAccountsBalance)
        {

            DataTable debtsData = data;

            if (debtsData.Rows.Count == 0)
            {
                lblNoTransaction.Visible = true;

                lblTransactionsCount.Text = "0";
                lblBalance.Text = "0";
                lblBalance.BackColor = Color.Blue;
                lblAllAccountsBalance.Text = "0";
                lblAllAccountsBalance.BackColor = Color.Blue;
                lblForYou.Text = "0";
                lblOnYou.Text = "0";

                return;
            }
            else
            {
                lblNoTransaction.Visible = false;
            }

            dgvDebts.DataSource = debtsData;

            _ConfigureDebtsGridView();
            lblTransactionsCount.Text = debtsData.Rows.Count.ToString();

            _LoadIncomeDebtsLabel(debtsData, CurrencySuffix);
            _LoadOutComeDebtsLabel(debtsData, CurrencySuffix);
            _LoadBalanceLabel(AccountBalance, CurrencySuffix);
            _LoadAllAccountsBalanceLabel(allAccountsBalance, CurrencySuffix);
            dgvDebts.AutoResizeRows();
            dgvDebts.Refresh();
        }

        private void _LoadAllAccountsBalanceLabel(decimal allAccountsBalance, string currencySuffix)
        {
            if (allAccountsBalance < 0)
            {
                lblAllAccountsBalance.Text = (-allAccountsBalance).ToString(clsSettings.GetNumberFormat()) + " " + currencySuffix + " لك";
                lblAllAccountsBalance.BackColor = Color.FromArgb(56, 161, 105);
            }
            else if (allAccountsBalance > 0)
            {
                lblAllAccountsBalance.Text = allAccountsBalance.ToString(clsSettings.GetNumberFormat()) + " " + currencySuffix + " عليك";
                lblAllAccountsBalance.BackColor = Color.FromArgb(231, 76, 60);
            }
            else
            {
                lblAllAccountsBalance.Text = decimal.Zero.ToString() + " " + currencySuffix;
                lblAllAccountsBalance.BackColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void _LoadDebts()
        {

            if (PersonAccount != null)
            {
                _LoadDebts(clsDebt.GetAllDebts(PersonAccount.AccountId),
                    CurrentCurrency.Suffix, PersonAccount.Balance,
                    clsPerson.CalculateTotalBalance(PersonAccount.PersonId));
            }
            else
            {
                _LoadDebts(new DataTable(), string.Empty, decimal.Zero,decimal.Zero);
            }
        }

        private bool _LoadAccount()
        {
            PersonAccount = clsAccount.FindAccount(CurrentPerson.Id, CurrentCurrency.Id);
            return PersonAccount != null;
        }

        private void _LoadCurrency()
        {
            int CurrencyId = clsCurrency.GetCurrencyId(cbCurrencies.Text);
            CurrentCurrency = clsCurrency.FindCurrency(CurrencyId);
        }

        private void _ConfigureDebtsGridView()
        {
            // Set up DataGridView properties
            dgvDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDebts.AllowUserToAddRows = false;
            dgvDebts.ReadOnly = true;
            dgvDebts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDebts.RowHeadersVisible = false;
            dgvDebts.AllowUserToResizeRows = false;
            dgvDebts.DefaultCellStyle.Font = new Font("El Messiri", 14);
            dgvDebts.EnableHeadersVisualStyles = false;

            // Format columns - wait until data is bound
            if (dgvDebts.Columns.Count > 0)
            {
                // Hide unnecessary columns (keep only needed ones)
                string[] visibleColumns = { "Notes", "Amount", "BalanceChange", "DebtDate", "DebtType" };

                foreach (DataGridViewColumn column in dgvDebts.Columns)
                {
                    if (!visibleColumns.Contains(column.Name))
                    {
                        column.Visible = false;
                    }
                }

                // Set column headers and formatting
                if (dgvDebts.Columns.Contains("Notes"))
                {
                    dgvDebts.Columns["Notes"].HeaderText = "الوصف";
                    dgvDebts.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvDebts.Columns.Contains("Amount"))
                {
                    dgvDebts.Columns["Amount"].HeaderText = "المبلغ";
                    dgvDebts.Columns["Amount"].DefaultCellStyle.Format = clsSettings.GetNumberFormat();
                    dgvDebts.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvDebts.Columns.Contains("BalanceChange"))
                {
                    dgvDebts.Columns["BalanceChange"].HeaderText = "الرصيد";
                    dgvDebts.Columns["BalanceChange"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    // DO NOT set format here - we handle it in CellFormatting
                }

                if (dgvDebts.Columns.Contains("DebtDate"))
                {
                    dgvDebts.Columns["DebtDate"].HeaderText = "التاريخ";
                    dgvDebts.Columns["DebtDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvDebts.Columns["DebtDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvDebts.Columns.Contains("DebtType"))
                {
                    dgvDebts.Columns["DebtType"].HeaderText = "النوع";
                    dgvDebts.Columns["DebtType"].Visible = false;
                }
            }
            dgvDebts.AutoResizeRows();
        }

        private void _LoadCurrenciesInMenuStrip()
        {
            tsmiShowInOtherCurrencies.DropDownItems.Clear();

            DataTable UsedCurrencies = clsCurrency.GetUsedCurrencies();
            ToolStripMenuItem item;
            foreach (DataRow Currency in UsedCurrencies.Rows)
            {
                item = new ToolStripMenuItem(Currency["CurrencyName"].ToString());
                item.Click += Item_Click;
                tsmiShowInOtherCurrencies.DropDownItems.Add(item);
            }
        }


        #endregion

    }
}
