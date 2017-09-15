using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DonVi;

namespace DaoBSCKPI.DonVi
{
    public class daPhongBan
    {
        private linqDonViDataContext lDV = new linqDonViDataContext();
        private sp_tblPhongBan_ThongTinResult _PB = new sp_tblPhongBan_ThongTinResult();

        public sp_tblPhongBan_ThongTinResult PB { get => _PB; set => _PB = value; }

        public sp_tblPhongBan_ThongTinResult ThongTin()
        {
            try
            {
                PB = lDV.sp_tblPhongBan_ThongTin(PB.ID).Single();
                return PB;
            }
            catch
            {
                return null;
            }
        }

        public void Xoa()
        {
            lDV.sp_tblPhongBan_Xoa(PB.ID);
        }

        public void ThemSua()
        {
            lDV.sp_tblPhongBan_ThemSua(PB.ID, PB.Ma, PB.Ten, PB.STTsx);
        }

        public DataTable DanhSach()
        {
            List<sp_tblPhongBan_DanhSachResult> lst;
            lst = lDV.sp_tblPhongBan_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
