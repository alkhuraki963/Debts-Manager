using DebtsManagerDataAccessLayer;
using DebtsManagerUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerBusinessLayer
{

    public class clsDebt
    {
        public enMode Mode;
        public int Id { get; private set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public enDebtType DebtType { get; set; }
        public DateTime DebtDate { get; set; }
        public decimal BalanceChange { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public int CurrencyId { get; set; }
        public int AccountId { get; set; }

        public clsDebt()
        {
            this.Mode = enMode.ADD;
            this.Id = -1;
            this.Notes = string.Empty;
            this.Amount = decimal.Zero;
            this.DebtType = enDebtType.INCOME;
            this.DebtDate = DateTime.Now;
            this.BalanceChange = decimal.Zero;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.CurrencyId = -1;
            this.AccountId = -1;
        }
        private clsDebt(int Id, string Notes, decimal Amount, enDebtType DebtType, DateTime DebtDate, decimal BalanceChange,
            DateTime CreatedAt, DateTime UpdatedAt, int CurrencyId, int AccountId)
        {
            this.Id = Id;
            this.Notes = Notes;
            this.Amount = Amount;
            this.DebtType = DebtType;
            this.DebtDate = DebtDate;
            this.BalanceChange = BalanceChange;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.AccountId = AccountId;
            this.CurrencyId = CurrencyId;
            Mode = enMode.UPDATE;
        }

        public static DataTable GetAllDebts(int AccountId)
        {
            return clsDebtDataAccess.GetAllDebts(AccountId);
        }

        public static clsDebt FindDebt(int debtId)
        {

            string Notes = string.Empty;
            decimal Amount = decimal.Zero;
            enDebtType DebtType = enDebtType.INCOME;
            DateTime DebtDate = DateTime.MinValue;
            decimal BalanceChange = decimal.MinValue;
            DateTime CreatedAt = DateTime.MinValue;
            DateTime UpdatedAt = DateTime.MinValue;
            int CurrencyId = -1;
            int AccountId = -1;

            if (clsDebtDataAccess.GetDebtByID(debtId, ref Notes, ref Amount, ref DebtType, ref DebtDate
                , ref BalanceChange, ref CreatedAt, ref UpdatedAt, ref AccountId))
            {
                return new clsDebt(debtId, Notes, Amount, DebtType, DebtDate, BalanceChange, CreatedAt, UpdatedAt,CurrencyId ,AccountId);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            this.BalanceChange = _UpdateAccountBalance();
            switch (this.Mode)
            {
                case enMode.ADD:
                    {
                        if (_AddNewDebt())
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
                        return _UpdateDebt();
                    }
                    break;
            }
            return false;
        }

        private decimal _UpdateAccountBalance()
        {
            clsAccount CurrencAccount = clsAccount.FindAccount(this.AccountId);
            if (this.DebtType == enDebtType.INCOME)
            {
                CurrencAccount.Deposit(Amount);
            }
            else if(this.DebtType == enDebtType.OUTCOME)
            {
                CurrencAccount.Withdraw(Amount);
            }
            return CurrencAccount.Balance;
        }

        private bool _UpdateDebt()
        {
            this.UpdatedAt = DateTime.Now;
            return clsDebtDataAccess.UpdateDebt(this.Id, this.Notes
                , this.Amount, this.DebtType, this.DebtDate, this.BalanceChange,this.CurrencyId,this.UpdatedAt);
        }

        private bool _AddNewDebt()
        {
            this.Id = clsDebtDataAccess.AddNewDebt(this.Notes, this.Amount, this.DebtType, this.DebtDate, this.BalanceChange,this.CurrencyId,this.AccountId);
            return this.Id > 0;
        }

        public static bool IsDebtExists(int debtID)
        {
            return clsDebtDataAccess.IsDebtExists(debtID);
        }

        public static bool DeleteDebt(int debtID)
        {
            if (IsDebtExists(debtID))
            {
                return clsDebtDataAccess.DeleteDebt(debtID);
            }
            else
            {
                return false;
            }
        }

    }

}
