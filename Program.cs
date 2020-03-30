using EquipmentManagement.page.craftSetting.workEquStation;
using EquipmentManagement.page.login;
using EquipmentManagement.page.production.BeginProduction;
using EquipmentManagement.page.production.错误选择页面;
using System;
using System.Windows.Forms;

namespace EquipmentManagement
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
            Application.Run(new login());
        }
    }
}
