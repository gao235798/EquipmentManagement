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
using EquipmentManagement.entity;

namespace EquipmentManagement.page.craftSetting.workEquStation
{
    public partial class ModelEdit : DevExpress.XtraEditors.XtraForm
    {
        DataTable station = new DataTable(); //工作站
        public ModelEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加工作站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addWorkStation_Click(object sender, EventArgs e)
        {
            station.Clear();
            if (stationNum.Text  !="")      //工作站个数不为空
            {
                int stationNums = Convert.ToInt32(stationNum.Text);
                for (int i = 1; i < stationNums+1; i++)
                {
                    station.Rows.Add(i,"工作站"+i);
                }
                workStationGrid.DataSource = station;
            }
        }

        private void ModelEdit_Load(object sender, EventArgs e)
        {   
            //初始化信息
            station.Columns.Add("id");
            station.Columns.Add("workStationName");
            station.Columns.Add("theSkills");
            station.Columns.Add("skillLevel");
            if (test.motoTypeCopy !="")
            {
                chooseOrder.Text = test.motoTypeCopy;
                stationNum.Text = "15";
                test.motoTypeCopy = "";
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            test.motoType = chooseOrder.Text;
            int selectNow = this.gridView11.GetSelectedRows()[0];
            test.workStation = this.gridView11.GetRowCellValue(selectNow, "workStationName").ToString(); 
            test.skill = this.gridView11.GetRowCellValue(selectNow, "theSkills").ToString();
            test.skillLevel = this.gridView11.GetRowCellValue(selectNow, "skillLevel").ToString();
            this.Close();
        }

        private void ModelEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}