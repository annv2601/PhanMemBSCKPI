using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DanhMucBK;

namespace DaoBSCKPI.DanhMucBSCKPI
{
    public class daDanhMucBK
    {
        private linqDanhMucBKDataContext lDM = new linqDanhMucBKDataContext();
        
        public DataTable DanhSach()
        {
            List<sp_tblBKNhomDanhMuc_DanhSachResult> lst;
            lst = lDM.sp_tblBKNhomDanhMuc_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
