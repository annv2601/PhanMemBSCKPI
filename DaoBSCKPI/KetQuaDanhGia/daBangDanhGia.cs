using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.KetQuaDanhGia;

namespace DaoBSCKPI.KetQuaDanhGia
{
    public class daBangDanhGia:daThamSo
    {
        public enum eLoaiChiTieu
        {
            KPI_Mục_Tiêu=1,
            Nhiệm_Vụ_Trọng_Tâm=2,
            KPI_Không_Mục_Tiêu=3
        }

        private linqBangDanhGiaDataContext lBDG = new linqBangDanhGiaDataContext();

        private clsBangDanhGia _Bang = new clsBangDanhGia();

        public clsBangDanhGia Bang { get => _Bang; set => _Bang = value; }

        public DataTable BangDanhGia()
        {
            List<clsBangDanhGia> lst;
            lst = lBDG.sp_tblBKMauBangDanhGia_Bang(Thang, Nam, IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
