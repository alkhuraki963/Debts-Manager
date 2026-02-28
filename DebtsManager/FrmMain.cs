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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DebtsManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            btnAddAccount.Location = new Point(this.Size.Width - 150, 3);

            _LoadCompanyInfo();
            _LoadDate();
            _LoadDashboard();
        }

        private void _LoadDate()
        {
            lblWeekDay.Text = clsUtility.TranslateDay(DateTime.Now.DayOfWeek.ToString());
            lblYear.Text = DateTime.Now.Year.ToString();
            lblMonthDay.Text = DateTime.Now.Day.ToString();
            lblMonth.Text = DateTime.Now.Month.ToString();
        }

        private void _LoadCompanyInfo()
        {
            // Loading Logo
            string companyLogo = clsSettings.GetCompanyLogo();

            if (!string.IsNullOrEmpty(companyLogo))
            {
                using (FileStream fs = new FileStream(companyLogo, FileMode.Open, FileAccess.Read))
                {
                    pbCompanyIcon.Image = System.Drawing.Image.FromStream(fs);
                }
            }
            else
            {
                pbCompanyIcon.Image = Properties.Resources.debts_manager;
            }

            // Loading Company Name
            string companyName = clsSettings.GetCompanyName();

            if (!string.IsNullOrEmpty(companyName))
            {
                lblCompanyName.Text = companyName;
            }
            else
            {
                lblCompanyName.Text = "شعار شركتك يمكنك تغييره";
            }
        }

        private void btnAccountPage_Click(object sender, EventArgs e)
        {
            pnlProgramData.Visible = false;
            pnlSummery.Visible = false;
            pnlLastOperations.Visible = false;
            pnlAccounts.Visible = true;
            _LoadClassificationsComboBox();
            _LoadPersons();
        }

        private void _LoadClassificationsComboBox()
        {
            cbClassifications.Items.Clear();
            DataTable dtClassification = clsClassification.GetAllClassifications();
            string classification = "الكل";
            cbClassifications.Items.Add(classification);
            foreach (DataRow item in dtClassification.Rows)
            {
                classification = (string)item["ClassificationName"];
                cbClassifications.Items.Add(classification);
            }
            cbClassifications.SelectedIndex = 0;
        }

        private void _ConfigureLvAccountsUI()
        {
            // Clear existing items
            lvAccounts.Items.Clear();

            // Setup ListView for better appearance
            lvAccounts.View = _GetLvAccountsType();
            lvAccounts.FullRowSelect = true;
            lvAccounts.GridLines = true;
            lvAccounts.HideSelection = false;
            lvAccounts.MultiSelect = false; // Change to true if needed
            lvAccounts.BackColor = Color.White;
            lvAccounts.ForeColor = Color.FromArgb(64, 64, 64);

            // Clear and add columns with better styling
            lvAccounts.Columns.Clear();
            lvAccounts.Columns.Add("الأسم", 250, HorizontalAlignment.Left);
            lvAccounts.Columns.Add("الرصيد", 300, HorizontalAlignment.Right);

            // Optional: Add column header styling
            lvAccounts.OwnerDraw = false; // Set to true for custom header drawing
            lvAccounts.HeaderStyle = ColumnHeaderStyle.Nonclickable; // Or Clickable for sorting

            // Use BeginUpdate for better performance
            lvAccounts.BeginUpdate();
        }

        private void _LoadPersons(DataTable persons)
        {

            _ConfigureLvAccountsUI();
            DataTable dtPersons = persons;

            try
            {
                foreach (DataRow row in dtPersons.Rows)
                {
                    string fullName = row["fullname"].ToString();
                    decimal balance = clsPerson.CalculateTotalBalance(Convert.ToInt32(row["PersonId"]));
                    // Create item
                    ListViewItem item = new ListViewItem(fullName);

                    // Format balance nicely
                    string formattedBalance = balance.ToString(clsSettings.GetNumberFormat()) + clsCurrency.GetDefaultCurrency().Suffix;
                    item.SubItems.Add(formattedBalance);

                    // Store ID in Tag
                    item.Tag = row["PersonId"];
                    item.ImageIndex = 0;

                    // Better color scheme based on balance
                    if (balance < 0)
                    {
                        item.BackColor = Color.FromArgb(230, 255, 230); // Very light green
                        item.ForeColor = Color.DarkGreen;
                        item.Font = new Font(lvAccounts.Font, FontStyle.Regular);
                    }
                    else if (balance > 0)
                    {
                        item.BackColor = Color.FromArgb(255, 230, 230); // Very light red
                        item.ForeColor = Color.DarkRed;
                        item.Font = new Font(lvAccounts.Font, FontStyle.Regular);
                    }
                    else // Zero balance
                    {
                        item.BackColor = Color.FromArgb(240, 240, 240); // Light gray
                        item.ForeColor = Color.Gray;
                        item.Font = new Font(lvAccounts.Font, FontStyle.Italic);
                    }

                    // Add tooltip for more info
                    item.ToolTipText = $"Name: {fullName}\nBalance: {formattedBalance}\nID: {row["PersonId"]}";

                    lvAccounts.Items.Add(item);

                }
            }
            finally
            {
                lvAccounts.EndUpdate();
            }

            // Optional: Auto-resize columns to fit content
            lvAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _LoadDebtOnYou(dtPersons);
            _LoadDebtsForYou(dtPersons);
            _LoadAccountsCount(dtPersons);
        }

        private void _LoadPersons()
        {
            if (cbClassifications.SelectedIndex != 0)
            {
                string classificationName = cbClassifications.Text;
                int clssificationId = clsClassification.GetClassificationId(classificationName);
                _LoadPersons(clsPerson.GetAllPersons(clssificationId));
            }
            else
            {
                _LoadPersons(clsPerson.GetAllPersons());
            }
        }

        private View _GetLvAccountsType()
        {
            string value = clsSettings.GetLvAccountsViewType().ToUpper();
            switch (value)
            {
                case "LARGE ICON": return View.LargeIcon;
                case "SMALL ICON": return View.SmallIcon;
                case "DETAILS": return View.Details;
                case "TILE": return View.Tile;
                default: return View.Tile;
            }
        }

        private void _LoadAccountsCount(DataTable dtPersons)
        {
            lblAccountsCount.Text = dtPersons.Rows.Count.ToString("N0");
        }

        private void _LoadDebtsForYou(DataTable dtPersons)
        {
            decimal DebtsForYou = decimal.Zero;
            decimal CurrentPersonBalance;
            foreach (DataRow person in dtPersons.Rows)
            {
                CurrentPersonBalance = clsPerson.CalculateTotalBalance(Convert.ToInt32(person["PersonId"]));
                if (CurrentPersonBalance < 0)
                {
                    DebtsForYou += CurrentPersonBalance;
                }
            }
            lblForYou.Text = (-DebtsForYou).ToString(clsSettings.GetNumberFormat()) + clsCurrency.GetDefaultCurrency().Suffix;
        }

        private void _LoadDebtOnYou(DataTable dtPersons)
        {
            decimal DebtsOnYou = decimal.Zero;
            decimal CurrentPersonBalance;
            foreach (DataRow person in dtPersons.Rows)
            {
                CurrentPersonBalance = clsPerson.CalculateTotalBalance(Convert.ToInt32(person["PersonId"]));
                if (CurrentPersonBalance > 0)
                {
                    DebtsOnYou += CurrentPersonBalance;
                }
            }
            lblOnYou.Text = DebtsOnYou.ToString(clsSettings.GetNumberFormat()) + clsCurrency.GetDefaultCurrency().Suffix;
        }

        private void _LoadDashboard()
        {
            DataTable dtpersons = clsPerson.GetAllPersons();
            decimal TotalDebtsForYou = decimal.Zero;
            decimal TotalDebtsOnYou = decimal.Zero;
            decimal CurrentPersonBalance;

            foreach (DataRow person in dtpersons.Rows)
            {
                CurrentPersonBalance = clsPerson.CalculateTotalBalance(Convert.ToInt32(person["PersonId"]));
                if (CurrentPersonBalance > 0)
                {
                    TotalDebtsOnYou += CurrentPersonBalance;
                }
                else
                {
                    TotalDebtsForYou += CurrentPersonBalance;
                }
            }
            TotalDebtsForYou = Math.Abs(TotalDebtsForYou);
            lblTotalDebtsForYou.Text = TotalDebtsForYou.ToString(clsSettings.GetNumberFormat()) + clsCurrency.GetDefaultCurrency().Suffix;
            lblTotalDebtsOnYou.Text = TotalDebtsOnYou.ToString(clsSettings.GetNumberFormat()) + clsCurrency.GetDefaultCurrency().Suffix;

            if (TotalDebtsForYou > TotalDebtsOnYou)
            {
                lblTotalBalance.Text = (TotalDebtsForYou - TotalDebtsOnYou).ToString(clsSettings.GetNumberFormat())
                    + clsCurrency.GetDefaultCurrency().Suffix
                    + "\nلك";

            }
            else if (TotalDebtsOnYou > TotalDebtsForYou)
            {
                lblTotalBalance.Text = (TotalDebtsOnYou - TotalDebtsForYou).ToString(clsSettings.GetNumberFormat())
                    + clsCurrency.GetDefaultCurrency().Suffix
                    + "\nعليك";
            }
            else
            {
                lblTotalBalance.Text = (decimal.Zero).ToString(clsSettings.GetNumberFormat())
                    + clsCurrency.GetDefaultCurrency().Suffix;
            }

            _LoadLastOperation();
        }

        private void _LoadLastOperation()
        {
            DataTable LastOperations = clsDebt.GetLast5Debts();
            lvLastOperations.Items.Clear();
            ListViewItem item;
            foreach (DataRow row in LastOperations.Rows)
            {
                item = new ListViewItem(row["FullName"].ToString());
                item.ForeColor = Color.Black;
                item.ImageIndex = 0;
                item.BackColor = row["DebtType"].ToString().Equals("INCOME") ?
                    Color.FromArgb(230, 255, 230) : Color.FromArgb(255, 230, 230);
                item.SubItems.Add(row["Amount"].ToString());
                item.SubItems.Add(row["Notes"].ToString());
                lvLastOperations.Items.Add(item);
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            _LoadDashboard();
            pnlAccounts.Visible = false;
            pnlProgramData.Visible = true;
            pnlSummery.Visible = true;
            pnlLastOperations.Visible = true;
        }

        private void lvAccounts_DoubleClick(object sender, EventArgs e)
        {

            // Check if an item is selected
            if (lvAccounts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAccounts.SelectedItems[0];

                // Retrieve the ID from the Tag property
                if (selectedItem.Tag != null)
                {
                    // Cast the Tag to appropriate type (assuming PersonId is int)
                    int personId = (int)selectedItem.Tag;

                    FrmAccount Frm = new FrmAccount(personId);
                    Frm.ShowDialog();
                    _LoadPersons();
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            FrmAddPerson frm = new FrmAddPerson();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _LoadPersons();
            }
        }

        private void lvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            btnAddAccount.Location = new Point(this.Size.Width - 170, 3);
            pnlSummery.Size = new Size(this.Width - 367, this.Height/3);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tsmiTableView_Click(object sender, EventArgs e)
        {
            lvAccounts.View = View.Details;
            clsSettings.UpdateLvAccountsViewType("DETAILS");
        }

        private void tsmiLargIconView_Click(object sender, EventArgs e)
        {
            lvAccounts.View = View.LargeIcon;
            clsSettings.UpdateLvAccountsViewType("LARGE ICON");
        }

        private void tsmiSmallIconView_Click(object sender, EventArgs e)
        {
            lvAccounts.View = View.SmallIcon;
            clsSettings.UpdateLvAccountsViewType("SMALL ICON");
        }

        private void tsmiTielsView_Click(object sender, EventArgs e)
        {
            lvAccounts.View = View.Tile;
            clsSettings.UpdateLvAccountsViewType("TILE");
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("سيتم حذف هذا الحساب وجميع العمليات المرتبطة به، هل أنت متأكد؟", "تأكيد الحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning
            , MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading) == DialogResult.OK)
            {
                int PersonId = Convert.ToInt32(lvAccounts.SelectedItems[0].Tag);
                string PersonName = clsPerson.FindPerson(PersonId).FullName;
                if (clsPerson.DeletePerson(PersonId))
                {
                    NotifyIcon notifyIcon = new NotifyIcon();
                    notifyIcon.Text = $"تم حذف حساب {PersonName} بنجاح";
                    notifyIcon.Icon = SystemIcons.Application;
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(3000, "تم الحذف", $"تم حذف حساب {PersonName} بنجاح", ToolTipIcon.Info);
                    _LoadPersons();
                }

            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count <= 0)
            {
                return;
            }
            int PersonId = Convert.ToInt32(lvAccounts.SelectedItems[0].Tag);
            clsPerson Person = clsPerson.FindPerson(PersonId);
            FrmAddPerson frmAddAccount = new FrmAddPerson(Person);

            if (frmAddAccount.ShowDialog() == DialogResult.OK)
            {
                NotifyIcon notifyIcon = new NotifyIcon();
                notifyIcon.Text = $"تم تعديل حساب بنجاح";
                notifyIcon.Icon = SystemIcons.Application;
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000, "تم التعديل", $"تم تعديل حساب بنجاح", ToolTipIcon.Info);
                _LoadPersons();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (lvAccounts.SelectedItems.Count > 0)
            {
                tsmiDelete.Enabled = true;
                tsmiEdit.Enabled = true;
            }
            else
            {
                tsmiDelete.Enabled = false;
                tsmiEdit.Enabled = false;
            }
        }

        private void btnReportPage_Click(object sender, EventArgs e)
        {

        }

        private void btnSettingsPage_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.ShowDialog();
            _LoadCompanyInfo();
        }

        private void btnAboutPage_Click(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dtPersons = clsPerson.Search((sender as System.Windows.Forms.TextBox).Text);

            _LoadPersons(dtPersons);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
            _LoadPersons();
        }

        private void cbClassifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClassifications.SelectedIndex != 0)
            {
                string classificationName = (sender as System.Windows.Forms.ComboBox).Text;
                int clssificationId = clsClassification.GetClassificationId(classificationName);
                _LoadPersons(clsPerson.GetAllPersons(clssificationId));
            }
            else
            {
                _LoadPersons(clsPerson.GetAllPersons());
            }
        }

        private void pnlSummery_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
