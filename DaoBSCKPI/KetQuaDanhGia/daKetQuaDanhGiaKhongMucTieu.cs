using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.KetQuaDanhGia;

namespace DaoBSCKPI.KetQuaDanhGia
{
    public class daKetQuaDanhGiaKhongMucTieu
    {
        private linqKetQuaDanhGiaKhongMucTieuDataContext lKQK = new linqKetQuaDanhGiaKhongMucTieuDataContext();
        private sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTinResult _KQK = new sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTinResult();

        public sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTinResult KQK { get => _KQK; set => _KQK = value; }

        public void KhoiTao(daThamSo dTS)
        {
            lKQK.sp_tblBKKetQuaDanhGia_KhongMucTieu_KhoiTao(dTS.Thang, dTS.Nam, dTS.IDDonVi, dTS.IDPhongBan, dTS.IDNguoiDung);
        }

        public void CapNhat()
        {
            lKQK.sp_tblBKKetQuaDanhGia_KhongMucTieu_CapNhat(KQK.Thang, KQK.Nam, KQK.IDNhanVien, KQK.IDKPI, KQK.KetQua, KQK.TrongSo,
                KQK.Diem, KQK.DienGiai, KQK.NguoiSua);
        }
    }
}
