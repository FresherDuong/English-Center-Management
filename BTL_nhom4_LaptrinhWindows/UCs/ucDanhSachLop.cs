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
    public partial class ucDanhSachLop : UserControl
    {
        public ucDanhSachLop()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dtgvDanhsachsinhvien.DataSource = HocvienDAO.Instance.LayDanhSachHocVien();
            cboKhoa.DataSource = KhoaHocDAO.Instance.LayDanhSachKhoaHoc();
            cboKhoa.ValueMember = "id";
            cboKhoa.DisplayMember = "ten";
        }

        public void LoadSiSo()
        {
            try
            {
                //Loi
                DataTable dataTable = LopDAO.Instance.KiemTraSoLuongHocVien((int)cboLop.SelectedValue);
                txtSoLuongHocVien.Text = dataTable.Rows[0]["soluonghocvien"].ToString();
            }
            catch
            {
                txtSoLuongHocVien.Text = "0";
            }
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Loi
                int idkhoa = (int)cboKhoa.SelectedValue;
                //

                cboThoiGian.DataSource = LopDAO.Instance.LayDanhSachThoiGianCuaMotKhoaHoc(idkhoa);
                cboThoiGian.ValueMember = "id";
                cboThoiGian.DisplayMember = "lich";
            }
            catch
            {

            }
        }

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Loi
                cboLop.DataSource = LopDAO.Instance.LayDanhSachLopTheoKhoaVaThoiGian((int)cboKhoa.SelectedValue, (int)cboThoiGian.SelectedValue);
                cboLop.ValueMember = "id";
                cboLop.DisplayMember = "ten";
            }
            catch { }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSiSo();
            if(int.Parse(txtSoLuongHocVien.Text) < 5)
            {
                lableSiSo.Text = "*Chưa đủ học viên mở lớp (Min : 5 học viên)";
            }
            else
            {
                lableSiSo.Text = "*Lớp đủ học viên mở lớp (Max : 10 học viên)";
            }
            try
            {
                //Loi
                dtgvDanhsachsvcualop.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop((int)cboLop.SelectedValue);
            }
            catch { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtSoLuongHocVien.Text) > 9)
            {
                MessageBox.Show("Lớp đã quá giới hạn học viên cho phép", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    //btnThem
                    if (LopDAO.Instance.KiemTraHocVienTrongLop((int)dtgvDanhsachsinhvien.SelectedCells[0].OwningRow.Cells["id"].Value, (int)cboLop.SelectedValue))
                    {
                        if (LopDAO.Instance.ThemHocVienVaoLop((int)dtgvDanhsachsinhvien.SelectedCells[0].OwningRow.Cells["id"].Value, (int)cboLop.SelectedValue))
                        {
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            dtgvDanhsachsvcualop.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop((int)cboLop.SelectedValue);
                            LoadSiSo();
                        }
                        else
                        {
                            MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Học viên đã được thêm vào lớp từ trước", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            dtgvDanhsachsinhvien.DataSource = HocvienDAO.Instance.LayDanhSachHocVien();

        }
        void Tim()
        {
            dtgvDanhsachsinhvien.DataSource = HocvienDAO.Instance.TimThongTinHocVien(txtHoten.Text, txtSdt.Text);
        }
        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            Tim();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            Tim();
        }

        #region empty
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

      
        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

      

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

       

        

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        

        private void labelX10_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                //btnXoa
                if (!LopDAO.Instance.XoaHocVienVaoLop((int)dtgvDanhsachsvcualop.SelectedCells[0].OwningRow.Cells["id2"].Value, (int)cboLop.SelectedValue))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dtgvDanhsachsvcualop.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop((int)cboLop.SelectedValue);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void txtSoLuongHocVien_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txtSoLuongHocVien.Text) < 5)
            {
                lableSiSo.Text = "*Chưa đủ học viên mở lớp (Min : 5 học viên)";
            }
            else
            {
                lableSiSo.Text = "*Lớp đủ học viên mở lớp (Max : 10 học viên)";
            }
        }
    }
}
