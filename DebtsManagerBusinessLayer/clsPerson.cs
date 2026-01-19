using DebtsManagerDataAccessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerBusinessLayer
{
    public enum enMode
    {
        ADD, UPDATE
    }

    public class clsPerson
    {
        public enMode Mode;
        public int Id { get; private set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ClassificationId { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public clsPerson()
        {
            this.Id = -1;
            this.FullName = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.ClassificationId = -1;
            this.UpdatedAt = DateTime.Now;
            this.CreatedAt = DateTime.Now;
            this.Mode = enMode.ADD;
        }

        private clsPerson(int Id, string FullName, string Phone, string Email, int ClassificationId, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Phone = Phone;
            this.Email = Email;
            this.ClassificationId = ClassificationId;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllPersons()
        {
            return clsPersonDataAccess.GetAllPersons();
        }

        public static clsPerson FindAccount(int AccountID)
        {
            string FullName = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int ClassificationId = -1;
            DateTime CreatedAt = DateTime.MinValue;
            DateTime UpdatedAt = DateTime.MinValue;

            if (clsPersonDataAccess.GetPersonByID(AccountID, ref FullName, ref Phone, ref Email, ref ClassificationId, ref CreatedAt, ref UpdatedAt))
            {
                return new clsPerson(AccountID, FullName, Phone, Email,ClassificationId, CreatedAt, UpdatedAt);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.ADD:
                    {
                        if (_AddNewAccount())
                        {
                            Mode = enMode.UPDATE;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    break;
                case enMode.UPDATE:
                    {
                        return _UpdateAccount();
                    }
                    break;
            }
            return false;
        }

        private bool _UpdateAccount()
        {
            this.UpdatedAt = DateTime.Now;
            return clsPersonDataAccess.UpdatePerson(this.Id, this.FullName
                , this.Phone, this.Email,this.ClassificationId,this.UpdatedAt);
        }

        private bool _AddNewAccount()
        {
            this.Id = clsPersonDataAccess.AddNewPerson(this.FullName, this.Phone, this.Email, this.ClassificationId);
            return this.Id > 0;
        }

        public static bool IsAccountExists(int AccountID)
        {
            return clsPersonDataAccess.IsPersonExists(AccountID);
        }

        public static bool DeleteAccount(int AccountID)
        {
            if (IsAccountExists(AccountID))
            {
                return clsPersonDataAccess.DeletePerson(AccountID);
            }
            else
            {
                return false;
            }
        }

        public static DataTable Search(string text)
        {
            return clsPersonDataAccess.SearchForPerson(text);
        }

        public static decimal CalculateTotalBalance(int PersonId)
        {
            List<clsAccount> PersonAccounts = clsAccount.GetAllAccounts(PersonId);
            return 0;
        }
    }
}
