using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DialogUnitity
    {
        private static string TxtFilter = "Text Files|*.txt;*.cs|All files (*.*)|*.*";
        private static string ImageFilter = "Image Files|*.BMP;*.bmp;*.JPG;*.jpg;*.GIF;*.gif;*.png|All File(*.*)|*.*";
        private static string ExcelFilter = "Excel Files|*.xlsx;*.xls|All File(*.*)|*.*";
        private static string WordFilter = "Word Files|*.docx;*.doc|All File(*.*)|*.*";
        private static string DvgFilter = "Dgv Files|*.dgv|All File(*.*)|*.*";
        private static string SqliteFilter = "Sqlite Files|*.db";
        private static string CSFilter = "C#类文件|*.cs";


        private static string SaveInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


        #region 打开文件对话框
        public static string DialogTextFile(string title)
        {
            return DialogUnitity.ShowOpenDialog(title, TxtFilter);
        }

        public static string DialogImageFile(string title)
        {
           return DialogUnitity.ShowOpenDialog(title, ImageFilter);
        }
        public static string DialogWordFile(string title)
        {
            return DialogUnitity.ShowOpenDialog(title, WordFilter);
        }
        public static string DialogExcelFile(string title)
        {
            return DialogUnitity.ShowOpenDialog(title, ExcelFilter);
        }
        public static string DialogDvgFile(string title)
        {
            return DialogUnitity.ShowOpenDialog(title, DvgFilter);
        }
        public static string DialogSqliteFile(string title)
        {
            return DialogUnitity.ShowOpenDialog(title, SqliteFilter);
        }
        public static string DialogCSFile(string title)
        {
            return DialogUnitity.ShowOpenDialog(title, CSFilter);
        }


        private static string ShowOpenDialog(string title, string filefilter)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = filefilter;
            dialog.Title = title;
            dialog.RestoreDirectory = true;
            dialog.FileName = string.Empty;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }
            else
            {
                return string.Empty;
            }


        }
        #endregion

        #region 保存对话框
        private static string ShowSaveDialog(string title, string filefilter)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = filefilter;
            dialog.Title = title;
            dialog.FileName = string.Empty;
            dialog.RestoreDirectory = true;
            if (!string.IsNullOrEmpty(SaveInitialDirectory))
            {
                dialog.InitialDirectory = SaveInitialDirectory;
            }
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        
        }

       
        public static string DialogSaveTextFile(string title)
        {
            return ShowSaveDialog(title, TxtFilter);
        }
        public static string DialogSaveDvgFile(string title)
        {
            return ShowSaveDialog(title, DvgFilter);
        }

        public static string DialogSaveWordFile(string title)
        {
            return ShowSaveDialog(title, WordFilter);
        }
        public static string DialogSaveSqliteFile(string title)
        {
            return ShowSaveDialog(title, SqliteFilter);
        }

        public static string DialogSaveCSFile(string title)
        {
            return ShowSaveDialog(title, CSFilter);
        }
       

        #endregion


        #region 打开文件夹对话框

        public static string DialogFolderBrowser()
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.Description = "请 您 选 需 要 的 文 件 夹";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            System.Windows.Forms.DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

    }
}
