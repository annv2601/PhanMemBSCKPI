using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ChiTieuBSC;
using DaoBSCKPI.Database.ChiTieuBSC;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.BSC
{
    public partial class frmDanhSachBSC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Node TN = new Node();
                TN = CayDanhSachBSC(0);
                tpBSC.Root.Add(TN);
                tpBSC.ExpandAll();

                ucBK1.KhoiTao();
            }
        }

        #region Rieng
        private List<ConfigItem> PhanTu(sp_tblBKChiTieuBSC_ThongTinResult pt)
        {
            List<ConfigItem> _lst = new List<ConfigItem>();
            ConfigItem _ci = new ConfigItem();

            _ci.Name = "Ma";
            _ci.Value = pt.Ma;
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "ID";
            _ci.Value = pt.ID.ToString();
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "Ten";
            _ci.Value = pt.TenHienThi;
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "TrongSo";
            _ci.Value = pt.TrongSoHienThi.ToString();
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "MucTieu";
            _ci.Value = pt.MucTieu.ToString();
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "DonViTinh";
            _ci.Value = pt.DonViTinh;
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "TanSuatDo";
            _ci.Value = pt.TanSuatDo;
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "XuHuongYeuCau";
            _ci.Value = pt.XuHuongYeuCau;
            _lst.Add(_ci);

            return _lst;
        }

        private Node CayDanhSachBSC(int IDBSCTren)
        {
            Node _treenode = new Node();
            List<ConfigItem> _lci = new List<ConfigItem>();
            daChiTieuBSC dBSC = new daChiTieuBSC();
            dBSC.BSC.IDChiTieuTren = IDBSCTren;
            dBSC.BSC.ID = IDBSCTren;
            dBSC.lstDanhSach();
            if (dBSC.lstBSC.Count==0)
            {                
                _lci=PhanTu(dBSC.ThongTin());

                _treenode.NodeID = IDBSCTren.ToString();
                _treenode.CustomAttributes.Add(_lci[0]);
                _treenode.CustomAttributes.Add(_lci[1]);
                _treenode.CustomAttributes.Add(_lci[2]);
                _treenode.CustomAttributes.Add(_lci[3]);
                _treenode.CustomAttributes.Add(_lci[4]);
                _treenode.CustomAttributes.Add(_lci[5]);
                _treenode.CustomAttributes.Add(_lci[6]);
                _treenode.CustomAttributes.Add(_lci[7]);
                _treenode.Leaf = true;

                /*_treenode.NodeID = IDBSCTren.ToString();
                _treenode.Text = dBSC.BSC.Ma + "." + dBSC.BSC.Ten;
                //_treenode.Icon= Dat icon
                _treenode.Leaf = true;*/
            }
            else
            {
                if (dBSC.ThongTin() != null)
                {
                    _lci = PhanTu(dBSC.BSC);
                    _treenode.NodeID = IDBSCTren.ToString();
                    _treenode.CustomAttributes.Add(_lci[0]);
                    _treenode.CustomAttributes.Add(_lci[1]);
                    _treenode.CustomAttributes.Add(_lci[2]);
                    _treenode.CustomAttributes.Add(_lci[3]);
                    _treenode.CustomAttributes.Add(_lci[4]);
                    _treenode.CustomAttributes.Add(_lci[5]);
                    _treenode.CustomAttributes.Add(_lci[6]);
                    _treenode.CustomAttributes.Add(_lci[7]);
                    _treenode.Leaf = false;
                }
                foreach (sp_tblBKChiTieuBSC_DanhSachResult pt in dBSC.lstBSC)
                {
                    _treenode.Children.Add(CayDanhSachBSC(pt.ID));
                }
            }

            return _treenode;
        }
        #endregion

        #region Su kien
        protected void btnThemMoiBSC_Click(object sender, DirectEventArgs e)
        {
            ucBK1.KhoiTao();
            try
            {
                ucBK1.idChiTieuTren = int.Parse(tpBSC.SelectedNodes[0].NodeID);
            }
            catch
            {
                ucBK1.idChiTieuTren = 0;
            }
        }
        protected void btnCapNhatBSC_Click(object sender, DirectEventArgs e)
        {
            daChiTieuBSC dBSC = new daChiTieuBSC();
            
            dBSC.BSC.ID = ucBK1.idBSC;
            dBSC.BSC.Ma = ucBK1.Ma;
            dBSC.BSC.Ten = ucBK1.Ten;
            dBSC.BSC.TrongSo = ucBK1.TrongSo;
            dBSC.BSC.MucTieu = ucBK1.MucTieu;
            dBSC.BSC.IDDonViTinh = ucBK1.DonViTinh;
            dBSC.BSC.IDChiTieuTren = ucBK1.idChiTieuTren;
            dBSC.BSC.Muc = ucBK1.Muc;
            dBSC.BSC.IDTanSuatDo = ucBK1.TanSuatDo;
            dBSC.BSC.IDXuHuongYeuCau = ucBK1.XuHuongYeuCau;
            dBSC.BSC.STTsx = ucBK1.STTsx;
            dBSC.BSC.InDam = ucBK1.InDam;
            dBSC.BSC.InNghieng = ucBK1.InNghieng;

            //Kiem tra
            if(dBSC.BSC.TrongSo+dBSC.LayTongTrongSo()>100)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Lỗi",
                    Message = "Tổng trọng số BSC trong cùng nhóm không được lớn hơn 100!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                });
                return;
            }
            //================

            dBSC.ThemSua();
            ucBK1.KhoiTao();

            tpBSC.Root.Clear();
            Node TN = new Node();
            TN = CayDanhSachBSC(0);
            tpBSC.Root.Add(TN);
            tpBSC.ExpandAll();
            tpBSC.Render();

            ucBK1.KhoiTaoDanhMuc();
            fdcNhapLieu.Render();
            tabBieuDo.Render();
        }

        protected void tpBSC_Click(object sender, DirectEventArgs e)
        {
            #region Hien thi bieu do
            Session["MaBieuDo"] = "BieuDoBSC";
            Session["IDBSCTren"] = tpBSC.SelectedNodes[0].NodeID;
            tabBieuDo.Loader.Url = daPhien.LayDiaChiURL("/BieuDo/frmBieuDoPie.aspx");
            tabBieuDo.Loader.LoadContent();
            #endregion

            //ucBK1.idChiTieuTren = int.Parse(tpBSC.SelectedNodes[0].NodeID);

            daChiTieuBSC dBSC = new daChiTieuBSC();
            dBSC.BSC.ID = int.Parse(tpBSC.SelectedNodes[0].NodeID);
            dBSC.ThongTin();
            ucBK1.idBSC = dBSC.BSC.ID;
            ucBK1.Ma = dBSC.BSC.Ma;
            ucBK1.Ten = dBSC.BSC.Ten;
            ucBK1.idChiTieuTren = dBSC.BSC.IDChiTieuTren.Value;
            ucBK1.MucTieu = dBSC.BSC.MucTieu.Value;
            ucBK1.DonViTinh = dBSC.BSC.IDDonViTinh.Value;
            ucBK1.TrongSo = dBSC.BSC.TrongSo.Value;
            ucBK1.Muc = dBSC.BSC.Muc.Value;
            ucBK1.TanSuatDo = dBSC.BSC.IDTanSuatDo.Value;
            ucBK1.XuHuongYeuCau = dBSC.BSC.IDXuHuongYeuCau.Value;
            ucBK1.STTsx = dBSC.BSC.STTsx.Value;
            ucBK1.InDam = dBSC.BSC.InDam.Value;
            ucBK1.InNghieng = dBSC.BSC.InNghieng.Value;

           
        }

        [DirectMethod(Namespace = "BangBSCX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangBSC)
        {
            daChiTieuBSC dP = new daChiTieuBSC();
            dP.BSC.ID = id;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangBSC.ToString());

            dP.BSC.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());

            if (dP.CapNhatTrongSo())
            {
                tpBSC.GetNodeById(id).Commit();
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Lỗi",
                    Message = "Tổng trọng số BSC trong cùng nhóm không được lớn hơn 100!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                });                

                tpBSC.GetNodeById(id).Reject();
            }
        }
        #endregion
    }
}