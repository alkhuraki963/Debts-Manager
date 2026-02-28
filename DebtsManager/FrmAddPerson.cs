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
    public partial class FrmAddPerson : Form
    {
        enMode Mode;
        clsPerson Person;
        public FrmAddPerson()
        {
            InitializeComponent();
            Mode = enMode.ADD;
            Person = new clsPerson();
        }
        public FrmAddPerson(clsPerson Person)
        {
            InitializeComponent();
            Mode = enMode.UPDATE;
            this.Person = Person;
        }


        private void FrmAddAccount_Load(object sender, EventArgs e)
        {
            _LoadClassifications();
            if (Mode == enMode.ADD) 
            {
                tbFullName.Clear();
                tbEmail.Clear();
                tbPhone.Clear();
                cbClassification.SelectedIndex = 0;
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
                cbClassification.SelectedIndex = _GetSelectedIndex();
                this.Text = "تعديل حساب";
                lblTitle.Text = "تعديل الحساب";
            }
        }

        private int _GetSelectedIndex()
        {
            if(Person == null)
            {
                return 0;
            }

            string ClassificationName = clsClassification.GetClassificationName(Person.ClassificationId);

            int i = 0;
            foreach (string item in cbClassification.Items)
            {
                if (item.Equals(ClassificationName))
                {
                    return i;
                }
                i++;
            }

            return 0;
        }

        private void _LoadClassifications()
        {
            cbClassification.Items.Clear();

            foreach (DataRow item in clsClassification.GetAllClassifications().Rows)
            {
                cbClassification.Items.Add(item["ClassificationName"]);
            }
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            if(!_IsInputValid())
            {
                return;
            }

            string FullName = tbFullName.Text;
            string Phone = tbPhone.Text;
            string Email = tbEmail.Text;
            int ClassificationId = clsClassification.GetClassificationId(cbClassification.Text);

            Person.FullName = FullName;
            Person.Phone = Phone;
            Person.Email = Email;
            Person.ClassificationId = ClassificationId;
            Person.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool _IsInputValid()
        {
            bool IsValid = true;

            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(tbFullName.Text))
            {
                errorProvider1.SetError(tbFullName, "لا يمكنك ترك هذا الحقل فارغاً");
                IsValid = false;
            }
            if (string.IsNullOrWhiteSpace(tbPhone.Text)) 
            {
                errorProvider1.SetError(tbPhone, "لا يمكنك ترك هذا الحقل فارغاً");
                IsValid = false;
            }
            if (!tbPhone.Text.All(Char.IsDigit)) 
            {
                errorProvider1.SetError(tbPhone, "رقم الهاتف يجب ان يحوي ارقاماً فقط");
                IsValid = false;
            }
            
            if (!string.IsNullOrEmpty(tbEmail.Text) && !clsUtility.IsEmail(tbEmail.Text)) 
            {
                errorProvider1.SetError(tbEmail, "البريد الألكتروني الذي ادخلته غير صحيح");
                IsValid = false;
            }

            return IsValid;
        }
    }
}
