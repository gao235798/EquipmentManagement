using DevExpress.XtraEditors;
using EquipmentManagement.entity;
using EquipmentManagement.tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.page.login
{
    class LoginDao
    {
        /// <summary>
        ///  登陆检测
        /// </summary> workid:1;plantid:3;
        /// <param name="setInfo">配置信息</param>
        public string loginChack(string setInfo,string id)
        {
            string status = "";
            userEntity.id = id; //人员id
            string sql = "SELECT " +
                        "	u.id,u.name, r.code,u.password " +
                        "FROM " +
                        "	o_user u " +
                        "	LEFT JOIN o_user_role ur ON u.id = ur.user_id " +
                        "	LEFT JOIN o_role r ON ur.role_id = r.id  " +
                        "WHERE " +
                        "	u.id = '"+ id + "' and status ='Y'";
            DataTable userInfo = data.selectTable(sql,"yl");
            if (userInfo.Rows.Count !=0)
            {
                userEntity.workId = setInfo.Split(':')[1].Split(';')[0]; //工站id
                userEntity.plantId = setInfo.Split(':')[2].Split(';')[0]; //车间id
                userEntity.stationId = setInfo.Split(':')[3].Split(';')[0]; //工位id
                userEntity.username = userInfo.Rows[0][1].ToString();
                userEntity.code = userInfo.Rows[0][2].ToString();
                userEntity.password = userInfo.Rows[0][3].ToString();
                getLineInfo(userEntity.workId, userEntity.stationId);
                if (planEntity.orderId=="")
                {

                }
                else
                {
                    status = checkUserInfo();
                }
                if (userEntity.workId != "")
                {
                    sql =   "SELECT\n" +
                            "	a.equ_info_id,b.category,b.name,b.model,b.spec \n" +
                            "FROM\n" +
                            "	equ_useage_info a \n" +
                            "	LEFT JOIN equ_info b on a. equ_info_id = b.id\n" +
                            "WHERE\n" +
                            "	a.work_id = '"+ userEntity.workId + "'\n" +
                            "	and b.category ='eleg'";
                    equEntity.eleg = data.selectTable(sql, "yl"); //电批信息
                }
            }
            else
            {
                status = "用户信息找不到或用户信息已过期";
            }
            return status;
        }
        /// <summary>
        /// 获取产线信息
        /// </summary>
        /// <param name="work_id"></param>
        /// <param name="station_id"></param>
        void getLineInfo(string work_id,string station_id)
        {
            planEntity.lineInfoId = data.selectone("select line_id from warning_work_info where id = '"+ work_id + "'","yl");  //产线id
            string sql = "SELECT\n" +
                    "	a.order_no,\n" +
                    "	a.yield,\n" +
                    "	a.plan_time,\n" +
                    "	a.send_time,\n" +
                    "	a.id,\n" +
                    "	a.scheme_id,\n" +
                    "	b.process_id,\n" +
                    "	a.erp_order_detail_id,\n" +
                    "	a.id AS planid,\n" +
                    "	b.id AS plan_configID,\n" +
                    "	a.tag \n" +
                    "FROM\n" +
                    "	o_plan AS a\n" +
                    "	LEFT JOIN o_plan_conf AS b ON a.id = b.plan_id \n" +
                    "WHERE\n" +
                    "	b.line_id = '"+ station_id + "' \n" +
                    "	AND a.STATUS IN ( 'allot', 'done' ) \n" +
                    "	AND b.STATUS IN ( 'uplode', 'done' ) \n" +
                    "ORDER BY\n" +
                    "	a.plan_time";
            DataTable planInfo = data.selectTable(sql,"yl");
            if (planInfo.Rows.Count !=0)
            {
                planEntity.orderId = planInfo.Rows[0][7].ToString(); //订单id
                planEntity.orderNo = planInfo.Rows[0][0].ToString(); //订单号
                planEntity.planCount = planInfo.Rows[0][1].ToString(); //计划数量
                planEntity.planId = planInfo.Rows[0][8].ToString(); //计划id
            }
            else
            {
                XtraMessageBox.Show("计划未开始");
            }
        }
        /// <summary>
        /// 检测人员信息
        /// </summary>
        /// <returns></returns>
        string checkUserInfo()
        {
            string status = "";
            if (userEntity.code == "liner")
            {
                status = "work"; //设置页面
            }
            else if (userEntity.code == "line")
            {
                status = "setting"; //工作页面
            }
            else
            {
                status = "用户非法";
            }
            return status;
        }
    }
}
