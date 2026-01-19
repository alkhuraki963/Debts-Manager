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

        public clsCurrency()
        {
            this.Id = -1;
            this.Name = string.Empty;
            this.Country = string.Empty;
            this.Suffix = string.Empty;
            this.IsUsed = false;
            this.IsDefault = false;
            this.Mode = enMode.ADD;
        }

        private clsCurrency(int Id, string Name, string Country, string Suffix, bool IsUsed, bool IsDefault)
        {
            this.Id = Id;
            this.Name = Name;
            this.Country = Country;
            this.Suffix = Suffix;
            this.IsUsed = IsUsed;
            this.IsDefault = IsDefault;
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

            if (clsCurrencyDataAccess.GetCurrencyById(CurrencyId, ref Name, ref Country, ref Suffix, ref IsUsed, ref IsDefault))
            {
                return new clsCurrency(CurrencyId, Name, Country, Suffix, IsUsed, IsDefault);
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
                    break;
                case enMode.UPDATE:
                    {
                        return _UpdateCurrency();
                    }
                    break;
            }
            return false;
        }

        private bool _UpdateCurrency()
        {
            return clsCurrencyDataAccess.UpdateCurrency(this.Id, this.Name, this.Country, this.Suffix, this.IsUsed);
        }

        private bool _AddNewCurrency()
        {
            this.Id = clsCurrencyDataAccess.AddNewCurrency(this.Name, this.Country, this.Suffix);
            return this.Id > 0;
        }

        public static bool IsCurrencyExists(int CurrencyId)
        {
            return clsCurrencyDataAccess.IsCurrencyExists(CurrencyId);
        }

        public static bool DeleteCurrency(int CurrencyId)
        {
            if (IsCurrencyExists(CurrencyId))
            {
                return clsCurrencyDataAccess.DeleteCurrency(CurrencyId);
            }
            else
            {
                return false;
            }
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
        public void SetAsUsedCurrency()
        {
            IsUsed = true;
            Save();
        }
    }
}
