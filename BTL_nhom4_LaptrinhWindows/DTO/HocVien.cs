using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DTO
{
   public class HocVien
    {
        public int id { get; set; }
        public HocVien(DataRow row)
        {
            id = (int)row["id"];
        }
        
    }
}
