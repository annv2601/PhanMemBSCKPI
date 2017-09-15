using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ChiTieuKPI;

namespace DaoBSCKPI.ChiTieuKPI
{
    class daChiTieuKPI
    {
        private linqChiTieuKPIDataContext lKPI = new linqChiTieuKPIDataContext();
        private sp_tblBKChiTieuKPI_ThongTinResult _KPI = new sp_tblBKChiTieuKPI_ThongTinResult();

        public sp_tblBKChiTieuKPI_ThongTinResult KPI { get => _KPI; set => _KPI = value; }

        public sp_tblBKChiTieuKPI_ThongTinResult ThongTin()
        {
            try
            {
                KPI = lKPI.sp_tblBKChiTieuKPI_ThongTin(KPI.ID).Single();
                return KPI;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lKPI.sp_tblBKChiTieuKPI_ThemSua(KPI.ID, KPI.Ma, KPI.STT, KPI.Ten, KPI.TrongSo, KPI.MucTieu, KPI.IDDonViTinh, KPI.IDBSC, KPI.Muc, KPI.IDTanSuatDo, KPI.IDXuHuongYeuCau,
                KPI.STTsx, KPI.InDam, KPI.InNghieng, KPI.NguoiTao, KPI.TrangThai, KPI.NguoiThaoTac);
        }

        public void GanVoiBSC()
        {
            lKPI.sp_tblBKChiTieuKPI_GanVoiBSC(KPI.ID, KPI.IDBSC);
        }

        public void DoiTrangThai()
        {
            lKPI.sp_tblBKChiTieuKPI_DoiTrangThai(KPI.ID, KPI.TrangThai, KPI.NguoiThaoTac);
        }
    }
}
