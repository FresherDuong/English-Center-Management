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
    public partial class frmReport_HocPhi_New : Form
    {
        public frmReport_HocPhi_New()
        {
            InitializeComponent();
        }

        private void frmReport_HocPhi_New_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BTL_N04DataSet1_NhacNhoDongTien.NhacNhoDongTien' table. You can move, or remove it, as needed.
            this.NhacNhoDongTienTableAdapter.Fill(this.BTL_N04DataSet1_NhacNhoDongTien.NhacNhoDongTien,0,700);
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e) //Reset
        {
            this.NhacNhoDongTienTableAdapter.Fill(this.BTL_N04DataSet1_NhacNhoDongTien.NhacNhoDongTien, 0, 700);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                this.NhacNhoDongTienTableAdapter.Fill(this.BTL_N04DataSet1_NhacNhoDongTien.NhacNhoDongTien, 0, 32);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton2.Checked == true)
            {
                this.NhacNhoDongTienTableAdapter.Fill(this.BTL_N04DataSet1_NhacNhoDongTien.NhacNhoDongTien, 32, 63);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton3.Checked == true)
            {
                this.NhacNhoDongTienTableAdapter.Fill(this.BTL_N04DataSet1_NhacNhoDongTien.NhacNhoDongTien, 63, 700);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
