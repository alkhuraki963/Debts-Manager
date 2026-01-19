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
        }

        private void btnAccountPage_Click(object sender, EventArgs e)
        {
            pnlProgramData.Visible = false;
            pnlAccounts.Visible = true;
            _LoadPersons();
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

        private void _LoadPersons()
        {

            _ConfigureLvAccountsUI();
            DataTable dtAccounts = clsPerson.GetAllPersons();

            try
            {
                foreach (DataRow row in dtAccounts.Rows)
                {
                    string fullName = row["fullname"].ToString();
                    decimal balance = clsPerson.CalculateTotalBalance(Convert.ToInt32(row["PersonId"]));
                    // Create item
                    ListViewItem item = new ListViewItem(fullName);

                    // Format balance nicely
                    string formattedBalance = balance.ToString(clsSettings.NumberFormat) + clsCurrency.GetDefaultCurrency().Suffix;
                    item.SubItems.Add(formattedBalance);

                    // Store ID in Tag
                    item.Tag = row["PersonId"];
                    item.ImageIndex = 0;

                    // Better color scheme based on balance
                    if (balance > 0)
                    {
                        item.BackColor = Color.FromArgb(230, 255, 230); // Very light green
                        item.ForeColor = Color.DarkGreen;
                        item.Font = new Font(lvAccounts.Font, FontStyle.Regular);
                    }
                    else if (balance < 0)
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
            _LoadDebtOnYou(dtAccounts);
            _LoadDebtsForYou(dtAccounts);
            _LoadAccountsCount(dtAccounts);
        }

        private View _GetLvAccountsType()
        {
            string value = clsSettings.GetLvAccountsViewType().ToUpper();
            switch (value)
            {
                case "LARGE ICON": return View.LargeIcon; break;
                case "SMALL ICON": return View.SmallIcon; break;
                case "DETAILS": return View.Details; break;
                case "TILE": return View.Tile; break;
                default: return View.Tile;
            }
        }

        private void _LoadAccountsCount(DataTable dtAccounts)
        {
            lblAccountsCount.Text = dtAccounts.Rows.Count.ToString(clsSettings.NumberFormat);
        }

        private void _LoadDebtsForYou(DataTable dtAccounts)
        {
            try
            {
                var DebtsForYou = dtAccounts.Compute("SUM(Balance)", "Balance<0");
                lblForYou.Text = (-Convert.ToDecimal(DebtsForYou)).ToString(clsSettings.NumberFormat) + " " + clsSettings.CurrencySuffix;
            }
            catch
            {
                lblForYou.Text = "0";
            }
        }

        private void _LoadDebtOnYou(DataTable dtAccounts)
        {
            try
            {
                var DebtsOnYou = dtAccounts.Compute("SUM(Balance)", "Balance>0");
                lblOnYou.Text = Convert.ToDecimal(DebtsOnYou).ToString(clsSettings.NumberFormat) + " " + clsSettings.CurrencySuffix;
            }
            catch
            {
                lblOnYou.Text = "0";
            }
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            pnlAccounts.Visible = false;
            //pnlNavigation.Dock = DockStyle.None;
            pnlProgramData.Visible = true;
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
            frm.ShowDialog();
            _LoadPersons();
        }

        private void lvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            btnAddAccount.Location = new Point(this.Size.Width - 170, 3);
            // make the panel always in the center
            pnlCompanyInfo.Location = new Point(this.Size.Width / 2, (this.Size.Height - 37) / 2 - 165);
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
                string PersonName = clsPerson.FindAccount(PersonId).FullName;
                if (clsPerson.DeleteAccount(PersonId))
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
            clsPerson Person = clsPerson.FindAccount(PersonId);
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

        }

        private void btnAboutPage_Click(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _ConfigureLvAccountsUI();
            DataTable dtAccounts = clsPerson.Search((sender as System.Windows.Forms.TextBox).Text);

            if (dtAccounts.Rows.Count == 0)
            {
                return;
            }



            try
            {
                foreach (DataRow row in dtAccounts.Rows)
                {
                    string fullName = row["fullname"].ToString();
                    decimal balance = 0;

                    // Safely parse balance
                    if (decimal.TryParse(row["balance"].ToString(), out balance))
                    {
                        // Create item
                        ListViewItem item = new ListViewItem(fullName);

                        // Format balance nicely
                        string formattedBalance = balance.ToString(clsSettings.NumberFormat) + " " + clsSettings.CurrencySuffix;
                        item.SubItems.Add(formattedBalance);

                        // Store ID in Tag
                        item.Tag = row["PersonId"];
                        item.ImageIndex = 0;

                        // Better color scheme based on balance
                        if (balance > 0)
                        {
                            item.BackColor = Color.FromArgb(230, 255, 230); // Very light green
                            item.ForeColor = Color.DarkGreen;
                            item.Font = new Font(lvAccounts.Font, FontStyle.Regular);
                        }
                        else if (balance < 0)
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
            }
            finally
            {
                lvAccounts.EndUpdate();
            }

            // Optional: Auto-resize columns to fit content
            lvAccounts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
            _LoadPersons();
        }
    }
}
