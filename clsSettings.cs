using DebtsManagerDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerBusinessLayer
{
    public class clsSettings
    {
        public static string CurrencySuffix = "ل.س";
        public static string NumberFormat = "N0";

        public static string GetLvAccountsViewType()
        {
            return clsSettingsDataAccess.GetLvAccountViewType();
        }
        public static bool UpdateLvAccountsViewType(string lvAccountViewType)
        {
            return clsSettingsDataAccess.UpdateLvAccountViewType(lvAccountViewType);
        }
    }
}
