using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;
using DaoBSCKPI.Database.NhanVien;

using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI.CongViec;

using BSCKPI.UIHelper;
using Ext.Net;
namespace BSCKPI.KetQuaDanhGia
{
    public partial class frmBangPhong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
            }
        }

        #region Rieng
        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();


            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachBangDanhGiaCaNhan()
        {
            Ext.Net.Panel pl;

            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTTNV.TTNV.IDDonVi = daPhien.NguoiDung.IDDonVi.Value;
            dTTNV.TTNV.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;

            //Khoi tao cac bang ket qua
            daThamSo dTSo = new daThamSo();
            daKetQuaDanhGia dKQ = new daKetQuaDanhGia();
            daKetQuaDanhGiaKhongMucTieu dKQK = new daKetQuaDanhGiaKhongMucTieu();
            daKQNhiemVuTrongTam dKQNV = new daKQNhiemVuTrongTam();
            dTSo.Thang = Convert.ToByte(dTTNV.TTNV.Thang.Value);
            dTSo.Nam = dTTNV.TTNV.Nam.Value;
            dTSo.IDDonVi = dTTNV.TTNV.IDDonVi.Value;
            dTSo.IDPhongBan = dTTNV.TTNV.IDPhongBan.Value;
            dTSo.IDNguoiDung = daPhien.NguoiDung.IDNhanVien.ToString();
            dKQ.KhoiTao(dTSo);
            dKQK.KhoiTao(dTSo);
            dKQNV.KhoiTao(dTSo);
            dTSo = null;
            dKQ = null;
            dKQK = null;
            dKQNV = null;
            //=========================

            List<sp_tblThongTinNhanVien_DanhSach_DonViResult> lst;
            lst = dTTNV.lstDanhSach();
            int i = 0;
            foreach(sp_tblThongTinNhanVien_DanhSach_DonViResult pt in lst)
            {
                pl = new Ext.Net.Panel();
                i = i + 1;
                pl.ID = "pnlBDG" + i.ToString();
                pl.Closable = true;
                pl.Layout = "Fit";
                pl.Title = pt.TenNhanVien;
                pl.MinHeight = 500;
                pl.Loader = new ComponentLoader
                {
                    Mode = LoadMode.Frame,
                    TriggerEvent = "show",
                    DisableCaching = true,
                    Url = "frmBangCaNhan.aspx?NhanVien=" + pt.IDNhanVien.ToString()
                };                
                tabBangDanhGia.Add(pl);
                pl.Render();
            }

            tabBangDanhGia.SetActiveTab(0);

        }
        #endregion

        #region Su kien
        protected void ChonThangNam_Click(object sender, DirectEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null)
            {
                return;
            }
            Session["ThangBangDanhGiaCaNhan"] = slbThang.SelectedItem.Value;
            Session["NamBangDanhGiaCaNhan"] = slbNam.SelectedItem.Value;
            DanhSachBangDanhGiaCaNhan();
        }

        protected void btnBoSung_Click(object sender, DirectEventArgs e)
        {

        }
        #endregion
    }
}