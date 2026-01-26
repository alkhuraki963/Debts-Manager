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
    public partial class FrmDefaultCurrency : Form
    {
        clsCurrency DefaultCurrency;
        public FrmDefaultCurrency()
        {
            InitializeComponent();
            DefaultCurrency = clsCurrency.GetDefaultCurrency();
        }

        private void FrmDefaultCurrency_Load(object sender, EventArgs e)
        {
            _LoadCurreciesComboBox();
            cbCurrency.SelectedIndex = _GetDefaultCurrencyIndex();
        }

        private int _GetDefaultCurrencyIndex()
        {         
            int index = 0;
            foreach (string currencyName in cbCurrency.Items)
            {
                if (currencyName.Equals(DefaultCurrency.Name))
                {
                    break;
                }
                index++;
            }
            return index;
        }

        private void _LoadCurreciesComboBox()
        {
            cbCurrency.Items.Clear();

            foreach (DataRow item in clsCurrency.GetUsedCurrencies().Rows)
            {
                cbCurrency.Items.Add(item["CurrencyName"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!cbCurrency.Text.Equals(DefaultCurrency.Name))
            {
                int SelectedCurrencyId = clsCurrency.GetCurrencyId(cbCurrency.Text);
                clsCurrency NewDefaultCurrency = clsCurrency.FindCurrency(SelectedCurrencyId);
                NewDefaultCurrency.SetDefaultCurrency();
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
