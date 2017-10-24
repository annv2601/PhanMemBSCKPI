using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ChiTieuKPI;
using DaoBSCKPI.DanhMucBSCKPI;
using DaoBSCKPI;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.DanhMuc
{
    public partial class frmDanhMucTrongSoNhom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachNhomChon();
                DanhSachTrongSo();
            }
        }

        #region Rieng
        private void DanhSachNhomChon()
        {
            daDanhMucBK dDM = new daDanhMucBK();
            stoNhom.DataSource = dDM.DanhSach((int)daNhomDanhMucBK.eNhom.Trọng_Số_Nhóm_KPI);
            stoNhom.DataBind();
        }

        private void DanhSachTrongSo()
        {
            daTrongSoNhomKPI dTSo = new daTrongSoNhomKPI();
            stoTSN.DataSource = dTSo.DanhSach();
            stoTSN.DataBind();
        }

        private void KhoiTaoNhap()
        {
            txtGiaTri.Number = 0;
            txtTuNgay.SelectedDate = daDatatableVaList.NgayDauThang(DateTime.Now);
            txtDenNgay.SelectedDate = DateTime.Parse("12/31/2999");
            slbNhom.SelectedItems.Clear();
            slbNhom.UpdateSelectedItems();            
        }
        #endregion

        #region Su Kien
        protected void btnThemTSNMoi_Click(object sender, DirectEventArgs e)
        {
            KhoiTaoNhap();
            wTSNhomKPI.Show();
        }

        protected void btnCapNhatTSN_Click(object sender, DirectEventArgs e)
        {
            if(slbNhom.SelectedItem.Value==null)
            {
                X.Msg.Alert("","Đề nghị chọn Nhóm trọng số!").Show();
                return;
            }
            if(txtGiaTri.Number==0)
            {
                X.Msg.Alert("", "Đề nghị nhập trọng số").Show();
                return;
            }
            daTrongSoNhomKPI dTSo = new daTrongSoNhomKPI();
            dTSo.TSN.IDNhomKPI = int.Parse(slbNhom.SelectedItem.Value);
            dTSo.TSN.GiaTri = Convert.ToDecimal(txtGiaTri.Number);
            dTSo.TSN.TuNgay = txtTuNgay.SelectedDate;
            dTSo.TSN.DenNgay = txtDenNgay.SelectedDate;
            dTSo.TSN.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dTSo.ThemSua();
            DanhSachTrongSo();
            wTSNhomKPI.Hide();
        }

        [DirectMethod(Namespace = "BangTSoNX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangTSoN)
        {
            daTrongSoNhomKPI dTSo = new daTrongSoNhomKPI();
            dTSo.TSN.GiaTri = decimal.Parse(newvalue);
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangTSoN.ToString());
            dTSo.TSN.IDNhomKPI = int.Parse(node.Property("IDNhomKPI").Value.ToString());
            dTSo.TSN.TuNgay = DateTime.Parse(node.Property("TuNgay").Value.ToString());
            dTSo.TSN.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dTSo.ThemSua();
            grdTSN.GetStore().GetById(id).Commit();
        }
        #endregion

    }
}