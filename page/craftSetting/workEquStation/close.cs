using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using EquipmentManagement.entity;
using EquipmentManagement.tool;

namespace EquipmentManagement.page.craftSetting.workEquStation
{
    public partial class close : WaitForm
    {
        public close()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
        /// <summary>
        /// 继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 下班
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string sql = "update  equ_punctual_info set down_time ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',day_hours ='" + userEntity.dayTime.Remove(userEntity.dayTime.Length - 2, 2) + "',time_length ='" + userEntity.dayTime.Remove(userEntity.dayTime.Length - 2, 2) + "'" +
                        " where user_id =" + userEntity.id + " and down_time is null";
            string updateUserSql = "update equ_user set work_hours = '" +(Convert.ToInt32(userEntity.dayTime.Remove(userEntity.dayTime.Length - 2, 2)) +
                                                        Convert.ToInt32(userEntity.total_time.Remove(userEntity.total_time.Length - 2, 2))) + "' where  user_id ='" + userEntity.id + "'";
            if (data.update(sql,"yl") && data.update(updateUserSql, "yl"))
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void close_Load(object sender, EventArgs e)
        {
            labelControl1.Text = "尊敬的员工您好: \r\n今日工作时长 "+userEntity.dayTime+",\r\n是否结束当前 工作 ?";
        }
    }
}