using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.KeHoachDanhGia;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.KeHoachDanhGia
{
    public partial class frmKeHoachDanhGia : System.Web.UI.Page
    {
        private int IDKeHoachDG
        {
            get { return int.Parse(txtID.Text); }
            set { txtID.Text = value.ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                IDKeHoachDG = 0;
                DanhSachKH();
            }
        }

        private void KhoiTao()
        {
            IDKeHoachDG = 0;
            txtTen.Text = "";
            DanhSachChon();
        }
        #region Rieng
        private void DanhSachChon()
        {
            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            dKH.CVu.KHChucVu.IDKeHoach = IDKeHoachDG;
            stoChucVu.DataSource = dKH.CVu.DanhSachChonChucVu();
            stoChucVu.DataBind();

            stoChucDanh.DataSource = dKH.CVu.DanhSachChonChucDanh();
            stoChucDanh.DataBind();

            dKH.DVi.KHDonVi.IDKeHoach = IDKeHoachDG;
            stoDonVi.DataSource = dKH.DVi.DanhSachChon(daPhien.NguoiDung.IDDonVi.Value);
            stoDonVi.DataBind();
        }

        private void DanhSachKH()
        {
            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            stoKHDG.DataSource = dKH.DanhSach();
            stoKHDG.DataBind();
        }

        private void DanhSachNhanVien(int rIDKH)
        {
            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            dKH.Thang = Convert.ToByte(DateTime.Now.Month);
            dKH.Nam = DateTime.Now.Year;
            dKH.KHDG.ID = rIDKH;
            stoDSNV.DataSource = dKH.DanhSachNhanVien();
            stoDSNV.DataBind();
        }
        #endregion

        #region Su kien
        protected void DanhSachKHDGTD(object sender, StoreReadDataEventArgs e)
        {
            DanhSachKH();
        }

        protected void btnThemMoiKHDG_Click(object sender, DirectEventArgs e)
        {
            KhoiTao();
            wKeHoachDG.Show();
        }

        protected void btnCapNhatKH_Click(object sender, DirectEventArgs e)
        {
            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            int _IDKHThem;
            dKH.KHDG.ID = IDKeHoachDG;
            dKH.KHDG.Ten = txtTen.Text.Trim();
            dKH.KHDG.TuNgay = txtTuNgay.SelectedDate;
            dKH.KHDG.DenNgay = txtDenNgay.SelectedDate;
            _IDKHThem = dKH.ThemSua();

            if (IDKeHoachDG==0)
            {
                //Chuc vu
                string json = e.ExtraParams["ValuesCV"];
                dKH.CVu.KHChucVu.IDKeHoach = _IDKHThem;
                Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);                
                foreach (Dictionary<string, string> row in companies)
                {
                    dKH.CVu.KHChucVu.IDChucVu = int.Parse(row["IDChucVu"].ToString());
                    dKH.CVu.KHChucVu.IDChucDanh = 0;
                    if (bool.Parse(row["DaChonCV"].ToString()))
                    {
                        dKH.CVu.ThemSua();
                    }
                }

                //Chuc danh
                json = e.ExtraParams["ValuesCD"];
                companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
                foreach (Dictionary<string, string> rowCD in companies)
                {
                    dKH.CVu.KHChucVu.IDChucDanh = int.Parse(rowCD["IDChucDanh"].ToString());
                    dKH.CVu.KHChucVu.IDChucVu = 0;
                    if (bool.Parse(rowCD["DaChonCD"].ToString()))
                    {
                        dKH.CVu.ThemSua();
                    }
                }

                //Don vi
                json = e.ExtraParams["ValuesDV"];
                dKH.DVi.KHDonVi.IDKeHoach = _IDKHThem;
                companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
                foreach (Dictionary<string, string> rowDV in companies)
                {
                    dKH.DVi.KHDonVi.IDDonVi = int.Parse(rowDV["IDDonVi"].ToString());
                    dKH.DVi.KHDonVi.IDPhongBan = 0;
                    if (bool.Parse(rowDV["DaChonDV"].ToString()))
                    {
                        dKH.DVi.ThemSua();
                    }
                }
            }

            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "Cập nhật kế hoạch đánh giá thành công!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO")
            });
        }

        protected void btnDanhSachNhanVien_Click(object sender, DirectEventArgs e)
        {

        }

        protected void mnuitmDSNV_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            int _IDKH = 0;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    _IDKH = int.Parse(row["ID"].ToString());
                }
                catch
                {
                    _IDKH = 0;
                }
            }

            if(_IDKH==0)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn 1 Kế hoạch trước khi xem danh sách nhân viên!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                daKeHoachDanhGia dKH = new daKeHoachDanhGia();
                DateTime _Ngay = DateTime.Now;
                dKH.Thang = Convert.ToByte(_Ngay.Month);
                dKH.Nam = _Ngay.Year;
                dKH.KHDG.ID = _IDKH;
                DataTable dt= dKH.DanhSachNhanVien();
                if(dt.Rows.Count==0)
                {
                    _Ngay = _Ngay.AddMonths(-1);
                    dKH.Thang = Convert.ToByte(_Ngay.Month);
                    dKH.Nam = _Ngay.Year;
                    dt = dKH.DanhSachNhanVien();
                }
                stoDSNV.DataSource = dt;
                stoDSNV.DataBind();
                wDSNhanVien.Show();
            }
        }

        protected void mnuitmThongTin_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            int _IDKH = 0;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    _IDKH = int.Parse(row["ID"].ToString());
                    txtTen.Text = row["Ten"].ToString();
                    txtTuNgay.SelectedDate = DateTime.Parse(row["TuNgay"].ToString());
                    txtDenNgay.SelectedDate = DateTime.Parse(row["DenNgay"].ToString());
                }
                catch
                {
                    _IDKH = 0;
                }
            }

            if (_IDKH == 0)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn 1 Kế hoạch trước khi chỉnh sửa!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                IDKeHoachDG = _IDKH;
                DanhSachChon();
                wKeHoachDG.Show();
            }
        }
        #endregion

        #region Edit cell
        [DirectMethod(Namespace = "BangCVX")]
        public void EditCV(int id, string field, string oldvalue, string newvalue, object BangDG)
        {
            daKeHoachDanhGiaChucVu dCVu = new daKeHoachDanhGiaChucVu();
            dCVu.KHChucVu.IDKeHoach = IDKeHoachDG;
            dCVu.KHChucVu.IDChucVu = id;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangDG.ToString());
            if (bool.Parse(node.Property("DaChonCV").Value.ToString()))
            {
                dCVu.ThemSua();
            }
            else
            {
                dCVu.XoaChucVu();
            }

            grdChucVu.GetStore().GetById(id).Commit();
        }

        [DirectMethod(Namespace = "BangCDX")]
        public void EditCD(int id, string field, string oldvalue, string newvalue, object BangDG)
        {
            daKeHoachDanhGiaChucVu dCVu = new daKeHoachDanhGiaChucVu();
            dCVu.KHChucVu.IDKeHoach = IDKeHoachDG;
            dCVu.KHChucVu.IDChucDanh = id;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangDG.ToString());
            if (bool.Parse(node.Property("DaChonCD").Value.ToString()))
            {
                dCVu.ThemSua();
            }
            else
            {
                dCVu.XoaChucDanh();
            }

            grdChucDanh.GetStore().GetById(id).Commit();
        }

        [DirectMethod(Namespace = "BangDVX")]
        public void EditDV(int id, string field, string oldvalue, string newvalue, object BangDG)
        {
            daKeHoachDanhGiaDonVi dDVi = new daKeHoachDanhGiaDonVi();
            dDVi.KHDonVi.IDKeHoach = IDKeHoachDG;
            dDVi.KHDonVi.IDDonVi = id;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangDG.ToString());
            if (bool.Parse(node.Property("DaChonDV").Value.ToString()))
            {
                dDVi.ThemSua();
            }
            else
            {
                dDVi.Xoa();
            }

            grdDonVi.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}