using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.CongViecCaNhan;
using DaoBSCKPI.NhanVien;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.CongViecCaNhan
{
    public partial class frmCongViecCaNhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachCongViecCaNhan();
                DanhSachNhanVienCVCN();
            }
        }

        #region Rieng
        private void DanhSachCongViecCaNhan()
        {
            daCongViecCaNhan dCV = new daCongViecCaNhan();
            DateTime _Ngay = DateTime.Now;
            dCV.DenNgay = daTienIch.NgayCuoiThang(_Ngay);
            _Ngay = _Ngay.AddMonths(-1);
            dCV.TuNgay = daTienIch.NgayDauThang(_Ngay);
            dCV.IDDonVi = daPhien.NguoiDung.IDDonVi.Value;
            dCV.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;
            stoCVCN.DataSource = dCV.DanhSach();
            stoCVCN.DataBind();            
        }

        private void DanhSachNhanVienCVCN()
        {
            DateTime _Ngay = DateTime.Now;
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = Convert.ToByte(_Ngay.Month);
            dTTNV.TTNV.Nam = _Ngay.Year;
            dTTNV.TTNV.IDDonVi = daPhien.NguoiDung.IDDonVi.Value;
            dTTNV.TTNV.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;

            DataTable dt = dTTNV.DanhSach();
            if (dt.Rows.Count==0)
            {
                _Ngay = _Ngay.AddMonths(-1);
                dTTNV.TTNV.Thang = Convert.ToByte(_Ngay.Month);
                dTTNV.TTNV.Nam = _Ngay.Year;
                dt = dTTNV.DanhSach();
            }

            CVCN1.DanhSachNguoiLam(dt);

            dt = dTTNV.DanhSachLanhDao();
            CVCN1.DanhSachLanhDao(dt);
        }
        #endregion

        #region Su kien
        protected void btnThemCVMoi_Click(object sender, DirectEventArgs e)
        {
            CVCN1.KhoiTao();
            NTH1.MaCongViec = 0;
            NTH1.DanhSachGan(daPhien.NguoiDung.IDDonVi.Value, daPhien.NguoiDung.IDPhongBan.Value);

            wCongViecCaNhan.Show();
        }

        protected void DanhSachCongViecCNTD(object sender, StoreReadDataEventArgs e)
        {
            DanhSachCongViecCaNhan();
        }

        protected void btnCapNhat_Click(object sender, DirectEventArgs e)
        {
            daCongViecCaNhan dCV = new daCongViecCaNhan();
            dCV.CVCN.Ma = CVCN1.MaCongViec;
            dCV.CVCN.NoiDung = CVCN1.NoiDung;
            dCV.CVCN.NguoiGiaoViec = CVCN1.NguoiGiaoViec;
            dCV.CVCN.NguoiTheoDoi = CVCN1.NguoiTheoDoi;
            dCV.CVCN.NgayGiaoViec = CVCN1.NgayGiao;
            dCV.CVCN.NgayDenHan = CVCN1.NgayDenHan;
            dCV.CVCN.GioDenHan = CVCN1.GioDenHan;
            dCV.CVCN.IDMucDo = CVCN1.IDMucDo;
            dCV.CVCN.NguoiLamChinh = CVCN1.NguoiLamChinh;
            dCV.CVCN.ChiDaoChung = CVCN1.ChiDaoChung;

            dCV.CVCN.IDDonVi = daPhien.NguoiDung.IDDonVi.Value;
            dCV.CVCN.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;

            //Kiem tra ngay giao va ngay den han
            if(dCV.CVCN.NgayGiaoViec>dCV.CVCN.NgayDenHan)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Lỗi Thêm công việc",
                    Message = "Ngày giao công việc không thể nhỏ hơn ngày đến hạn!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR"),
                    AnimEl = this.btnCapNhat.ClientID,
                    Fn = new JFunction { Fn = "showResult" }
                });
                return;
            }
            //==================================

            decimal _Ma = dCV.ThemSua();
            if (dCV.CVCN.Ma==0)
            {
                dacvcnNguoiThucHien dNTH = new dacvcnNguoiThucHien();
                dNTH.NTH.MaCongViecCaNhan = _Ma;
                dNTH.NTH.IDNguoiThucHien = dCV.CVCN.NguoiLamChinh;
                dNTH.NTH.YKienChiDao = dCV.CVCN.ChiDaoChung;
                dNTH.NTH.NgayGiao = dCV.CVCN.NgayGiaoViec;
                dNTH.ThemSua();
            }

            CVCN1.KhoiTao();

            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Thêm công việc",
                Message = "Công việc đã được cập nhật thành công!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon),"INFO"),
                AnimEl = this.btnCapNhat.ClientID,
                Fn = new JFunction { Fn = "showResult" }
            });
            
        }
        #endregion
    }
}