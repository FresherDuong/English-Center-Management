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
    public partial class ucThongtinTaiKhoan : UserControl
    {
        public ucThongtinTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (TaiKhoanDAO.Instance.KetquaDangnhap(txtTenTaiKhoan.Text, txtMatKhau.Text))
                    if (txtNhapLai.Text == txtMatKhauMoi.Text)
                    {
                        if (TaiKhoanDAO.Instance.Thaydoimatkhau(txtTenTaiKhoan.Text, txtMatKhauMoi.Text))
                            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show("Mật khẩu nhập lại không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ucThongtinTaiKhoan_Load(object sender, EventArgs e)
        {
            cboQuyen.Items.Add("Admin");
            cboQuyen.Items.Add("Nhân viên");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
