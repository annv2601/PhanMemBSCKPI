using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.CongViecCaNhan;

namespace DaoBSCKPI.CongViecCaNhan
{
    public class dacvcnQuaTrinhXuLy
    {
        private linqcvcnQuaTrinhXuLyDataContext lQTXL = new linqcvcnQuaTrinhXuLyDataContext();
        private sp_tblcvCongViecCaNhanQuaTrinhXuLy_ThongTinResult _QTXL = new sp_tblcvCongViecCaNhanQuaTrinhXuLy_ThongTinResult();

        public sp_tblcvCongViecCaNhanQuaTrinhXuLy_ThongTinResult QTXL { get => _QTXL; set => _QTXL = value; }

        public sp_tblcvCongViecCaNhanQuaTrinhXuLy_ThongTinResult ThongTin()
        {
            try
            {
                QTXL = lQTXL.sp_tblcvCongViecCaNhanQuaTrinhXuLy_ThongTin(QTXL.MaCongViecCaNhan, QTXL.IDNguoiXuLy).Single();
                return QTXL;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lQTXL.sp_tblcvCongViecCaNhanQuaTrinhXuLy_ThemSua(QTXL.ID,QTXL.MaCongViecCaNhan, QTXL.IDNguoiXuLy, QTXL.IDHuongXuLy, QTXL.NoiDungXuLy, QTXL.IDNguoiChiDao, QTXL.YKienChiDao);
        }

        public void CapNhatChiDao()
        {
            lQTXL.sp_tblcvCongViecCaNhanQuaTrinhXuLy_CapNhatChiDao(QTXL.ID, QTXL.IDNguoiChiDao, QTXL.YKienChiDao);
        }

        public DataTable DanhSach()
        {
            List<clsCongViecCaNhan> lst;
            lst = lQTXL.sp_tblcvCongViecCaNhan_DanhSachTienTrinh(QTXL.MaCongViecCaNhan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
