using EquipmentManagement.tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.page.production.错误选择页面
{
    class workErrDao
    {
        /// <summary>
        /// 查询错误id
        /// </summary>
        /// <param name="err_id"></param>
        /// <returns></returns>
        public DataTable errInfo(DataTable err_id)
        {
            string sql = "";
            for (int i = 0; i < err_id.Rows.Count; i++)
            {
                sql += err_id.Rows[i][0] + ",";
            }
            return data.selectTable("select err_name,model,id from warning_err_info where id in (" + sql.Remove(sql.Length-1,1)+")","yl");
        }
    }
}
