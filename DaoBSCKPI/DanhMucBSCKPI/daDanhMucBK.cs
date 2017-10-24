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
        private sp_tblBKDanhMuc_TimResult _DMTim = new sp_tblBKDanhMuc_TimResult();
        public sp_tblBKDanhMuc_TimResult DMTim { get => _DMTim; set => _DMTim = value; }

        public DataTable DanhSach(int rNhom)
        {
            List<sp_tblBKDanhMuc_DanhSachResult> lst;
            lst = lDM.sp_tblBKDanhMuc_DanhSach(rNhom).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public sp_tblBKDanhMuc_TimResult Tim()
        {
            try
            {
                DMTim = lDM.sp_tblBKDanhMuc_Tim(DMTim.Ten).Single();
                return DMTim;
            }
            catch
            {
                return null;
            }
        }
    }
}
