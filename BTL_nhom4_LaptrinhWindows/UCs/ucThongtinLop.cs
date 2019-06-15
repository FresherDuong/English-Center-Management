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

namespace BTL_nhom4_LaptrinhWindows
{
    public partial class ucThongtinLop : UserControl
    {
        BindingSource lop = new BindingSource();

        public ucThongtinLop()
        {
            InitializeComponent();
            dtgvlop.DataSource = lop;
            load();
            addBinding();
        }

        void load()
        {
            lop.DataSource = LopDAO.Instance.LayDanhSachLop();
            cboGiaoVien.DataSource = GiaoVienDAO.Instance.LayDanhSachGiaoVien();
            cboGiaoVien.DisplayMember = "hoten";
            cboGiaoVien.ValueMember = "id";
            cboLoaiGv.DataSource = GiaoVienDAO.Instance.LayDanhSachLoaiGiaoVien();
            cboLoaiGv.DisplayMember = "phanloai";
            cboKhoaSearch.DataSource=cboKhoa.DataSource = KhoaHocDAO.Instance.LayDanhSachKhoaHoc();
            cboKhoaSearch.DisplayMember= cboKhoa.DisplayMember = "ten";
            cboKhoaSearch.ValueMember= cboKhoa.ValueMember = "id";
            cboLich.DataSource = ThoigianDAO.Instance.LayThongtinLich();
            cboLich.DisplayMember = "detail";
            cboLich.ValueMember = "id";
        }

        void addBinding()
        {
            txtLop.DataBindings.Add(new Binding("text", dtgvlop.DataSource, "ten", true, DataSourceUpdateMode.Never));
            txtDaiDiem.DataBindings.Add(new Binding("text", dtgvlop.DataSource, "phong", true, DataSourceUpdateMode.Never));
            cboKhoa.DataBindings.Add(new Binding("text", dtgvlop.DataSource, "ten1", true, DataSourceUpdateMode.Never));
            cboLich.DataBindings.Add(new Binding("text", dtgvlop.DataSource, "lich", true, DataSourceUpdateMode.Never));
            cboGiaoVien.DataBindings.Add(new Binding("text", dtgvlop.DataSource, "hoten", true, DataSourceUpdateMode.Never));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ucThongTinTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void cboLoaiGv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboGiaoVien.DataSource= GiaoVienDAO.Instance.LayDanhSachGiaoVienTheoLoai(cboLoaiGv.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!
                //LopDAO.Instance.ThemLop(txtLop.Text, txtDaiDiem.Text, (int)cboLich.SelectedValue, (int)cboKhoa.SelectedValue, (int)cboGiaoVien.SelectedValue))
                //{
                //    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                //}

                if(LopDAO.Instance.KiemTraTrungLapPhong_Lich((int)cboLich.SelectedValue, txtDaiDiem.Text)){
                    MessageBox.Show("Phòng " + txtDaiDiem.Text + "đã được sử dụng vào " + cboLich.Text, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if(LopDAO.Instance.KiemTraTrungLapGiangVien_Lich((int)cboLich.SelectedValue, (int)cboGiaoVien.SelectedValue)){
                    MessageBox.Show("Giảng viên " + cboGiaoVien.Text + " đã được xếp lớp vào " + cboLich.Text, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if(LopDAO.Instance.ThemLop(txtLop.Text, txtDaiDiem.Text, (int)cboLich.SelectedValue, (int)cboKhoa.SelectedValue, (int)cboGiaoVien.SelectedValue))
                    {
                        MessageBox.Show("Đã xếp lớp mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                if (!
                LopDAO.Instance.SuaLop((int)dtgvlop.SelectedCells[0].OwningRow.Cells["id"].Value, txtLop.Text, txtDaiDiem.Text, (int)cboLich.SelectedValue, (int)cboKhoa.SelectedValue, (int)cboGiaoVien.SelectedValue))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                }
                else
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (!LopDAO.Instance.XoaLop((int)dtgvlop.SelectedCells[0].OwningRow.Cells["ID"].Value))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            load();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dtgvlop.DataSource = LopDAO.Instance.TimThongTinLop((int)cboKhoaSearch.SelectedValue,txtTenLopSearch.Text);
        }

        private void cboKhoaSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
