using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.PhanBoMucTieu;

namespace DaoBSCKPI.PhanBoMucTieu
{
    public class daPhanBoMucTieu
    {
        private linqPhanBoMucTieuDataContext lPB = new linqPhanBoMucTieuDataContext();
        private sp_tblBKPhanBoMucTieu_ThongTinResult _MT = new sp_tblBKPhanBoMucTieu_ThongTinResult();

        public sp_tblBKPhanBoMucTieu_ThongTinResult MT { get => _MT; set => _MT = value; } 

        public sp_tblBKPhanBoMucTieu_ThongTinResult ThongTin()
        {
            try
            {
                MT = lPB.sp_tblBKPhanBoMucTieu_ThongTin(MT.Thang, MT.Nam, MT.IDNhanVien,MT.IDKPI).Single();
                return MT;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lPB.sp_tblBKPhanBoMucTieu_ThemSua(MT.Thang, MT.Nam, MT.IDNhanVien, MT.IDKPI, MT.IDXuHuongYeuCau, MT.MucTieu, MT.TrongSo, MT.NguoiTao);
        }

        public void Xoa()
        {
            lPB.sp_tblBKPhanBoMucTieu_Xoa(MT.Thang, MT.Nam, MT.IDNhanVien, MT.IDKPI);
        }

        public void KhoiTao(int rIDDonVi, int rIDPhongBan)
        {
            lPB.sp_tblBKPhanBoMucTieu_KhoiTao(MT.Thang, MT.Nam, rIDDonVi, rIDPhongBan, MT.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKPhanBoMucTieu_DanhSachResult> lst;
            lst = lPB.sp_tblBKPhanBoMucTieu_DanhSach(MT.Thang, MT.Nam, MT.IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
