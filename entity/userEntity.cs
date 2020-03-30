using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.entity
{
    class userEntity
    {
        public static String username; //姓名
        public static String id;       
        public static String code;    //职称
        public static String password;  //密码
        public static String workId;  //工站id
        public static String plantId;  //车间id
        public static String stationId;  //工位id
        public static String dayTime;  //当天工作时间
        public static String total_time;  //当前总工作时间
        public static DateTime up_time;   //呼叫线长时间
    }
}
