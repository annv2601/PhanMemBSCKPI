using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DonVi;

namespace DaoBSCKPI.DonVi
{
    public class daMoHinhDonVi
    {
        private linqMoHinhDonViDataContext lmhdv = new linqMoHinhDonViDataContext();
        private sp_tblMoHinhDonVi_ThongTinResult _MHDV = new sp_tblMoHinhDonVi_ThongTinResult();

        public sp_tblMoHinhDonVi_ThongTinResult MHDV { get => _MHDV; set => _MHDV = value; }

        public sp_tblMoHinhDonVi_ThongTinResult ThongTin()
        {
            try
            {
                MHDV = lmhdv.sp_tblMoHinhDonVi_ThongTin(MHDV.IDDonVi, MHDV.TuNgay).Single();
                return MHDV;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lmhdv.sp_tblMoHinhDonVi_ThemSua(MHDV.IDDonVi, MHDV.IDDonViQuanLy, MHDV.STTsx, MHDV.TuNgay, MHDV.DenNgay, MHDV.GhiChu, MHDV.NguoiTao);
        }

        public void SuaDenNgay()
        {
            lmhdv.sp_tblMoHinhDonVi_SuaDenNgay(MHDV.IDDonVi, MHDV.DenNgay);
        }

        public DataTable DanhSach()
        {
            List<sp_tblMoHinhDonVi_DanhSachResult> lst;
            lst = lmhdv.sp_tblMoHinhDonVi_DanhSach(MHDV.IDDonViQuanLy, MHDV.TuNgay).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
