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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }




        private void FrmSettings_Load(object sender, EventArgs e)
        {
            _LoadCurrencies();
            _LoadUsedCurrencies();
        }

        #region Personal Information Tab

        #endregion

        #region Classification Tab

        #endregion

        #region Currencies Tab



        private void btnDefaultCurrency_Click(object sender, EventArgs e)
        {
            FrmDefaultCurrency frm = new FrmDefaultCurrency();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FrmCurrencyRate frmRate = new FrmCurrencyRate();
                frmRate.ShowDialog();
            }
        }

        private void btnAddNewCurrency_Click(object sender, EventArgs e)
        {
            FrmAddNewCurrency frm = new FrmAddNewCurrency();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _LoadCurrencies();
                clsUtility.NotifyUser(3000, "تم الإضافة", "تم إضافة عملة جديدة بنجاح");
            }
        }

        private void btnEditCurrency_Click(object sender, EventArgs e)
        {
            if (lvCurrencies.SelectedItems.Count == 0)
            {
                return;
            }

            int currencyId = Convert.ToInt32(lvCurrencies.SelectedItems[0].Tag);
            clsCurrency SelectedCurrency = clsCurrency.FindCurrency(currencyId);

            FrmAddNewCurrency frm = new FrmAddNewCurrency(SelectedCurrency);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _LoadCurrencies();
                clsUtility.NotifyUser(3000, "تم التعديل", "تم تعديل العملة بنجاح");
            }
        }



        private void btnDeleteCurrency_Click(object sender, EventArgs e)
        {
            if (lvCurrencies.SelectedItems.Count == 0)
            {
                return;
            }

            int currencyId = Convert.ToInt32(lvCurrencies.SelectedItems[0].Tag);
            if(clsUtility.ConfimeDeletionMessage("العملة") == DialogResult.OK)
            {
                clsCurrency.DeleteCurrency(currencyId);
                _LoadCurrencies();
                clsUtility.NotifyUser(3000, "تم الحذف", "تم حذف العملة بنجاح");
            }
        }

        private void btnUseCurrency_Click(object sender, EventArgs e)
        {
            if (lvCurrencies.SelectedItems.Count == 0)
            {
                return;
            }

            int currencyId = Convert.ToInt32(lvCurrencies.SelectedItems[0].Tag);
            clsCurrency SelectedCurrency = clsCurrency.FindCurrency(currencyId);
            SelectedCurrency.UseCurrency();
            _LoadUsedCurrencies();
        }

        private void btnUnUseCurrency_Click(object sender, EventArgs e)
        {
            if (lvUsedCurrencies.SelectedItems.Count == 0)
            {
                return;
            }
            int currencyId = Convert.ToInt32(lvUsedCurrencies.SelectedItems[0].Tag);
            clsCurrency SelectedCurrency = clsCurrency.FindCurrency(currencyId);
            if (!SelectedCurrency.UnUseCurrency())
            {
                clsUtility.ErrorMessage("خطأ", "لا يمكن ايقاف التعامل بهاذه العملة، ربما لأنها العملة الأفتراضية للتطبيق او انها مستخدمة في الحسابات، احذف الحسابات الخاصة بهاذه العملة اذا كنت لا تريدها وتأكد من انها ليست العملة الأفتراضية للتطبيق، ومن ثم اعد المحاولة");
                return;
            }
            _LoadUsedCurrencies();
        }

        private void btnCurrencyRate_Click(object sender, EventArgs e)
        {
            FrmCurrencyRate frm = new FrmCurrencyRate();
            frm.ShowDialog();
        }

        private void lvCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCurrencies.SelectedItems.Count > 0)
            {
                btnEditCurrency.Enabled = true;
                btnDeleteCurrency.Enabled = true;
                btnUseCurrency.Enabled = true;
            }
            else
            {
                btnEditCurrency.Enabled = false;
                btnDeleteCurrency.Enabled = false;
                btnUseCurrency.Enabled = false;
            }
        }

        private void lvUsedCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsedCurrencies.SelectedItems.Count > 0)
            {

                btnUnUseCurrency.Enabled = true;
            }
            else
            {

                btnUnUseCurrency.Enabled = false;
            }
        }

        private void _LoadCurrencies()
        {
            lvCurrencies.Items.Clear();
            DataTable UsedCurrencies = clsCurrency.GetAllCurrencies();
            ListViewItem item;
            foreach (DataRow currency in UsedCurrencies.Rows)
            {
                item = new ListViewItem();
                item.Text = currency["CurrencyName"].ToString();
                item.ImageIndex = 0;
                item.Tag = Convert.ToInt32(currency["CurrencyId"]);
                item.SubItems.Add(currency["CurrencyCountry"].ToString());
                item.SubItems.Add(currency["CurrencySuffix"].ToString());
                lvCurrencies.Items.Add(item);
            }
        }

        private void _LoadUsedCurrencies()
        {
            lvUsedCurrencies.Items.Clear();
            DataTable UsedCurrencies = clsCurrency.GetUsedCurrencies();
            ListViewItem item;
            foreach (DataRow currency in UsedCurrencies.Rows)
            {
                item = new ListViewItem();
                item.Text = currency["CurrencyName"].ToString();
                item.ImageIndex = 0;
                item.Tag = Convert.ToInt32(currency["CurrencyId"]);
                item.SubItems.Add(currency["CurrencyCountry"].ToString());
                item.SubItems.Add(currency["CurrencySuffix"].ToString());
                lvUsedCurrencies.Items.Add(item);
            }
        }

        #endregion

        #region Security Tab

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLock.Checked)
            {
                tbPassword.Enabled = true;
                tbUsername.Enabled = true;
            }
            else
            {
                tbPassword.Enabled = false;
                tbUsername.Enabled = false;
            }
        }








        #endregion


    }
}
