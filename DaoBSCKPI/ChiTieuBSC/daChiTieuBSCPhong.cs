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

        public sp_tblBKChiTieuBSCPhong_ThongTinResult ThongTin()
        {
            try
            {
                BSCP = lBSCP.sp_tblBKChiTieuBSCPhong_ThongTin().Single();
                return BSCP;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lBSCP.sp_tblBKChiTieuBSCPhong_ThemSua(BSCP.Thang, BSCP.Nam, BSCP.IDDonVi, BSCP.IDPhongBan, BSCP.IDBSC, BSCP.IDXuHuongYeuCau, BSCP.TrongSoChung, BSCP.TrongSoChiTieu,
                BSCP.MucTieu, BSCP.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKChiTieuBSCPhong_DanhSachResult> lst;
            lst = lBSCP.sp_tblBKChiTieuBSCPhong_DanhSach(BSCP.Thang, BSCP.Nam, BSCP.IDDonVi, BSCP.IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
