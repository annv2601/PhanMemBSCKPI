using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.CongViecCaNhan;
using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.CongViecCaNhan
{
    public partial class frmcvcnNguoiThucHien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["MaCongViecCaNhan"]!=null)
            {
                MaCongViec = Convert.ToDecimal(Request.QueryString["MaCongViecCaNhan"]);
                NgayGiaoViec = Convert.ToDateTime(Request.QueryString["NgayGiaoViec"]);
                DanhSachGan(daPhien.NguoiDung.IDDonVi.Value, daPhien.NguoiDung.IDPhongBan.Value);
                grdNguoiThucHien.Title = Request.QueryString["TenCongViec"];                
            }
        }

        public decimal MaCongViec
        {
            get { return decimal.Parse(txtMaCongViecCaNhan.Text); }
            set { txtMaCongViecCaNhan.Text = value.ToString(); }
        }

        public DateTime NgayGiaoViec
        {
            get { return DateTime.Parse(txtNgayGiao.Text); }
            set { txtNgayGiao.Text = value.ToString(); }
        }

        public void DanhSachGan(int rIDDonVi, int rIDPhongBan)
        {
            dacvcnNguoiThucHien dNTH = new dacvcnNguoiThucHien();
            DateTime _Ngay = DateTime.Now;
            DataTable dt;
            dNTH.Thang = Convert.ToByte(_Ngay.Month);
            dNTH.Nam = _Ngay.Year;
            dNTH.IDDonVi = rIDDonVi;
            dNTH.IDPhongBan = rIDPhongBan;
            dNTH.NTH.MaCongViecCaNhan = MaCongViec;
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
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangNTH)
        {
            dacvcnNguoiThucHien dNTH = new dacvcnNguoiThucHien();
            dNTH.NTH.MaCongViecCaNhan = MaCongViec;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangNTH.ToString());
            dNTH.NTH.IDNguoiThucHien = Guid.Parse(node.Property("IDNhanVien").Value.ToString());
            if (bool.Parse(node.Property("DaChon").Value.ToString()))
            {
                dNTH.NTH.YKienChiDao = node.Property("YKienChiDao").Value.ToString();
                dNTH.NTH.NgayGiao = NgayGiaoViec;
                dNTH.ThemSua();
            }
            else
            {
                dNTH.Xoa();
            }

            grdNguoiThucHien.GetStore().GetById(id).Commit();
            grdNguoiThucHien.Render();
        }
    }
}