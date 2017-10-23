using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DanhMucHeThong;

namespace BSCKPI.MoHinhToChuc.UC
{
    public partial class ucNhanVien : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Ext.Net.X.IsAjaxRequest)
            {
                DanhSachGioiTinh();
                DanhSachChucDanhChucVu();
            }
        }


        #region Thuoc tinh
        public Guid IDNhanVien
        {
            get { return Guid.Parse(txtIDNhanVien.Text); }
            set { txtIDNhanVien.Text = value.ToString(); }
        }

        public string HoDem
        {
            get { return txtHoDem.Text.Trim(); }
            set { txtHoDem.Text = value; }
        }

        public string Ten
        {
            get { return txtTen.Text.Trim(); }
            set { txtTen.Text = value; }
        }

        public string TenNhanVien
        {
            get { return HoDem + " " + Ten; }
        }

        public string MaNhanVien
        {
            get { return txtMa.Text.Trim(); }
            set { txtMa.Text = value; }
        }

        public DateTime NgaySinh
        {
            get { return txtNgaySinh.SelectedDate; }
            set { txtNgaySinh.SelectedDate = value; }
        }

        public Boolean GioiTinh
        {
            get
            {
                if (slbGioiTinh.SelectedItem.Value == null)
                {
                    return false;
                }
                else
                {
                    if(slbGioiTinh.SelectedItem.Value=="1")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            set
            {
                slbGioiTinh.SelectedItems.Clear();
                if(value)
                {
                    slbGioiTinh.SelectedItems.Add(new Ext.Net.ListItem { Value = "1", Mode = Ext.Net.ParameterMode.Raw });
                }
                else
                {
                    slbGioiTinh.SelectedItems.Add(new Ext.Net.ListItem { Value = "0", Mode = Ext.Net.ParameterMode.Raw });
                }
                

                slbGioiTinh.UpdateSelectedItems();
            }
        }

        public string DienThoaiDiDong
        {
            get { return txtDienThoaiDiDong.Text.Trim(); }
            set { txtDienThoaiDiDong.Text = value; }
        }

        public string Email
        {
            get {return txtEmail.Text.Trim(); }
            set { txtEmail.Text = value; }
        }

        public int IDChucVu
        {
            get
            {
                if (cboChucVu.SelectedItem.Value == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(cboChucVu.SelectedItem.Value);
                }
            }
            set
            {
                cboChucVu.SelectedItems.Clear();
                if(value<=0)
                {
                    cboChucVu.SelectedItems.Add(new Ext.Net.ListItem { Text=string.Empty, Mode = Ext.Net.ParameterMode.Raw });
                }
                else
                {
                    cboChucVu.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = Ext.Net.ParameterMode.Raw });
                }
                cboChucVu.UpdateSelectedItems();
            }
        }

        public int IDChucDanh
        {
            get
            {
                if (cboChucDanh.SelectedItem.Value == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(cboChucDanh.SelectedItem.Value);
                }
            }
            set
            {
                cboChucDanh.SelectedItems.Clear();
                if (value <= 0)
                {
                    cboChucDanh.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = Ext.Net.ParameterMode.Raw });
                }
                else
                {
                    cboChucDanh.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = Ext.Net.ParameterMode.Raw });
                }
                cboChucDanh.UpdateSelectedItems();
            }
        }

        public string MoTaCongViec
        {
            get { return txtMoTaCongViec.Text.Trim(); }
            set { txtMoTaCongViec.Text = value; }
        }
        #endregion

        #region Chuc nang
        private void DanhSachGioiTinh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Ten", typeof(string));

            dt.Rows.Add(1, "Nam");
            dt.Rows.Add(0, "Nữ");

            stoGioiTinh.DataSource = dt;
            stoGioiTinh.DataBind();
        }

        public void DanhSachChucDanhChucVu()
        {
            daDanhMucHT dDM = new daDanhMucHT();
            dDM.DM.Nhom = (int)daNhomDanhMucHT.eNhom.Nhóm_chức_vụ;
            stoChucVu.DataSource = dDM.DanhSach();
            stoChucVu.DataBind();

            dDM.DM.Nhom = (int)daNhomDanhMucHT.eNhom.Nhóm_chức_danh;
            stoChucDanh.DataSource = dDM.DanhSach();
            stoChucDanh.DataBind();
        }

        public void KhoiTao()
        {
            IDNhanVien = Guid.Empty;
            HoDem = "";
            Ten = "";
            MaNhanVien = "";
            DienThoaiDiDong = "";
            Email = "";
            //GioiTinh = true;
            NgaySinh = DateTime.Now.AddYears(-18);
            MoTaCongViec = "";
            IDChucDanh = -1;
            IDChucVu = -1;
        }
        #endregion
    }
}