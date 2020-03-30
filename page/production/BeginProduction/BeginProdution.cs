using DevExpress.XtraEditors;
using EquipmentManagement.entity;
using EquipmentManagement.page.craftSetting.workEquStation;
using EquipmentManagement.tool;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace EquipmentManagement.page.production.BeginProduction
{
    public partial class BeginProdution : DevExpress.XtraEditors.XtraForm
    {
        DataTable test = new DataTable(); //测试数据
        int elegHeartNumber = 0;         //电批心跳计数
        BeginProductionDao beginProductionDao = new BeginProductionDao();
        public BeginProdution()
        {
            InitializeComponent();
        }

        //生产详情
        private void productionDetial_Click(object sender, EventArgs e)
        {
            XtraForm1 form1 = new XtraForm1();
            form1.ShowDialog();
        }
         /// <summary>
         /// 呼叫线长
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ContactLineLength lineLength = new ContactLineLength();
            userEntity.up_time = DateTime.Now;
            AnDengTimer.Enabled = false;
            lineLength.ShowDialog();
            //if (lineLength.DialogResult == DialogResult.OK)
            //{
            //    AnDengTimer.Enabled = true;
            //}
        }
        
        /// <summary>
        /// 页面初始化生产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginProdution_Load(object sender, EventArgs e)
        {
            pageLode();
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        void pageLode()
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("串口打开失败");
                }
            }
            elegHeart.Enabled = true;     //启动定时器
            DataTable  workInfo = beginProductionDao.workInfo(userEntity.workId);
            gridControl1.DataSource = data.selectTable("SELECT	* FROM equ_eleg_working a left join warning_err_info b on a.err_id =b.id WHERE a.work_id = '" + userEntity.workId + "'  AND a. STATUS = 'init'  ORDER BY a.datetime", "yl");
            if (workInfo!=null && workInfo.Rows.Count !=0)
            {
                equ_number.Text = workInfo.Rows[0][6].ToString();  //pc机编号
                line_name.Text = workInfo.Rows[0][3].ToString();    //产线名称
                work_station.Text = workInfo.Rows[0][0].ToString();    //工位名称
                skill_name.Text = workInfo.Rows[0][7].ToString();    //工位名称
                skill_level.Text = workInfo.Rows[0][2].ToString();    //工位名称
                planCount.Text = planEntity.planCount;     //计划数量
                plantName.Text = beginProductionDao.plantName(userEntity.plantId);
                //用户信息
                DataTable userInfo = beginProductionDao.getUserInfo(userEntity.id);
                if (userInfo != null && userInfo.Rows.Count != 0)
                {
                    usernameT.Text = userInfo.Rows[0][0].ToString(); //姓名
                    userNoT.Text = userInfo.Rows[0][1].ToString();   //工号
                    workHoursT.Text = userInfo.Rows[0][2].ToString();    //工作总时长
                }
                else
                {
                    XtraMessageBox.Show("没有查到员工信息");
                }   
            }
            else
            {
                XtraMessageBox.Show("工位没有设置完成");
            }

        }
        /// <summary>
        /// 测试生产
        /// </summary>
        private void testProduction()
        {
            gridControl1.DataSource = null;
            gridControl1.Refresh();
            Thread.Sleep(1000);
        }

        private void testProduction1()
        {
            test.Clear();
            gridControl1.Refresh();
            ScrewErr screw = new ScrewErr();
            for (int i = 1; i < 6; i++)
            {
                gridControl1.Refresh();
                if (screw.DialogResult  ==DialogResult.OK)         //如果是继续
                {

                }
                else if(screw.DialogResult == DialogResult.No)
                {
                    XtraMessageBox.Show("上报信息成功");
                    screw.DialogResult = DialogResult.None;
                }
                else if (screw.DialogResult == DialogResult.Yes)
                {
                    screw.DialogResult = DialogResult.None;
                    break;
                }
                Thread.Sleep(1000);
            }
        }
        private void BeginProdution_FormClosing(object sender, FormClosingEventArgs e)
        {
            userEntity.dayTime = dayTimeT.Text;
            userEntity.total_time = workHoursT.Text;
            close close = new close();
            close.ShowDialog();
            if (close.DialogResult == DialogResult.OK)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 安灯计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnDengTimer_Tick(object sender, EventArgs e)
        {  
            string total_time = "";
            dayTimeT.Text=beginProductionDao.updatePunctualInfo(userEntity.id, out total_time); //上线工作时间
            workHoursT.Text = total_time;                                                       //总工时
        }
        /// <summary>
        /// 工艺视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ProcessVideo video = new ProcessVideo();
            video.ShowDialog();
        }

        private void pdfViewer1_Load(object sender, EventArgs e)
        {

        }
        //双击
        private void pdfViewer1_DoubleClick(object sender, EventArgs e)
        {
            PdfView pdf = new PdfView();
            pdf.ShowDialog();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 电批心跳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elegHeart_Tick(object sender, EventArgs e)
        {   
            if (elegHeartNumber>40)
            {
                elegStatusT.Text = "断开连接";
            }
            byte [] elegHeartAsk = beginProductionDao.ELE_Screwdriver_DataSend(254, 0xAA, 60625,20);    //心跳数据请求
            if (serialPort1.IsOpen)
            {
                elegHeartNumber++;
                serialPort1.Write(elegHeartAsk,0, elegHeartAsk.Length);
                elegHeart.Enabled = false;
            }
            else
            {
                elegStatusT.Text = "串口打开失败";
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] ReData_Temp = new byte[serialPort1.BytesToRead];
            Byte[] Screwdriver_Current_Data = new Byte[40];//定义电批数据内存
            this.Invoke(new Action(() =>     //匿名封装方法
            {
                if (ReData_Temp.Length==45)
                {
                  serialPort1.Read(ReData_Temp, 0, ReData_Temp.Length);              //数据收集
                  string taskNumber =   (ReData_Temp[3] * 256 + ReData_Temp[4]).ToString(); //任务号
                  string numberTurns = ((float)(ReData_Temp[6] * 256 + ReData_Temp[7]) / 100).ToString(); //圈数
                  string torsion =   (ReData_Temp[9] * 256 + ReData_Temp[10]).ToString();   //最大扭矩
                  string speed =   (ReData_Temp[11] * 256 + ReData_Temp[12]).ToString();  //总拧紧时间ms
                  string goperation_status =   (ReData_Temp[13] * 256 + ReData_Temp[14]).ToString();  //最终拧紧结果
                    switch (goperation_status)
                    {
                        case "19387":
                            goperation_status = "OK";
                            break;
                        case "19114":
                            goperation_status = "NG";
                            break;
                        case "19660":
                            goperation_status = "未完成";
                            break;
                    }
                    string err_id =   (ReData_Temp[29] * 256 + ReData_Temp[30]).ToString();  //最终拧紧结果
                  if (equEntity.eleg !=null && equEntity.eleg.Rows.Count!=0)
                  {

                    string sql = "INSERT INTO `yele_okmes`.`equ_eleg_working` ( `id`, `equ_id`, `equ_process_id`, `task_number`, `body_code`, `work_id`, `number_turns`, `torsion`, `speed`, `status`,operation_status, `err_id`, `datetime` )\n" +
                                            "VALUES\n" +
                                            "	( '"+Guid.NewGuid()+"', '"+ equEntity.eleg .Rows[0][0]+ "', '"+ Guid.NewGuid() + "', "+ taskNumber + ", '1', '"+userEntity.workId+"', '"+ numberTurns + "', '"+ torsion + "', "+ speed + ", 'init','"+ goperation_status + "'," +
                                            " "+ err_id + ", '"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"' )";
                    if (this.gridView1.RowCount !=0 )
                    {
                        string nowtaskNumber = this.gridView1.GetRowCellValue(this.gridView1.RowCount-1, "task_number").ToString();
                        if (nowtaskNumber != taskNumber)
                        {
                            if (data.update(sql, "yl"))
                            {
                                gridControl1.DataSource = data.selectTable("SELECT	* FROM equ_eleg_working a left join warning_err_info b on a.err_id =b.id WHERE a.work_id = '"+ userEntity.workId + "'  AND a. STATUS = 'init'  ORDER BY a.datetime", "yl");
                                gridControl1.Refresh();              //表格刷新
                                this.gridView1.FocusedRowHandle = this.gridView1.DataRowCount - 1; //焦点移动到最后一行
                            }
                        }
                    }
                    else
                    {
                        if (data.update(sql, "yl"))
                        {
                            gridControl1.DataSource = data.selectTable("select * from equ_eleg_working where work_id ='" + userEntity.workId + "'  and status  ='init' ORDER BY datetime", "yl");
                            gridControl1.Refresh();              //表格刷新
                            this.gridView1.FocusedRowHandle = this.gridView1.DataRowCount - 1; //焦点移动到最后一行
                        }
                    }
                  }
                  elegHeartNumber = 0;
                  elegHeart.Enabled = true;
                  elegStatusT.Text = "正常连接";
                }
            
            }));
        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = data.selectTable("SELECT	* FROM equ_eleg_working a left join warning_err_info b on a.err_id =b.id" +
                " WHERE a.work_id = '" + userEntity.workId + "' ORDER BY a.datetime desc", "yl");
        }
    }
}