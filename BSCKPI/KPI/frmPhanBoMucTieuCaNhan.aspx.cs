using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.PhanBoMucTieu;
using DaoBSCKPI.ChiTieuKPI;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI
{
    public partial class frmPhanBoMucTieuCaNhan : System.Web.UI.Page
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

        private bool KiemTraChonThangNam()
        {
            if (slbThang.SelectedItem.Value==null || slbNam.SelectedItem.Value==null)
            {
                /*X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn tháng hoặc năm!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });*/
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Su kien
        protected void DanhSachNhanVien(object sender, StoreReadDataEventArgs e)
        {
            if (KiemTraChonThangNam())
            {
                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.IDDonVi = daPhien.NguoiDung.IDDonVi;
                dTTNV.TTNV.IDPhongBan = daPhien.NguoiDung.IDPhongBan;
                dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
                stoNhanVien.DataSource = dTTNV.DanhSach();
                stoNhanVien.DataBind();
            }
        }

        protected void DanhSachChiTieu(object sender, StoreReadDataEventArgs e)
        {            
            if (KiemTraChonThangNam())
            {
                daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
                dPBMT.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dPBMT.Nam = int.Parse(slbNam.SelectedItem.Value);
                dPBMT.IDDonVi = daPhien.NguoiDung.IDDonVi.Value;
                dPBMT.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;
                stoChiTieu.DataSource = dPBMT.DanhSachChiTieu();
                stoChiTieu.DataBind();

                dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
                if (dPBMT.KiemTraCoSoLieu() == 0)
                {
                    dPBMT.KhoiTao();
                }
            }
        }

        protected void DanhSachPBMTNV(object sender, StoreReadDataEventArgs e)
        {
            if (KiemTraChonThangNam()&& slbNhanVien.SelectedItem.Value!=null)
            {
                daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
                dPBMT.MT.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dPBMT.MT.Nam = int.Parse(slbNam.SelectedItem.Value);
                dPBMT.MT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
                stoPhanBoCT.DataSource = dPBMT.DanhSach();
                stoPhanBoCT.DataBind();

                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.IDNhanVien = dPBMT.MT.IDNhanVien;
                dTTNV.TTNV.Thang = dPBMT.MT.Thang;
                dTTNV.TTNV.Nam = dPBMT.MT.Nam;
                
                
                if(dTTNV.TimTT()!=null)
                {
                    lblChucVu.Text = "CV: "+dTTNV.Tim.ChucVu;
                    lblChucDanh.Text = "CD: "+dTTNV.Tim.ChucDanh;
                    lblMoTaCongViec.Text = "MTCV: "+dTTNV.Tim.MoTaCongViec;
                }
                else
                {
                    lblChucVu.Text = "";
                    lblChucDanh.Text = "";
                    lblMoTaCongViec.Text = "";
                }
            }
        }

        protected void DanhSachPBMTCT(object sender, StoreReadDataEventArgs e)
        {
            if (KiemTraChonThangNam() && slbChiTieuKPI.SelectedItem.Value != null)
            {
                daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
                dPBMT.MT.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dPBMT.MT.Nam = int.Parse(slbNam.SelectedItem.Value);
                dPBMT.IDDonVi = daPhien.NguoiDung.IDDonVi.Value;
                dPBMT.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;
                dPBMT.MT.IDKPI = int.Parse(slbChiTieuKPI.SelectedItem.Value);
                stoPhanBoNV.DataSource = dPBMT.DanhSach_DonVi();
                stoPhanBoNV.DataBind();

                daChiTieuKPI dKPI = new daChiTieuKPI();
                dKPI.KPI.ID = dPBMT.MT.IDKPI.Value;
                if(dKPI.TimTT()!=null)
                {
                    lblDonViTinh.Text ="ĐVT: "+ dKPI.Tim.DonViTinh;
                    lblTanSuatDo.Text ="TSĐ: " + dKPI.Tim.TanSuatDo;
                    lblXuHuongYeuCau.Text ="XHYC: "+ dKPI.Tim.XuHuongYeuCau;
                }
                else
                {
                    lblDonViTinh.Text = "";
                    lblTanSuatDo.Text = "";
                    lblXuHuongYeuCau.Text = "";
                }
            }
        }

        [DirectMethod(Namespace = "BangPBMTCTX")]
        public void EditCT(int id, string field, string oldvalue, string newvalue, object BangPB)
        {
            daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
            dPBMT.MT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dPBMT.MT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dPBMT.MT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
            dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.Value.ToString();
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangPB.ToString());

            dPBMT.MT.IDKPI = int.Parse(node.Property("IDKPI").Value.ToString());
            try
            {
                dPBMT.MT.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
            }
            catch { dPBMT.MT.TrongSo = 0; }
            try
            {
                dPBMT.MT.MucTieu = decimal.Parse(node.Property("MucTieu").Value.ToString());
            }
            catch { dPBMT.MT.TrongSo = 0; }

            dPBMT.ThemSua();
            grdPBChiTieu.GetStore().GetById(id).Commit();
        }

        [DirectMethod(Namespace = "BangPBMTNVX")]
        public void EditNV(int id, string field, string oldvalue, string newvalue, object BangPB)
        {
            daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
            dPBMT.MT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dPBMT.MT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dPBMT.MT.IDKPI = int.Parse(slbChiTieuKPI.SelectedItem.Value);
            dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.Value.ToString();
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangPB.ToString());

            dPBMT.MT.IDNhanVien = Guid.Parse(node.Property("IDNhanVien").Value.ToString());
            try
            {
                dPBMT.MT.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
            }
            catch { dPBMT.MT.TrongSo = 0; }
            try
            {
                dPBMT.MT.MucTieu = decimal.Parse(node.Property("MucTieu").Value.ToString());
            }
            catch { dPBMT.MT.TrongSo = 0; }

            dPBMT.ThemSua();
            grdPBNhanVien.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}