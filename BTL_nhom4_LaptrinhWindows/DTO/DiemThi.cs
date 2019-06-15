using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DTO
{
    public class DiemThi
    {
        public int idhocvien { get; set; }
        public int iddotthi { get; set; }
        public int idlop { get; set; }
        public float diemnghe { get; set; }
        public float diemnoi { get; set; }
        public float diemdoc { get; set; }
        public float diemviet { get; set; }

        public DiemThi()
        {
            idhocvien = iddotthi = idlop = 0;
            diemnghe = diemnoi = diemdoc = diemviet = 0;
        }
        public DiemThi(DataRow row)
        {
            this.idlop = (int)row["idlop"];
            this.idhocvien = (int)row["idhocvien"];
            this.iddotthi = (int)row["iddotthi"];
            this.diemnghe = float.Parse(row["diemnghe"].ToString());
            this.diemnoi = float.Parse(row["diemnoi"].ToString());
            this.diemdoc = float.Parse(row["diemdoc"].ToString());
            this.diemviet = float.Parse(row["diemviet"].ToString());
        }
    }
}
