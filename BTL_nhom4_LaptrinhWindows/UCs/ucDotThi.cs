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
    public partial class ucDotThi : UserControl
    {
        BindingSource dotthi = new BindingSource();
        public ucDotThi()
        {
            InitializeComponent();
            dtgvDanhsachdotthi.DataSource = dotthi;
            Load();
            Addbinding();
        }
        void Addbinding()
        {
            cboKhoa.DataBindings.Add(new Binding("text", dtgvDanhsachdotthi.DataSource, "ten", true, DataSourceUpdateMode.Never));
            txtGioThi.DataBindings.Add(new Binding("text", dtgvDanhsachdotthi.DataSource, "giothi", true, DataSourceUpdateMode.Never));
            dtpNgayThi.DataBindings.Add(new Binding("value", dtgvDanhsachdotthi.DataSource, "ngaythi", true, DataSourceUpdateMode.Never));
        }
        void Load()
        {
            dotthi.DataSource = DotThiDAO.Instance.LayDanhSachDotThi();
            cboKhoa.DataSource = KhoaHocDAO.Instance.LayDanhSachKhoaHoc();
            cboKhoa.DisplayMember = "ten";
            cboKhoa.ValueMember = "id";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DotThiDAO.Instance.ThemDotThi((int)cboKhoa.SelectedValue, dtpNgayThi.Value.ToString("MM/dd/yyyy"), txtGioThi.Text))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DotThiDAO.Instance.SuaDotThi((int)dtgvDanhsachdotthi.SelectedCells[0].OwningRow.Cells["id"].Value, (int)cboKhoa.SelectedValue, dtpNgayThi.Value.ToString("MM/dd/yyyy"), txtGioThi.Text))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DotThiDAO.Instance.XoaDotThi((int)dtgvDanhsachdotthi.SelectedCells[0].OwningRow.Cells["id"].Value))
                {
                    MessageBox.Show("Thông tin chưa chính xác, bạn vui lòng kiểm tra lại thông tin");
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load();
        }
    }
}
