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
    public partial class ucHocVien : UserControl
    {
        BindingSource hocvien = new BindingSource();

        public ucHocVien()
        {
            InitializeComponent();

            dtgvHocVien.DataSource = hocvien;
            loadDanhSachSinhVien();
            cboGioitinh.SelectedIndex = 0;

            Addbinding();
        }

        //void loadDanhSachSinhVien()
        //{
        //    hocvien.DataSource = HocvienDAO.Instance.LayDanhSachHocVien();
        //}

        void loadDanhSachSinhVien()
        {
            hocvien.DataSource = HocvienDAO.Instance.LayDanhSachHocVien();

            for (int i = 0; i < dtgvHocVien.Rows.Count; i++)
            {
                if (dtgvHocVien.Rows[i].Cells["id"].Value != null)
                {
                    int item = (int)dtgvHocVien.Rows[i].Cells["id"].Value;
                    HocvienDAO.Instance.LaySoTienConNo(item);
                }
            }

        }

        void Addbinding()
        {
            txtHoten.DataBindings.Add(new Binding("text", dtgvHocVien.DataSource, "hoten", true, DataSourceUpdateMode.Never));
            dtpNgaysinh.DataBindings.Add(new Binding("value", dtgvHocVien.DataSource, "ngaysinh", true, DataSourceUpdateMode.Never));
            txtDiachi.DataBindings.Add(new Binding("text", dtgvHocVien.DataSource, "diachi", true, DataSourceUpdateMode.Never));
            txtSoDienThoai1.DataBindings.Add(new Binding("text", dtgvHocVien.DataSource, "sodienthoai", true, DataSourceUpdateMode.Never));
            cboGioitinh.DataBindings.Add(new Binding("text", dtgvHocVien.DataSource, "gioitinh", true, DataSourceUpdateMode.Never));
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            loadDanhSachSinhVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try { 
            string hoten = txtHoten.Text;
            string ngaysinh = dtpNgaysinh.Value.ToString("MM/dd/yyyy");
            string diachi = txtDiachi.Text;
            string sodienthoai = txtSoDienThoai1.Text;
            string gioitinh = cboGioitinh.Text;

            
            
                if (HocvienDAO.Instance.ThemHocVien(hoten, gioitinh, ngaysinh, diachi, sodienthoai))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadDanhSachSinhVien();
        }

        #region empty
        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string hoten = txtHoten.Text;
            string ngaysinh = dtpNgaysinh.Value.ToString("MM/dd/yyyy");
            string diachi = txtDiachi.Text;
            string sodienthoai = txtSoDienThoai1.Text;
            string gioitinh = cboGioitinh.Text;
            int id = (int)dtgvHocVien.SelectedCells[0].OwningRow.Cells["id"].Value;


                if (HocvienDAO.Instance.SuaHocVien(id, hoten, ngaysinh, diachi, sodienthoai, gioitinh))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadDanhSachSinhVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvHocVien.SelectedCells[0].OwningRow.Cells["id"].Value;
            try
            {
                if (HocvienDAO.Instance.XoaHocVien(id))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadDanhSachSinhVien();
        }

        
        void Tim()
        {
            hocvien.DataSource = HocvienDAO.Instance.TimThongTinHocVien(txtHotensearch.Text, txtSdtsearch.Text);
        }

        private void txtHotensearch_TextChanged(object sender, EventArgs e)
        {
            Tim();
        }

        private void txtSdtsearch_TextChanged(object sender, EventArgs e)
        {
            Tim();
        }
    }
}
