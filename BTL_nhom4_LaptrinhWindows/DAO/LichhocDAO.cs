using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
   public  class LichhocDAO
    {
        private static LichhocDAO instance = new LichhocDAO();
        public static LichhocDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDanhSachThoiGian()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from lichhoc");
            return data;
        }
        
        public bool ThemThoiGianHoc(string thu, int ca)
        {
            string query = string.Format("insert into thoigian(thu,ca) values (N'{0}',{1}) ", thu , ca);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaThoiGian(int id, string thu, int ca)
        {
            string query = string.Format("update thoigian set thu= N'{0}', ca={1} where id={2} ", thu, ca,id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaNguoiDung(int id)
        {
            string query = string.Format("delete thoigian where id={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
