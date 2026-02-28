using DebtsManagerDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerBusinessLayer
{
    public class clsAccount
    {
        public enMode Mode;
        public int AccountId { get; private set; }
        public decimal Balance { get; set; }
        public bool IsDefault { get; set; }
        public int PersonId { get; set; }
        public int CurrencyId { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public clsAccount()
        {
            this.AccountId = -1;
            this.Balance = decimal.Zero;
            this.IsDefault = false;
            this.PersonId = -1;
            this.CurrencyId = -1;
            this.UpdatedAt = DateTime.Now;
            this.CreatedAt = DateTime.Now;
            this.Mode = enMode.ADD;
        }

        private clsAccount(int AccountId, decimal Balance, bool IsDefault, int PersonId, int CurrencyId, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.AccountId = AccountId;
            this.Balance = Balance;
            this.IsDefault = IsDefault;
            this.PersonId = PersonId;
            this.CurrencyId = CurrencyId;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.Mode = enMode.UPDATE;
        }

        public static DataTable GetAllAccounts()
        {
            return clsAccountDataAccess.GetAllAccounts();
        }

        public static clsAccount FindAccount(int AccountID)
        {
            decimal Balance = decimal.Zero;
            bool IsDefault = false;
            int PersonId = -1;
            int CurrencyId = -1;
            DateTime CreatedAt = DateTime.MinValue;
            DateTime UpdatedAt = DateTime.MinValue;

            if (clsAccountDataAccess.GetAccountById(AccountID, ref Balance, ref IsDefault, ref PersonId, ref CurrencyId,
                ref CreatedAt, ref UpdatedAt))
            {
                return new clsAccount(AccountID, Balance, IsDefault, PersonId, CurrencyId, CreatedAt, UpdatedAt);
            }
            else
            {
                return null;
            }

        }

        public static clsAccount FindAccount(int PersonId,int CurrencyId) 
        {
            return FindAccount(clsAccountDataAccess.GetAccountId(PersonId, CurrencyId));
        }

        public static int GetAccountId(int PersonId, int CurrencyId) 
        {
            return clsAccountDataAccess.GetAccountId(PersonId, CurrencyId);
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
                case enMode.UPDATE:
                    {
                        return _UpdateAccount();
                    }
            }
            return false;
        }

        private bool _UpdateAccount()
        {
            this.UpdatedAt = DateTime.Now;
            return clsAccountDataAccess.UpdateAccount(this.AccountId, this.Balance, this.IsDefault,this.UpdatedAt);
        }

        private bool _AddNewAccount()
        {
            this.AccountId = clsAccountDataAccess.AddNewAccount(this.PersonId,this.CurrencyId);
            return this.AccountId > 0;
        }

        public static bool IsAccountExists(int AccountID)
        {
            return clsAccountDataAccess.IsAccountExists(AccountID);
        }

        public static bool DeleteAccount(int AccountID)
        {
            if (IsAccountExists(AccountID))
            {
                return clsAccountDataAccess.DeleteAccount(AccountID);
            }
            else
            {
                return false;
            }
        }

        public void Deposit(decimal amount)
        {
            if (IsAccountExists(this.AccountId))
            {
                this.Balance += amount;
                Save();
            }
        }

        public void Withdraw(decimal amount)
        {
            Deposit(-amount);
        }

        public bool SetAsDefaultAccount()
        {
            return clsAccountDataAccess.SetDefaultAccount(this.AccountId);
        }

        public static clsAccount GetDefaultAccount(int PersonId)
        {
            DataTable dt = GetAllAccounts();
            clsAccount DefaultAccount = new clsAccount();
            foreach (DataRow Account in dt.Rows)
            {
                if (Convert.ToBoolean(Account["IsDefault"]))
                {
                    DefaultAccount.AccountId = (int)Account["AccountId"];
                    DefaultAccount.Balance = (decimal)Account["Balance"];
                    DefaultAccount.IsDefault = (bool)Account["IsDefault"];
                    DefaultAccount.PersonId = (int)Account["PersonId"];
                    DefaultAccount.CurrencyId = (int)Account["CurrencyId"];
                    DefaultAccount.CreatedAt = (DateTime)Account["CreatedAt"];
                    DefaultAccount.UpdatedAt = (DateTime)Account["UpdatedAt"];

                }
            }
            return DefaultAccount;
        }

        public static List<clsAccount> GetAllAccounts(int personId)
        {
            DataRow[] PersonAccountRows = GetAllAccounts().Select($"PersonId = {personId}");
            List<clsAccount> PersonAccounts = new List<clsAccount>();
            clsAccount Account;
            foreach (DataRow AccountRow in PersonAccountRows)
            {
                Account = new clsAccount();
                Account.AccountId = (int)AccountRow["AccountId"];
                Account.Balance = (decimal)AccountRow["Balance"];
                Account.IsDefault = (bool)AccountRow["IsDefault"];
                Account.PersonId = (int)AccountRow["PersonId"];
                Account.CurrencyId = (int)AccountRow["CurrencyId"];
                Account.CreatedAt = (DateTime)AccountRow["CreatedAt"];
                Account.UpdatedAt = (DateTime)AccountRow["UpdatedAt"];
                PersonAccounts.Add(Account);
            }
            return PersonAccounts;
        }

        //public DataTable GetAllDebts()
        //{
        //    DataTable AllDebts = clsDebt.GetAllDebts(this.PersonId);

        //    DataTable dt = AllDebts.Clone();

        //    DataRow[] CurrencyDebts;

        //    try
        //    {
        //        CurrencyDebts = AllDebts.Select($"'CurrencyId'={CurrencyId}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error in GetAllDebts for person {this.Id}: {ex.Message}");
        //        return new DataTable();
        //    }

        //    if (CurrencyDebts != null)
        //    {
        //        foreach (DataRow CurrencyDebt in CurrencyDebts)
        //        {
        //            dt.ImportRow(CurrencyDebt);
        //        }
        //    }

        //    return dt;
        //}

        //public DataTable GetAllIncomeDebts(int CurrencyId)
        //{
        //    DataTable allDebts = GetAllDebts(CurrencyId);
        //    DataTable incomeTable = allDebts.Clone();
        //    DataRow[] incomeRows;
        //    try
        //    {
        //        incomeRows = allDebts.Select("DebtType = 'INCOME'");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error in GetAllIncomeDebts for person {this.Id}: {ex.Message}");
        //        return new DataTable();
        //    }

        //    if (incomeTable != null)
        //    {
        //        foreach (DataRow row in incomeRows)
        //        {
        //            incomeTable.ImportRow(row);
        //        }
        //    }
        //    return incomeTable;
        //}

        //public DataTable GetAllOutcomeDebts(int CurrencyId)
        //{
        //    DataTable allDebts = GetAllDebts(CurrencyId);
        //    DataTable outcomeTable = allDebts.Clone();
        //    DataRow[] outcomeRows;
        //    try
        //    {
        //        outcomeRows = allDebts.Select("DebtType = 'INCOME'");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error in GetAllOutcomeDebts for person {this.Id}: {ex.Message}");
        //        return new DataTable();
        //    }

        //    if (outcomeRows != null)
        //    {
        //        foreach (DataRow row in outcomeRows)
        //        {
        //            outcomeTable.ImportRow(row);
        //        }
        //    }
        //    return outcomeTable;
        //}
    }
}
