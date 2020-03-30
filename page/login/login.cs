using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EquipmentManagement.page.production.BeginProduction;
using EquipmentManagement.page.craftSetting.workEquStation;
using System.IO;

namespace EquipmentManagement.page.login
{
    public partial class login : DevExpress.XtraEditors.XtraForm
    {
        LoginDao LoginDao = new LoginDao();
        public static String linePath = System.Windows.Forms.Application.StartupPath;    //产线id    
        string setInfo = "";  //配置信息
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            string settingFile = System.AppDomain.CurrentDomain.BaseDirectory+"\\setting\\workStation.txt"; //配置文件路径
            setInfo = File.ReadAllText(settingFile);                   //读取文件
            people.Select();   //焦点部署

        }
 
        private void people_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string status = LoginDao.loginChack(setInfo, people.Text);
                loginMethod(status);
            }
        }

        private void loginMethod(string status)
        {
            if (status == "work")       //正常运行
            {
                BeginProdution begin = new BeginProdution();
                this.Hide();
                begin.ShowDialog();
               
            }
            else if (status == "setting") //设置页面
            {
                WorkEquStation work = new WorkEquStation();
                this.Hide();
                work.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show(status,"警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}