using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtsManagerUtility
{
    public class clsUtility
    {

        public static void NotifyUser(string title, string text,int timeout = 3000)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(timeout, title, text, ToolTipIcon.Info);
        }

        public static DialogResult ConfimeDeletionMessage(string ThingToDelete)
        {
            return MessageBox.Show($"سيتم حذف هذه {ThingToDelete} نهائياً، هل أنت متأكد؟", "تأكيد الحذف",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation
                ,MessageBoxDefaultButton.Button1,MessageBoxOptions.RtlReading);
        }

        public static DialogResult ErrorMessage(string title, string ErrorMessage)
        {
            return MessageBox.Show(ErrorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error
                , MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }

        public static string TranslateDay(string v)
        {
            v = v.ToLower();

            switch (v)
            {
                case "friday": return "الجمعة";
                case "saturday": return "السبت";
                case "sunday": return "الأحد";
                case "monday": return "الأثنين";
                case "tuesday": return "الثلاثاء";
                case "wednesday": return "الأربعاء";
                case "thursday": return "الخميس";
                default: return "";
            }
        }

        public static string CreateBackupName(string destinationFolder)
        {
            string AppName = "Debts-Manager";
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string BackupName = string.Empty;

            return Path.Combine(destinationFolder, $"{AppName}_{timestamp}.bak");
        }

        public static DialogResult ConfirmeRestoreBackup()
        {
            return MessageBox.Show($"سيتم فقدان اي بيانات لم يتم حفظها بنسخة احتياطية, هل تود فعلاً استرجاع هذه النسخة الأحتياطية؟", "تأكيد استعادة النسخة", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation
                , MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }

        public static bool IsEmail(string text)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(text);
                return addr.Address == text;
            }
            catch
            {
                return false;
            }
        }
    }
}
