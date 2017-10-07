using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.CongViec;

namespace DaoBSCKPI.CongViec
{
    public class daKQNhiemVuTrongTam
    {
        private linqKQNhiemVuTrongTamDataContext lKQNV = new linqKQNhiemVuTrongTamDataContext();
        private sp_tblcvKetQuaNhiemVuTrongTam_ThongTinResult _KQNV = new sp_tblcvKetQuaNhiemVuTrongTam_ThongTinResult();

        public sp_tblcvKetQuaNhiemVuTrongTam_ThongTinResult KQNV { get => _KQNV; set => _KQNV = value; }

        public sp_tblcvKetQuaNhiemVuTrongTam_ThongTinResult ThongTin()
        {
            try
            {
                KQNV = lKQNV.sp_tblcvKetQuaNhiemVuTrongTam_ThongTin(KQNV.Thang, KQNV.Nam, KQNV.IDNhiemVu).Single();
                return KQNV;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lKQNV.sp_tblcvKetQuaNhiemVuTrongTam_ThemSua(KQNV.Thang, KQNV.Nam, KQNV.IDNhiemVu, KQNV.KetQua, KQNV.TrongSo, KQNV.Diem,
                KQNV.DienGiai, KQNV.NguoiTao);
        }

        public void KhoiTao(daThamSo dTS)
        {
            lKQNV.sp_tblcvKetQuaNhiemVuTrongTam_KhoiTao(dTS.Thang, dTS.Nam, dTS.IDDonVi, dTS.IDPhongBan, dTS.IDNguoiDung);
        }

        public void CapNhat()
        {
            lKQNV.sp_tblcvKetQuaNhiemVuTrongTam_CapNhat(KQNV.Thang, KQNV.Nam, KQNV.IDNhiemVu, KQNV.KetQua, KQNV.TrongSo, KQNV.Diem,
                KQNV.DienGiai, KQNV.NguoiTao);
        }

        public void BoSung(daThamSo dTS)
        {
            lKQNV.sp_tblcvKetQuaNhiemVuTrongTam_BoSung(dTS.Thang, dTS.Nam, dTS.IDDonVi, dTS.IDPhongBan, dTS.IDNguoiDung);
        }
    }
}
