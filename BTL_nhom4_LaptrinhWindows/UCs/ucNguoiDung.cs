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
    public partial class ucNguoiDung : UserControl
    {
        BindingSource nguoidung = new BindingSource();
        public ucNguoiDung()
        {
            InitializeComponent();
            dtgvNguoidung.DataSource = nguoidung;
            load();
            cboGioiTinh.SelectedIndex = 0;
            cboQuyen.SelectedIndex = 0;
            Addbinding();
        }
        void load()
        {
            loadDanhSachNguoiDung();
            loadDanhSachQuyen();
        }

        private void loadDanhSachQuyen()
        {
            cboQuyenSearch.DataSource= cboQuyen.DataSource=TaiKhoanDAO.Instance.LayDanhSachQuyen();
            cboQuyenSearch.DisplayMember = "quyen";
            cboQuyen.DisplayMember = "quyen";
            cboQuyenSearch.SelectedIndex = -1;
        }
        private void Addbinding()
        {
            txtTenDangNhap.DataBindings.Add(new Binding("text", dtgvNguoidung.DataSource, "tendangnhap", true, DataSourceUpdateMode.Never));
            txtTenHienThi.DataBindings.Add(new Binding("text", dtgvNguoidung.DataSource, "hoten", true, DataSourceUpdateMode.Never));
            cboGioiTinh.DataBindings.Add(new Binding("text", dtgvNguoidung.DataSource, "gioitinh", true, DataSourceUpdateMode.Never));
            cboQuyen.DataBindings.Add(new Binding("text", dtgvNguoidung.DataSource, "quyen", true, DataSourceUpdateMode.Never));
            
        }

        private void loadDanhSachNguoiDung()
        {
            nguoidung.DataSource = TaiKhoanDAO.Instance.LayDanhSachNguoiDung();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tendangnhap = txtTenDangNhap.Text;
            string tenhienthi = txtTenHienThi.Text;
            string gioitinh = cboGioiTinh.Text;
            string quyen = cboQuyen.Text;


                if (TaiKhoanDAO.Instance.ThemNguoiDung(tendangnhap, tenhienthi, gioitinh, quyen))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string tendangnhap = txtTenDangNhap.Text;
            string tenhienthi = txtTenHienThi.Text;
            string gioitinh = cboGioiTinh.Text;
            string quyen = cboQuyen.Text;


                if (TaiKhoanDAO.Instance.SuaNguoiDung(tendangnhap, tenhienthi, gioitinh, quyen))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tendangnhap = dtgvNguoidung.SelectedCells[0].OwningRow.Cells["tendangnhap"].Value.ToString();

            try
            {
                if (TaiKhoanDAO.Instance.XoaNguoiDung(tendangnhap))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            loadDanhSachNguoiDung();
        }
        void Tim()
        {
            nguoidung.DataSource = TaiKhoanDAO.Instance.TimThongNguoidung(cboQuyenSearch.Text, txtTenDangNhapSearch.Text);
        }

        private void cboQuyenSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboQuyen.SelectedIndex!=-1)
            {
                Tim();
            }
            else
            {
                loadDanhSachNguoiDung();
            }
        }

        private void txtTenDangNhapSearch_TextChanged(object sender, EventArgs e)
        {
            Tim();
        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }
    }
}
