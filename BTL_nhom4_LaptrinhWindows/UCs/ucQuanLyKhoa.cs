using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BTL_nhom4_LaptrinhWindows.DAO;

namespace BTL_nhom4_LaptrinhWindows.UCs
{
    public partial class ucQuanLyKhoa : UserControl
    {
        BindingSource khoa = new BindingSource();
        public ucQuanLyKhoa()
        {
         
            InitializeComponent();
            dtgvKhoa.DataSource = khoa;
            Load();
            Addbinding();
            
            
        }
        private void Addbinding()
        {
           txtTenKhoaHoc.DataBindings.Add(new Binding("text", dtgvKhoa.DataSource, "ten", true, DataSourceUpdateMode.Never));
            txtHocPhi.DataBindings.Add(new Binding("text", dtgvKhoa.DataSource, "hocphi", true, DataSourceUpdateMode.Never));
            dtpNgaybatdau.DataBindings.Add(new Binding("value", dtgvKhoa.DataSource, "ngaybatdau", true, DataSourceUpdateMode.Never));
            dtpNgayKetThuc.DataBindings.Add(new Binding("value", dtgvKhoa.DataSource, "ngayketthuc", true, DataSourceUpdateMode.Never));
        }
        void Load()
        {
            khoa.DataSource = KhoaHocDAO.Instance.LayDanhSachKhoaHoc();
        }

        private void buttonX1_Click(object sender, EventArgs e) //Them
        {
            //SulyChuoi
            string final = "";
            string tien = txtHocPhi.Text;
            string[] a = tien.Trim().Split(',');

            foreach (var items in a)
            {
                final = final + items.ToString();
            }
            //

            try
            {
                if (KhoaHocDAO.Instance.ThemKhoaHoc(txtTenKhoaHoc.Text, dtpNgaybatdau.Value.ToString("MM/dd/yyyy"), dtpNgayKetThuc.Value.ToString("MM/dd/yyyy"), int.Parse(final)))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvKhoa.SelectedCells[0].OwningRow.Cells["id"].Value;

            try
            {
                //SulyChuoi
                string final = "";
                string tien = txtHocPhi.Text;
                string[] a = tien.Trim().Split(',');

                foreach (var items in a)
                {
                    final = final + items.ToString();
                }
                //

                if (!KhoaHocDAO.Instance.SuaKhoahoc(id, txtTenKhoaHoc.Text, dtpNgaybatdau.Value.ToString("MM/dd/yyyy"), dtpNgayKetThuc.Value.ToString("MM/dd/yyyy"), int.Parse(final)))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvKhoa.SelectedCells[0].OwningRow.Cells["id"].Value;

            try
            {
                if (!KhoaHocDAO.Instance.XoaKhoaHoc(id))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load();
        }

        private void txtHocPhi_TextChanged(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            try
            {
                decimal value = decimal.Parse(txtHocPhi.Text, System.Globalization.NumberStyles.AllowThousands);
                txtHocPhi.Text = String.Format(culture, "{0:N0}", value);
                txtHocPhi.Select(txtHocPhi.Text.Length, 0);
            }
            catch { }
        }
    }
}
