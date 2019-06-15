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
    public partial class frmReport_DSSV : Form
    {
        public frmReport_DSSV()
        {
            InitializeComponent();
        }

        private void frmReport_DSSV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BTL_N04DataSet.thongkesinhvien' table. You can move, or remove it, as needed.
            //this.thongkesinhvienTableAdapter.Fill(this.BTL_N04DataSet.thongkesinhvien, 1);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.thongkesinhvienTableAdapter.Fill(this.BTL_N04DataSet.thongkesinhvien, int.Parse(textBox1.Text));
            this.reportViewer1.RefreshReport();
        }
    }
}
