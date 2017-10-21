using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.KeHoachDanhGia;

namespace DaoBSCKPI.KeHoachDanhGia
{
    public class daKeHoachDanhGia:daThamSo
    {
        private linqKeHoachDanhGiaDataContext lKH = new linqKeHoachDanhGiaDataContext();
        private sp_tblBKKeHoachDanhGia_ThongTinResult _KHDG = new sp_tblBKKeHoachDanhGia_ThongTinResult();
        public sp_tblBKKeHoachDanhGia_ThongTinResult KHDG { get => _KHDG; set => _KHDG = value; }
        public daKeHoachDanhGiaChucVu CVu { get => _CVu; set => _CVu = value; }
        public daKeHoachDanhGiaDonVi DVi { get => _DVi; set => _DVi = value; }

        private daKeHoachDanhGiaChucVu _CVu = new daKeHoachDanhGiaChucVu();

        private daKeHoachDanhGiaDonVi _DVi = new daKeHoachDanhGiaDonVi();

        public sp_tblBKKeHoachDanhGia_ThongTinResult ThongTin()
        {
            try
            {
                KHDG = lKH.sp_tblBKKeHoachDanhGia_ThongTin(KHDG.ID).Single();
                return KHDG;
            }
            catch
            {
                return null;
            }
        }

        public int ThemSua()
        {
            return lKH.sp_tblBKKeHoachDanhGia_ThemSua(KHDG.ID, KHDG.Ten, KHDG.TuNgay, KHDG.DenNgay, KHDG.NguoiNhap).Single().IDKeHoachThem.Value;
        }

        public void KhoiTaoPhanBo()
        {
            lKH.sp_tblBKKeHoachDanhGia_KhoiTaoPhanBo(Thang, Nam, KHDG.ID, KHDG.NguoiNhap);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKKeHoachDanhGia_DanhSachResult> lst;
            lst = lKH.sp_tblBKKeHoachDanhGia_DanhSach(KHDG.TuNgay, KHDG.DenNgay).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachNhanVien()
        {
            List<sp_tblBKKeHoachDanhGia_DanhSachNhanVienResult> lst;
            lst = lKH.sp_tblBKKeHoachDanhGia_DanhSachNhanVien(Thang, Nam, KHDG.ID).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

    }
}
