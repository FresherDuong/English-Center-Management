using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_nhom4_LaptrinhWindows.DAO;

namespace BTL_nhom4_LaptrinhWindows.UCs
{
    public partial class ucThoiGianHoc : UserControl
    {
        BindingSource thoigian = new BindingSource();
       

        public ucThoiGianHoc()
        {
            InitializeComponent();
            dtgvLichhoc.DataSource = thoigian;
            load();
            Addbinding();
            loadComboBox();
        }
        void Addbinding()
        { 
            txtBuoitrongtuan1.DataBindings.Add(new Binding("text", dtgvLichhoc.DataSource, "thu", true, DataSourceUpdateMode.Never));
            txtCahoc2.DataBindings.Add(new Binding("text", dtgvLichhoc.DataSource, "ca", true, DataSourceUpdateMode.Never));
        }
        void load()
        {
            thoigian.DataSource = ThoigianDAO.Instance.LayDanhSachThoiGian();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //bool ThoigianhocDao = false;
                if (!ThoigianDAO.Instance.ThemThoiGian(txtBuoitrongtuan1.Text, txtCahoc2.Text))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dtgvLichhoc.SelectedCells[0].OwningRow.Cells["id"].Value;
                if (!ThoigianDAO.Instance.SuaLich(txtBuoitrongtuan1.Text, txtCahoc2.Text, id))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dtgvLichhoc.SelectedCells[0].OwningRow.Cells["id"].Value;
                if (!ThoigianDAO.Instance.XoaLich(id))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        void loadComboBox()
        {
            txtBuoitrongtuan1.Items.Add("Thứ 2");
            txtBuoitrongtuan1.Items.Add("Thứ 3");
            txtBuoitrongtuan1.Items.Add("Thứ 4");
            txtBuoitrongtuan1.Items.Add("Thứ 5");
            txtBuoitrongtuan1.Items.Add("Thứ 6");
            txtBuoitrongtuan1.Items.Add("Thứ 7");
            txtBuoitrongtuan1.Items.Add("Chủ nhật");

            txtCahoc2.Items.Add("1");
            txtCahoc2.Items.Add("2");
            txtCahoc2.Items.Add("3");
            txtCahoc2.Items.Add("4");
        }
    }
}
