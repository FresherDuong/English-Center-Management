
using BTL_nhom4_LaptrinhWindows.DTO;
using BTL_nhom4_LaptrinhWindows.UCs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
   public class HocvienDAO
    {
        private static HocvienDAO instance = new HocvienDAO();
        public static HocvienDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDanhSachHocVien()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from hocvien");
            return data;
        }
        public List<HocVien> LayDanhSachIDHocVien()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from hocvien");
            List<HocVien> ds = new List<HocVien>();
            foreach (DataRow row in data.Rows)
            {
                HocVien a = new HocVien(row);
                ds.Add(a);
            }
            return ds;
        }
        public DataTable LayDanhSachHocPhi(int idhocvien)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select thanhtoan.id,hoten,ngaythanhtoan,tienthanhtoan from thanhtoan inner join hocvien on hocvien.id=thanhtoan.idhocvien where idhocvien="+idhocvien);
            return data;
        }
        public int LaySoTienConNo(int idhocvien)
        {
            int TienPhaiThanhToan = 0;
            var temp = DataProvider.Instance.ExcuteScalar("select sum(hocphi) from hocvien inner join tinhtranghoctap on hocvien.id=tinhtranghoctap.idhocvien inner join lophoc " +
                "on tinhtranghoctap.idlop =lophoc.id inner join khoa on khoa.id=lophoc.idkhoa where idhocvien=" + idhocvien + " group by hocvien.id ");
            if (temp == null ||temp.ToString()=="")
                temp = "0";
            TienPhaiThanhToan = int.Parse(temp.ToString());
            int TienDaThanhToan = 0;
            var temp2= DataProvider.Instance.ExcuteScalar("select sum(tienthanhtoan) from thanhtoan where idhocvien=" + idhocvien);
            if (temp2 == null ||temp2.ToString()=="")
                temp2 = "0";
            TienDaThanhToan = int.Parse(temp2.ToString());
            DataProvider.Instance.ExcuteNonQuery("update hocvien set conno=" + (TienPhaiThanhToan - TienDaThanhToan) + " where id="+ idhocvien);
            return  TienPhaiThanhToan-TienDaThanhToan;
        }
        public bool ThemHocVien(string hoten,string gioitinh, string ngaysinh, string diachi, string sdt)
        {
            string query = string.Format("insert into hocvien(hoten,gioitinh,ngaysinh,diachi,sodienthoai) values (N'{0}',N'{1}','{2}',N'{3}','{4}') ", hoten,gioitinh, ngaysinh, diachi, sdt);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaHocVien(int id, string hoten, string ngaysinh, string diachi, string sdt, string gioitinh)
        {
            string query = string.Format("update hocvien set hoten= N'{0}', gioitinh= N'{1}', ngaysinh='{2}',diachi=N'{3}',sodienthoai='{4}' where id={5} ", hoten,gioitinh, ngaysinh.ToString(), diachi, sdt, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaHocVien(int id)
        {
            XoaThanhToanTheoIdHocvien(id);
            DiemThiDAO.Instance.XoaDiemThiTheo("idhocvien", id);
            DataProvider.Instance.ExcuteNonQuery("delete tinhtranghoctap where idhocvien= "+ id);
            string query = string.Format("delete hocvien where id={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public DataTable TimThongTinHocVien(string ten, string sdt)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select *from hocvien where hoten like N'%" + ten + "%' and sodienthoai like N'%" + sdt + "%'");
            return data;
        }
        public bool ThemThanhToan(int idhocvien,int sotien)
        {
            string query = string.Format("insert into thanhtoan(idhocvien,tienthanhtoan) values ({0},{1}) ", idhocvien,sotien);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaThanhToan(int id,int sotien)
        { 
            string query = string.Format("update thanhtoan set tienthanhtoan={0} where id={1}", sotien, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaThanhToan(int id)
        {
            string query = string.Format("delete thanhtoan where id={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaThanhToanTheoIdHocvien(int id)
        {
            string query = string.Format("delete thanhtoan where idhocvien={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }



    }
}
