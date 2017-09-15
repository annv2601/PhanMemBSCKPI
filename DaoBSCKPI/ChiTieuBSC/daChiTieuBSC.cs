using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ChiTieuBSC;

namespace DaoBSCKPI.ChiTieuBSC
{
    public class daChiTieuBSC
    {
        private linqChiTieuBSCDataContext lBSC = new linqChiTieuBSCDataContext();
        private sp_tblBKChiTieuBSC_ThongTinResult _BSC = new sp_tblBKChiTieuBSC_ThongTinResult();

        public sp_tblBKChiTieuBSC_ThongTinResult BSC { get => _BSC; set => _BSC = value; }

        public sp_tblBKChiTieuBSC_ThongTinResult ThongTin()
        {
            try
            {
                BSC = lBSC.sp_tblBKChiTieuBSC_ThongTin(BSC.ID).Single();
                return BSC;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lBSC.sp_tblBKChiTieuBSC_ThemSua(BSC.ID, BSC.Ma, BSC.STT, BSC.Ten, BSC.TrongSo, BSC.MucTieu, BSC.IDDonViTinh, BSC.IDChiTieuTren, BSC.Muc, BSC.IDTanSuatDo,
                BSC.IDXuHuongYeuCau, BSC.STTsx, BSC.InDam, BSC.InNghieng);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKChiTieuBSC_DanhSachResult> lst;
            lst = lBSC.sp_tblBKChiTieuBSC_DanhSach(BSC.IDChiTieuTren).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
