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
using EquipmentManagement.tool;
using EquipmentManagement.entity;

namespace EquipmentManagement.page.production.错误选择页面
{
    public partial class workErr : DevExpress.XtraEditors.XtraForm
    {
        DataTable SelectErr = new DataTable();     //所选的id
        DataTable SelectErrInfo = new DataTable(); //所选的详细信息
        workErrDao workErrDao = new workErrDao();
        public workErr()
        {
            InitializeComponent();
        }

        private void workErr_Load(object sender, EventArgs e)
        {
            SelectErr.Columns.Add("err_id");
            string sql = "SELECT\n" +
                            "	a.err_id,\n" +
                            "	b.err_name,\n" +
                            "	b.model \n" +
                            "FROM\n" +
                            "	warning_work_err a\n" +
                            "	LEFT JOIN warning_err_info b ON a.err_id = b.id \n" +
                            "WHERE\n" +
                            "	a.work_id = '"+userEntity.workId +"' \n" +
                            "AND b.`status` ='Y'";
            if (data.selectTable(sql, "yl").Rows.Count <= 6)
            {
                cardView1.MaximumCardRows = 1;
                cardView1.OptionsBehavior.AutoHorzWidth = false;
            }
            errControl.DataSource = data.selectTable(sql, "yl");
        }
        /// <summary>
        /// 错误点击事件
        /// </summary>
        /// <param name="sender"></param>
        private void errControl_Click(object sender, EventArgs e)
        {
            int selectRow = cardView1.GetSelectedRows()[0];
            string err_id = cardView1.GetRowCellValue(selectRow, "err_id").ToString();
            if (SelectErr.Select("err_id ='"+ err_id +"'") .Length ==0)      //查询值是否在数据表中
            {
                SelectErr.Rows.Add(err_id);    //复制
                SelectErrInfo=workErrDao.errInfo(SelectErr);
                selectErrControl .DataSource= SelectErrInfo;
            }
        }
        /// <summary>
        /// 取消所选错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectErrControl_Click(object sender, EventArgs e)
        {
            int selectRow = cardView2.GetSelectedRows()[0];
            string id = cardView2.GetRowCellValue(selectRow, "id").ToString();
            SelectErrInfo.Rows.Remove(SelectErrInfo.Select("id ='" + id + "'")[0]);
            SelectErr.Rows.Remove(SelectErr.Select("err_id ='" + id + "'")[0]);
            selectErrControl.DataSource = SelectErrInfo;
        }
        /// <summary>
        /// 写入错误信息到数据库当中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void write_Click(object sender, EventArgs e)
        {
            string errIdsql = "";
            if (SelectErrInfo.Rows.Count ==0)
            {
                XtraMessageBox.Show("至少选择一项错误提交");
            }
            else
            {
                DateTime now = DateTime.Now;
                TimeSpan ts1 = DateTime.Now - userEntity.up_time;
                string proTime = ts1.TotalSeconds.ToString("0");

                for (int i = 0; i < SelectErrInfo.Rows.Count; i++)
                {
                    errIdsql += "('" + Guid.NewGuid() + "','" + userEntity.workId + "','" + SelectErrInfo.Rows[i][2] + "','" + now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + userEntity.id + "','" +
                        ""+userEntity.up_time.ToString("yyyy-MM-dd HH:mm:ss")+ "','"+ proTime+"','"+planEntity.lineInfoId+"','"+planEntity.orderId+"'),";
                }
                string insertId = "INSERT INTO `yele_okmes`.`warning_err_record` ( `id`, `work_id`, `err_id`, `dateline`, `user_id`, `done_time`, `pro_time`,line_id,order_id) " +
                                  "VALUES " + errIdsql.Remove(errIdsql.Length - 1, 1);
                if (data.update(insertId,"yl"))
                {
                    this.Close();
                }

            }
        }
    }
}