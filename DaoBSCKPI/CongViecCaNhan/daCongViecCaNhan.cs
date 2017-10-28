using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.CongViecCaNhan;

namespace DaoBSCKPI.CongViecCaNhan
{
    public class daCongViecCaNhan:daThamSo
    {
        private linqCongViecCaNhanDataContext lCVCN = new linqCongViecCaNhanDataContext();
        private sp_tblcvCongViecCaNhan_ThongTinResult _CVCN = new sp_tblcvCongViecCaNhan_ThongTinResult();

        public sp_tblcvCongViecCaNhan_ThongTinResult CVCN { get => _CVCN; set => _CVCN = value; }

        public sp_tblcvCongViecCaNhan_ThongTinResult ThongTin()
        {
            try
            {
                CVCN = lCVCN.sp_tblcvCongViecCaNhan_ThongTin(CVCN.Ma).Single();
                return CVCN;
            }
            catch
            {
                return null;
            }
        }

        public decimal ThemSua()
        {
            return lCVCN.sp_tblcvCongViecCaNhan_ThemSua(CVCN.Ma, CVCN.MaNhap, CVCN.NoiDung, CVCN.NguoiGiaoViec, CVCN.NguoiTheoDoi, CVCN.NgayGiaoViec,
                CVCN.NgayDenHan, CVCN.GioDenHan, CVCN.IDMucDo, CVCN.NguoiLamChinh, CVCN.ChiDaoChung, CVCN.MaCongViecDonVi, CVCN.IDKPI,
                CVCN.IDDonVi, CVCN.IDPhongBan, CVCN.IDTrangThai).Single().MaCongViec.Value;
        }

        public void DanhGiaketQua()
        {
            lCVCN.sp_tblcvCongViecCaNhan_DanhGiaKetQua(CVCN.Ma, CVCN.IDTrangThai, CVCN.DaHoanThanh, CVCN.NguoiDanhGia, CVCN.MucDoHoanThanh, CVCN.KetQuaHoanThanh,CVCN.NgayHoanThanh);
        }

        public DataTable DanhSach()
        {
            List<sp_tblcvCongViecCaNhan_DanhSachResult> lst;
            lst = lCVCN.sp_tblcvCongViecCaNhan_DanhSach(TuNgay, DenNgay, IDDonVi, IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
