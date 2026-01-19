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
            this.CurrentPerson = clsPerson.FindAccount(PersonId);
            this.PersonAccount = new clsAccount();
            this.CurrentCurrency = new clsCurrency();
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            _LoadCurrenciesComboBox();
            _LoadDebts();
            btnAddDebts.Location = new Point(this.Size.Width - 100, 3);
            this.Text = CurrentPerson.FullName;
        }

        private void _LoadCurrenciesComboBox()
        {
            cbCurrencies.Items.Clear();

            foreach (DataRow Currency in clsCurrency.GetAllCurrencies().Rows)
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

        private void _LoadBalance()
        {
            
            decimal AccountBalance = PersonAccount.Balance;

            if (AccountBalance < 0)
            {
                lblBalance.Text = (-AccountBalance).ToString(clsSettings.NumberFormat) + " " + CurrentCurrency.Suffix + " لك";
                lblBalance.BackColor = Color.Green;
            }
            else if (AccountBalance > 0) 
            {
                lblBalance.Text = AccountBalance.ToString(clsSettings.NumberFormat) + " " + CurrentCurrency.Suffix + " عليك";
                lblBalance.BackColor = Color.Red;
            }
            else
            {
                lblBalance.Text =  decimal.Zero.ToString() + " " + CurrentCurrency.Suffix;
                lblBalance.BackColor = Color.Blue;
            }
        }

        private void _LoadOutComeDebtsLabel(DataTable AllDebts)
        {
            try
            {
                decimal OutcomeDebts = Convert.ToDecimal(AllDebts.Compute("SUM(Amount)", "DebtType = 'OUTCOME'"));
                lblForYou.Text = OutcomeDebts.ToString(clsSettings.NumberFormat) + CurrentCurrency.Suffix;
                lblForYou.Refresh();
            }
            catch
            {
                lblForYou.Text = decimal.Zero + CurrentCurrency.Suffix;
            }
        }

        private void _LoadIncomeDebtsLabel(DataTable AllDebts)
        {
            try
            {
                decimal IncomeDebts = Convert.ToDecimal(AllDebts.Compute("SUM(Amount)", "DebtType = 'INCOME'"));
                lblOnYou.Text = IncomeDebts.ToString(clsSettings.NumberFormat) + " " + clsSettings.CurrencySuffix;
                lblOnYou.Refresh();
            }
            catch
            {
                lblOnYou.Text = "0 " + clsSettings.CurrencySuffix;
            }

        }

        private void _LoadDebts()
        {

            //dgvDebts.CellFormatting -= dgvDebts_CellFormatting;
            //dgvDebts.Sorted -= dgvDebts_Sorted;
            //dgvDebts.DataError -= dgvDebts_DataError;

            _LoadCurrency();
            _LoadAccount();

            DataTable debtsData = clsDebt.GetAllDebts(PersonAccount.AccountId);

            _LoadIncomeDebtsLabel(debtsData);
            _LoadOutComeDebtsLabel(debtsData);
            _LoadBalance();


            if(debtsData.Rows.Count == 0) 
            {
                lblNoTransaction.Visible = true;
                return;
            }
            else
            {
                lblNoTransaction.Visible = false;
            }

            dgvDebts.DataSource = debtsData;

            _ConfigureDebtsGridView();
            lblTransactionsCount.Text = clsDebt.GetAllDebts(CurrentPerson.Id).Rows.Count.ToString(clsSettings.NumberFormat);

            //dgvDebts.CellFormatting += dgvDebts_CellFormatting;
            //dgvDebts.Sorted += dgvDebts_Sorted;
            //dgvDebts.DataError += dgvDebts_DataError;

            dgvDebts.Refresh();
        }

        private void _LoadAccount()
        {
            PersonAccount = clsAccount.FindAccount(CurrentPerson.Id, CurrentCurrency.Id);
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
                    dgvDebts.Columns["Amount"].DefaultCellStyle.Format = "N2";
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

            if(Frm.ShowDialog() == DialogResult.OK)
            {
                _LoadDebts();
            }
        }

        private void FrmAccount_SizeChanged(object sender, EventArgs e)
        {
            btnAddDebts.Location = new Point(this.Size.Width-100, 3);
        }

        private void cbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadDebts();
            PersonAccount.SetAsDefaultAccount();
        }

        private void lblNoTransaction_Click(object sender, EventArgs e)
        {
            
        }
    }
}
