using DebtsManagerDataAccessLayer;
using DebtsManagerUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerBusinessLayer
{
    public class clsCurrency
    {
        enMode Mode;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Suffix { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDefault { get; set; }
        public decimal ToDefaultRate { get; set; }

        public clsCurrency()
        {
            this.Id = -1;
            this.Name = string.Empty;
            this.Country = string.Empty;
            this.Suffix = string.Empty;
            this.IsUsed = false;
            this.IsDefault = false;
            this.ToDefaultRate = decimal.One;
            this.Mode = enMode.ADD;
        }

        private clsCurrency(int Id, string Name, string Country, string Suffix, bool IsUsed, bool IsDefault, decimal ToDefaultRate)
        {
            this.Id = Id;
            this.Name = Name;
            this.Country = Country;
            this.Suffix = Suffix;
            this.IsUsed = IsUsed;
            this.IsDefault = IsDefault;
            this.ToDefaultRate = ToDefaultRate;
            Mode = enMode.UPDATE;
        }

        public static DataTable GetAllCurrencies()
        {
            return clsCurrencyDataAccess.GetAllCurrencies();
        }

        public static clsCurrency FindCurrency(int CurrencyId)

        {
            string Name = string.Empty;
            string Country = string.Empty;
            string Suffix = string.Empty;
            bool IsUsed = false;
            bool IsDefault = false;
            decimal ToDefaultRate = decimal.MinValue;

            if (clsCurrencyDataAccess.GetCurrencyById(CurrencyId, ref Name, ref Country, ref Suffix, ref IsUsed, ref IsDefault, ref ToDefaultRate))
            {
                return new clsCurrency(CurrencyId, Name, Country, Suffix, IsUsed, IsDefault, ToDefaultRate);
            }
            else
            {
                return null;
            }

        }

        public static clsCurrency FindCurrency(string CurrencyName)
        {
            return FindCurrency(GetCurrencyId(CurrencyName));
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.ADD:
                    {
                        if (_AddNewCurrency())
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
                        return _UpdateCurrency();
                    }
            }
            return false;
        }

        private bool _UpdateCurrency()
        {
            return clsCurrencyDataAccess.UpdateCurrency(this.Id, this.Name, this.Country, this.Suffix, this.IsUsed, this.ToDefaultRate);
        }

        private bool _AddNewCurrency()
        {
            this.Id = clsCurrencyDataAccess.AddNewCurrency(this.Name, this.Country, this.Suffix, this.ToDefaultRate);
            return this.Id > 0;
        }

        public static bool IsCurrencyExists(int CurrencyId)
        {
            return clsCurrencyDataAccess.IsCurrencyExists(CurrencyId);
        }

        public static bool DeleteCurrency(int CurrencyId)
        {
            if (!IsCurrencyExists(CurrencyId))
            {
                return false;
            }
            if (_IsCurencyUsedInAccounts(CurrencyId))
            {
                return false;
            }

            return clsCurrencyDataAccess.DeleteCurrency(CurrencyId);

        }

        public static clsCurrency GetDefaultCurrency()
        {
            DataTable dt = GetAllCurrencies();
            clsCurrency DefaultCurrency = new clsCurrency();
            foreach (DataRow Currency in dt.Rows)
            {
                if (Convert.ToBoolean(Currency["IsDefault"]))
                {
                    DefaultCurrency.Id = (int)Currency["CurrencyId"];
                    DefaultCurrency.Name = (string)Currency["CurrencyName"];
                    DefaultCurrency.Country = (string)Currency["CurrencyCountry"];
                    DefaultCurrency.Suffix = (string)Currency["CurrencySuffix"];
                    DefaultCurrency.IsUsed = (bool)Currency["IsUsed"];
                    DefaultCurrency.IsDefault = (bool)Currency["IsDefault"];
                    DefaultCurrency.ToDefaultRate = (decimal)Currency["ToDefaultRate"];
                }
            }
            return DefaultCurrency;
        }

        public static DataTable GetUsedCurrencies()
        {
            DataTable dt = GetAllCurrencies();
            DataTable usedCurrencies = new DataTable();
            usedCurrencies = dt.Clone();
            foreach (DataRow Currency in dt.Rows)
            {
                if (Convert.ToBoolean(Currency["IsUsed"]))
                {
                    usedCurrencies.ImportRow(Currency);
                }
            }
            return usedCurrencies;
        }

        public bool SetDefaultCurrency()
        {
            return clsCurrencyDataAccess.SetDefaultCurrency(this.Id);
        }

        public static int GetCurrencyId(string CurrencyName)
        {
            return clsCurrencyDataAccess.GetCurrencyId(CurrencyName);
        }

        public bool UseCurrency()
        {
            if (!IsCurrencyExists(this.Id))
            {
                return false;
            }

            IsUsed = true;
            return Save();

        }

        public bool UnUseCurrency()
        {
            if (!IsCurrencyExists(this.Id))
            {
                return false;
            }
            if (_IsCurencyUsedInAccounts())
            {
                return false;
            }
            if (IsDefault)
            {
                return false;
            }

            IsUsed = false;
            return Save();
        }

        private bool _IsCurencyUsedInAccounts()
        {
            return _IsCurencyUsedInAccounts(this.Id);
        }

        private static bool _IsCurencyUsedInAccounts(int currencyId)
        {
            return clsCurrencyDataAccess.IsCurrencyUsedInAccounts(currencyId);
        }

        public static decimal ConvertCurrency(decimal AmountToConvert, string FromCurrency, string ToCurrency)
        {

            if (FromCurrency.Equals(ToCurrency))
            {
                return AmountToConvert;
            }

            clsCurrency fromCurrency = FindCurrency(FromCurrency);
            clsCurrency toCurrency = FindCurrency(ToCurrency);

            decimal converToDefault = AmountToConvert * fromCurrency.ToDefaultRate;

            return converToDefault / toCurrency.ToDefaultRate;
        }
    }
}
