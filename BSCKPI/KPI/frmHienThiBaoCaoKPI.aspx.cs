using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI.NhanVien;
using BaoBieuIn.PhanBo;
using DaoBSCKPI.DonVi;

namespace BSCKPI.KPI
{
    public partial class frmHienThiBaoCaoKPI : System.Web.UI.Page
    {
        private rptBangPhanBo crBangPB = new rptBangPhanBo();
        protected void Page_Load(object sender, EventArgs e)
        {
            BangPhanBo(9, 2017, Guid.Parse("2cdac79d-aa49-4998-9593-a66af89cbc98"));
            /*
            if (Request.QueryString["ThangBaoCao"]!=null)
            {
                byte _Thang;
                int _Nam;
                Guid _IDNhanVien;
                _Thang = byte.Parse(Request.QueryString["ThangBaoCao"]);
                _Nam = int.Parse(Request.QueryString["NamBaoCao"]);
                _IDNhanVien = Guid.Parse(Request.QueryString["NhanVienBaoCao"]);
                switch(int.Parse(Request.QueryString["BieuBaoCao"]))
                {
                    case 1:
                        BangPhanBo(_Thang, _Nam, _IDNhanVien);
                        break;
                    case 2:
                        break;
                }
            }*/
        }

        #region Phan bo muc tieu
        private void BangPhanBo(byte rThang, int rNam, Guid rIDNhanVien)
        {
            daBangDanhGia dBDG = new daBangDanhGia();
            dBDG.Thang = rThang;
            dBDG.Nam = rNam;
            dBDG.IDNhanVien = rIDNhanVien;
            crBangPB.SetDataSource(dBDG.BangPhanBo());

            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.IDNhanVien = rIDNhanVien;
            dTTNV.TTNV.Thang = rThang;
            dTTNV.TTNV.Nam = rNam;
            dTTNV.ThongTin();

            daDonVi dDV = new daDonVi();
            daPhongBan dPB = new daPhongBan();
                        
            if (dTTNV.TTNV.IDPhongBan!=0)
            {
                dPB.PB.ID = dTTNV.TTNV.IDPhongBan.Value;
                dPB.ThongTin();
                crBangPB.SetParameterValue(6, dPB.PB.Ten);
            }
            else
            {
                dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
                dDV.ThongTin();
                crBangPB.SetParameterValue(6, dDV.DV.Ten);
            }

            dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
            dDV.ThongTin();
            crBangPB.SetParameterValue(1, dDV.DV.Ten);
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.IDDonVi = dTTNV.TTNV.IDDonVi.Value;
            dMHDV.MHDV.TuNgay = DateTime.Parse(rThang.ToString()+"/01/"+rNam.ToString());
            dMHDV.ThongTin();
            dDV.DV.ID = dMHDV.MHDV.IDDonViQuanLy;
            dDV.ThongTin();
            crBangPB.SetParameterValue(0, dDV.DV.Ten);

            crBangPB.SetParameterValue(2, "Tháng " + rThang.ToString() + " năm " + rNam.ToString());

            crBangPB.SetParameterValue(3, dTTNV.TTNV.TenNhanVien);
                       
            dTTNV.TimTT();
            
            crBangPB.SetParameterValue(4, dTTNV.Tim.ChucVu);
            crBangPB.SetParameterValue(5, dTTNV.Tim.ChucDanh);
            
            
            CrystalReportViewer1.ReportSource = crBangPB;
        }
        #endregion
    }
}