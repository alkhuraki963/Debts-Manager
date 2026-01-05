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
    public partial class FrmAddAccount : Form
    {
        public FrmAddAccount()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmAddAccount_Load(object sender, EventArgs e)
        {

        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string FullName = tbFullName.Text;
            string Phone = tbPhone.Text;
            string Email = tbEmail.Text;

            clsPerson Person = new clsPerson();
            Person.FullName = FullName;
            Person.Phone = Phone;
            Person.Email = Email;
            Person.Save();
            this.Close();
        }
    }
}
