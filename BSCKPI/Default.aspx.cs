using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DanhMucHeThong;
using DaoBSCKPI.Database.DanhMucMoHinh;
using DaoBSCKPI.NhanVien;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.IDDonVi = 2;
                dTTNV.TTNV.IDPhongBan = 2;
                dTTNV.TTNV.IDNhanVien = Guid.Empty;
                daPhien.NguoiDung = dTTNV.TTNV;


                DanhSachChucNang();

            }
        }

        #region Rieng
        private void DanhSachChucNang()
        {
            MenuPanel mp=new MenuPanel();
            Ext.Net.Menu mn = new Ext.Net.Menu();
            Ext.Net.MenuItem mni = new Ext.Net.MenuItem();
            daChucNang dCN = new daChucNang();
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.BSC;
            dCN.lstDanhSach();
            if (dCN.LstChucNang.Count>0)
            {
                mp.Title = "BSC";
                mp.SelectedTextCls = "bold-highlight";
                mp.Cls = "my-item";
                mn.ID = "mnuBSC";
                foreach(sp_tblChucNang_DanhSachResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiBSC" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Cls = "my-item";
                    mni.Icon = Icon.ArrowRight;
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCN" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURL(pt.dcUrl) + "','" + pt.TieuDe + "');";
                    mp.Menu.Add(mni);
                }                
                pnlChucNang.Add(mp);
            }

            //KPI
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.KPI;
            dCN.lstDanhSach();
            if (dCN.LstChucNang.Count > 0)
            {
                mp = new MenuPanel();
                mp.Title = "KPI";
                mp.SelectedTextCls = "bold-highlight";
                mn.ID = "mnuKPI";
                foreach (sp_tblChucNang_DanhSachResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiKPI" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Icon = Icon.ArrowRight;
                    mni.Cls = "my-item";
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCNKPI" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURL(pt.dcUrl) + "','" + pt.TieuDe + "');";
                    mp.Menu.Add(mni);
                }
                pnlChucNang.Add(mp);
            }

            //Cong viec ca nhan
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.Công_Việc_Cá_Nhân;
            dCN.lstDanhSach();
            if (dCN.LstChucNang.Count > 0)
            {
                mp = new MenuPanel();
                mp.Title = "Công việc thường xuyên";
                mp.SelectedTextCls = "bold-highlight";
                mn.ID = "mnuCVTX";
                foreach (sp_tblChucNang_DanhSachResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiCVTX" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Icon = Icon.ArrowRight;
                    mni.Cls = "my-item";
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCNKPI" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURL(pt.dcUrl) + "','" + pt.TieuDe + "');";
                    mp.Menu.Add(mni);
                }
                pnlChucNang.Add(mp);
            }

            //Bao cao
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.Báo_cáo;
            dCN.lstDanhSach();
            if (dCN.LstChucNang.Count > 0)
            {
                mp = new MenuPanel();
                mp.Title = "Báo cáo";
                mp.SelectedTextCls = "bold-highlight";
                mn.ID = "mnuBaoCao";
                foreach (sp_tblChucNang_DanhSachResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiBaoCao" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Icon = Icon.ArrowRight;
                    mni.Cls = "my-item";
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCN" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURL(pt.dcUrl) + "','" + pt.TieuDe + "');";                    
                    mp.Menu.Add(mni);
                }
                pnlChucNang.Add(mp);
            }
        }
        #endregion
    }
}