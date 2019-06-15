using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
    public class GiaoVienDAO
    {
        private static GiaoVienDAO instance = new GiaoVienDAO();
        public static GiaoVienDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDanhSachGiaoVien()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from giaovien");
            return data;
        }
        public DataTable LayDanhSachGiaoVienTheoLoai(string loai)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from giaovien where phanloai=N'{0}'", loai));
            return data;
        }
        public DataTable LayDanhSachLoaiGiaoVien()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select phanloai from giaovien group by phanloai");
            return data;
        }
        public bool ThemGiaoVien(string hoten,string ngaysinh,string diachi,string sdt,string phanloai)
        {
            string query = string.Format("insert into giaovien(hoten,ngaysinh,diachi,sodienthoai,phanloai) values (N'{0}','{1}',N'{2}','{3}',N'{4}') ", hoten, ngaysinh.ToString(), diachi, sdt, phanloai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result>0;
        }
        public bool SuaGiaoVien(int id,string hoten, string ngaysinh, string diachi, string sdt, string phanloai)
        {
            string query = string.Format("update giaovien set hoten= N'{0}',ngaysinh='{1}',diachi=N'{2}',sodienthoai='{3}',phanloai=N'{4}' where id={5} ", hoten, ngaysinh.ToString(), diachi, sdt, phanloai, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaGiaoVien(int id)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete diemthi where idlop in (select id from lophoc where idgiaovien ={0})", id));
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete tinhtranghoctap where idlop in (select id from lophoc where idgiaovien ={0})", id));
            DataProvider.Instance.ExcuteNonQuery("delete lophoc where idgiaovien=" + id);
            string query = string.Format("delete giaovien where id={0} ",  id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public DataTable TimThongTinGiangVien(string loai,string ten)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select *from giaovien where phanloai like N'%"+loai+"%' and hoten like N'%"+ten+"%'");
            return data;
        }


    }
}
