using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ChiTieuKPI;

namespace DaoBSCKPI.ChiTieuKPI
{
    public class daTrongSoNhomKPI
    {
        private linqTrongSoNhomKPIDataContext lTSo = new linqTrongSoNhomKPIDataContext();
        private sp_tblBKTrongSoNhomKPI_ThongTinResult _TSN = new sp_tblBKTrongSoNhomKPI_ThongTinResult();

        public sp_tblBKTrongSoNhomKPI_ThongTinResult TSN { get => _TSN; set => _TSN = value; }

        public sp_tblBKTrongSoNhomKPI_ThongTinResult ThongTin()
        {
            try
            {
                TSN = lTSo.sp_tblBKTrongSoNhomKPI_ThongTin(TSN.IDNhomKPI, TSN.TuNgay).Single();
                return TSN;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lTSo.sp_tblBKTrongSoNhomKPI_ThemSua(TSN.IDNhomKPI, TSN.GiaTri, TSN.TuNgay, TSN.DenNgay, TSN.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKTrongSoNhomKPI_DanhSachResult> lst;
            lst = lTSo.sp_tblBKTrongSoNhomKPI_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSach_DDL(DateTime rNgay)
        {
            List<sp_tblBKTrongSoNhomKPI_DanhSachResult> lst;
            DataTable BangDL = new DataTable();
            BangDL.Columns.Add("ID", typeof(int));
            BangDL.Columns.Add("Ten", typeof(String));

            lst = lTSo.sp_tblBKTrongSoNhomKPI_DanhSach().ToList();
            foreach(sp_tblBKTrongSoNhomKPI_DanhSachResult pt in lst)
            {
                if(rNgay >=pt.TuNgay && rNgay<=pt.DenNgay)
                {
                    BangDL.Rows.Add(pt.IDNhomKPI, pt.TenChon);
                }
            }

            return BangDL;
        }
    }
}
