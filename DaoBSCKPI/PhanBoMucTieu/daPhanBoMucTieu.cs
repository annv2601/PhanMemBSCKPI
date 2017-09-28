using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.PhanBoMucTieu;

namespace DaoBSCKPI.PhanBoMucTieu
{
    public class daPhanBoMucTieu:daThamSo
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

        public void KhoiTao()
        {
            lPB.sp_tblBKPhanBoMucTieu_KhoiTao(Thang, Nam, IDDonVi, IDPhongBan, MT.NguoiTao);
        }

        public int KiemTraCoSoLieu()
        {
            return lPB.sp_tblBKPhanBoMucTieu_KiemTraCoSoLieu(Thang, Nam, IDDonVi, IDPhongBan).Single().SoLuongCo.Value;
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKPhanBoMucTieu_DanhSachResult> lst;
            lst = lPB.sp_tblBKPhanBoMucTieu_DanhSach(MT.Thang, MT.Nam, MT.IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSach_DonVi()
        {
            List<sp_tblBKPhanBoMucTieu_DanhSach_DonViResult> lst;
            lst = lPB.sp_tblBKPhanBoMucTieu_DanhSach_DonVi(MT.Thang, MT.Nam, IDDonVi,IDPhongBan,MT.IDKPI).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachChiTieu()
        {
            List<sp_tblBKPhanBoMucTieu_DanhSach_ChiTieuResult> lst;
            lst = lPB.sp_tblBKPhanBoMucTieu_DanhSach_ChiTieu(Thang, Nam, IDDonVi, IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
