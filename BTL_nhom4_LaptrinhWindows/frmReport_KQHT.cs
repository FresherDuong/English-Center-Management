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
    public partial class frmReport_KQHT : Form
    {
        public frmReport_KQHT()
        {
            InitializeComponent();
        }

        private void frmReport_KQHT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BTL_N04DataSet1_thongkediem.thongkediem' table. You can move, or remove it, as needed.
            //this.thongkediemTableAdapter.Fill(this.BTL_N04DataSet1_thongkediem.thongkediem,1,2);

            //this.reportViewer1.RefreshReport();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.thongkediemTableAdapter.Fill(this.BTL_N04DataSet1_thongkediem.thongkediem, 
                int.Parse(textBox1.Text),
                int.Parse(textBox2.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}
