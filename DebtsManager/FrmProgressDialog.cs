using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtsManager
{
    public partial class FrmProgressDialog : Form
    {
        public FrmProgressDialog()
        {
            InitializeComponent();
        }

        public void StartProgress()
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar.Value = i;
                Thread.Sleep(10);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmProgressDialog_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(50);
            StartProgress();
        }
    }
}
