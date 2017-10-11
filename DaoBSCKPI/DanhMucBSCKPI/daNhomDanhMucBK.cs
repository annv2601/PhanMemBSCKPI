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
        public enum eNhom
        {
            Đơn_Vị_Tính=1,
            Tần_Suất=2,
            Xu_Hướng=3,
            Mức_Độ=4,
            Hướng_Xử_Lý_Công_Việc=5,
            Trạng_Thái_Công_Việc=6
        }

        private linqDanhMucBKDataContext lDM = new linqDanhMucBKDataContext();

        public DataTable DanhSach()
        {
            List<sp_tblBKNhomDanhMuc_DanhSachResult> lst;
            lst = lDM.sp_tblBKNhomDanhMuc_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
        
    }
}
