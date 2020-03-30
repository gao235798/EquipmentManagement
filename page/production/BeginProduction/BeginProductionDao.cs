using EquipmentManagement.entity;
using EquipmentManagement.page.craftSetting.workEquStation;
using EquipmentManagement.tool;
using System;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace EquipmentManagement.page.production.BeginProduction
{
    class BeginProductionDao
    {
        static string Send_IP = "192.168.1.183";               //发送IP
        IPEndPoint send_ipep = new IPEndPoint(IPAddress.Parse(Send_IP), 9050);
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//创建一个Socket对象
        /// <summary>
        /// CrC8校验
        /// </summary>
        /// <param name="data"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte Crc8Check(Byte[] data, int len)
        {
            byte crc = 0;
            for (int j = 0; j < len; j++)
            {
                crc ^= data[j];
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x01) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0x8c;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return crc;
        }
         /// <summary>
         /// 发送心跳数据
         /// </summary>
         /// <param name="plate_no">车间号</param>
         /// <param name="line_no"> 线体号</param>
         /// <param name="work_no"> 工位号</param>
        public  byte[] sendHeartRate(byte plate_no, byte line_no, byte work_no)
        {
            byte[] data = new byte[12];//定义一个数组用来做数据的缓冲区
            data[0] = 0xA5;       //帧头
            data[1] = 0x00;
            data[2] = plate_no;
            data[3] = line_no;
            data[4] = work_no;
            data[5] = 0x00;
            data[6] = 0x00;
            data[11] = BeginProductionDao.Crc8Check(data, data.Length - 1);
            try
            {
                server.SendTo(data, data.Length, SocketFlags.None, send_ipep);//将数据发送到指定的服务器
                IPEndPoint sender1 = new IPEndPoint(IPAddress.Any, 0);//定义要发送的计算机的地址 IPAddress.Any位本机IP
                EndPoint Remote = (EndPoint)(sender1);
                data = new byte[1024];
                int recv = server.ReceiveFrom(data, ref Remote);//接收来自服务器的数据
            }
            catch (Exception)
            {
                data[0] = 0x10;
            }
            return data;         //返回服务器Ack
        }

        /// <summary>
        /// 发送呼叫线长信号
        /// </summary>
        /// <param name="plate_no">车间号</param>
        /// <param name="line_no"> 线体号</param>
        /// <param name="work_no"> 工位号</param>
        public  byte[] sendErrSign(byte plate_no, byte line_no, byte work_no)
        {
            byte[] data = new byte[12];//定义一个数组用来做数据的缓冲区
            data[0] = 0xA5;       //帧头
            data[1] = 0x00;
            data[2] = plate_no;
            data[3] = line_no;
            data[4] = work_no;
            data[5] = 0x55;
            data[6] = 0x01;
            data[11] = BeginProductionDao.Crc8Check(data, data.Length - 1);
            try
            {
                server.SendTo(data, data.Length, SocketFlags.None, send_ipep);//将数据发送到指定的服务器
                IPEndPoint sender1 = new IPEndPoint(IPAddress.Any, 0);        //定义要发送的计算机的地址 IPAddress.Any位本机IP
                EndPoint Remote = (EndPoint)(sender1);
                data = new byte[1024];
                int recv = server.ReceiveFrom(data, ref Remote);               //接收来自服务器的数据
            }
            catch (Exception)
            {
                data[0] = 0x10;
            }
            return data;         //返回服务器Ack
        }
        /// <summary>
        ///  处理心跳包
        /// </summary>
        /// <param name="Ack"></param>
        /// <returns></returns>
        public  string checkSeverAck(Byte[] Ack)
        {
            string status = "";
            if (Ack[6] == Crc8Check(Ack,6))  //CrC8校验
            {
                if (Ack[5] == 0x01)        
                {
                    status = "重发心跳包";
                }
            }
            else
            {
                   status = "数据不完整";
            }
            return status;
        }
        
        /// <summary>
        ///  处理错误心跳包
        /// </summary>
        /// <param name="Ack"></param>
        /// <returns></returns>
        public  string checkSeverErrAck(Byte[] Ack)
        {
            string status = "";
            if (Ack[6] == Crc8Check(Ack, 6)) //CrC8校验
            {
                if (Ack[5] == 0x03)        
                {
                    status = "重发异常数据";
                }
            }
            else
            {
                   status = "数据不完整";
            }
            return status;
        }
        /// <summary>
        /// 检测程序
        /// </summary>
        /// <returns></returns>
        public  byte[] serch()
        {
            byte[] data = new byte[50];//定义一个数组用来做数据的缓冲区
            if (server.Available>0)  
            {
                IPEndPoint sender1 = new IPEndPoint(IPAddress.Any, 0);//定义要发送的计算机的地址 IPAddress.Any位本机IP
                EndPoint Remote = (EndPoint)(sender1);
                data = new byte[1024];
                int recv = server.ReceiveFrom(data, ref Remote);//接收来自服务器的数据
            }
            return data;
        }
        /// <summary>
        ///  返回页面信息
        /// </summary>
        /// <param name="work_id"> 工位id</param>
        /// <returns></returns>
        public DataTable workInfo(string work_id)
        {
            string sql = "SELECT\n" +
                        "	wi.work_info,\n" +
                        "	wi.id as wi_id,\n" +
                        "	wi.skill_level,\n" +
                        "	wl.name,\n" +
                        "	wl.id  as wl_id, \n" +
                        "	equ.id  as equ_id ,\n" +
                        "	equ.number ,\n" +
                        "	skill.name as skill_name\n" +
                        "FROM\n" +
                        "	equ_useage_info us \n" +
                        "	left join warning_work_info wi  on us.work_id  = wi.id\n" +
                        "	left join warning_line_property wl on us.line_id = wl.id\n" +
                        "	left join equ_info  equ on us.equ_info_id = equ.id\n" +
                        "  left join equ_skill skill on wi.skill_id = skill_id	\n" +
                        "WHERE\n" +
                        "	us.work_id = '"+ work_id + "'\n" +
                        "	and equ.category ='pc'";
            return data.selectTable(sql, "yl");
        }
        /// <summary>
        /// 获取产线名称
        /// </summary>
        /// <param name="plant_id"></param>
        /// <returns></returns>
        public string plantName( string plant_id)
        {
            return data.selectone("select name from o_line where id = '"+ plant_id + "'","yl");
        }
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserInfo(string user_id)
        {
            return data.selectTable("select name,user_no,work_hours from equ_user where user_id ='"+ user_id + "'","yl");
        }
        /// <summary>
        /// 更新打卡信息
        /// </summary>
        /// <param name="user_id">员工id</param>
        /// <returns></returns>
        public string  updatePunctualInfo(string user_id,out string total_time)
        {
            string work_time = "";   //当前工作时间
           // string total_time = "";  //工作总时间
            string insertSql = "";  //写入打卡信息
            if (data.selectone("select work_hours from equ_user where user_id ='"+ user_id + "'","yl")=="")
            {
                total_time = "0";
            }
            else
            {
                total_time = data.selectone("select work_hours from equ_user where user_id ='" + user_id + "'", "yl")+"分钟";
            }
            string sql = "select count(*) from  equ_punctual_info where datatime like '"+DateTime.Now.ToString("yyyy-MM-dd")+"%' and user_id ='"+ user_id + "' and down_time is null";
            if (data.selectone(sql, "yl") == "0")        //写入打卡信息
            {
                insertSql = "INSERT INTO `yele_okmes`.`equ_punctual_info`( `work_id`, `up_time`, `down_time`, `user_id`, `day_hours`, `totol_hours`, `datatime`) " +
                                                                                  "VALUES ('" + userEntity.workId + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', NULL, " + user_id + ", 0, " + total_time.Remove(total_time.Length-2,2) + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                if (data.update(insertSql,"yl"))
                {
                    work_time = "1分钟";
                }
            }
            else      //更新当前工作时间
            {
                string upTime = data.selectone("select up_time from equ_punctual_info where user_id ='" + user_id + "' and  datatime like '" + DateTime.Now.ToString("yyyy-MM-dd") + "%' and down_time is null","yl");
                TimeSpan ts1 = DateTime.Now - Convert.ToDateTime(upTime);
                work_time = ts1.TotalMinutes.ToString("0") + "分钟";
            }
            return work_time;
        }
        //#region  获取ic卡信息
        //    public string getIcidInfo(string icid)
        //    {
        //        string sql = "SELECT\n" +
        //                        "	b.name as username,\n" +
        //                        "  d.`code`	\n" +
        //                        "FROM\n" +
        //                        "	equ_user a\n" +
        //                        "	left join o_user b on a.user_id = b.id \n" +
        //                        "	left join o_user_role c on b.id = c.user_id\n" +
        //                        "	left join o_role  d  on c.role_id = d.id\n" +
        //                        "WHERE\n" +
        //                        "	a.icid = '21053826'";
        //    }
        //    #endregion
        public  byte[] ELE_Screwdriver_DataSend(byte Screwdriver_Num, byte order, int addr, int Data_Size)
        {
            Byte[] ScrewSendTemp = new Byte[8];       //建立临时字节数组对象
            int CRC16_Temp = 0;                       //校验临时值
            Byte Address_H_Temp;                      //地址高字节
            Byte Address_L_Temp;                      //地址低字节
            Address_H_Temp = (Byte)(addr >> 8);
            Address_L_Temp = (Byte)(addr);

            ScrewSendTemp[0] = Screwdriver_Num;          //控制器编号
            ScrewSendTemp[1] = order;                    //编号
            ScrewSendTemp[2] = Address_H_Temp;           //地址高字节
            ScrewSendTemp[3] = Address_L_Temp;           //地址低字节
            ScrewSendTemp[4] = (Byte)(Data_Size / 256);  //读取数据量高字节
            ScrewSendTemp[5] = (Byte)Data_Size;          //读取数据量低字节
            CRC16_Temp = workEquStationDao.CRC16_Check(ScrewSendTemp, ScrewSendTemp.Length - 2);  //CRC16校验
            ScrewSendTemp[6] = (Byte)CRC16_Temp;         //CRC16低位在前
            ScrewSendTemp[7] = (Byte)(CRC16_Temp >> 8);  //CRC16高位在后

            return ScrewSendTemp;
        } 
    }
}
