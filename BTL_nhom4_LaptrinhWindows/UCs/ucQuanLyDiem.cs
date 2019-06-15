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
    public partial class ucQuanLyDiem : UserControl
    {
        int idlop;
        public ucQuanLyDiem()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            cboKhoasearch.DataSource = KhoaHocDAO.Instance.LayDanhSachKhoaHoc();
            cboKhoasearch.ValueMember = "id";
            cboKhoasearch.DisplayMember = "ten";
            cboKhoasearch.SelectedIndex = -1;
        }
        #region empty

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
 
        }

        private void groupPanel5_Click(object sender, EventArgs e)
        {

        }
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLop_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void cboKhoasearch_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void txtHotensearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dtgvSinhvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void txtViet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX10_Click(object sender, EventArgs e)
        {

        }

        private void txtNoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void txtNghe_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }

        private void txtLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void txtHoten_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void cboKhoasearch_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoasearch.SelectedIndex != -1)
                {
                    //Loi
                    dtgvDanhsachlop.DataSource = LopDAO.Instance.LayDanhSachLopTheoKhoa((int)cboKhoasearch.SelectedValue);
                    //Loi

                    DataTable data = DotThiDAO.Instance.LayDanhSachDotThiTheoKhoa((int)cboKhoasearch.SelectedValue);

                    cboDotThi.DataSource = DotThiDAO.Instance.LayDanhSachDotThiTheoKhoa((int)cboKhoasearch.SelectedValue);
                    cboDotThi.DisplayMember = "ngaythi";
                    cboDotThi.ValueMember = "id";


                    if (data.Rows.Count == 0)
                    {
                        cboDotThi.Text = "";
                        MessageBox.Show("Không có đợt thi phù hợp");
                    }
                }
                else
                    dtgvDanhsachlop.DataSource = LopDAO.Instance.LayDanhSachLop();
            }
            catch
            {

            }
           

        }

        private void dtgvDanhsachlop_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dtgvDanhsachlop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idlop = (int)dtgvDanhsachlop.SelectedCells[0].OwningRow.Cells["id"].Value;
                dtgvSinhvien.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop(idlop);
            }
            catch { }
        }

        private void dtgvSinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtgvDiem.DataSource = DiemThiDAO.Instance.LayDiemThiTheoMaHocVien((int)dtgvSinhvien.SelectedCells[0].OwningRow.Cells["id2"].Value,
                    (int)cboDotThi.SelectedValue, (int)dtgvDanhsachlop.SelectedCells[0].OwningRow.Cells["id"].Value);
                dtgvDiem.Rows[0].Cells[0].Selected = true;
                textBoxX1.Text = dtgvSinhvien.SelectedCells[0].OwningRow.Cells["id2"].Value.ToString();
                txtTen.Text = dtgvSinhvien.SelectedCells[0].OwningRow.Cells["hoten2"].Value.ToString();
                txtLop.Text = dtgvDanhsachlop.SelectedCells[0].OwningRow.Cells["ten"].Value.ToString();

                if (dtgvDiem.SelectedCells[0].OwningRow.Cells["diemnghe"].Value != null)
                {
                    txtNghe.Text = dtgvDiem.SelectedCells[0].OwningRow.Cells["diemnghe"].Value.ToString();
                    txtNoi.Text = dtgvDiem.SelectedCells[0].OwningRow.Cells["diemnoi"].Value.ToString();
                    txtDoc.Text = dtgvDiem.SelectedCells[0].OwningRow.Cells["diemdoc"].Value.ToString();
                    txtViet.Text = dtgvDiem.SelectedCells[0].OwningRow.Cells["diemviet"].Value.ToString();
                }
                else
                {
                    txtNghe.Text = txtNoi.Text = txtDoc.Text = txtViet.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadDiem();

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                //btnThem
                int iddothi = (int)cboDotThi.SelectedValue;
                int idhocvien = (int)dtgvSinhvien.SelectedCells[0].OwningRow.Cells["id2"].Value;
                int idlop = (int)dtgvDanhsachlop.SelectedCells[0].OwningRow.Cells["id"].Value;
                if (DiemThiDAO.Instance.KiemTraThiChua(idhocvien, idlop, iddothi))
                {
                    float nghe = float.Parse(txtNghe.Text);
                    float noi = float.Parse(txtNoi.Text);
                    float doc = float.Parse(txtDoc.Text);
                    float viet = float.Parse(txtViet.Text);
                    if (!DiemThiDAO.Instance.ThemDiemThi(iddothi, idlop, idhocvien, nghe, noi, doc, viet))
                    {
                        MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                    }
                    dtgvSinhvien.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop(idlop);
                }
                else
                {
                    float nghe = float.Parse(txtNghe.Text);
                    float noi = float.Parse(txtNoi.Text);
                    float doc = float.Parse(txtDoc.Text);
                    float viet = float.Parse(txtViet.Text);
                    if (!DiemThiDAO.Instance.SuaDiemThi(idhocvien, idlop, iddothi, nghe, noi, doc, viet))
                    {
                        MessageBox.Show("Thông. tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                    }
                    dtgvSinhvien.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop(idlop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadDiem();
           
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            dtgvDanhsachlop.DataSource = LopDAO.Instance.LayDanhSachLop();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            int iddothi = (int)cboDotThi.SelectedValue;
            int idhocvien = (int)dtgvSinhvien.SelectedCells[0].OwningRow.Cells["id2"].Value;
            int idlop = (int)dtgvDanhsachlop.SelectedCells[0].OwningRow.Cells["id"].Value;

            try
            {
                if (!DiemThiDAO.Instance.XoaDiemThi(idhocvien, idlop, iddothi))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                }
                dtgvSinhvien.DataSource = LopDAO.Instance.LayDanhSachSinhVienThuocLop(idlop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadDiem();
        }

        void loadDiem()
        {
            try
            {
                dtgvDiem.DataSource = DiemThiDAO.Instance.LayDiemThiTheoMaHocVien(int.Parse(textBoxX1.Text),
                   (int)cboDotThi.SelectedValue, (int)dtgvDanhsachlop.SelectedCells[0].OwningRow.Cells["id"].Value);
            }
            catch
            {
            }
        }
        private void cboDotThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDiem();
        }
    }
}
