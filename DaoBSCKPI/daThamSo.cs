using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoBSCKPI
{
    public class daThamSo
    {
        private byte _Thang;

        private int _Nam;

        private int _IDDonVi;

        private int _IDPhongBan;

        private string _IDNguoiDung;

        private Guid _IDNhanVien;

        public byte Thang { get => _Thang; set => _Thang = value; }

        public int Nam { get => _Nam; set => _Nam = value; }

        public int IDDonVi { get => _IDDonVi; set => _IDDonVi = value; }

        public int IDPhongBan { get => _IDPhongBan; set => _IDPhongBan = value; }

        public string IDNguoiDung { get => _IDNguoiDung; set => _IDNguoiDung = value; }
        public Guid IDNhanVien { get => _IDNhanVien; set => _IDNhanVien = value; }

        public DataTable DanhSachThang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Ten", typeof(string));

            for(int i=1;i<=12; i++)
            {
                dt.Rows.Add(i, "Tháng "+ i.ToString());
            }
            return dt;
        }

        public DataTable DanhSachNam()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Ten", typeof(string));

            for (int i = DateTime.Now.Year-1; i <= DateTime.Now.Year; i++)
            {
                dt.Rows.Add(i, "Năm " + i.ToString());
            }
            return dt;
        }
    }
}
