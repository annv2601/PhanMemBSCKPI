using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NhanVien;

namespace DaoBSCKPI.NhanVien
{
    public class daNhanVien
    {
        private linqNhanVienDataContext lNV = new linqNhanVienDataContext();
        private sp_tblNhanVien_ThongTinResult _NV = new sp_tblNhanVien_ThongTinResult();

        public sp_tblNhanVien_ThongTinResult NV { get => _NV; set => _NV = value; }

        public sp_tblNhanVien_ThongTinResult ThongTin()
        {
            try
            {
                NV = lNV.sp_tblNhanVien_ThongTin(NV.IDNhanVien).Single();
                return NV;
            }
            catch
            {
                return null;
            }
        }

        public void SuaHoatDong()
        {
            lNV.sp_tblNhanVien_SuaHoatDong(NV.IDNhanVien, NV.HoatDong);
        }

        public void ThemSua()
        {
            lNV.sp_tblNhanVien_ThemSua(NV.IDNhanVien, NV.MaNhanVien, NV.TenNhanVien, NV.HoDem, NV.Ten, NV.NgaySinh, NV.GioiTinh, NV.DienThoaiDiDong, NV.Email, true,NV.urlAnh, NV.NguoiTao);
        }
    }
}
