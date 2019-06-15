using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
    public class KhoaHocDAO
    {
        private static KhoaHocDAO instance = new KhoaHocDAO();
        public static KhoaHocDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDanhSachKhoaHoc()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from khoa");
            return data;
        }

        public DataTable LayDanhSachLopHocTheoKhoa(int idkhoa)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from lophoc where idkhoa="+idkhoa);
            return data;
        }
        public bool ThemKhoaHoc(string ten, string ngaybatdau,string ngayketthuc,int hocphi)
        {
            string query = string.Format("insert into khoa(ten,hocphi,ngaybatdau,ngayketthuc) values (N'{0}',{1},'{2}','{3}') ", ten, hocphi,ngaybatdau,ngayketthuc);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaKhoahoc(int id, string ten, string ngaybatdau, string ngayketthuc, int hocphi)
        {
            string query = string.Format("update khoa set ten= N'{0}', hocphi={1} ,ngaybatdau= '{2}',ngayketthuc='{3}'where id={4} ", ten, hocphi, ngaybatdau,ngayketthuc,id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaKhoaHoc(int id)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete diemthi where idlop in (select id from lophoc where idkhoa ={0})", id));
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete tinhtranghoctap where idlop in (select id from lophoc where idkhoa ={0})", id));
            DataProvider.Instance.ExcuteNonQuery("delete lophoc where idkhoa=" + id);
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete diemthi where iddotthi in (select id from dotthi where idkhoa ={0})", id));
            DataProvider.Instance.ExcuteNonQuery("delete dotthi where idkhoa=" + id);
            string query = string.Format("delete khoa where id={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
