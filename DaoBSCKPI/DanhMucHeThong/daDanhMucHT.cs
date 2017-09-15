using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DanhMucMoHinh;

namespace DaoBSCKPI.DanhMucHeThong
{
    public class daDanhMucHT
    {
        private linqDanhMucHeThongDataContext lDM = new linqDanhMucHeThongDataContext();
        private sp_tblDanhMucMoHinhToChuc_ThongTinResult _DM = new sp_tblDanhMucMoHinhToChuc_ThongTinResult();

        public sp_tblDanhMucMoHinhToChuc_ThongTinResult DM { get => _DM; set => _DM = value; }

        public sp_tblDanhMucMoHinhToChuc_ThongTinResult ThongTin()
        {
            try
            {
                DM = lDM.sp_tblDanhMucMoHinhToChuc_ThongTin(DM.ID).Single();
                return DM;
            }
            catch
            {
                return null;
            }
        }

        public void Xoa()
        {
            lDM.sp_tblDanhMucMoHinhToChuc_Xoa(DM.ID);
        }

        public void ThemSua()
        {
            lDM.sp_tblDanhMucMoHinhToChuc_ThemSua(DM.ID, DM.Ma, DM.Ten, DM.TenTat, DM.GhiChu, DM.STTsx, DM.Nhom, DM.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblDanhMucMoHinhToChuc_DanhSachResult> lst;
            lst = lDM.sp_tblDanhMucMoHinhToChuc_DanhSach(DM.Nhom).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
