using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Repository
{
    public class MsgBox
    {
        public static System.Windows.Forms.TextBox MyTextBox { get; set; }

        public static DialogResult Infor(string inforText)
        {
            StringBuilder _StringBuilder = new StringBuilder();
            _StringBuilder.Append(DateTime.Now.ToString("dd HHmmss"));
            _StringBuilder.Append(" ");
            _StringBuilder.AppendLine(inforText);
          if(MyTextBox!=null)  MyTextBox.AppendText(_StringBuilder.ToString());
            return XtraMessageBox.Show(inforText, ConstKeyUnitity.CAPTIONTEXT, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult Warning(string inforText)
        {
            StringBuilder _StringBuilder = new StringBuilder();
            _StringBuilder.Append(DateTime.Now.ToString("dd HHmmss"));
            _StringBuilder.Append(" ");
            _StringBuilder.AppendLine(inforText);
          if(null!=MyTextBox)  MyTextBox.AppendText(_StringBuilder.ToString());
            return XtraMessageBox.Show(inforText, ConstKeyUnitity.CAPTIONTEXT, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Question(string inforText)
        {
            return XtraMessageBox.Show(inforText, ConstKeyUnitity.CAPTIONTEXT, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult Confirm(string inforText)
        {
            StringBuilder _StringBuilder = new StringBuilder();
            _StringBuilder.Append(DateTime.Now.ToString("dd HHmmss"));
            _StringBuilder.Append(" ");
            _StringBuilder.AppendLine(inforText);
            MyTextBox.AppendText(_StringBuilder.ToString());
            return XtraMessageBox.Show(inforText, ConstKeyUnitity.CAPTIONTEXT, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }


    }
}
