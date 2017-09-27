using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ChiTieuKPI;
using DaoBSCKPI;
using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI
{
    public partial class frmKPIPhong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachNam();
            }
        }

        #region Rieng
        private void DanhSachNam()
        {
            daThamSo dTS = new daThamSo();
            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachKPIPhong()
        {
            daChiTieuKPIPhong dKPIP = new daChiTieuKPIPhong();
            dKPIP.KPIP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKPIP.KPIP.IDDonVi = daPhien.NguoiDung.IDDonVi;
            dKPIP.KPIP.IDPhongBan = daPhien.NguoiDung.IDPhongBan;
            dKPIP.KhoiTao();
            stoKPIPhong.DataSource = dKPIP.DanhSach();
            stoKPIPhong.DataBind();
        }
        #endregion

        #region Su Kien
        protected void dsKPIPhong(object sender, StoreReadDataEventArgs e)
        {
            DanhSachKPIPhong();
        }

        [DirectMethod(Namespace = "BangKPIPX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangKPIP)
        {
            daChiTieuKPIPhong dKPIP = new daChiTieuKPIPhong();
            dKPIP.KPIP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKPIP.KPIP.IDDonVi = daPhien.NguoiDung.IDDonVi;
            dKPIP.KPIP.IDPhongBan = daPhien.NguoiDung.IDPhongBan;
            dKPIP.KPIP.IDKPI = id;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangKPIP.ToString());

            try { dKPIP.KPIP.MucTieuNam = decimal.Parse(node.Property("MucTieuNam").Value.ToString()); } catch { dKPIP.KPIP.MucTieuNam = 0; }

            try { dKPIP.KPIP.MucTieuThang1 = decimal.Parse(node.Property("MucTieuThang1").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang1 = 0; }
            try { dKPIP.KPIP.MucTieuThang2 = decimal.Parse(node.Property("MucTieuThang2").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang2 = 0; }
            try { dKPIP.KPIP.MucTieuThang3 = decimal.Parse(node.Property("MucTieuThang3").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang3 = 0; }
            try { dKPIP.KPIP.MucTieuThang4 = decimal.Parse(node.Property("MucTieuThang4").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang4 = 0; }
            try { dKPIP.KPIP.MucTieuThang5 = decimal.Parse(node.Property("MucTieuThang5").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang5 = 0; }
            try { dKPIP.KPIP.MucTieuThang6 = decimal.Parse(node.Property("MucTieuThang6").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang6 = 0; }
            try { dKPIP.KPIP.MucTieuThang7 = decimal.Parse(node.Property("MucTieuThang7").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang7 = 0; }
            try { dKPIP.KPIP.MucTieuThang8 = decimal.Parse(node.Property("MucTieuThang8").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang8 = 0; }
            try { dKPIP.KPIP.MucTieuThang9 = decimal.Parse(node.Property("MucTieuThang9").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang9 = 0; }
            try { dKPIP.KPIP.MucTieuThang10 = decimal.Parse(node.Property("MucTieuThang10").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang10 = 0; }
            try { dKPIP.KPIP.MucTieuThang11 = decimal.Parse(node.Property("MucTieuThang11").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang11 = 0; }
            try { dKPIP.KPIP.MucTieuThang12 = decimal.Parse(node.Property("MucTieuThang12").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang12 = 0; }

            dKPIP.ThemSua();
            grdKPIP.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}