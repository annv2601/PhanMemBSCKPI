using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.KeHoachDanhGia;

namespace DaoBSCKPI.KeHoachDanhGia
{
    public class daKeHoachDanhGiaDonVi
    {
        private linqKeHoachDanhGiaTheoDonViDataContext lKHDV = new linqKeHoachDanhGiaTheoDonViDataContext();
        private sp_tblBKKeHoachDanhGiaTheoDonVi_DanhSachResult _KHDonVi = new sp_tblBKKeHoachDanhGiaTheoDonVi_DanhSachResult();
        public sp_tblBKKeHoachDanhGiaTheoDonVi_DanhSachResult KHDonVi { get => _KHDonVi; set => _KHDonVi = value; }

        public void ThemSua()
        {
            lKHDV.sp_tblBKKeHoachDanhGiaTheoDonVi_ThemSua(KHDonVi.IDKeHoach, KHDonVi.IDDonVi, KHDonVi.IDPhongBan, KHDonVi.TuNgay, KHDonVi.DenNgay);
        }

        public void Xoa()
        {
            lKHDV.sp_tblBKKeHoachDanhGiaTheoDonVi_Xoa(KHDonVi.IDKeHoach, KHDonVi.IDDonVi);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKKeHoachDanhGiaTheoDonVi_DanhSachResult> lst;
            lst = lKHDV.sp_tblBKKeHoachDanhGiaTheoDonVi_DanhSach(KHDonVi.IDKeHoach).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachChon(int rIDCapTren)
        {
            List<sp_tblBKKeHoachDanhGiaTheoDonVi_DanhSachChonResult> lst;
            lst = lKHDV.sp_tblBKKeHoachDanhGiaTheoDonVi_DanhSachChon(KHDonVi.IDKeHoach, rIDCapTren).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
