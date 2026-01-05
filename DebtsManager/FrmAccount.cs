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

        public FrmAccount(int PersonId)
        {
            InitializeComponent();
            this.CurrentPerson = clsPerson.FindAccount(PersonId);
        }


        private void FrmAccount_Load(object sender, EventArgs e)
        {
            _LoadDebts();
            btnAddDebts.Location = new Point(this.Size.Width - 100, 3);
            this.Text = CurrentPerson.FullName;
        }

        private void _LoadBalance()
        {
            lblBalance.Text = CurrentPerson.Balance.ToString(clsSettings.NumberFormat) + " " +clsSettings.CurrencySuffix;
        }

        private void _LoadDebtsForYou()
        {
            try
            {
                DataTable dt = clsDebt.GetAllIncomeDebts(CurrentPerson.Id);
                decimal IncomeDebts = Convert.ToDecimal(dt.Compute("SUM(Amount)", string.Empty));
                lblForYou.Text = IncomeDebts.ToString(clsSettings.NumberFormat) + " " + clsSettings.CurrencySuffix;
                lblForYou.Refresh();
            }
            catch (Exception ex)
            {
                lblForYou.Text = "0 " + clsSettings.CurrencySuffix;
            }
        }

        private void _LoadDebtsOnYou()
        {
            try
            {
                DataTable dt = clsDebt.GetAllOutcomeDebts(CurrentPerson.Id);
                decimal OutcomeDebts = Convert.ToDecimal(dt.Compute("SUM(Amount)", string.Empty));
                lblOnYou.Text = OutcomeDebts.ToString(clsSettings.NumberFormat) + " " + clsSettings.CurrencySuffix;
                lblOnYou.Refresh();
            }
            catch (Exception ex)
            {
                lblOnYou.Text = "0 " + clsSettings.CurrencySuffix;
            }

        }

        private void _LoadDebts()
        {

            dgvDebts.CellFormatting -= dgvDebts_CellFormatting;
            dgvDebts.Sorted -= dgvDebts_Sorted;
            dgvDebts.DataError -= dgvDebts_DataError;


            DataTable debtsData = clsDebt.GetAllDebts(CurrentPerson.Id);
            if(debtsData.Rows.Count == 0) 
            {
                lblNoTransaction.Visible = true;
            }
            else
            {
                lblNoTransaction.Visible = false;
            }

            dgvDebts.DataSource = debtsData;

            _ConfigureDebtsGridView();
            lblTransactionsCount.Text = clsDebt.GetAllDebts(CurrentPerson.Id).Rows.Count.ToString(clsSettings.NumberFormat);

            dgvDebts.CellFormatting += dgvDebts_CellFormatting;
            dgvDebts.Sorted += dgvDebts_Sorted;
            dgvDebts.DataError += dgvDebts_DataError;



            _LoadDebtsOnYou();
            _LoadDebtsForYou();
            _LoadBalance();

            dgvDebts.Refresh();
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
            dgvDebts.DefaultCellStyle.Font = new Font("Tahoma", 12);
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
            Frm.ShowDialog();
            _LoadDebts();
        }

        private void FrmAccount_SizeChanged(object sender, EventArgs e)
        {
            btnAddDebts.Location = new Point(this.Size.Width-100, 3);
        }
    }
}
