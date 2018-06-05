using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace MyPorgamManage
{
    static class Program
    {
        /// <summary>
        /// 互斥量
        /// </summary>
        private static System.Threading.Mutex mutex;
        public static Entity.User_MST UserMST { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            mutex = new System.Threading.Mutex(true, "Erric.MyPorgamManage");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //Application.Run(new TableToWord());

            if (mutex.WaitOne(0, false))
            {
                Program.UserMST = null;
                Application.Run(new Frm.LogInFrm());
                if (Program.UserMST != null)
                {
                    Application.Run(new Frm_Main());
                }
            }
            else
            {
                //WCS.Utility.MsgBox.Warning("程序已经在运行！", "提示");
                Repository.MsgBox.Warning("程序已经在运行！");
                Application.Exit();
            }
            
        }
    }
}
