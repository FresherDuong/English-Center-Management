
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
    public class DiemThiDAO
    {
        private static DiemThiDAO instance = new DiemThiDAO();
        public static DiemThiDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDiemThiTheoMaHocVien(int idhocvien, int iddotthi,int idlop)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery
                ("select hoten,diemnghe,diemnoi,diemdoc,diemviet from diemthi  inner join hocvien on hocvien.id=diemthi.idhocvien where idhocvien= " + idhocvien + " and iddotthi like N'%" + iddotthi+"%' and idlop= "+idlop);

           return data;
        }
        public bool KiemTraThiChua(int idhocvien,int idlop,int iddothi)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from diemthi where idhocvien={0} and idlop={1} and iddotthi={2}",idhocvien,idlop,iddothi));
            return data.Rows.Count == 0;
        }
        public bool ThemDiemThi(int iddotthi,int idlop, int idhocvien, float nghe=0,float noi=0,float doc=0,float viet =0)
        {
            string query = string.Format("insert into diemthi(iddotthi,idlop,idhocvien,diemnghe,diemnoi,diemdoc,diemviet) values ({0},{1},{2},{3},{4},{5},{6}) ", iddotthi,idlop, idhocvien,nghe,noi,doc,viet);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaDiemThi(int idhocvien, int idlop,int iddotthi, float nghe = 0, float noi = 0, float doc = 0, float viet = 0)
        {
            string query = string.Format("update diemthi set diemnghe= {0},diemnoi={1},diemdoc={2} ,diemviet={3} where idhocvien={4} and idlop={5} and iddotthi={6} ", nghe, noi, doc, viet,idhocvien,idlop,iddotthi);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaDiemThi(int idhocvien,int idlop,int iddotthi)
        {
            string query = string.Format("delete diemthi where idhocvien={0} and idlop={1} and iddotthi={2} ", idhocvien,idlop,iddotthi);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaDiemThiTheo(string vari,int value)
        {
            string query = string.Format("delete diemthi where {0}={1} ", vari, value);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
