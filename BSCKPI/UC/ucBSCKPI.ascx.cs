using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.DanhMucBSCKPI;

using Ext.Net;

namespace BSCKPI.UC
{
    public partial class ucBSCKPI : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Đơn_Vị_Tính);
                DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Tần_Suất);
                DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Xu_Hướng);
            }
        }

        #region Thuoc tinh
        /*public int idBSC
        {
            get { return Session["IDBSCThemSua"] == null ? 0 : (int)Session["IDBSCThemSua"]; }
            set { Session["IDBSCThemSua"] = value; }
        }

        public int idChiTieuTren
        {
            get { return Session["IDChiTieuTrenBSC"] == null ? 0 : (int)Session["IDChiTieuTrenBSC"]; }
            set { Session["IDChiTieuTrenBSC"] = value; }
        }*/

        public int idBSC
        {
            get { return txtIDBSC.Text == "" ? 0 : int.Parse(txtIDBSC.Text); }
            set { txtIDBSC.Text = value.ToString(); }
        }

        public int idChiTieuTren
        {
            get { return txtidChiTieuTren.Text == "" ? 0 : int.Parse(txtidChiTieuTren.Text); }
            set { txtidChiTieuTren.Text = value.ToString(); }
        }

        public string Ma
        {
            get { return txtMa.Text.Trim(); }
            set { txtMa.Text = value; }
        }
        
        public string Ten
        {
            get { return this.txtTen.Text.Trim(); }
            set { txtTen.Text = value; }
        }

        public decimal TrongSo
        {
            get { return Convert.ToDecimal(txtTrongSo.Number); }
            set { txtTrongSo.Number = Convert.ToDouble(value); }
        }

        public decimal MucTieu
        {
            get { return Convert.ToDecimal(txtMucTieu.Number); }
            set { txtMucTieu.Number = Convert.ToDouble(value); }
        }

        public int Muc
        {
            get { return Convert.ToInt32(txtMuc.Number); }
            set { txtMuc.Number = Convert.ToDouble(value); }
        }

        public bool InDam
        {
            get { return chkInDam.Checked; }
            set { chkInDam.Checked = value; }
        }

        public bool InNghieng
        {
            get { return chkInNghieng.Checked; }
            set { chkInNghieng.Checked = value; }
        }

        public decimal STTsx
        {
            get { return Convert.ToDecimal(txtSTTsx.Number); }
            set { txtSTTsx.Number = Convert.ToDouble(value); }
        }

        public int DonViTinh
        {
            get
            {
                return cboDonViTinh.SelectedItem.Value == null ? 0 : int.Parse(cboDonViTinh.SelectedItem.Value);
            }
            set
            {
                cboDonViTinh.SelectedItems.Clear();
                if (value <= 0)
                {
                    cboDonViTinh.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    cboDonViTinh.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = ParameterMode.Raw });
                }
                cboDonViTinh.UpdateSelectedItems();
            }
        }

        public int TanSuatDo
        {
            get
            {
                return cboTanSuatDo.SelectedItem.Value == null ? 0 : int.Parse(cboTanSuatDo.SelectedItem.Value);
            }
            set
            {
                cboTanSuatDo.SelectedItems.Clear();
                if (value <= 0)
                {
                    cboTanSuatDo.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    cboTanSuatDo.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = ParameterMode.Raw });
                }
                cboTanSuatDo.UpdateSelectedItems();
            }
        }

        public int XuHuongYeuCau
        {
            get
            {
                return cboXuHuongYeuCau.SelectedItem.Value == null ? 0 : int.Parse(cboXuHuongYeuCau.SelectedItem.Value);
            }
            set
            {
                cboXuHuongYeuCau.SelectedItems.Clear();
                if (value <= 0)
                {
                    cboXuHuongYeuCau.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    cboXuHuongYeuCau.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = ParameterMode.Raw });
                }
                cboXuHuongYeuCau.UpdateSelectedItems();
            }
        }
        #endregion

        #region Tinh nang
        private void DanhSachDanhMuc(int rNhomDM)
        {
            daDanhMucBK dDM = new daDanhMucBK();
            DataTable dt = dDM.DanhSach(rNhomDM);
            switch(rNhomDM)
            {
                case (int)daNhomDanhMucBK.eNhom.Đơn_Vị_Tính:
                    stoDonViTinh.DataSource = dt;
                    stoDonViTinh.DataBind();
                    break;
                case (int)daNhomDanhMucBK.eNhom.Tần_Suất:
                    stoTanSuat.DataSource = dt;
                    stoTanSuat.DataBind();
                    break;
                case (int)daNhomDanhMucBK.eNhom.Xu_Hướng:
                    stoXuHuong.DataSource = dt;
                    stoXuHuong.DataBind();
                    break;
            }
        }

        public void KhoiTao()
        {
            idBSC = 0;
            //idChiTieuTren = 0;
            Ma = "";
            Ten = "";
            TrongSo = 0;
            MucTieu = 0;
            Muc = 0;
            InDam = false;
            InNghieng = false;
            STTsx = 1;
            DonViTinh = -1;
            TanSuatDo = -1;
            XuHuongYeuCau = -1;

            txtTen.Focus();
        }

        public void KhoiTaoDanhMuc()
        {
            DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Đơn_Vị_Tính);
            DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Tần_Suất);
            DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Xu_Hướng);
        }
        #endregion
    }
}