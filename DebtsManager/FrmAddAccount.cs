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
        enMode Mode;
        clsPerson Person;
        public FrmAddAccount()
        {
            InitializeComponent();
            Mode = enMode.ADD;
            Person = new clsPerson();
        }
        public FrmAddAccount(clsPerson Person)
        {
            InitializeComponent();
            Mode = enMode.UPDATE;
            this.Person = Person;
        }


        private void FrmAddAccount_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.ADD) 
            {
                tbFullName.Clear();
                tbEmail.Clear();
                tbPhone.Clear();
            }
            else
            {
                if (Person == null)
                {
                    return;
                }
                tbFullName.Text = Person.FullName;
                tbPhone.Text = Person.Phone;
                tbEmail.Text = Person.Email;
                this.Text = "تعديل حساب";
                lblTitle.Text = "تعديل الحساب";
            }
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            string FullName = tbFullName.Text;
            string Phone = tbPhone.Text;
            string Email = tbEmail.Text;

            Person.FullName = FullName;
            Person.Phone = Phone;
            Person.Email = Email;
            Person.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
