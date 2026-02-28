using DebtsManagerBusinessLayer;
using DebtsManagerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtsManager
{
    public partial class FrmSettings : Form
    {
        private string StoragePath = Path.Combine(Application.StartupPath, "UserImages");
        private string BackupFolderPath = Path.Combine(Application.StartupPath, "Backups");
        private string CurrentBackupFolder = string.Empty;
        private string CurrentSavedImagePath = string.Empty;
        private bool IsPersonalInfoEdited = false;
        private bool IsPropertiesInfoEdited = false;

        public FrmSettings()
        {
            InitializeComponent();
            if (!Directory.Exists(StoragePath))
            {
                Directory.CreateDirectory(StoragePath);
            }
        }




        private void FrmSettings_Load(object sender, EventArgs e)
        {
            _LoadPersonalInformation();
            _LoadClassifications();
            _LoadCurrencies();
            _LoadUsedCurrencies();
            _LoadPropertiesInfo();
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

            _SavePersonalInfo();


            _SavePropertiesInfo();

        }


        #region Personal Information Tab

        private void tbPersonalInfo_Enter(object sender, EventArgs e)
        {
            IsPersonalInfoEdited = true;
        }

        private void lnklblDefaultIcon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IsPersonalInfoEdited = true;

            pbCompanyLogo.Image = Properties.Resources.debts_manager;

            CurrentSavedImagePath = string.Empty;
        }

        private void lnklblChangeCompanyLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IsPersonalInfoEdited = true;

            if (ofdCompanyIcon.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = ofdCompanyIcon.FileName;

                if (pbCompanyLogo.Image != null)
                {
                    pbCompanyLogo.Image.Dispose();
                    pbCompanyLogo.Image = null;
                }

                if (!string.IsNullOrEmpty(CurrentSavedImagePath) && File.Exists(CurrentSavedImagePath))
                {
                    File.Delete(CurrentSavedImagePath);
                }

                string filename = Path.GetFileName(selectedFile);
                string destinationPath = Path.Combine(StoragePath, filename);

                File.Copy(selectedFile, destinationPath, true);

                using (FileStream fs = new FileStream(destinationPath, FileMode.Open, FileAccess.Read))
                {
                    pbCompanyLogo.Image = System.Drawing.Image.FromStream(fs);
                }
                CurrentSavedImagePath = destinationPath;
            }
        }
        private void _LoadPersonalInformation()
        {
            tbCompanyName.Text = clsSettings.GetCompanyName();
            tbCompanyAddress.Text = clsSettings.GetCompanyAddress();
            tbCompanyPhoneNumber.Text = clsSettings.GetCompanyPhone();

            string companyLogo = clsSettings.GetCompanyLogo();

            if (!string.IsNullOrEmpty(companyLogo))
            {
                using (FileStream fs = new FileStream(companyLogo, FileMode.Open, FileAccess.Read))
                {
                    pbCompanyLogo.Image = System.Drawing.Image.FromStream(fs);
                }
                CurrentSavedImagePath = companyLogo;
            }
            else
            {
                pbCompanyLogo.Image = Properties.Resources.debts_manager;
            }

        }

        private void _SavePersonalInfo()
        {
            if (!IsPersonalInfoEdited)
            {
                return;
            }


            if (!string.IsNullOrWhiteSpace(tbCompanyName.Text))
            {
                clsSettings.UpdateCompanyName(tbCompanyName.Text);
            }
            if (!string.IsNullOrWhiteSpace(tbCompanyAddress.Text))
            {
                clsSettings.UpdateCompanyAddress(tbCompanyAddress.Text);
            }
            if (!string.IsNullOrWhiteSpace(tbCompanyPhoneNumber.Text))
            {
                clsSettings.UpdateCompanyPhone(tbCompanyPhoneNumber.Text);
            }

            clsSettings.UpdateCompanyLogo(CurrentSavedImagePath);

        }

        #endregion

        #region Classification Tab

        private void btnAddClassification_Click(object sender, EventArgs e)
        {
            FrmAddNewClassification frm = new FrmAddNewClassification();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _LoadClassifications();
                clsUtility.NotifyUser("تم الإضافة", "تم إضافة صنف جديد بنجاح");
            }
        }

        private void btnEditClassification_Click(object sender, EventArgs e)
        {
            if (lvClassifications.SelectedItems.Count == 0)
            {
                return;
            }
            int classificationId = Convert.ToInt32(lvClassifications.SelectedItems[0].Tag);
            clsClassification SelectedClassification = clsClassification.FindClassification(classificationId);

            FrmAddNewClassification frm = new FrmAddNewClassification(SelectedClassification);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _LoadClassifications();
                clsUtility.NotifyUser("تم التعديل", "تم تعديل الصنف بنجاح");
            }

        }

        private void btnDeleteClassification_Click(object sender, EventArgs e)
        {
            if (lvClassifications.SelectedItems.Count == 0)
            {
                return;
            }

            int classificationId = Convert.ToInt32(lvClassifications.SelectedItems[0].Tag);
            if (clsUtility.ConfimeDeletionMessage("الصنف") == DialogResult.OK)
            {
                if (!clsClassification.DeleteClassification(classificationId))
                {
                    clsUtility.ErrorMessage("خطأ", "لا يمكنك حذف هذا الصنف بسبب وجود حسابات ضمنه، يمكنك نقل الحسابات الى صنف اخر ومن ثم اعادة المحاولة.");
                    return;
                }

                _LoadClassifications();
                clsUtility.NotifyUser("تم الحذف", "تم حذف الصنف بنجاح");
            }
        }

        private void lvClassifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvClassifications.SelectedItems.Count > 0)
            {
                btnEditClassification.Enabled = true;
                btnDeleteClassification.Enabled = true;
            }
            else
            {
                btnEditClassification.Enabled = false;
                btnDeleteClassification.Enabled = false;
            }
        }

        private void _LoadClassifications()
        {
            lvClassifications.Items.Clear();
            DataTable Classicications = clsClassification.GetAllClassifications();
            ListViewItem item;
            foreach (DataRow classification in Classicications.Rows)
            {
                item = new ListViewItem();

                item.Text = classification["ClassificationName"].ToString();
                item.ImageIndex = 1;
                item.Tag = Convert.ToInt32(classification["ClassificationId"]);

                lvClassifications.Items.Add(item);
            }
        }


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
                clsUtility.NotifyUser("تم الإضافة", "تم إضافة عملة جديدة بنجاح");
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
                clsUtility.NotifyUser("تم التعديل", "تم تعديل العملة بنجاح");
            }
        }

        private void btnDeleteCurrency_Click(object sender, EventArgs e)
        {
            if (lvCurrencies.SelectedItems.Count == 0)
            {
                return;
            }

            int currencyId = Convert.ToInt32(lvCurrencies.SelectedItems[0].Tag);
            if (clsUtility.ConfimeDeletionMessage("العملة") == DialogResult.OK)
            {
                if (!clsCurrency.DeleteCurrency(currencyId))
                {
                    clsUtility.ErrorMessage("خطأ", "هذه العملة مستخدمة، يمكنك إيقاف التعامل بهذه العملة ومن ثم إعادة المحاولة");
                    return;
                }
                _LoadCurrencies();
                clsUtility.NotifyUser("تم الحذف", "تم حذف العملة بنجاح");
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
                string ErrorMessage = "\"لا يمكن إيقاف التعامل بهاذه العملة، ربما لأنها العملة الأفتراضية للتطبيق او أنها مستخدمة في الحسابات،" +
                    " احذف الحسابات الخاصة بهذه العملة اذا كنت لا تريد التعامل بها وتأكد من أنها ليست العملة الأفتراضية للتطبيق، ومن ثم أعد المحاولة\"";
                clsUtility.ErrorMessage("خطأ", ErrorMessage);
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
                item = new ListViewItem
                {
                    Text = currency["CurrencyName"].ToString(),
                    ImageIndex = 0,
                    Tag = Convert.ToInt32(currency["CurrencyId"])
                };
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
                item = new ListViewItem
                {
                    Text = currency["CurrencyName"].ToString(),
                    ImageIndex = 0,
                    Tag = Convert.ToInt32(currency["CurrencyId"])
                };
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

        #region Properties Tab

        private void _LoadPropertiesInfo()
        {
            tbBackUpFolder.Text = clsSettings.GetBackupFolder();
            cbIncomeText.Text = clsSettings.GetIncomeText();
            cbOutcomeText.Text = clsSettings.GetOutcomeText();
            string NumberFormat = clsSettings.GetNumberFormat();
            nudNumberFormat.Value = Convert.ToInt32(NumberFormat.Substring(1));

        }

        private void _SavePropertiesInfo()
        {
            if (!IsPropertiesInfoEdited)
            {
                return;
            }

            if (!string.IsNullOrEmpty(CurrentBackupFolder))
            {
                clsSettings.UpdateBackupFolder(CurrentBackupFolder);
            }
            if (!string.IsNullOrEmpty(cbIncomeText.Text))
            {
                clsSettings.UpdateIncomeText(cbIncomeText.Text);
            }
            if (!string.IsNullOrEmpty(cbOutcomeText.Text))
            {
                clsSettings.UpdateOutcomeText(cbOutcomeText.Text);
            }
            clsSettings.UpdateNumberFormat($"N{nudNumberFormat.Value}");
        }

        private void nudNumberFormat_ValueChanged(object sender, EventArgs e)
        {
            IsPropertiesInfoEdited = true;

            string zeros = string.Empty;
            for (int i = 0; i < nudNumberFormat.Value; i++)
            {
                zeros += "0";
            }
            lblNumberFormat.Text = "0." + zeros;
        }

        private void btnBackUpFolder_Click(object sender, EventArgs e)
        {
            IsPropertiesInfoEdited = true;

            if (fbdBackupFolderDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentBackupFolder = fbdBackupFolderDialog.SelectedPath;
                tbBackUpFolder.Text = CurrentBackupFolder;
            }

        }

        private void cbIncomeText_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsPropertiesInfoEdited = true;
        }

        private void cbOutcomeText_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsPropertiesInfoEdited = true;
        }


        private void btnSaveNewBackup_Click(object sender, EventArgs e)
        {
            // حفظ الإعدادات الحالية (موجود مسبقاً)
            _SavePropertiesInfo();


            try
            {

                bool result = clsSettings.SaveNewBackup();

                if (result)
                {
                    // إظهار نافذة التقدم (كما في الكود الأصلي) ثم الإشعار
                    FrmProgressDialog frm = new FrmProgressDialog();
                    frm.Text = "حفظ نسخة احتياطية";

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        clsUtility.NotifyUser("النسخ الاحتياطي", "تم حفظ نسخة احتياطية بنجاح");
                    }
                }
                else
                {
                    clsUtility.ErrorMessage("فشل النسخ الاحتياطي", "حدث خطأ أثناء عملية النسخ الاحتياطي. يرجى المحاولة مرة أخرى.");
                }
            }
            catch (Exception ex)
            {
                // عرض رسالة الخطأ (مثل عدم وجود نسخة كاملة سابقة أو نموذج استعادة غير مناسب)
                clsUtility.ErrorMessage("خطأ", ex.Message);
            }
        }

        private void btnRestorDatabase_Click(object sender, EventArgs e)
        {
            if (ofdBackupFile.ShowDialog() == DialogResult.OK)
            {
                string backupPath = ofdBackupFile.FileName;
                if (clsUtility.ConfirmeRestoreBackup() == DialogResult.OK)
                {
                    if (clsSettings.RestoreDatabase(backupPath))
                    {
                        FrmProgressDialog frm = new FrmProgressDialog();
                        frm.Text = "استعادة نسخة احتياطية";

                        frm.ShowDialog();

                        clsUtility.NotifyUser("النسخ الأحتياطي", "تم استعادة نسخة احتياطية بنجاح");

                    }
                }
            }
        }

        #endregion


    }
}
