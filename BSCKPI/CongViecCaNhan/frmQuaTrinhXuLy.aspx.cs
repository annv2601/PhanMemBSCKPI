using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.CongViecCaNhan;
using DaoBSCKPI.DanhMucBSCKPI;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.CongViecCaNhan
{
    public partial class frmQuaTrinhXuLy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                txtMaCongViecCaNhan.Text = Request.QueryString["MaCongViec"];
                txtIDQTXL.Text = "0";
                DanhSachTienTrinh();
                DanhSachHuongXL();

                daCongViecCaNhan dCV = new daCongViecCaNhan();
                dCV.CVCN.Ma = decimal.Parse(txtMaCongViecCaNhan.Text);
                if(dCV.ThongTin()!=null)
                {
                    lblTenCongViec.Text = dCV.CVCN.NoiDung.ToUpper();
                }
            }
        }

        #region Rieng
        private void DanhSachTienTrinh()
        {
            dacvcnQuaTrinhXuLy dQT = new dacvcnQuaTrinhXuLy();
            dQT.QTXL.MaCongViecCaNhan = decimal.Parse(txtMaCongViecCaNhan.Text);
            stoTienTrinh.DataSource = dQT.DanhSach();
            stoTienTrinh.DataBind();
        }

        private void DanhSachHuongXL()
        {
            daDanhMucBK dDM = new daDanhMucBK();
            stoHuongXuLy.DataSource = dDM.DanhSach((int)daNhomDanhMucBK.eNhom.Hướng_Xử_Lý_Công_Việc);
            stoHuongXuLy.DataBind();
        }
        #endregion

        #region Su kien
        protected void DanhSachTienTrinhTD(object sender, StoreReadDataEventArgs e)
        {
            DanhSachTienTrinh();
        }

        protected void btnCapNhatXL_Click(object sender, DirectEventArgs e)
        {
            if (slbHuongXuLy.SelectedItem.Value==null || txtNoiDungXuLy.Text.Trim()=="")
            {
                X.Msg.Alert("","Đề nghị nhập đầy đủ thông tin").Show();
                return;
            }
            dacvcnQuaTrinhXuLy dQT = new dacvcnQuaTrinhXuLy();
            dQT.QTXL.MaCongViecCaNhan = decimal.Parse(txtMaCongViecCaNhan.Text);
            dQT.QTXL.ID = decimal.Parse(txtIDQTXL.Text);
            if (daPhien.NguoiDung.IDChucVu != null && daPhien.NguoiDung.IDChucVu != 0)
            {
                dQT.QTXL.IDNguoiChiDao = daPhien.NguoiDung.IDNhanVien;
            }
            else
            {
                dQT.QTXL.IDNguoiXuLy = daPhien.NguoiDung.IDNhanVien;
            }
            dQT.QTXL.IDHuongXuLy = int.Parse(slbHuongXuLy.SelectedItem.Value);
            dQT.QTXL.NoiDungXuLy = txtNoiDungXuLy.Text.Trim();

            dQT.ThemSua();

            stoTienTrinh.Reload();
            txtIDQTXL.Text = "0";
            txtNoiDungXuLy.Text = "";
            slbHuongXuLy.SelectedItems.Clear();
            slbHuongXuLy.UpdateSelectedItems();
        }

        [DirectMethod(Namespace = "BangQTXLX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangKQ)
        {
            if(daPhien.NguoiDung.IDChucVu==null || daPhien.NguoiDung.IDChucVu==0)
            {
                grdTienTrinh.GetStore().GetById(id).Reject();
                return;
            }
            dacvcnQuaTrinhXuLy dQT = new dacvcnQuaTrinhXuLy();
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangKQ.ToString());
            dQT.QTXL.ID = decimal.Parse(node.Property("ID").Value.ToString());
            dQT.QTXL.IDNguoiChiDao = daPhien.NguoiDung.IDNhanVien;
            dQT.QTXL.YKienChiDao = node.Property("YKienChiDao").Value.ToString();
            dQT.CapNhatChiDao();

            grdTienTrinh.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}