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
using System.Threading;
using EquipmentManagement.page.production.BeginProduction;
using EquipmentManagement.entity;
using EquipmentManagement.tool;

namespace EquipmentManagement.page.craftSetting.workEquStation
{
    public partial class WorkEquStation : DevExpress.XtraEditors.XtraForm
    {
        int heartbeat = 0;        //心跳数据
        workEquStationDao workDao = new workEquStationDao();   //实例化
        int writeNumber = 0;                                   //下发条数

        public WorkEquStation()
        {
            InitializeComponent();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            openModelEdit();
        }

        private void copy_Click(object sender, EventArgs e)
        {
            test.motoTypeCopy = chooseOrder.Text + "-副本";
            openModelEdit();
        }


        private void add_Click(object sender, EventArgs e)
        {
            openModelEdit();
        }

        private void openModelEdit()
        {
            ModelEdit model = new ModelEdit();
            model.ShowDialog();
            if (model.DialogResult == DialogResult.OK)
            {
                chooseOrder.Text = test.motoType;
                chooseLine.Text = test.workStation;
                statrtTime.Text = test.skill;
                endTime.Text = test.skillLevel;
            }
        }
        // 防止闪屏
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void WorkEquStation_Load(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }
             pageInfoLode();
        }
        //上位主动发送数据(短数据)
        private void ELE_Screwdriver_DataSend(byte Screwdriver_Num, byte order, int addr, int Data_Size)
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
            ScrewSendTemp[7] = (Byte)(CRC16_Temp >> 8);  //CRC16高位在后 ScrewSendTemp[0] = Screwdriver_Num;          //控制器编号
                                                         // FE AA EF 4C 00 19 39 14                            
                                                         //发送数据
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(ScrewSendTemp, 0, ScrewSendTemp.Length);//写入缓存
            }
            else
            {
                serialPort1.Close();
                MessageBox.Show("串口未打开");
            }
        }
        //上位主动发送数据(查询设备编号)
        private void ELE_Screwdriver_(byte Screwdriver_Num)
        {
            Byte[] ScrewSendTemp = new Byte[8];       //建立临时字节数组对象
            int CRC16_Temp = 0;                       //校验临时值
           // Byte Address_H_Temp;                      //地址高字节
           // Byte Address_L_Temp;                      //地址低字节
           // Address_H_Temp = (Byte)(addr >> 8);
           // Address_L_Temp = (Byte)(addr);

            ScrewSendTemp[0] = Screwdriver_Num;          //控制器编号
            ScrewSendTemp[1] = 0xAA;                    //编号
            ScrewSendTemp[2] = 0xEF;           //地址高字节
            ScrewSendTemp[3] = 0x4C;           //地址低字节
            ScrewSendTemp[4] = 0x00;           //读取数据量高字节
            ScrewSendTemp[5] = 0x19;           //读取数据量低字节
            CRC16_Temp = workEquStationDao.CRC16_Check(ScrewSendTemp, ScrewSendTemp.Length - 2);  //CRC16校验
            ScrewSendTemp[6] = (Byte)CRC16_Temp;         //CRC16低位在前
            ScrewSendTemp[7] = (Byte)(CRC16_Temp >> 8);  //CRC16高位在后 ScrewSendTemp[0] = Screwdriver_Num;          //控制器编号
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(ScrewSendTemp, 0, ScrewSendTemp.Length);//写入缓存
            }
            else
            {
                serialPort1.Close();
                MessageBox.Show("串口未打开");
            }
        }
        /// <summary>
        /// 页面信息赋值
        /// </summary>
        void pageInfoLode()
        {
            string sql = "SELECT\n" +
                        "  b.category,\n" +
                        "  b.name,\n" +
                        "  b.service_time,\n" +
                        "  b.number,\n" +
                        "  b.time," +
                        "  b.model," +
                        "  b.spec," +
                        "  b.opera_times," +
                        "  b.calibration_time	\n" +
                        "FROM\n" +
                        "	equ_useage_info a\n" +
                        "	left join equ_info b on a.equ_info_id =b.id\n" +
                        "WHERE\n" +
                        "	a.work_id = '79b79af2-e691-4252-8b5f-20651a36a47a' \n" +
                        "	AND a.STATUS = 'in_use'";
            DataTable equInfo = data.selectTable(sql, "yl");
            if (equInfo!=null && equInfo.Rows.Count!=0)
            {
                for (int i = 0; i < equInfo.Rows.Count; i++)
                {
                    if (equInfo.Rows[i][0].ToString() =="pc")      //如果是电脑
                    {
                        pcDatetimeT.Text = equInfo.Rows[i][4].ToString();  //登记时间
                        pcNumberT.Text = equInfo.Rows[i][3].ToString();    //电脑编号
                    }
                    else if (equInfo.Rows[i][0].ToString() == "eleg") //如果是智能电批
                    {
                        edegTimeT.Text = equInfo.Rows[i][4].ToString();  //登记时间
                        elegNumberT.Text = equInfo.Rows[i][3].ToString();  //电批编号
                        elegServerTimeT.Text = equInfo.Rows[i][2].ToString();  //电批使用时间
                        elegModelT.Text = equInfo.Rows[i][5].ToString();  //电批型号
                        elegSpecT.Text = equInfo.Rows[i][6].ToString();  //电批规格
                        elegOperaTimes.Text = equInfo.Rows[i][7].ToString();  //电批动作次数
                        elegCalibrationTime.Text = equInfo.Rows[i][8].ToString();  //电批校准时间
                        //    byte hex =Convert.ToByte(string.Format("0x{0:X2}", Convert.ToInt32(equInfo.Rows[i][3])));
                        byte hex = Convert.ToByte(Convert.ToInt32(equInfo.Rows[i][3]) & 0xff); //当前电批编号
                        ELE_Screwdriver_DataSend(hex, 0xAA, 61260, 0x19);//发送查询电批编号 
                        heart.Enabled = true;  //启动定时器
                    }
                }
            }
        }
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "保存")
            {
                XtraMessageBox.Show("保存成功");
            }
            else if (e.Button.Caption == "编辑")
            {
                CraftEdit craftEdit = new CraftEdit();
                craftEdit.ShowDialog();
            }
            else if (e.Button.Caption == "新增")
            {
                gridView11.AddNewRow();
            }
        }
        /// <summary>
        /// 导入配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraOpenFileDialog openFile = new XtraOpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                craftNumber.Text = openFile.FileName;
                XtraMessageBox.Show(craftNumber.Text);
            }
            else
            {

            }
        }
        private void WorkEquStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close close = new close();
            //close.ShowDialog();
            //if (close.DialogResult == DialogResult.OK)
            //{
            //    System.Environment.Exit(0);
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //ELE_Screwdriver_DataSend(0x01, 0xAA, 61260, 0x19);//发送查询电批编号 
            BeginProdution begin = new BeginProdution();
            this.Hide();
            begin.ShowDialog();
            this.Close();
        }

        //写入电批配置
        private void writeSetting(int writeNumber)
        {
            int[,] screwdriver_Data= workDao.readSettingFile();  //解析本地数据
            byte[] ScrewSendTemp= workDao.ELE_Screwdriver_DataSend(4000 + writeNumber * 50, screwdriver_Data, writeNumber,Convert.ToByte(Convert.ToInt32(elegNumberT.Text) & 0xff));
            serialPort1.Write(ScrewSendTemp, 0, 109);//写入缓存
        }
        //端口接收方法
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] ReData_Temp = new byte[serialPort1.BytesToRead];
            this.Invoke(new Action(() =>     //匿名封装方法
            {
                if (ReData_Temp.Length > 0)
                {
                    if (label1.BackColor == Color.Green)     //如果已连接信息处理返回信息
                    {
                        if (ReData_Temp.Length >= 8)        //确保数据接收完整才能读取缓存的数据,防止缓存数据丢失
                        {
                            serialPort1.Read(ReData_Temp, 0, ReData_Temp.Length);
                            if (workEquStationDao.CRC16_Check(ReData_Temp, ReData_Temp.Length - 2) == (ReData_Temp[ReData_Temp.Length - 1] * 256 + ReData_Temp[ReData_Temp.Length - 2]))  //CRC16校验判断
                            {
                                if (writeNumber < 23)  //写入配置数据
                                {
                                    ++writeNumber;
                                    writeSetting(writeNumber);
                                    //System.Threading.Thread.Sleep(500);  //暂停500ms
                                }
                                else
                                {
                                    if (ReData_Temp[0].ToString() == elegNumberT .Text )  //验证电批编号
                                    {
                                        XtraMessageBox.Show("当前电批编号:" + ReData_Temp[0].ToString());
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("当前电批编号:"+ ReData_Temp[0].ToString() + "\r\n" +
                                                            "机器电批编号:"+ elegNumberT.Text + "\r\n" +
                                                            "配置编号不符");
                                    }
                                }
                            }
                            else
                            {
                                writeSetting(writeNumber);
                            }
                           // serialPort1.DiscardInBuffer();//清除接收缓存
                        }
                    }
                    else
                    {
                        label1.Text = "正常连接";
                        label1.BackColor = Color.Green;
                        heart.Enabled = false;  //关闭定时器
                        heartbeat = 0;
                        serialPort1.DiscardInBuffer();//清除接收缓存
                        writeSetting(writeNumber);
                    }
                }
                else
                {
                    label1.Text = "断开连接";
                    label1.BackColor = Color.Red;
                }
            }));
        }
        /// <summary>
        /// 心跳数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heart_Tick(object sender, EventArgs e)
        {
            if (heartbeat>10)
            {
                XtraMessageBox.Show("电批和电脑断开连接");
            }
            else
            {
                byte hex = Convert.ToByte(Convert.ToInt32(elegNumberT.Text) & 0xff);
                ELE_Screwdriver_DataSend(hex, 0xAA, 61260, 0x19);  // 发送心跳数据
                heartbeat++;
            }
        }
        
        //获取电批编号
        private void getElegNumber_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 254; i++)
            {
                ELE_Screwdriver_((byte)(i & 0xFF));//发送查询电批编号 
            }
        }
    }
}