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
using DaoBSCKPI.Database.KeHoachDanhGia;
using DaoBSCKPI.KeHoachDanhGia;

namespace BSCKPI.KPI
{
    public partial class frmHienThiBaoCaoKPI : System.Web.UI.Page
    {
        private rptBangPhanBo crBangPB = new rptBangPhanBo();
        private crBangPhanBoNhieu rptBangPBNhieu = new crBangPhanBoNhieu();
        protected void Page_Load(object sender, EventArgs e)
        {
            //BangPhanBo(9, 2017, Guid.Parse("2cdac79d-aa49-4998-9593-a66af89cbc98"));
            
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
                        BangPhanBoKeHoach(_Thang, _Nam, int.Parse(Request.QueryString["IDKeHoach"]));
                        break;
                }
            }
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


        #region Tham So
        private void NapThamSoPB(byte rThang, int rNam, Guid rIDNhanVien, string rTenBC)
        {
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.IDNhanVien = rIDNhanVien;
            dTTNV.TTNV.Thang = rThang;
            dTTNV.TTNV.Nam = rNam;
            dTTNV.ThongTin();

            daDonVi dDV = new daDonVi();
            daPhongBan dPB = new daPhongBan();

            if (dTTNV.TTNV.IDPhongBan != 0)
            {
                dPB.PB.ID = dTTNV.TTNV.IDPhongBan.Value;
                dPB.ThongTin();
                rptBangPBNhieu.SetParameterValue("DonVi", dPB.PB.Ten,rTenBC);
            }
            else
            {
                dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
                dDV.ThongTin();
                rptBangPBNhieu.SetParameterValue("DonVi", dDV.DV.Ten, rTenBC);
            }

            dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
            dDV.ThongTin();
            rptBangPBNhieu.SetParameterValue("DonViDuoi", dDV.DV.Ten, rTenBC);
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.IDDonVi = dTTNV.TTNV.IDDonVi.Value;
            dMHDV.MHDV.TuNgay = DateTime.Parse(rThang.ToString() + "/01/" + rNam.ToString());
            dMHDV.ThongTin();
            dDV.DV.ID = dMHDV.MHDV.IDDonViQuanLy;
            dDV.ThongTin();
            rptBangPBNhieu.SetParameterValue("DonViTren", dDV.DV.Ten, rTenBC);

            rptBangPBNhieu.SetParameterValue("ThoiGian", "Tháng " + rThang.ToString() + " năm " + rNam.ToString(), rTenBC);

            rptBangPBNhieu.SetParameterValue("HoTen", dTTNV.TTNV.TenNhanVien, rTenBC);

            dTTNV.TimTT();

            rptBangPBNhieu.SetParameterValue("ChucVu", dTTNV.Tim.ChucVu, rTenBC);
            rptBangPBNhieu.SetParameterValue("ChucDanh", dTTNV.Tim.ChucDanh, rTenBC);
        }

        private void NapThamSoPBTrong(string rTenBC)
        {
            rptBangPBNhieu.SetParameterValue("DonVi", "", rTenBC);
            rptBangPBNhieu.SetParameterValue("DonViDuoi", "", rTenBC);
            rptBangPBNhieu.SetParameterValue("DonViTren", "", rTenBC);
            rptBangPBNhieu.SetParameterValue("ThoiGian", "", rTenBC);
            rptBangPBNhieu.SetParameterValue("HoTen", "", rTenBC);
            rptBangPBNhieu.SetParameterValue("ChucVu", "", rTenBC);
            rptBangPBNhieu.SetParameterValue("ChucDanh", "", rTenBC);
        }
        #endregion

        #region Nhieu
        private void BangPhanBoKeHoach(byte _Thang, int _Nam, int _IDKeHoach)
        {            
            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            List<sp_tblBKKeHoachDanhGia_DanhSachNhanVienResult> lst;
            dKH.Thang = _Thang;
            dKH.Nam = _Nam;
            dKH.KHDG.ID = _IDKeHoach;
            lst = dKH.lstDanhSachNhanVien();
            if (lst.Count > 0)
            {
                daBangDanhGia dBDG = new daBangDanhGia();
                dBDG.Thang = _Thang;
                dBDG.Nam = _Nam;

                int i = 0;
                string _TenBC;
                while (i < 100 && i < lst.Count)
                {
                    _TenBC = "rptPB" + i.ToString();
                    dBDG.IDNhanVien = lst[i].IDNhanVien.Value;
                    rptBangPBNhieu.Subreports[_TenBC].SetDataSource(dBDG.BangPhanBo());
                    i = i + 1;
                }
                /* while (i < 100)
                 {   
                     _TenBC = "rptDG" + i.ToString();
                     dBDG.IDNhanVien = Guid.Empty;

                     rptDGNhieu.Subreports[_TenBC].SetDataSource(dBDG.BangIn());
                     i = i + 1;
                 }*/

                //Nap tham so cac bao cao sau
                i = 0;
                while (i < 100 && i < lst.Count)
                {
                    _TenBC = "rptPB" + i.ToString();
                    NapThamSoPB(_Thang, _Nam, lst[i].IDNhanVien.Value, _TenBC);
                    i = i + 1;
                }
                int j = i;
                while (i < 100)
                {
                    _TenBC = "rptPB" + i.ToString();
                    NapThamSoPBTrong(_TenBC);
                    i = i + 1;
                }
                while (j <= 100)
                {
                    rptBangPBNhieu.ReportDefinition.Sections[j + 2].SectionFormat.EnableSuppress = true;
                    j = j + 1;
                }
                //================================


                //Hien thi bao cao
                CrystalReportViewer1.ReportSource = rptBangPBNhieu;
            }
        }
        
        #endregion
    }
}