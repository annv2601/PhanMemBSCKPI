using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DanhMucMoHinh;

namespace DaoBSCKPI.DanhMucHeThong
{
    public class daNhomDanhMucHT
    {
        public enum eNhom
        {
            Cấp_đơn_vị=1,
            Loại_đơn_vị=2,
            Nhóm_chức_vụ=3,
            Nhóm_chức_danh=4
        }

        private linqDanhMucHeThongDataContext lDM = new linqDanhMucHeThongDataContext();
        private sp_tblNhomDanhMuc_ThongTinResult _NhomDM = new sp_tblNhomDanhMuc_ThongTinResult();

        public sp_tblNhomDanhMuc_ThongTinResult NhomDM { get => _NhomDM; set => _NhomDM = value; }

        public sp_tblNhomDanhMuc_ThongTinResult ThongTin()
        {
            try
            {
                NhomDM = lDM.sp_tblNhomDanhMuc_ThongTin(NhomDM.ID).Single();
                return NhomDM;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lDM.sp_tblNhomDanhMuc_ThemSua(NhomDM.ID, NhomDM.Ma, NhomDM.Ten, NhomDM.GhiChu, NhomDM.STTsx);
        }

        public DataTable DanhSach(int rNhom)
        {
            List<sp_tblNhomDanhMuc_DanhSachResult> lst;
            lst = lDM.sp_tblNhomDanhMuc_DanhSach(rNhom).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
