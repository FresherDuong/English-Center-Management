using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_nhom4_LaptrinhWindows;
using BTL_nhom4_LaptrinhWindows.DAO;

namespace BTL_nhom4_LaptrinhWindows.UCs
{
    public partial class ucGiangVien : UserControl
    {
        BindingSource giaovien = new BindingSource();
        public ucGiangVien()
        {
            InitializeComponent();
            dtgvGiangVien.DataSource = giaovien;
            LoadDanhSachGiaoVien();
            loadcboLoaiGiaoVien();
            Addbinding();
        }
        void Addbinding()
        {
            txtHoten.DataBindings.Add(new Binding("text", dtgvGiangVien.DataSource, "hoten", true, DataSourceUpdateMode.Never));
            dtpNgaysinh.DataBindings.Add(new Binding("value", dtgvGiangVien.DataSource, "ngaysinh", true, DataSourceUpdateMode.Never));
            txtDiachi.DataBindings.Add(new Binding("text", dtgvGiangVien.DataSource, "diachi", true, DataSourceUpdateMode.Never));
            txtSoDienThoai1.DataBindings.Add(new Binding("text", dtgvGiangVien.DataSource, "sodienthoai", true, DataSourceUpdateMode.Never));
            txtPhanLoai.DataBindings.Add(new Binding("text", dtgvGiangVien.DataSource, "phanloai", true, DataSourceUpdateMode.Never));
        }
       
        void LoadDanhSachGiaoVien()
        {
            giaovien.DataSource = GiaoVienDAO.Instance.LayDanhSachGiaoVien();
        }
        void loadcboLoaiGiaoVien()
        {
            cboPhanLoaiSearch.DataSource = GiaoVienDAO.Instance.LayDanhSachLoaiGiaoVien();
           
            cboPhanLoaiSearch.DisplayMember = "phanloai";
            cboPhanLoaiSearch.SelectedIndex = -1;

        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string hoten = txtHoten.Text;
            string ngaysinh = dtpNgaysinh.Value.ToString("MM/dd/yyyy");
            string diachi = txtDiachi.Text;
            string sodienthoai = txtSoDienThoai1.Text;
            string phanloai = txtPhanLoai.Text;

            
                if (GiaoVienDAO.Instance.ThemGiaoVien(hoten, ngaysinh, diachi, sodienthoai, phanloai))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadDanhSachGiaoVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string hoten = txtHoten.Text;
            string ngaysinh = dtpNgaysinh.Value.ToString("MM/dd/yyyy");
            string diachi = txtDiachi.Text;
            string sodienthoai = txtSoDienThoai1.Text;
            string phanloai = txtPhanLoai.Text;
            int id = (int)dtgvGiangVien.SelectedCells[0].OwningRow.Cells["id"].Value;

            
                if (GiaoVienDAO.Instance.SuaGiaoVien(id, hoten, ngaysinh, diachi, sodienthoai, phanloai))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadDanhSachGiaoVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvGiangVien.SelectedCells[0].OwningRow.Cells["id"].Value;

            try
            {
                if (GiaoVienDAO.Instance.XoaGiaoVien(id))
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadDanhSachGiaoVien();
        }

        void Tim()
        {
            string loai = cboPhanLoaiSearch.Text;
            string ten = txtHotenSearch.Text;
            giaovien.DataSource = GiaoVienDAO.Instance.TimThongTinGiangVien(loai, ten);
        }
 

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadDanhSachGiaoVien();
        }

        #region empty
        private void cboPhanLoaiSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhanLoaiSearch.SelectedIndex != -1)
            {
                Tim();
            }
            else
            {
                LoadDanhSachGiaoVien();
            }
        }

        private void txtHotenSearch_TextChanged(object sender, EventArgs e)
        {
            Tim();
        }

        #endregion

        #region empty
        private void cboPhanLoaiSearch_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cboPhanLoaiSearch_MouseEnter(object sender, EventArgs e)
        {
          
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void edit(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
    }
}
