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
    public partial class BeginProdution : DevExpress.XtraEditors.XtraForm
    {
        public BeginProdution()
        {
            InitializeComponent();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }


        //生产详情
        private void productionDetial_Click(object sender, EventArgs e)
        {
            XtraForm1 form1 = new XtraForm1();
            form1.ShowDialog();
        }
    }
}