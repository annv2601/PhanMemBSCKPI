using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.KetQuaDanhGia;

namespace DaoBSCKPI.KetQuaDanhGia
{
    public class daKetQuaDanhGia
    {
        private linqKetQuaDanhGiaDataContext lKQ = new linqKetQuaDanhGiaDataContext();
        private sp_tblBKKetQuaDanhGia_ThongTinResult _KQ = new sp_tblBKKetQuaDanhGia_ThongTinResult();

        public sp_tblBKKetQuaDanhGia_ThongTinResult KQ { get => _KQ; set => _KQ = value; }

        public sp_tblBKKetQuaDanhGia_ThongTinResult ThongTin()
        {
            try
            {
                KQ = lKQ.sp_tblBKKetQuaDanhGia_ThongTin(KQ.Thang, KQ.Nam, KQ.IDNhanVien, KQ.IDKPI).Single();
                return KQ;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lKQ.sp_tblBKKetQuaDanhGia_ThemSua(KQ.Thang, KQ.Nam, KQ.IDNhanVien, KQ.IDKPI, KQ.KetQua, KQ.TrongSo, KQ.Diem, KQ.DienGiai, KQ.NguoiTao);
        }

        public void CapNhat()
        {
            lKQ.sp_tblBKKetQuaDanhGia_CapNhat(KQ.Thang, KQ.Nam, KQ.IDNhanVien, KQ.IDKPI, KQ.KetQua, KQ.TrongSo, KQ.Diem, KQ.DienGiai, KQ.NguoiTao);
        }

        public void Xoa()
        {
            lKQ.sp_tblBKKetQuaDanhGia_Xoa(KQ.Thang, KQ.Nam, KQ.IDNhanVien, KQ.IDKPI);
        }

        public void KhoiTao(daThamSo dTS)
        {
            lKQ.sp_tblBKKetQuaDanhGia_KhoiTao(dTS.Thang, dTS.Nam, dTS.IDDonVi, dTS.IDPhongBan, dTS.IDNguoiDung);
        }

        public void KhoiTaoNhanVien()
        {
            lKQ.sp_tblBKKetQuaDanhGia_KhoiTao_NhanVien(KQ.Thang, KQ.Nam, KQ.IDNhanVien, KQ.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKKetQuaDanhGia_DanhSachResult> lst;
            lst = lKQ.sp_tblBKKetQuaDanhGia_DanhSach(KQ.Thang, KQ.Nam, KQ.IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
