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
    public partial class FrmChooseFilterDates : Form
    {
        public DateTime FromDate { get;  private set; }
        public DateTime ToDate { get; private set; }

        public FrmChooseFilterDates()
        {
            InitializeComponent();
        }

        private void FrmChooseFilterDates_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now.AddDays(1);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            if (dtpFromDate.Value > dtpToDate.Value)
            {
                return;
            }

            FromDate = dtpFromDate.Value;
            ToDate = dtpToDate.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }





        private void dtpFromDate_Validating(object sender, CancelEventArgs e)
        {
            _ValidateDates();
        }

        private void dtpToDate_Validating(object sender, CancelEventArgs e)
        {
            _ValidateDates();
        }

        private void DatesChange(object sender, EventArgs e)
        {
            _ValidateDates();
        }

        private void _ValidateDates()
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {

                errorProvider1.SetError(dtpFromDate, "تاريخ البداية لا يمكن ان يكون بعد تاريخ النهاية.");
                errorProvider1.SetError(dtpToDate, "تاريخ النهاية لا يمكن ان يكون قبل تاريخ البداية.");

            }
            else
            {
                errorProvider1.SetError(dtpFromDate, "");
                errorProvider1.SetError(dtpToDate, "");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
