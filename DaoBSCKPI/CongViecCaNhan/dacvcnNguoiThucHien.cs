using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.CongViecCaNhan;

namespace DaoBSCKPI.CongViecCaNhan
{
    public class dacvcnNguoiThucHien:daThamSo
    {
        private linqcvcnNguoiThucHienDataContext lNTH = new linqcvcnNguoiThucHienDataContext();
        private sp_tblcvCongViecCaNhanNguoiThucHien_ThongTinResult _NTH = new sp_tblcvCongViecCaNhanNguoiThucHien_ThongTinResult();

        public sp_tblcvCongViecCaNhanNguoiThucHien_ThongTinResult NTH { get => _NTH; set => _NTH = value; }

        public sp_tblcvCongViecCaNhanNguoiThucHien_ThongTinResult ThongTin()
        {
            try
            {
                NTH = lNTH.sp_tblcvCongViecCaNhanNguoiThucHien_ThongTin(NTH.MaCongViecCaNhan, NTH.IDNguoiThucHien).Single();
                return NTH;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lNTH.sp_tblcvCongViecCaNhanNguoiThucHien_ThemSua(NTH.MaCongViecCaNhan, NTH.IDNguoiThucHien, NTH.YKienChiDao, NTH.NgayGiao);
        }

        public void Xoa()
        {
            lNTH.sp_tblcvCongViecCaNhanNguoiThucHien_Xoa(NTH.MaCongViecCaNhan, NTH.IDNguoiThucHien);
        }

        public void DanhGiaKetQua()
        {
            lNTH.sp_tblcvCongViecCaNhanNguoiThucHien_DanhGia(NTH.MaCongViecCaNhan, NTH.IDNguoiThucHien, NTH.IDKetQua, NTH.ChatLuong, NTH.KhoiLuong,
                NTH.TienDo, NTH.DoPhucTap, NTH.TrachNhiem);
        }

        public DataTable DanhSach()
        {
            List<sp_tblcvCongViecCaNhanNguoiThucHien_DanhSachResult> lst;
            lst = lNTH.sp_tblcvCongViecCaNhanNguoiThucHien_DanhSach(NTH.MaCongViecCaNhan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachGan()
        {
            List<sp_tblcvCongViecCaNhanNguoiThucHien_DanhSachGanResult> lst;
            lst = lNTH.sp_tblcvCongViecCaNhanNguoiThucHien_DanhSachGan(Thang,Nam,IDDonVi,IDPhongBan,NTH.MaCongViecCaNhan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
