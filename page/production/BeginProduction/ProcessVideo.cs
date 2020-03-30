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

namespace EquipmentManagement.page.production.BeginProduction
{
    public partial class ProcessVideo : DevExpress.XtraEditors.XtraForm
    {
        public ProcessVideo()
        {
            InitializeComponent();
        }

        private void ProcessVideo_Load(object sender, EventArgs e)
        {
            ProcessVideoPlay.URL = "G:\\pc项目\\设备上位机\\视频\\S2050007.MP4";
        }
    }
}