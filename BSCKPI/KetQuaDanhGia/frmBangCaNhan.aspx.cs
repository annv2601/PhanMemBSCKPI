using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI.CongViec;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.KetQuaDanhGia
{
    public partial class frmBangCaNhan : System.Web.UI.Page
    {
        #region Thuoc tinh
        private byte Thang
        {
            get { return byte.Parse(Session["ThangBangDanhGiaCaNhan"].ToString()); }
            set { Session["ThangBangDanhGiaCaNhan"] = value; }
        }

        private int Nam
        {
            get { return int.Parse(Session["NamBangDanhGiaCaNhan"].ToString()); }
            set { Session["NamBangDanhGiaCaNhan"] = value; }
        }

        private Guid IDNhanVien
        {
            get { return Guid.Parse(txtIDNhanVien.Text); }
            set { txtIDNhanVien.Text = value.ToString(); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                //txtIDNhanVien.Text = Request.QueryString["NhanVien"].ToString();
                IDNhanVien= Guid.Parse(Request.QueryString["NhanVien"].ToString());
                LayBangDanhGia(Thang, Nam, Guid.Parse(txtIDNhanVien.Text));
            }
        }

        #region Rieng
        private void LayBangDanhGia(byte rThang, int rNam, Guid rIDNhanVien)
        {
            daBangDanhGia dBDG = new daBangDanhGia();
            dBDG.Thang = rThang;
            dBDG.Nam = rNam;
            dBDG.IDNhanVien = rIDNhanVien;
            stoBCN.DataSource = dBDG.BangDanhGia();
            stoBCN.DataBind();

            grdBangCN.Title = "Tháng " + rThang.ToString() + " năm " + rNam.ToString();
        }

        [DirectMethod(Namespace = "BangKQDGX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangKQ)
        {
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangKQ.ToString());
            switch(Convert.ToInt32(node.Property("LoaiChiTieu").Value))
            {
                case (int)daBangDanhGia.eLoaiChiTieu.KPI_Mục_Tiêu:
                    daKetQuaDanhGia dKQ = new daKetQuaDanhGia();
                    dKQ.KQ.Thang = Thang;
                    dKQ.KQ.Nam = Nam;
                    dKQ.KQ.IDNhanVien = IDNhanVien;
                    dKQ.KQ.IDKPI = int.Parse(node.Property("ID").Value.ToString());
                    dKQ.KQ.KetQua = decimal.Parse(node.Property("KetQua").Value.ToString());
                    dKQ.KQ.Diem = int.Parse(node.Property("Diem").Value.ToString());
                    dKQ.KQ.DienGiai = node.Property("DienGiai").Value.ToString();
                    dKQ.KQ.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

                    dKQ.CapNhat();
                    break;
                case (int)daBangDanhGia.eLoaiChiTieu.Nhiệm_Vụ_Trọng_Tâm:
                    daKQNhiemVuTrongTam dKQNV = new daKQNhiemVuTrongTam();
                    dKQNV.KQNV.Thang = Thang;
                    dKQNV.KQNV.Nam = Nam;

                    dKQNV.KQNV.IDNhiemVu = int.Parse(node.Property("ID").Value.ToString());
                    dKQNV.KQNV.KetQua = decimal.Parse(node.Property("KetQua").Value.ToString());
                    dKQNV.KQNV.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
                    dKQNV.KQNV.Diem = int.Parse(node.Property("Diem").Value.ToString());
                    dKQNV.KQNV.DienGiai = node.Property("DienGiai").Value.ToString();
                    dKQNV.KQNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

                    dKQNV.CapNhat();
                    break;
                case (int)daBangDanhGia.eLoaiChiTieu.KPI_Không_Mục_Tiêu:
                    daKetQuaDanhGiaKhongMucTieu dKQK = new daKetQuaDanhGiaKhongMucTieu();
                    dKQK.KQK.Thang = Thang;
                    dKQK.KQK.Nam = Nam;
                    dKQK.KQK.IDNhanVien = IDNhanVien;
                    dKQK.KQK.IDKPI = int.Parse(node.Property("ID").Value.ToString());
                    dKQK.KQK.KetQua = decimal.Parse(node.Property("KetQua").Value.ToString());
                    dKQK.KQK.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
                    dKQK.KQK.Diem = int.Parse(node.Property("Diem").Value.ToString());
                    dKQK.KQK.DienGiai = node.Property("DienGiai").Value.ToString();
                    dKQK.KQK.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

                    dKQK.CapNhat();
                    break;
            }

            grdBangCN.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}