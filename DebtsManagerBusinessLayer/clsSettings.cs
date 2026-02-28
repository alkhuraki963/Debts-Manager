using DebtsManagerDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DebtsManagerBusinessLayer
{
    public class clsSettings
    {

        public static string GetNumberFormat()
        {
            return clsSettingsDataAccess.GetSetting("Number Format");
        }

        public static string GetCompanyName()
        {
            return clsSettingsDataAccess.GetSetting("Company Name");
        }

        public static string GetCompanyAddress()
        {
            return clsSettingsDataAccess.GetSetting("Company Address");
        }

        public static string GetCompanyPhone()
        {
            return clsSettingsDataAccess.GetSetting("Company Phone");
        }

        public static string GetCompanyLogo()
        {
            return clsSettingsDataAccess.GetSetting("Company Logo");
        }

        public static string GetLvAccountsViewType()
        {
            return clsSettingsDataAccess.GetSetting("ListViewAccountsViewType");
        }

        public static string GetIncomeText()
        {
            return clsSettingsDataAccess.GetSetting("Income Text");
        }

        public static string GetOutcomeText()
        {
            return clsSettingsDataAccess.GetSetting("Outcome Text");
        }

        public static string GetBackupFolder()
        {
            return clsSettingsDataAccess.GetSetting("Backup Folder");
        }


        public static bool UpdateNumberFormat(string NewFormat)
        {
            string[] allowedFormats = { "N2", "N3", "N4" };

            if (allowedFormats.Contains(NewFormat))
            {
                return clsSettingsDataAccess.UpdateSetting("Number Format", NewFormat);
            }

            return false;
        }

        public static bool UpdateLvAccountsViewType(string NewType)
        {
            // this method save the account list view type in Database (Tile,list,large icon, etc...)
            return clsSettingsDataAccess.UpdateSetting("ListViewAccountsViewType", NewType);
        }

        public static bool UpdateCompanyName(string NewName)
        {
            return clsSettingsDataAccess.UpdateSetting("Company Name", NewName);
        }

        public static bool UpdateCompanyAddress(string NewAddress)
        {
            return clsSettingsDataAccess.UpdateSetting("Company Address", NewAddress);
        }

        public static bool UpdateCompanyPhone(string NewPhone)
        {
            return clsSettingsDataAccess.UpdateSetting("Company Phone", NewPhone);
        }

        public static bool UpdateCompanyLogo(string NewLogoPath)
        {
            return clsSettingsDataAccess.UpdateSetting("Company Logo", NewLogoPath);
        }

        public static bool UpdateIncomeText(string NewIncomeText)
        {
            return clsSettingsDataAccess.UpdateSetting("Income Text", NewIncomeText);
        }

        public static bool UpdateOutcomeText(string NewOutcomeText)
        {
            return clsSettingsDataAccess.UpdateSetting("Outcome Text", NewOutcomeText);
        }

        public static bool UpdateBackupFolder(string NewBackupFolder)
        {
            return clsSettingsDataAccess.UpdateSetting("Backup Folder", NewBackupFolder);
        }


        public static bool SaveNewBackup()
        {
            return clsSettingsDataAccess.SaveBackup(GetBackupFolder());
        }

        public static bool RestoreDatabase(string backupPath)
        {
            return clsSettingsDataAccess.RestoreDatabase(backupPath);
        }
    }
}
