using System;
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

        public byte Thang { get => _Thang; set => _Thang = value; }

        public int Nam { get => _Nam; set => _Nam = value; }

        public int IDDonVi { get => _IDDonVi; set => _IDDonVi = value; }

        public int IDPhongBan { get => _IDPhongBan; set => _IDPhongBan = value; }

        public string IDNguoiDung { get => _IDNguoiDung; set => _IDNguoiDung = value; }
    }
}
