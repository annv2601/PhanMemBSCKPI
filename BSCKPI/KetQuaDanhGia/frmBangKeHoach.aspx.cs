using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;
using DaoBSCKPI.Database.NhanVien;
using DaoBSCKPI.KeHoachDanhGia;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI.CongViec;


using BSCKPI.UIHelper;
using Ext.Net;
namespace BSCKPI.KetQuaDanhGia
{
    public partial class frmBangKeHoach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachKeHoachDG();
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

        private void DanhSachKeHoachDG()
        {
            daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
            stoKHDG.DataSource = dKHDG.DanhSach();
            stoKHDG.DataBind();
        }

        private void DanhSachNhanVienDanhGia()
        {
            if (slbKeHoachDG.SelectedItem.Value != null)
            {
                daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
                dKHDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dKHDG.Nam = int.Parse(slbNam.SelectedItem.Value);
                dKHDG.KHDG.ID = int.Parse(slbKeHoachDG.SelectedItem.Value);
                stoNhanVien.DataSource = dKHDG.DanhSachNhanVien();
                stoNhanVien.DataBind();
            }
        }

        private Ext.Net.Window CuaSoChucNang(string rTieuDe, string Url)
        {
            Ext.Net.Window _CSo = new Ext.Net.Window();
            ComponentLoader _Loader = new ComponentLoader();
            _Loader.Url = Url;
            _Loader.Mode = LoadMode.Frame;
            _Loader.LoadMask.ShowMask = true;
            _Loader.LoadMask.Msg = "Đang xử lý .....";

            _CSo.ID = "IDcsBaoCaoDG";
            _CSo.Title = rTieuDe;
            _CSo.TitleAlign = TitleAlign.Center;
            _CSo.AutoRender = true;
            _CSo.Maximizable = false;
            _CSo.Icon = Icon.Printer;
            _CSo.Width = 900;
            _CSo.Height = 500;
            _CSo.Loader = _Loader;

            return _CSo;
        }
        #endregion

        #region Su kien
        protected void ChonThangNam_Click(object sender, DirectEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null)
            {
                return;
            }

            daKetQuaDanhGia dKQ = new daKetQuaDanhGia();
            dKQ.KQ.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dKQ.KQ.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKQ.KQ.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
            dKQ.KQ.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dKQ.KhoiTaoNhanVien();

            Session["ThangBangDanhGiaCaNhan"] = slbThang.SelectedItem.Value;
            Session["NamBangDanhGiaCaNhan"] = slbNam.SelectedItem.Value;
            //DanhSachBangDanhGiaCaNhan();
            Ext.Net.Panel pl;
            pl = new Ext.Net.Panel();
            pl.ID = "pnlBDG" + slbNhanVien.SelectedItem.Value;
            pl.Closable = true;
            pl.Layout = "Fit";
            pl.Title = slbNhanVien.SelectedItem.Text;
            pl.MinHeight = 500;
            pl.Loader = new ComponentLoader
            {
                Mode = LoadMode.Frame,
                DisableCaching = true,
                Url = "frmBangCaNhan.aspx?NhanVien=" + slbNhanVien.SelectedItem.Value
            };
            tabBangDanhGia.Add(pl);
            pl.Render();
            tabBangDanhGia.SetActiveTab(pl);
        }

        protected void btnBoSung_Click(object sender, DirectEventArgs e)
        {

        }

        protected void DanhSachNhanVien(object sender, StoreReadDataEventArgs e)
        {
            DanhSachNhanVienDanhGia();
        }

        protected void btnInCaNhan_Click(object sender, DirectEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null || slbNam.SelectedItem.Value==null || slbNhanVien.SelectedItem.Value==null)
            {
                X.Msg.Alert("", "Thiếu dữ liệu chọn để in báo cáo").Show();
                return;
            }
            Ext.Net.Window CSo = new Ext.Net.Window();
            CSo = CuaSoChucNang("Bảng đánh giá kết quả", "frmHienThiBaoCaoDanhGia.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&NhanVienBaoCao=" + slbNhanVien.SelectedItem.Value + "&&BieuBaoCao=1");

            this.Form.Controls.Add(CSo);
            CSo.Render();
            CSo.Show();
        }

        protected void btnInKeHoach_Click(object sender, DirectEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null || slbNhanVien.SelectedItem.Value == null)
            {
                X.Msg.Alert("", "Thiếu dữ liệu chọn để in báo cáo").Show();
                return;
            }
            Ext.Net.Window CSo = new Ext.Net.Window();
            CSo = CuaSoChucNang("Bảng đánh giá kết quả", "frmHienThiBaoCaoDanhGia.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&NhanVienBaoCao=" + slbNhanVien.SelectedItem.Value + "&&IDKeHoach=" + slbKeHoachDG.SelectedItem.Value + "&&BieuBaoCao=2");

            this.Form.Controls.Add(CSo);
            CSo.Render();
            CSo.Show();
        }
        #endregion
    }
}