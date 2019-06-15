using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BTL_nhom4_LaptrinhWindows
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void addNewTab(string strTabName, UserControl ucContent)
        {
            //-----------If exist tabpage then exit---------------
            foreach (TabItem tabPage in tabMain.Tabs)
                if (tabPage.Text == strTabName)
                {
                    tabMain.SelectedTab = tabPage;
                    return;
                }
            //-------------------------Clear Tab Before---------------
            //if (tabMain.Tabs.Count > 1)
            //    tabMain.Tabs.RemoveAt(1);

            TabControlPanel newTabPanel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newTabPage = new TabItem(this.components);
            newTabPage.ImageIndex = 0;
            newTabPage.MouseDown += new System.Windows.Forms.MouseEventHandler(tabItem_MouseDown);
            newTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newTabPanel.Location = new System.Drawing.Point(0, 26);
            newTabPanel.Name = "panel" + strTabName;
            newTabPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabPanel.Size = new System.Drawing.Size(1230, 384);
            newTabPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newTabPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newTabPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newTabPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newTabPanel.Style.GradientAngle = 90;
            newTabPanel.TabIndex = 2;
            newTabPanel.TabItem = newTabPage;
            //-------------New  tab page---------------------
            Random ran = new Random();
            newTabPage.Name = strTabName + ran.Next(100000) + ran.Next(22342);
            newTabPage.AttachedControl = newTabPanel;
            newTabPage.Text = strTabName;
            ucContent.Dock = DockStyle.Fill;
            newTabPanel.Controls.Add(ucContent);
            //------------add Tab page to Tab control-------------
            tabMain.Controls.Add(newTabPanel);
            tabMain.Tabs.Add(newTabPage);
            tabMain.SelectedTab = newTabPage;
        }
        
        #region Events
        private void tabMain_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            if(tabMain.SelectedTabIndex!=0)
            if(MessageBox.Show("Bạn có muốn đóng tab "+tabMain.SelectedTab.Text,"Đóng tab",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            tabMain.Tabs.Remove(tabMain.SelectedTab);
        }

        private void đóngTrangNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTabIndex != 0)
                if (MessageBox.Show("Bạn có muốn đóng tab " + tabMain.SelectedTab.Text, "Đóng tab", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                tabMain.Tabs.Remove(tabMain.SelectedTab);
        }

        private void ctmnMain_Opening(object sender, CancelEventArgs e)
        {
            if (tabMain.SelectedTabIndex != 0)
            {
                đóngTrangNàyToolStripMenuItem.Enabled = true;
            }
            else
                đóngTrangNàyToolStripMenuItem.Enabled = false;
        }

        private void đóngCácTrangKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i=tabMain.Tabs.Count -1; i > 0; i--)
            {
                if (tabMain.SelectedTabIndex != i)
                    tabMain.Tabs.RemoveAt(i);
            }
            tabMain.Refresh();

        }

        private void đóngTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
            {
                    tabMain.Tabs.RemoveAt(i);
            }
            tabMain.Refresh();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            ucThongtinTaiKhoan uc = new ucThongtinTaiKhoan();
            addNewTab("Thông tin tài khoản", uc);
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            ucThongtinLop uc = new ucThongtinLop();
            addNewTab("Thông tin lớp", uc);
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            UCs.ucNguoiDung uc = new UCs.ucNguoiDung();
            addNewTab("Thông tin người dùng", uc);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Close();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            UCs.ucQuanLyKhoa uc = new UCs.ucQuanLyKhoa();
            addNewTab("Quản lý khóa học", uc);
        }

        private void btnCahoc_Click(object sender, EventArgs e)
        {
            UCs.ucThoiGianHoc uc= new UCs.ucThoiGianHoc();
            addNewTab("Thời gian học", uc);
        }

        private void btnQuanLySinhVien_Click(object sender, EventArgs e)
        {
            UCs.ucHocVien uc = new UCs.ucHocVien();
            addNewTab("Quản lý học viên", uc);
        }

        private void btnQuanLyGiangVien_Click(object sender, EventArgs e)
        {
            UCs.ucGiangVien uc = new UCs.ucGiangVien();
            addNewTab("Quản lý giảng viên", uc);
        }

        private void btnQuanlyDiemThi_Click(object sender, EventArgs e)
        {
            UCs.ucQuanLyDiem uc = new UCs.ucQuanLyDiem();
            addNewTab("Quản lý điểm", uc);
        }

        private void btnDanhSachLop_Click(object sender, EventArgs e)
        {
            UCs.ucDanhSachLop uc = new UCs.ucDanhSachLop();
            addNewTab("Đăng ký học", uc);
        }
        private void btnQuanLyHocPhi_Click(object sender, EventArgs e)
        {
            UCs.ucThanhToan uc = new UCs.ucThanhToan();
            addNewTab("Thanh toán", uc);
        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            UCs.ucDotThi uc = new UCs.ucDotThi();
            addNewTab("Đợt thi", uc);
        }
        #endregion

        #region Ấn nhầm ahihi
        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {

        }
        private void ribbonBar12_ItemClick(object sender, EventArgs e)
        {

        }
        private void ribbonTabItem5_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiemSinhVien_Click(object sender, EventArgs e)
        {

        }
        private void tabItem_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void applicationButton1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }


        #endregion

        private void btnThongkeHocPhi_Click(object sender, EventArgs e)
        {
            //Old Version
            //frmReport_HocPhi frmReport_HocPhi = new frmReport_HocPhi();
            //frmReport_HocPhi.ShowDialog();

            //New Version
            frmReport_HocPhi_New frmReport_HocPhi_New = new frmReport_HocPhi_New();
            frmReport_HocPhi_New.ShowDialog();
        }

        private void btnThongKeSinhVien_Click(object sender, EventArgs e)
        {
            frmReport_DSSV f = new frmReport_DSSV();
            f.ShowDialog();
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            frmReport_KQHT frmReport_KQHT = new frmReport_KQHT();
            frmReport_KQHT.ShowDialog();
        }

        private void ribbonPanel5_Click(object sender, EventArgs e)
        {

        }
    }
}
