using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NhanVien;

namespace DaoBSCKPI.NhanVien
{
    public class daThongTinNhanVien
    {
        private linqThongTinNhanVienDataContext lTT = new linqThongTinNhanVienDataContext();
        private sp_tblThongTinNhanVien_ThongTinResult _TTNV = new sp_tblThongTinNhanVien_ThongTinResult();

        public sp_tblThongTinNhanVien_ThongTinResult TTNV { get => _TTNV; set => _TTNV = value; }

        public sp_tblThongTinNhanVien_ThongTinResult ThongTin()
        {
            try
            {
                TTNV = lTT.sp_tblThongTinNhanVien_ThongTin(TTNV.Thang, TTNV.Nam, TTNV.IDNhanVien).Single();
                return TTNV;
            }
            catch
            {
                return null;
            }
        }

        public void Xoa()
        {
            lTT.sp_tblThongTinNhanVien_Xoa(TTNV.Thang, TTNV.Nam, TTNV.IDNhanVien, TTNV.IDDonVi, TTNV.IDPhongBan);
        }

        public void ThemSua()
        {
            lTT.sp_tblThongTinNhanVien_ThemSua(TTNV.Thang, TTNV.Nam, TTNV.IDNhanVien, TTNV.TenNhanVien, TTNV.IDDonVi, TTNV.IDPhongBan, TTNV.IDChucVu,
                TTNV.IDChucDanh, TTNV.MoTaCongViec, TTNV.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblThongTinNhanVien_DanhSach_DonViResult> lst;
            lst = lTT.sp_tblThongTinNhanVien_DanhSach_DonVi(TTNV.Thang, TTNV.Nam, TTNV.IDDonVi, TTNV.IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
