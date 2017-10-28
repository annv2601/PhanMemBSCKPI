using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoBSCKPI.Database.CongViecCaNhan;
using System.Data;

namespace DaoBSCKPI.CongViecCaNhan
{
    public class dacvcnGiaHan
    {
        private linqcvcnGiaHanDataContext lGH = new linqcvcnGiaHanDataContext();
        private sp_tblcvCongViecCaNhanGiaHan_ThongTinResult _GH = new sp_tblcvCongViecCaNhanGiaHan_ThongTinResult();

        public sp_tblcvCongViecCaNhanGiaHan_ThongTinResult GH { get => _GH; set => _GH = value; }

        public sp_tblcvCongViecCaNhanGiaHan_ThongTinResult ThongTin()
        {
            try
            {
                GH = lGH.sp_tblcvCongViecCaNhanGiaHan_ThongTin(GH.MaCongViecCaNhan, GH.LanGiaHan).Single();
                return GH;
            }
            catch
            {
                return null;
            }
        }

        public void Them()
        {
            lGH.sp_tblcvCongViecCaNhanGiaHan_Them(GH.MaCongViecCaNhan, GH.HanNgayCu, GH.HanGioCu, GH.HanNgayMoi, GH.HanGioMoi, GH.LyDo, GH.NguoiThucHien);
        }

        public DataTable DanhSach()
        {
            List<sp_tblcvCongViecCaNhanGiaHan_DanhSachResult> lst;
            lst = lGH.sp_tblcvCongViecCaNhanGiaHan_DanhSach(GH.MaCongViecCaNhan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
