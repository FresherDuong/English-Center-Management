using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
    public class DotThiDAO
    {
        private static DotThiDAO instance = new DotThiDAO();
        public static DotThiDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDanhSachDotThi()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select dotthi.id,ten,ngaythi,giothi from dotthi inner join khoa on khoa.id=dotthi.idkhoa");
            return data;
        }
        public DataTable LayDanhSachDotThiTheoKhoa(int idkhoa)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select dotthi.id,ten,ngaythi,giothi from dotthi inner join khoa on khoa.id=dotthi.idkhoa where idkhoa="+idkhoa);
            return data;
        }
    
        public bool ThemDotThi(int idkhoa, string ngaythi, string giothi)
        {
            string query = string.Format("insert into dotthi(idkhoa,ngaythi,giothi) values ({0},'{1}','{2}') ", idkhoa, ngaythi, giothi);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaDotThi(int id, int idkhoa,string ngaythi, string giothi)
        {
            string query = string.Format("update dotthi set idkhoa= {0},ngaythi='{1}',giothi='{2}' where id={3} ", idkhoa, ngaythi, giothi, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaDotThi(int id)
        {

            DiemThiDAO.Instance.XoaDiemThiTheo("iddotthi", id);
            string query = string.Format("delete dotthi where id={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaDotThiTheoIdKhoa(int id)
        {

            DiemThiDAO.Instance.XoaDiemThiTheo("iddotthi", id);
            string query = string.Format("delete dotthi where idkhoa={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
