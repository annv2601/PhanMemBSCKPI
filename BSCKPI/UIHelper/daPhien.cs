using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DaoBSCKPI.Database.NhanVien;

namespace BSCKPI.UIHelper
{
    public static class daPhien
    {
        public static sp_tblThongTinNhanVien_ThongTinResult NguoiDung
        {
            get { return (sp_tblThongTinNhanVien_ThongTinResult)HttpContext.Current.Session["PhienLamViecBSC"]; }
            set { HttpContext.Current.Session["PhienLamViecBSC"] = value; }
        }
    }
}