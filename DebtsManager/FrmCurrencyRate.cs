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
    public partial class FrmCurrencyRate : Form
    {
        public FrmCurrencyRate()
        {
            InitializeComponent();
        }

        private void FrmCurrencyRate_Load(object sender, EventArgs e)
        {
            _LoadDefaultCurrency();
            _LoadCurrencies();
        }

        private void _LoadDefaultCurrency()
        {
            clsCurrency DefaultCurrency = clsCurrency.GetDefaultCurrency();
            lblCurrencyName.Text = DefaultCurrency.Name;
            lblCurrencySuffix.Text = DefaultCurrency.Suffix;
        }

        private void _EditingNote()
        {
            MessageBox.Show("يمكنك تعديل اسعار الصرف من العملات المستخدمة إلى العملة الأفتراضية. \n مثال: دولار امريكي = 10 ليرة سورية", "ملاحظة",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }

        private void _LoadCurrencies()
        {
            DataTable UsedCurrencies = clsCurrency.GetUsedCurrencies();

            _EditFormUI(UsedCurrencies.Rows.Count);

            dgvCurrenciesRates.DataSource = UsedCurrencies;
            string[] VisableColumns = { "CurrencyName", "ToDefaultRate" };

            foreach (DataGridViewColumn column in dgvCurrenciesRates.Columns)
            {
                if (!VisableColumns.Contains(column.Name))
                {
                    column.Visible = false;
                }
            }

            if (dgvCurrenciesRates.Columns.Contains("CurrencyName"))
            {
                dgvCurrenciesRates.Columns["CurrencyName"].HeaderText = "العملة";
                dgvCurrenciesRates.Columns["CurrencyName"].Width = 350;
            }

            if (dgvCurrenciesRates.Columns.Contains("ToDefaultRate"))
            {
                dgvCurrenciesRates.Columns["ToDefaultRate"].HeaderText = "العملة";
                dgvCurrenciesRates.Columns["ToDefaultRate"].Width = 200;
                dgvCurrenciesRates.Columns["ToDefaultRate"].DefaultCellStyle.Format = "N2";
            }
            dgvCurrenciesRates.Refresh();
        }

        private void _EditFormUI(int count)
        {
            if(count < 5)
            {
                dgvCurrenciesRates.Size = new Size(dgvCurrenciesRates.Size.Width, dgvCurrenciesRates.Size.Height / 2);
                this.Size = new Size(this.Size.Width,450);
                btnSave.Location = new Point(btnSave.Location.X, 370);
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            _EditingNote();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCurrenciesRates.Rows)
            {
                string currencyName = row.Cells["CurrencyName"].Value.ToString();
                decimal newRate = Convert.ToDecimal(row.Cells["ToDefaultRate"].Value);
                clsCurrency CurrentCurrency = clsCurrency.FindCurrency(clsCurrency.GetCurrencyId(currencyName));

                if(CurrentCurrency.ToDefaultRate == newRate)
                {
                    continue;
                }

                CurrentCurrency.ToDefaultRate = newRate;
                CurrentCurrency.Save();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
