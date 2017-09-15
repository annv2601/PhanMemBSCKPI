using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DonVi;

namespace DaoBSCKPI.DonVi
{
    public class daDonVi
    {
        private linqDonViDataContext lDV = new linqDonViDataContext();
        private sp_tblDonVi_ThongTinResult _DV = new sp_tblDonVi_ThongTinResult();

        public sp_tblDonVi_ThongTinResult DV { get => _DV; set => _DV = value; }

        public sp_tblDonVi_ThongTinResult ThongTin()
        {
            try
            {
                DV = lDV.sp_tblDonVi_ThongTin(DV.ID).Single();
                return DV;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lDV.sp_tblDonVi_ThemSua(DV.ID, DV.Ma, DV.Ten, DV.TenTat, DV.CapDonVi, DV.LoaiDonVi, DV.TrangThai, DV.STTsx, DV.NguoiTao);
        }

        public void Xoa()
        {
            lDV.sp_tblDonVi_Xoa(DV.ID);
        }
    }
}
