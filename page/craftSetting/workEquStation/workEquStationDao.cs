using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.page.craftSetting.workEquStation
{
    class workEquStationDao
    {
       
        //CRC16校验
        public static int CRC16_Check(Byte[] puchMsg, int Length)
        {
            int i, j;
            int CRC16 = 0xffff;

            for (i = 0; i < Length; i++)
            {
                CRC16 ^= puchMsg[i];

                for (j = 0; j < 8; j++)
                {
                    if ((CRC16 & 0x01) != 0)
                    {
                        CRC16 >>= 1;
                        CRC16 ^= 0xA001;
                    }
                    else
                    {
                        CRC16 >>= 1;
                    }
                }
            }
            return CRC16;
        }
        //读取配置文件
        public int[,] readSettingFile()
        {
            int[,] Screwdriver_Data = new int[24, 50];//定义电批数据内存
            string ID = File.ReadAllText("G:\\pc项目\\设备上位机\\配置文件\\11.Tlst");                   //读取文件
            string[] IDArrayTemp = ID.Split(new string[] { "\r\n\0" }, StringSplitOptions.None); //分割\r\n\0
            for (int j = 0; j < 24; j++)//储存24组数据
            {
                int b;
                int a = j * 50 + 2;
                for (int i = 0; i < 50; i++)
                {
                    if (IDArrayTemp[a + i].Split('=')[1] != "")
                    {
                        Screwdriver_Data[j, i] = Convert.ToInt32(IDArrayTemp[a + i].Split('=')[1]);//string转int类型                        
                    }
                }
            }
            return Screwdriver_Data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr">起始位置</param>
        /// <param name="Screwdriver_Data">数据集合</param>
        /// <param name="Data_Group">当前数据组</param>
        /// <param name="elegNumber">控制器编号</param>
        /// <returns></returns>
        public byte[] ELE_Screwdriver_DataSend(int addr, int[,] Screwdriver_Data, int Data_Group,byte elegNumber)
        {
            Byte[] ScrewSendTemp = new Byte[109];     //建立临时字节数组对象
            Byte Drive_Controller_Type = elegNumber;        //驱动控制器型号
            Byte Drive_Read = 0xAA;                   //读取标志
            Byte Batch_Write = 0xCC;                  //批写标志           

            Byte Address_H_Temp;                      //地址高字节
            Byte Address_L_Temp;                      //地址低字节
            int CRC16_Temp = 0;                       //校验临时值

            Address_H_Temp = (Byte)(addr >> 8);
            Address_L_Temp = (Byte)(addr);

            ScrewSendTemp[0] = Drive_Controller_Type;//控制器型号
            ScrewSendTemp[1] = Batch_Write;          //批写标志
            ScrewSendTemp[2] = Address_H_Temp;       //地址高字节
            ScrewSendTemp[3] = Address_L_Temp;       //地址低字节
            ScrewSendTemp[4] = 0x00;                 //发送数据量
            ScrewSendTemp[5] = 0x32;                 //发送数据量
            ScrewSendTemp[6] = 0x64;                 //发送数据字节数

            for (int i = 0; i < 50; i++)
            {
                ScrewSendTemp[7 + 2 * i] = (Byte)(Screwdriver_Data[Data_Group, i] / 256);//高位在前
                ScrewSendTemp[8 + 2 * i] = (Byte)(Screwdriver_Data[Data_Group, i]);      //低位在后
            }
            CRC16_Temp = CRC16_Check(ScrewSendTemp, 107);//CRC16校验
            ScrewSendTemp[107] = (Byte)CRC16_Temp;        //CRC16低位在前
            ScrewSendTemp[108] = (Byte)(CRC16_Temp >> 8); //CRC16高位在后
            return ScrewSendTemp;
            
        }
    }
}
