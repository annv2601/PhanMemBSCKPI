using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.KeHoachDanhGia;

namespace DaoBSCKPI.KeHoachDanhGia
{
    public class daKeHoachDanhGiaChucVu
    {
        private linqKeHoachDanhGiaTheoChucVuDataContext lKHCV = new linqKeHoachDanhGiaTheoChucVuDataContext();
        private sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult _KHChucVu = new sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult();

        public sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult KHChucVu { get => _KHChucVu; set => _KHChucVu = value; }

        public void ThemSua()
        {
            lKHCV.sp_tblBKKeHoachDanhGiatheochucvu_ThemSua(KHChucVu.IDKeHoach, KHChucVu.IDChucVu, KHChucVu.IDChucDanh, KHChucVu.TuNgay, KHChucVu.DenNgay);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult> lst;
            lst = lKHCV.sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach(KHChucVu.IDKeHoach).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public void XoaChucVu()
        {
            lKHCV.sp_tblBKKeHoachDanhGiaTheoChucVu_Xoa(KHChucVu.IDKeHoach, KHChucVu.IDChucVu);
        }

        public void XoaChucDanh()
        {
            lKHCV.sp_tblBKKeHoachDanhGiaTheoChucVu_XoaChucDanh(KHChucVu.IDKeHoach, KHChucVu.IDChucDanh);
        }

        public DataTable DanhSachChonChucVu()
        {
            List<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVuResult> lst;
            lst = lKHCV.sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVu(KHChucVu.IDKeHoach).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachChonChucDanh()
        {
            List<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanhResult> lst;
            lst = lKHCV.sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanh(KHChucVu.IDKeHoach).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
