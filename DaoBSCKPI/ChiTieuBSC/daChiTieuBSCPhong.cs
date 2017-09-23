using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ChiTieuBSC;

namespace DaoBSCKPI.ChiTieuBSC
{
    public class daChiTieuBSCPhong
    {
        private linqChiTieuBSCPhongDataContext lBSCP = new linqChiTieuBSCPhongDataContext();
        private sp_tblBKChiTieuBSCPhong_ThongTinResult _BSCP = new sp_tblBKChiTieuBSCPhong_ThongTinResult();

        public sp_tblBKChiTieuBSCPhong_ThongTinResult BSCP { get => _BSCP; set => _BSCP = value; }
        public sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult HtBSCP { get => _htBSCP; set => _htBSCP = value; }

        private sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult _htBSCP = new sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult();

        public List<sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult> lstBSCPhong = new List<sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult>();

        public sp_tblBKChiTieuBSCPhong_ThongTinResult ThongTin()
        {
            try
            {
                BSCP = lBSCP.sp_tblBKChiTieuBSCPhong_ThongTin(BSCP.Thang,BSCP.Nam,BSCP.IDDonVi,BSCP.IDPhongBan,BSCP.IDBSC).Single();
                return BSCP;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult ThongTinHienThi()
        {
            try
            {
                HtBSCP = lBSCP.sp_tblBKChiTieuBSCPhong_ThongTinHienThi(BSCP.Thang, BSCP.Nam, BSCP.IDDonVi, BSCP.IDPhongBan, BSCP.IDBSC).Single();
                return HtBSCP;
            }
            catch
            {
                return null;
            }
        }

        public void KhoiTao()
        {
            lBSCP.sp_tblBKChiTieuBSCPhong_KhoiTao(BSCP.Thang, BSCP.Nam, BSCP.IDDonVi, BSCP.IDPhongBan, BSCP.NguoiTao);
        }
        
        public decimal LayTrongSoChung()
        {
            return lBSCP.sp_tblBKChiTieuBSC_LayTrongSo(BSCP.IDBSC).Single().TrongSoChung.Value;
        }

        public void ThemSua()
        {
            lBSCP.sp_tblBKChiTieuBSCPhong_ThemSua(BSCP.Thang, BSCP.Nam, BSCP.IDDonVi, BSCP.IDPhongBan, BSCP.IDBSC, BSCP.IDDonViTinh,BSCP.IDTanSuatDo,
                BSCP.IDXuHuongYeuCau, BSCP.TrongSoChung, BSCP.TrongSoChiTieu,BSCP.MucTieu, BSCP.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKChiTieuBSCPhong_DanhSachResult> lst;
            lst = lBSCP.sp_tblBKChiTieuBSCPhong_DanhSach(BSCP.Thang, BSCP.Nam, BSCP.IDDonVi, BSCP.IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public List<sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult> DanhSachNhom(int IDNhom)
        {
            lstBSCPhong = lBSCP.sp_tblBKChiTieuBSCPhong_DanhSach_NhomID(BSCP.Thang,BSCP.Nam,BSCP.IDDonVi,BSCP.IDPhongBan,IDNhom).ToList();
            return lstBSCPhong;
        }
    }
}
