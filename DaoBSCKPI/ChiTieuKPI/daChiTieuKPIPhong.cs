using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ChiTieuKPI;

namespace DaoBSCKPI.ChiTieuKPI
{
    public class daChiTieuKPIPhong
    {
        private linqChiTieuKPIPhongDataContext lKPIP = new linqChiTieuKPIPhongDataContext();
        private sp_tblBKChiTieuKPIPhong_ThongTinResult _KPIP = new sp_tblBKChiTieuKPIPhong_ThongTinResult();

        public sp_tblBKChiTieuKPIPhong_ThongTinResult KPIP { get => _KPIP; set => _KPIP = value; }

        public sp_tblBKChiTieuKPIPhong_ThongTinResult ThongTin()
        {
            try
            {
                KPIP = lKPIP.sp_tblBKChiTieuKPIPhong_ThongTin(KPIP.Nam, KPIP.IDDonVi, KPIP.IDPhongBan, KPIP.IDKPI).Single();
                return KPIP;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lKPIP.sp_tblBKChiTieuKPIPhong_ThemSua(KPIP.Nam, KPIP.IDDonVi, KPIP.IDPhongBan, KPIP.IDKPI, KPIP.IDXuHuongYeuCau, KPIP.MucTieuNam, KPIP.MucTieuThang1,
                KPIP.MucTieuThang2, KPIP.MucTieuThang3, KPIP.MucTieuThang4, KPIP.MucTieuThang5, KPIP.MucTieuThang6, KPIP.MucTieuThang7, KPIP.MucTieuThang8, KPIP.MucTieuThang9,
                KPIP.MucTieuThang10, KPIP.MucTieuThang11, KPIP.MucTieuThang12, KPIP.NguoiTao);
        }

        public void CapNhatMucTieuNam()
        {
            lKPIP.sp_tblBKChiTieuKPIPhong_CapNhatMucTieuNam(KPIP.Nam, KPIP.IDDonVi, KPIP.IDPhongBan);
        }

        public void Xoa()
        {
            lKPIP.sp_tblBKChiTieuKPIPhong_Xoa(KPIP.Nam, KPIP.IDDonVi, KPIP.IDPhongBan, KPIP.IDKPI);
        }

        public void KhoiTao()
        {
            lKPIP.sp_tblBKChiTieuKPIPhong_KhoiTao(KPIP.Nam, KPIP.IDDonVi, KPIP.IDPhongBan, KPIP.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKChiTieuKPIPhong_DanhSachResult> lst;
            lst = lKPIP.sp_tblBKChiTieuKPIPhong_DanhSach(KPIP.Nam, KPIP.IDDonVi, KPIP.IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
