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
using DaoBSCKPI.KeHoachDanhGia;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI
{
    public partial class frmPhanBoMucTieuCaNhanTheoKeHoach : System.Web.UI.Page
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

        private void DanhSachKeHoachDG()
        {
            daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
            stoKHDG.DataSource = dKHDG.DanhSach();
            stoKHDG.DataBind();
        }

        private void DanhSachNhanVienDanhGia()
        {
            if(slbKeHoachDG.SelectedItem.Value!=null)
            {
                daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
                dKHDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dKHDG.Nam = int.Parse(slbNam.SelectedItem.Value);
                dKHDG.KHDG.ID = int.Parse(slbKeHoachDG.SelectedItem.Value);
                stoNhanVien.DataSource = dKHDG.DanhSachNhanVien();
                stoNhanVien.DataBind();
            }            
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

        private Ext.Net.Window CuaSoChucNang(string rTieuDe, string Url)
        {
            Ext.Net.Window _CSo = new Ext.Net.Window();
            ComponentLoader _Loader = new ComponentLoader();
            _Loader.Url = Url; 
            _Loader.Mode = LoadMode.Frame;
            _Loader.LoadMask.ShowMask = true;
            _Loader.LoadMask.Msg = "Đang xử lý .....";

            _CSo.ID = "IDcsBaoCao";
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
        protected void DanhSachNhanVien(object sender, StoreReadDataEventArgs e)
        {
            if (KiemTraChonThangNam())
            {
                DanhSachNhanVienDanhGia();
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
                dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

                dPBMT.KhoiTaoTheoNhanVien();

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
        
        protected void btnInbangPhanBo_Click(object sender, DirectEventArgs e)
        {
            Ext.Net.Window CSo = new Ext.Net.Window();
            CSo = CuaSoChucNang("Bảng giao kế hoạch mục tiêu", "frmHienThiBaoCaoKPI.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&NhanVienBaoCao=" + slbNhanVien.SelectedItem.Value + "&&BieuBaoCao=1");            
            
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
            CSo = CuaSoChucNang("Bảng đánh giá kết quả", "frmHienThiBaoCaoKPI.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&NhanVienBaoCao=" + slbNhanVien.SelectedItem.Value + "&&IDKeHoach=" + slbKeHoachDG.SelectedItem.Value + "&&BieuBaoCao=2");

            this.Form.Controls.Add(CSo);
            CSo.Render();
            CSo.Show();
        }
        #endregion
    }
}