using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.CongViecCaNhan;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI.DanhMucBSCKPI;

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
                DanhSachTrangThaiHoanThanh();
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

        private Ext.Net.Window CuaSoChucNang(string rTieuDe,string Url)
        {
            Ext.Net.Window _CSo = new Ext.Net.Window();
            ComponentLoader _Loader = new ComponentLoader();
            _Loader.Url = Url; //daPhien.LayDiaChiURL(Url);
            _Loader.Mode = LoadMode.Frame;
            _Loader.LoadMask.ShowMask = true;
            _Loader.LoadMask.Msg = "Đang xử lý .....";

            _CSo.ID = "IDCSCN_CVCN";
            _CSo.Title = rTieuDe;
            _CSo.TitleAlign = TitleAlign.Center;
            _CSo.AutoRender = true;
            _CSo.Maximizable = false;
            _CSo.Icon = Icon.Eyes;
            _CSo.Width = 810;
            _CSo.Height = 500;
            _CSo.Loader = _Loader;

            return _CSo;
        }

        #endregion

        #region Su kien
        protected void btnThemCVMoi_Click(object sender, DirectEventArgs e)
        {
            CVCN1.KhoiTao();
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
            dCV.CVCN.MaNhap = CVCN1.MaNhap;
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
                    AnimEl = this.btnCapNhat.ClientID
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
                AnimEl = this.btnCapNhat.ClientID
            });
            
        }

        protected void mnuitmThemNguoiThucHien_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            string _IDCV = "0";
            string _NgayGiao="";
            string _TenCV = "";
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    _IDCV = row["Ma"].ToString();
                    _NgayGiao = row["NgayGiaoViec"].ToString();
                    _TenCV = row["NoiDung"].ToString();
                }
                catch
                {
                    _IDCV = "0";
                }
            }
            if (_IDCV!="0")
            {
                txtMaCongViecCaNhan.Text = _IDCV;
                txtNgayGiao.Text = _NgayGiao;
                grdNguoiThucHien.Title = _TenCV;
                DanhSachGanNTH(daPhien.NguoiDung.IDDonVi.Value, daPhien.NguoiDung.IDPhongBan.Value);
                wNguoiThucHien.Show();
            }
        }

        protected void mnuitemDanhGia_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            string _IDCV = "0";
            string _NgayGiao = "";
            string _TenCV = "";
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    _IDCV = row["Ma"].ToString();
                    _NgayGiao = row["NgayGiaoViec"].ToString();
                    _TenCV = row["NoiDung"].ToString();
                }
                catch
                {
                    _IDCV = "0";
                }
            }
            if (_IDCV != "0")
            {
                txtMaCongViecCaNhan.Text = _IDCV;
                txtNgayGiao.Text = _NgayGiao;
                wDanhGiaCVCN.Title = _TenCV;
                DanhSachCaNhanDanhGia();
                DanhSachLanhDaoDanhGia();
                ThongTinDanhGiaChung();
                wDanhGiaCVCN.Show();
            }
        }

        protected void mnuitemGiaHan_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            ucGHa1.KhoiTao();
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            bool _DHT=false;
            bool _DQH;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    ucGHa1.MaCongViec = decimal.Parse(row["Ma"].ToString());
                    ucGHa1.NguoiThucHien = daPhien.NguoiDung.IDNhanVien.Value;
                    ucGHa1.HanNgayCu = DateTime.Parse(row["NgayDenHan"].ToString());
                    ucGHa1.HanGioCu = TimeSpan.Parse(row["GioDenHan"].ToString());
                    wGiaHan.Title = row["NoiDung"].ToString();

                    _DHT = bool.Parse(row["DaHoanThanh"].ToString());
                    _DQH = bool.Parse(row["QuaHan"].ToString());
                }
                catch
                {
                    ucGHa1.MaCongViec = 0;
                }
            }
            if (ucGHa1.MaCongViec != 0)
            {
                if (_DHT)
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Cảnrh báo",
                        Message = "Công việc đã kết thúc, không thể gia hạn!",
                        Buttons = MessageBox.Button.OK,
                        Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                    });
                    return;
                }
                ucGHa1.HanGioMoi = ucGHa1.HanGioCu;
                ucGHa1.HanNgayMoi = ucGHa1.HanNgayCu.AddDays(7);
                wGiaHan.Show();
            }
        }
        protected void btnGiaHan_Click(object sender, DirectEventArgs e)
        {
            dacvcnGiaHan dGH = new dacvcnGiaHan();
            dGH.GH.MaCongViecCaNhan = ucGHa1.MaCongViec;
            dGH.GH.NguoiThucHien = ucGHa1.NguoiThucHien;
            dGH.GH.HanNgayCu = ucGHa1.HanNgayCu;
            dGH.GH.HanGioCu = ucGHa1.HanGioCu;
            dGH.GH.HanNgayMoi = ucGHa1.HanNgayMoi;
            dGH.GH.HanGioMoi = ucGHa1.HanGioMoi;
            dGH.GH.LyDo = ucGHa1.LyDo;
            dGH.Them();
            X.Msg.Alert("Hoàn thành","Đã gia hạn công việc thành công").Show();
            wGiaHan.Hide();
            stoCVCN.Reload();
        }

        protected Field OnCreateFilterableField(object sender, ColumnBase column, Field defaultField)
        {
            if (column.DataIndex == "Id")
            {
                ((TextField)defaultField).Icon = Icon.Magnifier;
            }

            return defaultField;
        }
        #endregion

        #region Nguoi thuc hien
        private void DanhSachGanNTH(int rIDDonVi, int rIDPhongBan)
        {
            dacvcnNguoiThucHien dNTH = new dacvcnNguoiThucHien();
            DateTime _Ngay = DateTime.Now;
            DataTable dt;
            dNTH.Thang = Convert.ToByte(_Ngay.Month);
            dNTH.Nam = _Ngay.Year;
            dNTH.IDDonVi = rIDDonVi;
            dNTH.IDPhongBan = rIDPhongBan;
            dNTH.NTH.MaCongViecCaNhan = decimal.Parse(txtMaCongViecCaNhan.Text);
            dt = dNTH.DanhSachGan();
            if (dt.Rows.Count == 0)
            {
                _Ngay = _Ngay.AddMonths(-1);
                dNTH.Thang = Convert.ToByte(_Ngay.Month);
                dNTH.Nam = _Ngay.Year;
                dt = dNTH.DanhSachGan();
            }
            stoNTH.DataSource = dt;
            stoNTH.DataBind();
        }

        [DirectMethod(Namespace = "BangNTHX")]
        public void EditNTH(int id, string field, string oldvalue, string newvalue, object BangNTH)
        {
            dacvcnNguoiThucHien dNTH = new dacvcnNguoiThucHien();
            dNTH.NTH.MaCongViecCaNhan = decimal.Parse(txtMaCongViecCaNhan.Text);
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangNTH.ToString());
            dNTH.NTH.IDNguoiThucHien = Guid.Parse(node.Property("IDNhanVien").Value.ToString());
            if (bool.Parse(node.Property("DaChon").Value.ToString()))
            {
                dNTH.NTH.YKienChiDao = node.Property("YKienChiDao").Value.ToString();
                dNTH.NTH.NgayGiao = DateTime.Parse(txtNgayGiao.Text);
                dNTH.ThemSua();
            }
            else
            {
                grdNguoiThucHien.GetStore().GetById(id).Set("YKienChiDao", "");
                dNTH.Xoa();
            }

            grdNguoiThucHien.GetStore().GetById(id).Commit();
        }
        #endregion

        #region Danh gia ket qua
        private void DanhSachCaNhanDanhGia()
        {
            dacvcnNguoiThucHien dNTH = new dacvcnNguoiThucHien();
            dNTH.NTH.MaCongViecCaNhan = decimal.Parse(txtMaCongViecCaNhan.Text);
            stoCaNhanDG.DataSource = dNTH.DanhSach();
            stoCaNhanDG.DataBind();
        }

        private void DanhSachLanhDaoDanhGia()
        {
            dacvcnKetQuaDanhGia dDG = new dacvcnKetQuaDanhGia();
            dDG.KQDG.MaCongViecCaNhan= decimal.Parse(txtMaCongViecCaNhan.Text);
            stoLanhDaoDG.DataSource = dDG.DanhSach();
            stoLanhDaoDG.DataBind();
        }

        private void ThongTinDanhGiaChung()
        {
            daCongViecCaNhan dCV = new daCongViecCaNhan();
            dCV.CVCN.Ma = decimal.Parse(txtMaCongViecCaNhan.Text);
            dCV.ThongTin();
            slbTrangThaiHoanThanh.SelectedItems.Clear();
            if(dCV.CVCN.IDTrangThai==null)
            {
                slbTrangThaiHoanThanh.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
            }
            else
            {
                slbTrangThaiHoanThanh.SelectedItems.Add(new Ext.Net.ListItem { Value=dCV.CVCN.IDTrangThai.ToString(), Mode = ParameterMode.Raw });
            }
            slbTrangThaiHoanThanh.UpdateSelectedItems();

            if (dCV.CVCN.NgayHoanThanh!=null)
            {
                txtNgayHoanThanh.SelectedDate = dCV.CVCN.NgayHoanThanh.Value;
            }
            txtMucDoHoanThanh.Text = dCV.CVCN.MucDoHoanThanh;
            txtKetQuaHoanThanh.Text = dCV.CVCN.KetQuaHoanThanh;
            if (dCV.CVCN.DaHoanThanh==null)
            {
                chkDaHoanThanh.Text = false.ToString();
            }
            else
            {
                chkDaHoanThanh.Text = dCV.CVCN.DaHoanThanh.Value.ToString();
            }
        }

        private void DanhSachTrangThaiHoanThanh()
        {
            daDanhMucBK dDM = new daDanhMucBK();
            stoTrangThaiHoanThanh.DataSource = dDM.DanhSach((int)daNhomDanhMucBK.eNhom.Trạng_Thái_Công_Việc);
            stoTrangThaiHoanThanh.DataBind();
        }
        protected void btnCapNhatDanhGia_Click(object sender, DirectEventArgs e)
        {
            if (slbTrangThaiHoanThanh.SelectedItem.Value!=null)
            {
                daCongViecCaNhan dCV = new daCongViecCaNhan();
                dCV.CVCN.Ma = decimal.Parse(txtMaCongViecCaNhan.Text);
                dCV.CVCN.IDTrangThai = int.Parse(slbTrangThaiHoanThanh.SelectedItem.Value);
                if (slbTrangThaiHoanThanh.SelectedItem.Text.ToUpper() == "Hoàn thành".ToUpper())
                {
                    dCV.CVCN.DaHoanThanh = true;
                }
                else
                {
                    dCV.CVCN.DaHoanThanh = false;
                }
                dCV.CVCN.NguoiDanhGia = daPhien.NguoiDung.IDNhanVien;
                dCV.CVCN.MucDoHoanThanh = txtMucDoHoanThanh.Text.Trim();
                dCV.CVCN.KetQuaHoanThanh = txtKetQuaHoanThanh.Text.Trim();
                dCV.CVCN.NgayHoanThanh = txtNgayHoanThanh.SelectedDate;

                dCV.DanhGiaketQua();
                X.Msg.Alert("Hoàn thành","Đã cập nhật thành công đánh giá kết quả công việc!").Show();
            }
        }

        [DirectMethod(Namespace = "BangDGX")]
        public void EditDG(int id, string field, string oldvalue, string newvalue, object BangDG)
        {
            dacvcnKetQuaDanhGia dDG = new dacvcnKetQuaDanhGia();
            dDG.KQDG.MaCongViecCaNhan = decimal.Parse(txtMaCongViecCaNhan.Text);
            dDG.KQDG.IDNguoiDanhGia = daPhien.NguoiDung.IDNhanVien;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangDG.ToString());
            dDG.KQDG.IDNguoiDuocDanhGia = Guid.Parse(node.Property("IDNguoiDuocDanhGia").Value.ToString());
            dDG.KQDG.ChatLuong = node.Property("ChatLuong").Value.ToString();
            dDG.KQDG.KhoiLuong = node.Property("KhoiLuong").Value.ToString();
            dDG.KQDG.TienDo = node.Property("TienDo").Value.ToString();
            dDG.KQDG.DoPhucTap = node.Property("DoPhucTap").Value.ToString();
            dDG.KQDG.TrachNhiem = node.Property("TrachNhiem").Value.ToString();

            dDG.ThemSua();

            grdLanhDaoDanhGia.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}