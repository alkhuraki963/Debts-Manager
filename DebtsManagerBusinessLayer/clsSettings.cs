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
        public static string NumberFormat = "N2";

        public static string GetLvAccountsViewType()
        {
            return clsSettingsDataAccess.GetLvAccountViewType();
        }
        public static bool UpdateLvAccountsViewType(string lvAccountViewType)
        {
            return clsSettingsDataAccess.UpdateLvAccountViewType(lvAccountViewType);
        }
        public static string GetIncomeText()
        {
            return "له";
        }
        public static string GetOutcomeText()
        {
            return "عليه";
        }

    }
}
