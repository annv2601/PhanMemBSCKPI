using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI.DanhMucBSCKPI;

using Ext.Net;
namespace BSCKPI.CongViecCaNhan
{
    public partial class ucCongViecCaNhan : System.Web.UI.UserControl
    {
        #region Thuoc Tinh
        public decimal MaCongViec
        {
            get { return decimal.Parse(txtMaCongViecCaNhan.Text); }
            set { txtMaCongViecCaNhan.Text = value.ToString(); }
        }

        public Guid NguoiGiaoViec
        {
            get { return Guid.Parse(slbLanhDaoGiaoViec.SelectedItem.Value); }
            set
            {
                slbLanhDaoGiaoViec.SelectedItems.Clear();
                if (value == Guid.Empty)
                {
                    slbLanhDaoGiaoViec.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbLanhDaoGiaoViec.Value = value;
                }
                slbLanhDaoGiaoViec.UpdateSelectedItems();
            }
        }

        public Guid NguoiTheoDoi
        {
            get { return Guid.Parse(slbNguoiTheoDoi.SelectedItem.Value); }
            set
            {
                slbNguoiTheoDoi.SelectedItems.Clear();
                if (value == Guid.Empty)
                {
                    slbNguoiTheoDoi.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbNguoiTheoDoi.Value = value;
                }
                slbNguoiTheoDoi.UpdateSelectedItems();
            }
        }

        public DateTime NgayGiao
        {
            get { return txtNgayGiao.SelectedDate; }
            set { txtNgayGiao.SelectedDate = value; }
        }

        public DateTime NgayDenHan
        {
            get { return txtNgayDenHan.SelectedDate; }
            set { txtNgayDenHan.SelectedDate = value; }
        }

        public TimeSpan GioDenHan
        {
            get { return txtGioDenHan.SelectedTime; }
            set { txtGioDenHan.SelectedTime = value; }
        }

        public int IDMucDo
        {
            get { return int.Parse(slbMucDo.SelectedItem.Value); }
            set { slbMucDo.SelectedItems.Clear();
                if (value<=0)
                {
                    slbMucDo.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbMucDo.Value = value;
                }
                slbMucDo.UpdateSelectedItems();
            }
        }

        public string NoiDung
        {
            get { return txtNoiDung.Text.Trim(); }
            set { txtNoiDung.Text = value; }
        }

        public string ChiDaoChung
        {
            get { return txtChiDaoChung.Text.Trim(); }
            set { txtChiDaoChung.Text = value; }
        }

        public Guid NguoiLamChinh
        {
            get { return Guid.Parse(slbNguoiLamChinh.SelectedItem.Value); }
            set {
                slbNguoiLamChinh.SelectedItems.Clear();
                if (value == Guid.Empty)
                {
                    slbNguoiLamChinh.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbNguoiLamChinh.Value = value;
                }
                slbNguoiLamChinh.UpdateSelectedItems();
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachMucDo();
            }
        }

        #region Rieng
        public void DanhSachLanhDao(DataTable dt)
        {
            stoLanhDaoGV.DataSource = dt;
            stoLanhDaoGV.DataBind();

            stoLanhDaoTD.DataSource = dt;
            stoLanhDaoTD.DataBind();
        }

        public void DanhSachNguoiLam(DataTable dt)
        {
            stoNguoiLamChinh.DataSource = dt;
            stoNguoiLamChinh.DataBind();
        }

        private void DanhSachMucDo()
        {
            daDanhMucBK dDM = new daDanhMucBK();
            stoMucDo.DataSource = dDM.DanhSach((int)daNhomDanhMucBK.eNhom.Mức_Độ);
            stoMucDo.DataBind();
        }
        #endregion

        #region Chuc nang
        public void KhoiTao()
        {
            MaCongViec = 0;
            NguoiGiaoViec = Guid.Empty;
            NguoiTheoDoi = Guid.Empty;
            NguoiLamChinh = Guid.Empty;
            NgayGiao = DateTime.Now;
            txtNgayDenHan.SelectedValue = string.Empty;
            //txtGioDenHan.SelectedValue = "";
            IDMucDo = 0;
            NoiDung = "";
            ChiDaoChung = "";
        }
        #endregion
    }
}