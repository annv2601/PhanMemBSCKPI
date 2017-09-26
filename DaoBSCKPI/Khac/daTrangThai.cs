using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.Khac;

namespace DaoBSCKPI.Khac
{
    public class daTrangThai
    {
        public enum eTrangThai
        {
            Không=0,
            Nhập=1,
            Sửa=2,
            Gửi=3,
            Chờ_Duyệt=4,
            Đã_Duyệt=5,
            Khóa=9
        }

        private linqTrangThaiDataContext LTT = new linqTrangThaiDataContext();

        public DataTable DanhSach()
        {
            List<sp_tblTrangThai_DanhSachResult> lst;
            lst = LTT.sp_tblTrangThai_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
