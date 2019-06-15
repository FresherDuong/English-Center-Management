using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
   public  class ThoigianDAO
    {
        private static ThoigianDAO instance = new ThoigianDAO();
        public static ThoigianDAO Instance { get => instance; set => instance = value; }

        public DataTable LayThongtinLich()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select thu + ' ca: '+cast( ca as nvarchar) as detail,id from lich");
            return data;
        }
        public DataTable LayDanhSachThoiGian()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from lich");
            return data;
        }
     
        public bool ThemThoiGian(string thu, string ca)
        {
            string query = string.Format("insert into lich(thu,ca) values (N'{0}',N'{1}') ", thu, ca);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaLich(string thu, string ca,int id)
        {
            string query = string.Format("update lich set thu= N'{0}', ca= N'{1}' where id='{2}' ", thu, ca, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaLich(int id)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete diemthi where idlop in (select id from lophoc where idlich ={0})", id));
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete tinhtranghoctap where idlop in (select id from lophoc where idlich ={0})", id));
            DataProvider.Instance.ExcuteNonQuery("delete lophoc where idlich=" + id);
            string query = string.Format("delete lich where id={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
