using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DonVi;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.MoHinhToChuc
{
    public partial class frmNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachDonVi(DateTime.Now,daPhien.NguoiDung.IDDonVi.Value);
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

        private void DanhSachDonVi(DateTime rNgay,int rIDDVQL)
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = rNgay;
            dMHDV.MHDV.IDDonViQuanLy = rIDDVQL;
            stoDonVi.DataSource = dMHDV.DanhSach();
            stoDonVi.DataBind();
        }
        #endregion

        #region Su Kien Danh Sach
        protected void DanhSachNhanVien(object sender, StoreReadDataEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null||slbPhongBan.SelectedItem.Value==null)
            {
                return;
            }
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dTTNV.TTNV.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);

            stoNhanVien.DataSource = dTTNV.DanhSach();
            stoNhanVien.DataBind();
        }

        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            daMoHinhPhongBan dMHPB = new daMoHinhPhongBan();
            dMHPB.MHPB.TuNgay = DateTime.Now;
            dMHPB.MHPB.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            stoPhong.DataSource = dMHPB.DanhSachDDL();
            stoPhong.DataBind();
        }
        #endregion

        #region Su kien Nut bam
        protected void btnThemMoiNhanVien_Click(object sender, DirectEventArgs e)
        {

        }
        #endregion

        #region Su kien menu
        protected void mnuitemThongTin_Click(object sender, DirectEventArgs e)
        {

        }
        #endregion
    }
}