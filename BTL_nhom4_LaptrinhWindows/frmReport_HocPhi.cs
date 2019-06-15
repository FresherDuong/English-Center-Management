using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom4_LaptrinhWindows
{
    public partial class frmReport_HocPhi : Form
    {
        public frmReport_HocPhi()
        {
            InitializeComponent();
        }

        private void frmReport_HocPhi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BTL_N04DataSet1_thongkehocphi.thongkehocphi' table. You can move, or remove it, as needed.
            this.thongkehocphiTableAdapter.Fill(this.BTL_N04DataSet1_thongkehocphi.thongkehocphi,1);

            this.reportViewer1.RefreshReport();
        }
    }
}
