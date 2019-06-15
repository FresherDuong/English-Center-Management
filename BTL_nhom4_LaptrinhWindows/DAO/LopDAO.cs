using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom4_LaptrinhWindows.DAO
{
    public class LopDAO
    {
        private static LopDAO instance = new LopDAO();
        public static LopDAO Instance { get => instance; set => instance = value; }

        public DataTable LayDanhSachLop()
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select lophoc.id,lophoc.ten,phong,giaovien.hoten,khoa.ten, lich.thu+' ca: '+cast(lich.ca as nvarchar(1)) as lich " +
                "from lophoc " +
                "inner join lich on lich.id=lophoc.idlich " +
                "inner join giaovien on giaovien.id=lophoc.idgiaovien " +
                "inner join khoa on khoa.id=lophoc.idkhoa");
            return data;
        }
        public DataTable LayDanhSachLopTheoKhoa(int idkhoa)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select lophoc.id,lophoc.ten,phong,giaovien.hoten,khoa.ten, lich.thu+' ca: '+cast(lich.ca as nvarchar(1)) as lich " +
                "from lophoc " +
                "inner join lich on lich.id=lophoc.idlich " +
                "inner join giaovien on giaovien.id=lophoc.idgiaovien " +
                "inner join khoa on khoa.id=lophoc.idkhoa " +
                "where idkhoa="+idkhoa);
            return data;
        }
        
        public DataTable LayDanhSachSinhVienThuocLop(int idlop)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select hocvien.id,hoten,ten,ngaysinh,thoigiandangky,diemtongket,xeploai from hocvien inner join tinhtranghoctap on hocvien.id =tinhtranghoctap.idhocvien inner join lophoc on tinhtranghoctap.idlop=lophoc.id where lophoc.id=" + idlop);
            return data;
        }
        public DataTable LayDanhSachLopTheoKhoaVaThoiGian(int idkhoa,int idlich)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select lophoc.id,lophoc.ten from lophoc inner join khoa on lophoc.idkhoa=khoa.id inner join lich on lophoc.idlich=lich.id where khoa.id=" + idkhoa+" and idlich="+idlich);
            return data;
        }
        public DataTable LayDanhSachThoiGianCuaMotKhoaHoc(int idkhoa)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select lich.id, thu+' ca: '+cast(ca as nvarchar(1)) as lich from lophoc inner join khoa on lophoc.idkhoa=khoa.id inner join lich on lophoc.idlich=lich.id where khoa.id="+idkhoa);
            return data;
        }
        public bool ThemLop(string ten, string phong, int idlich, int idkhoa,int idgiaovien)
        {
            string query = string.Format("insert into lophoc(ten,phong,idlich,idkhoa,idgiaovien) values (N'{0}',N'{1}','{2}','{3}',{4}) ", ten, phong, idlich, idkhoa ,idgiaovien);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool SuaLop(int id, string ten, string phong, int idlich, int idkhoa, int idgiaovien)
        {
            string query = string.Format("update lophoc set ten= N'{0}',phong=N'{1}',idlich={2},idkhoa={3},idgiaovien={4} where id={5} ", ten, phong, idlich, idkhoa , idgiaovien,id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool ThemHocVienVaoLop(int idhocvien, int idlop)
        {
            string query = string.Format("insert into tinhtranghoctap(idhocvien,idlop) values({0},{1}) ",idhocvien , idlop);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool KiemTraHocVienTrongLop(int idhocvien, int idlop)
        {
            string query = string.Format("select * from tinhtranghoctap where idhocvien={0} and idlop={1} ", idhocvien, idlop);
            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            return result.Rows.Count == 0;
        }
        public bool XoaHocVienVaoLop(int idhocvien, int idlop)
        {
            string query = string.Format("delete tinhtranghoctap where idhocvien={0} and idlop={1} ", idhocvien, idlop);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool XoaLop(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("delete tinhtranghoctap where idlop=" + id);
            DataProvider.Instance.ExcuteNonQuery("delete diemthi where idlop="+id);
           
            string query = string.Format("delete lophoc where id={0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public DataTable TimThongTinLop(int khoa, string ten)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select *from lophoc where idkhoa =" + khoa + " and ten like N'%" + ten + "%'");
            return data;
        }

        //Duong_Add
        public DataTable KiemTraSoLuongHocVien(int idlop)
        {
            string query = string.Format("select count(tinhtranghoctap.idhocvien) as soluonghocvien" +
                " from tinhtranghoctap" +
                " where idlop = {0}"+
                " group by idlop", idlop);
            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            return result;
        }

        public bool KiemTraTrungLapGiangVien_Lich(int idLich, int idGiangVien)
        {
            string query = string.Format("select * from lophoc " +
                "where lophoc.idgiaovien = {0} and lophoc.idlich = {1}", 
                idGiangVien, idLich);

            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            return dataTable.Rows.Count > 0;
        }

        public bool KiemTraTrungLapPhong_Lich(int idLich, string Phong)
        {
            string query = string.Format("select * from lophoc " +
                "where lophoc.phong = '{0}' and lophoc.idlich = {1}",
                Phong, idLich);

            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query);

            return dataTable.Rows.Count > 0;
        }
    }
}
