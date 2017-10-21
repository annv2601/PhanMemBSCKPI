using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DonVi;

namespace DaoBSCKPI.DonVi
{
    public class daMoHinhPhongBan
    {
        private linqMoHinhPhongBanDataContext lmhpb = new linqMoHinhPhongBanDataContext();
        private sp_tblMoHinhPhongBan_ThongTinResult _MHPB = new sp_tblMoHinhPhongBan_ThongTinResult();

        public sp_tblMoHinhPhongBan_ThongTinResult MHPB { get => _MHPB; set => _MHPB = value; }

        public sp_tblMoHinhPhongBan_ThongTinResult ThongTin()
        {
            try
            {
                MHPB = lmhpb.sp_tblMoHinhPhongBan_ThongTin(MHPB.IDDonVi, MHPB.IDPhongBan, MHPB.TuNgay).Single();
                return MHPB;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lmhpb.sp_tblMoHinhPhongBan_ThemSua(MHPB.IDDonVi, MHPB.IDPhongBan, MHPB.STTsx, MHPB.TuNgay, MHPB.DenNgay, MHPB.NguoiTao);
        }

        public void SuaDenNgay()
        {
            lmhpb.sp_tblMoHinhPhongBan_SuaDenNgay(MHPB.IDDonVi, MHPB.IDPhongBan, MHPB.DenNgay);
        }

        public DataTable DanhSach()
        {
            List<sp_tblMoHinhPhongBan_DanhSachResult> lst;
            lst = lmhpb.sp_tblMoHinhPhongBan_DanhSach(MHPB.IDDonVi, MHPB.TuNgay).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachDDL()
        {
            List<sp_tblMoHinhPhongBan_DanhSachResult> lst;
            lst = lmhpb.sp_tblMoHinhPhongBan_DanhSach(MHPB.IDDonVi, MHPB.TuNgay).ToList();
            DataTable dt= daDatatableVaList.ToDataTable(lst);
            try
            {
                dt.Columns.Remove("IDDonVi");
                dt.Columns.Remove("STTsx");
                dt.Columns.Remove("TuNgay");
                dt.Columns.Remove("DenNgay");
                dt.Columns.Remove("NgayTao");
                dt.Columns.Remove("NguoiTao");
            }
            catch { }


            dt.Rows.Add(0, "--- Không Phòng ban ---");
            return dt;
        }
    }
}
