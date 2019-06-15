using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance = new TaiKhoanDAO();
        public static TaiKhoanDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDanhSachNguoiDung()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from taikhoan");
            return data;
        }
        public bool Thaydoimatkhau(string tendangnhap,string matkhau)
        {
            int result = 0;
            result = DataProvider.Instance.ExcuteNonQuery("update taikhoan set matkhau='" + matkhau + "' where tendangnhap='" + tendangnhap + "'");
            return result > 0;
        }
        public bool KetquaDangnhap(string tendangnhap,string matkhau)
        {
            
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select *from taikhoan where tendangnhap= '{0}' and matkhau= N'{1}'", tendangnhap, matkhau));
            return data.Rows.Count > 0;
        }
        public bool ThemNguoiDung(string tendangnhap, string hoten, string gioitinh, string quyen)
        {
            string query = string.Format("insert into taikhoan(tendangnhap,hoten,gioitinh,quyen) values (N'{0}',N'{1}',N'{2}',N'{3}') ",tendangnhap, hoten, gioitinh, quyen);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaNguoiDung( string tendangnhap ,string hoten,   string gioitinh,string quyen)
        {
            string query = string.Format("update taikhoan set hoten= N'{0}', gioitinh= N'{1}',quyen=N'{2}' where tendangnhap='{3}' ", hoten, gioitinh,quyen, tendangnhap);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaNguoiDung(string  tendangnhap)
        {
            string query = string.Format("delete taikhoan where tendangnhap='{0}' ", tendangnhap);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public DataTable TimThongNguoidung(string quyen, string tendangnhap)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select *from taikhoan where quyen like N'%" + quyen + "%' and tendangnhap like N'%" + tendangnhap + "%'");
            return data;
        }
        public DataTable LayDanhSachQuyen()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select quyen from taikhoan group by quyen");
            return data;
        }

    }
}
