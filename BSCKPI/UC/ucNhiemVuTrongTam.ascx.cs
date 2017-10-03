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
    public partial class ucNhiemVuTrongTam : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Đơn_Vị_Tính);
                DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Tần_Suất);                
            }
        }

        #region Thuoc tinh
        public int IDNVChinh
        {
            get { return int.Parse(txtID.Text); }
            set { txtID.Text = value.ToString(); }
        }

        public Guid IDNhanVien
        {
            get { return Guid.Parse(cboNhanVien.SelectedItem.Value); }
            set
            {
                cboNhanVien.SelectedItem.Value = value.ToString();
                cboNhanVien.UpdateSelectedItems();
                /*cboNhanVien.SelectedItems.Clear();
                if(value==Guid.Empty)
                {
                    cboNhanVien.SelectedItems.Add(new Ext.Net.ListItem {Text=string.Empty,Mode=ParameterMode.Raw });
                }
                else
                {
                    cboNhanVien.SelectedItems.Add(new Ext.Net.ListItem { Value=value.ToString(), Mode = ParameterMode.Raw });
                }
                cboNhanVien.UpdateSelectedItems();*/
            }
        }

        public string TenCongViec
        {
            get { return txtTen.Text.Trim(); }
            set { txtTen.Text = value; }
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

        public decimal MucTieu
        {
            get { return Convert.ToDecimal(txtMucTieu.Number); }
            set { txtMucTieu.Number = Convert.ToDouble(value); }
        }

        public int TrangThai
        {
            get { return int.Parse(txtTrangThai.Text); }
            set { txtTrangThai.Text = value.ToString(); }
        }
        #endregion

        #region Tinh nang
        private void DanhSachDanhMuc(int rNhomDM)
        {
            daDanhMucBK dDM = new daDanhMucBK();
            DataTable dt = dDM.DanhSach(rNhomDM);
            switch (rNhomDM)
            {
                case (int)daNhomDanhMucBK.eNhom.Đơn_Vị_Tính:
                    stoDonViTinh.DataSource = dt;
                    stoDonViTinh.DataBind();
                    break;
                case (int)daNhomDanhMucBK.eNhom.Tần_Suất:
                    stoTanSuat.DataSource = dt;
                    stoTanSuat.DataBind();
                    break;
                
            }
        }

        public void DanhSachNhanVien(DataTable dt)
        {
            stoNhanVien.DataSource = dt;
            stoNhanVien.DataBind();
        }

        public void KhoiTao()
        {
            IDNVChinh = 0;
            IDNhanVien = Guid.Empty;
            TenCongViec = "";
            TanSuatDo = 0;
            DonViTinh = 0;
            MucTieu = 0;
        }
        #endregion
    }
}