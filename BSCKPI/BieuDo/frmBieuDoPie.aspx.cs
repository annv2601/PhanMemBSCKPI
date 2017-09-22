using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ChiTieuBSC;

namespace BSCKPI.BieuDo
{
    public partial class frmBieuDoPie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*this.Chart1.GetStore().DataSource = new List<object>
        {
            new { Ten = "Jan", TrongSo = 20 },
            new { Ten = "Feb", TrongSo = 20 },
            new { Ten = "Mar", TrongSo = 19 },
            new { Ten = "Apr", TrongSo = 18 },
            new { Ten = "May", TrongSo = 18 },
            new { Ten = "Jun", TrongSo = 17 },
            new { Ten = "Jul", TrongSo = 16 }
        };*/

            //Session["MaBieuDo"] = "BieuDoBSC";
            //Session["IDBSCTren"] = "3";
            if (Session["MaBieuDo"]!=null && Session["MaBieuDo"].ToString()!="")
            {
                switch (Session["MaBieuDo"])
                {
                    case "BieuDoBSC":
                        BieuDoBSC(int.Parse(Session["IDBSCTren"].ToString()));
                        break;
                }
            }
        }

        private void BieuDoBSC(int rIDBSC)
        {
            daChiTieuBSC dBSC = new daChiTieuBSC();
            dBSC.BSC.IDChiTieuTren = rIDBSC;
            Chart1.GetStore().DataSource = dBSC.lstDanhSach();
            this.Chart1.GetStore().DataBind();
            /*stoPie.DataSource = dBSC.DanhSach();
            stoPie.DataBind();*/
        }
    }
}