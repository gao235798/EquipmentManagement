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

namespace EquipmentManagement.page.craftSetting.workEquStation
{
    public partial class CraftEdit : DevExpress.XtraEditors.XtraForm
    {
        public CraftEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 页面初始化信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CraftEdit_Load(object sender, EventArgs e)
        {
            DataTable craft = new DataTable();
            craft.Columns.Add("equ_model", typeof(string)); 
            craft.Columns.Add("craft_edit", typeof(string));
            craft.Columns.Add("equ_type", typeof(string));
            craft.Columns.Add("tag", typeof(string));
            craft.Rows.Add("机械手");
            craft.Rows.Add("智能电批");
            craft.Rows.Add("供料机");
            craft.Rows.Add("视觉传感器");
            gridControl1.DataSource = craft;
        }
    }
}