using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using BTL_nhom4_LaptrinhWindows.DAO;

namespace BTL_nhom4_LaptrinhWindows.UCs
{
    public partial class ucThanhToan : UserControl
    {
        BindingSource thanhtoan = new BindingSource();

        public ucThanhToan()
        {
            InitializeComponent();
            dtgvHocPhi.DataSource = thanhtoan;
            load(); 
        }
      
        void load()
        {
            cboKhoasearch.DataSource = KhoaHocDAO.Instance.LayDanhSachKhoaHoc();
            cboKhoasearch.ValueMember = "id";
            cboKhoasearch.DisplayMember = "ten";
            cboKhoasearch.SelectedIndex = -1;
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtgvLop.DataSource = HocvienDAO.Instance.LayDanhSachHocVien();
        }
        void HienDanhSach()
        {
            try
            {
                //Loi
                dtgvLop.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop((int)cboLop.SelectedValue);
            }
            catch { }
        }


        private void cboKhoasearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoasearch.SelectedIndex != -1)
                {
                    //Loi
                    cboLop.DataSource = LopDAO.Instance.LayDanhSachLopTheoKhoa((int)cboKhoasearch.SelectedValue);
                    //
                    cboLop.ValueMember = "id";
                    cboLop.DisplayMember = "ten";
                    cboLop.SelectedIndex = -1;
        }
    }
            catch { }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex != -1)
                HienDanhSach();
            else
                dtgvLop.DataSource = HocvienDAO.Instance.LayDanhSachHocVien();
        }

        private void dtgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idhocvien = (int)dtgvLop.SelectedCells[0].OwningRow.Cells["id"].Value;
            thanhtoan.DataSource = HocvienDAO.Instance.LayDanhSachHocPhi(idhocvien);
            txtConNo.Text = HocvienDAO.Instance.LaySoTienConNo(idhocvien).ToString();
            txtHoten.Text = dtgvLop.SelectedCells[0].OwningRow.Cells["hoten"].Value.ToString();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                //SulyChuoi
                string final = "";
                string tien = txtSoTien.Text;
                string[] a = tien.Trim().Split(',');

                foreach (var items in a)
                {
                    final = final + items.ToString();
                }
                //

                int idhocvien = (int)dtgvLop.SelectedCells[0].OwningRow.Cells["id"].Value;
                if (!HocvienDAO.Instance.ThemThanhToan(idhocvien, int.Parse(final)))
                {
                    MessageBox.Show("Thông tin không chính xác!");
                }
            ;
                txtConNo.Text = HocvienDAO.Instance.LaySoTienConNo(idhocvien).ToString();
                thanhtoan.DataSource = HocvienDAO.Instance.LayDanhSachHocPhi(idhocvien);
                dtgvLop.DataSource = HocvienDAO.Instance.LayDanhSachHocVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int idhocvien = (int)dtgvLop.SelectedCells[0].OwningRow.Cells["id"].Value;
            int idthanhtoan = (int)dtgvHocPhi.SelectedCells[0].OwningRow.Cells["id2"].Value;

            try
            {
                //SulyChuoi
                string final = "";
                string tien = txtSoTien.Text;
                string[] a = tien.Trim().Split(',');

                foreach (var items in a)
                {
                    final = final + items.ToString();
                }
                //

                if (!HocvienDAO.Instance.SuaThanhToan(idthanhtoan, int.Parse(final)))
                {
                    MessageBox.Show("Thông tin không chính xác!");
                }
            ;
                txtConNo.Text = HocvienDAO.Instance.LaySoTienConNo(idhocvien).ToString();
                thanhtoan.DataSource = HocvienDAO.Instance.LayDanhSachHocPhi(idhocvien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int idhocvien = (int)dtgvLop.SelectedCells[0].OwningRow.Cells["id"].Value;
                int idthanhtoan = (int)dtgvHocPhi.SelectedCells[0].OwningRow.Cells["id2"].Value;
                if (!HocvienDAO.Instance.XoaThanhToan(idthanhtoan))
                {
                    MessageBox.Show("Thông tin không chính xác!");
                }
            ;
                txtConNo.Text = HocvienDAO.Instance.LaySoTienConNo(idhocvien).ToString();
                thanhtoan.DataSource = HocvienDAO.Instance.LayDanhSachHocPhi(idhocvien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvHocPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvHocPhi.SelectedCells.Count > 0)
                txtSoTien.Text = dtgvHocPhi.SelectedCells[0].OwningRow.Cells["tienthanhtoan"].Value.ToString();
            else
                txtSoTien.Text = "";
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            try
            {
                decimal value = decimal.Parse(txtSoTien.Text, System.Globalization.NumberStyles.AllowThousands);
                txtSoTien.Text = String.Format(culture, "{0:N0}", value);
                txtSoTien.Select(txtSoTien.Text.Length, 0);
            }
            catch { }
        }

        private void txtConNo_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            try
            {
                decimal value = decimal.Parse(txtConNo.Text, System.Globalization.NumberStyles.AllowThousands);
                txtConNo.Text = String.Format(culture, "{0:N0}", value);
                txtConNo.Select(txtConNo.Text.Length, 0);
            }
            catch { }
        }
    }
}
