using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.CongViecCaNhan;

namespace DaoBSCKPI.CongViecCaNhan
{
    public class dacvcnKetQuaDanhGia
    {
        private linqcvcnKetQuaDanhGiaDataContext lKQDG = new linqcvcnKetQuaDanhGiaDataContext();
        private sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult _KQDG = new sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult();

        public sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult KQDG { get => _KQDG; set => _KQDG = value; }

        public sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult ThongTin()
        {
            try
            {
                KQDG = lKQDG.sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTin(KQDG.MaCongViecCaNhan, KQDG.IDNguoiDuocDanhGia).Single();
                return KQDG;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lKQDG.sp_tblcvCongViecCaNhanKetQuaDanhGia_ThemSua(KQDG.MaCongViecCaNhan, KQDG.IDNguoiDanhGia, KQDG.IDNguoiDuocDanhGia, KQDG.ChatLuong,
                KQDG.KhoiLuong, KQDG.TienDo, KQDG.DoPhucTap, KQDG.TrachNhiem, KQDG.IDKetQua);
        }
        
        public DataTable DanhSach()
        {
            List<sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSachResult> lst;
            lst = lKQDG.sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSach(KQDG.MaCongViecCaNhan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
