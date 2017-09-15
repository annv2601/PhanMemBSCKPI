using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DanhMucBK;

namespace DaoBSCKPI.DanhMucBSCKPI
{
    public class daNhomDanhMucBK
    {
        private linqDanhMucBKDataContext lDM = new linqDanhMucBKDataContext();

        public DataTable DanhSach(int rNhom)
        {
            List<sp_tblBKDanhMuc_DanhSachResult> lst;
            lst = lDM.sp_tblBKDanhMuc_DanhSach(rNhom).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
