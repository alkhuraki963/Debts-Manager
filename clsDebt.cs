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
        public decimal BalanceChange { get;private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public int PersonID { get; set; }

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
            this.PersonID = -1;
        }
        private clsDebt(int id, string notes, decimal amount, enDebtType debtType, DateTime debtDate, decimal balanceChange,
            DateTime createdAt, DateTime updatedAt, int personID)
        {
            this.Id = id;
            this.Notes = notes;
            this.Amount = amount;
            this.DebtType = debtType;
            this.DebtDate = debtDate;
            this.BalanceChange = balanceChange;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.PersonID = personID;
            Mode = enMode.UPDATE;
        }


        public static DataTable GetAllDebts(int personId)
        {
            return clsDebtDataAccess.GetAllDebts(personId);
        }

        public static DataTable GetAllIncomeDebts(int personId)
        {
            try
            {
                DataTable allDebts = GetAllDebts(personId);

                DataTable incomeTable = allDebts.Clone();

                DataRow[] incomeRows = allDebts.Select("DebtType = 'INCOME'");

                foreach (DataRow row in incomeRows)
                {
                    incomeTable.ImportRow(row);
                }

                return incomeTable;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetAllIncomeDebts for person {personId}: {ex.Message}");
                return new DataTable();
            }
        }

        public static DataTable GetAllOutcomeDebts(int personId)
        {
            try
            {
                DataTable allDebts = GetAllDebts(personId);

                DataTable outcomeTable = allDebts.Clone();

                DataRow[] outcomeRows = allDebts.Select("DebtType = 'OUTCOME'");

                foreach (DataRow row in outcomeRows)
                {
                    outcomeTable.ImportRow(row);
                }

                return outcomeTable;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetAllOutcomeDebts for person {personId}: {ex.Message}");
                return new DataTable();
            }
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
            int PersonID = -1;

            if (clsDebtDataAccess.GetDebtByID(debtId, ref Notes, ref Amount, ref DebtType, ref DebtDate
                , ref BalanceChange, ref CreatedAt, ref UpdatedAt, ref PersonID))
            {
                return new clsDebt(debtId, Notes, Amount, DebtType, DebtDate, BalanceChange, CreatedAt, UpdatedAt, PersonID);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            this.BalanceChange = _CalculateBalance();
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

        private bool _UpdateDebt()
        {
            this.UpdatedAt = DateTime.Now;
            return clsDebtDataAccess.UpdateDebt(this.Id, this.Notes
                , this.Amount, this.DebtType, this.DebtDate, this.BalanceChange, this.UpdatedAt);
        }

        private bool _AddNewDebt()
        {
            this.Id = clsDebtDataAccess.AddNewDebt(this.Notes, this.Amount, this.DebtType, this.DebtDate, this.BalanceChange, this.PersonID);
            return this.Id > 0;
        }

        private decimal _CalculateBalance()
        {
            decimal CalculatedBalance = decimal.Zero;

            if (PersonID > 0)
            {
                clsPerson Account = clsPerson.FindAccount(PersonID);

                switch (this.DebtType)
                {
                    case enDebtType.INCOME:
                        {
                            CalculatedBalance = Account.Balance + this.Amount;
                            Account.Balance = CalculatedBalance;
                            Account.Save();
                        }break;
                    case enDebtType.OUTCOME:
                        {
                            CalculatedBalance = Account.Balance - this.Amount;
                            Account.Balance = CalculatedBalance;
                            Account.Save();
                        }
                        break;
                }
            }
            return CalculatedBalance;
        }

        public static bool IsDebtExists(int debtID)
        {
            return clsDebtDataAccess.IsDebtExists(debtID);
        }

        public static bool DeleteAccount(int debtID)
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
