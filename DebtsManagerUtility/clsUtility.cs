using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtsManagerUtility
{
    public class clsUtility
    {

        public static void NotifyUser(int timeout, string title, string text)
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
    }
}
