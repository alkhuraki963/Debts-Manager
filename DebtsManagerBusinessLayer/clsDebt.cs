using DebtsManagerDataAccessLayer;
using DebtsManagerUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static DataTable GetIncomeDebts(int AccountId)
        {
            DataTable AllDebts = GetAllDebts(AccountId);
            DataTable IncomeDebts = AllDebts.Clone();
            DataRow[] IncomeDebtsRows = AllDebts.Select("DebtType = 'INCOME'");

            foreach (DataRow debtRow in IncomeDebtsRows)
            {
                IncomeDebts.ImportRow(debtRow);
            }

            return IncomeDebts;
        }

        public static DataTable GetOutComeDebts(int AccountId)
        {
            DataTable AllDebts = GetAllDebts(AccountId);
            DataTable OutcomeDebts = AllDebts.Clone();
            DataRow[] OutcomeDebtsRows = AllDebts.Select("DebtType = 'OUTCOME'");

            foreach (DataRow debtRow in OutcomeDebtsRows)
            {
                OutcomeDebts.ImportRow(debtRow);
            }

            return OutcomeDebts;
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
            switch (this.Mode)
            {
                case enMode.ADD:
                    {
                        this.BalanceChange = _GetBalanceChange();

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

                case enMode.UPDATE:
                    {
                        bool IsUpdated;
                        IsUpdated = _UpdateDebt();
                        _UpdateAccountBalance(this.AccountId);
                        return IsUpdated;
                    }

            }
            return false;
        }

        private static void _UpdateAccountBalance(int accountId)
        {
            // this function update balance change and account balance after edit or delete
            DataTable allDebts = GetAllDebts(accountId);
            clsDebt debt;

            decimal NewBalanceChange = decimal.Zero;
            decimal amount = decimal.Zero;
            string debtType = string.Empty;

            foreach (DataRow debtRow in allDebts.Rows)
            {
                debtType = debtRow["DebtType"].ToString();
                amount = Convert.ToDecimal(debtRow["Amount"]);

                if(_GetDebtType(debtType) == enDebtType.INCOME)
                {
                    NewBalanceChange += amount;
                }
                else if (_GetDebtType(debtType) == enDebtType.OUTCOME)
                {
                    NewBalanceChange -= amount;
                }

                if(NewBalanceChange != Convert.ToDecimal(debtRow["BalanceChange"]))
                {
                    debt = clsDebt.FindDebt(Convert.ToInt32(debtRow["DebtId"]));
                    debt.BalanceChange = NewBalanceChange;
                    debt.Save();
                }
            }
            clsAccount account = clsAccount.FindAccount(accountId);
            account.Balance = NewBalanceChange;
            account.Save();
        }

        private static enDebtType _GetDebtType(string type)
        {
            if (type.ToUpper().Equals("INCOME"))
                return enDebtType.INCOME;
            else
                return enDebtType.OUTCOME;
        }

        private decimal _GetBalanceChange()
        {
            // this fucntion update the account balance and return balance change
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
            bool IsDeleted;
            int accountId = FindDebt(debtID).AccountId;
            if (IsDebtExists(debtID))
            {
                IsDeleted = clsDebtDataAccess.DeleteDebt(debtID);
                _UpdateAccountBalance(accountId);
            }
            else
            {
                IsDeleted = false;
            }
            return IsDeleted;
        }

        public static DataTable Search(string Text,int AccountId)
        {
            return clsDebtDataAccess.SearchForDebt(Text,AccountId);
        }

        public static DataTable GetLast5Debts()
        {
            return clsDebtDataAccess.GetLast5Debts();
        }

        public static DataTable FilterByDates(int accountId, DateTime fromDate, DateTime toDate)
        {
            DataTable AllDebts = GetAllDebts(accountId);
            DataTable FilteredDebts = AllDebts.Clone();
            DataRow[] FilteredDebtsRows = AllDebts.Select($"DebtDate >= '{fromDate}' and DebtDate <= '{toDate}'");

            foreach (DataRow debtRow in FilteredDebtsRows)
            {
                FilteredDebts.ImportRow(debtRow);
            }

            return FilteredDebts;
        }
    }

}
