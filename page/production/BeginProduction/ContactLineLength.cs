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
using EquipmentManagement.page.production.错误选择页面;

namespace EquipmentManagement.page.production.BeginProduction
{

    public partial class ContactLineLength : DevExpress.XtraEditors.XtraForm
    {
        BeginProductionDao BeginProductionDao = new BeginProductionDao();  //实例化
        public ContactLineLength()
        {
            InitializeComponent();
            secach.Enabled = true;
        }
        /// <summary>
        /// 发送错误数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactLineLength_Load(object sender, EventArgs e)
        {
            //  errCheck();
            icidT.Select();
        }
        void errCheck()
        {
            Byte[] severAck = BeginProductionDao.sendErrSign(0x03, 0x01, 0x01);  //发送心跳数据
            if (BeginProductionDao.checkSeverErrAck(severAck) != "")      //数据返回有问题
            {
                if (BeginProductionDao.checkSeverErrAck(severAck) == "重发异常数据")
                {
                    errCheck();                 //重新发送错误信息
                }
                else if (BeginProductionDao.checkSeverErrAck(severAck) == "数据不完整")
                {
                    errCheck();                //重新发送错误信息
                }
            }
        }
        /// <summary>
        /// 检测器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secach_Tick(object sender, EventArgs e)
        {
            byte[] Recive_data = new byte[1204];         //接收缓存数组
            Recive_data = BeginProductionDao.serch();
            if (Recive_data[0] != 0x00)                 //如果非空
            {
                secach.Enabled = false;
                this.Close();
            }
        }

        private void ContactLineLength_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void icidT_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                workErr workErr = new workErr();
                this.Hide();
                workErr.ShowDialog();
            }
        }
    }
}