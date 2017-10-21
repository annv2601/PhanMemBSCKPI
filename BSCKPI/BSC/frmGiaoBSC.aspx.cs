using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ChiTieuBSC;
using DaoBSCKPI.Database.ChiTieuBSC;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;
using Ext.Net;
using BSCKPI.UIHelper;
using DaoBSCKPI.DonVi;

namespace BSCKPI.BSC
{
    public partial class frmGiaoBSC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                
                DanhSachThangNam();
                DanhSachDonVi();
                ucBK1.KhoiTao();

                LaChon = true;
            }
        }

        private bool LaChon
        {
            get { return Session["ChonThangNamBSC"] == null ? false : (bool)Session["ChonThangNamBSC"]; }
            set { Session["ChonThangNamBSC"] = value; }
        }

        #region Rieng

        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachDonVi()
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.IDDonViQuanLy = daPhien.NguoiDung.IDDonVi.Value;
            dMHDV.MHDV.TuNgay = DateTime.Now;
            stoDonVi.DataSource = dMHDV.DanhSach();
            stoDonVi.DataBind();
        }

        private List<ConfigItem> PhanTu(sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult pt)
        {
            List<ConfigItem> _lst = new List<ConfigItem>();
            ConfigItem _ci = new ConfigItem();

            _ci.Name = "Ma";
            _ci.Value = pt.Ma;
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "ID";
            _ci.Value = pt.IDBSC.Value.ToString();
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "Ten";
            _ci.Value = pt.TenBSC;
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "TrongSo";
            _ci.Value = pt.TrongSoChiTieu.ToString();
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "TrongSoChung";
            _ci.Value = pt.TrongSoChung.ToString();
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "MucTieu";
            _ci.Value = pt.MucTieu.ToString();
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "DonViTinh";
            _ci.Value = pt.DonViTing;
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

        private Node CayDanhSachBSC(daThamSo TS,int IDBSCTren)
        {
            Node _treenode = new Node();
            List<ConfigItem> _lci = new List<ConfigItem>();
            daChiTieuBSCPhong dBSCP = new daChiTieuBSCPhong();
            
            dBSCP.BSCP.Nam = TS.Nam;
            dBSCP.BSCP.IDDonVi = TS.IDDonVi;
            dBSCP.BSCP.IDPhongBan = TS.IDPhongBan;
            dBSCP.BSCP.IDBSC = IDBSCTren;
            dBSCP.DanhSachNhom(IDBSCTren);
            if (dBSCP.lstBSCPhong.Count == 0)
            {
                
                _lci = PhanTu(dBSCP.ThongTinHienThi());

                _treenode.NodeID = IDBSCTren.ToString();
                _treenode.CustomAttributes.Add(_lci[0]);
                _treenode.CustomAttributes.Add(_lci[1]);
                _treenode.CustomAttributes.Add(_lci[2]);
                _treenode.CustomAttributes.Add(_lci[3]);
                _treenode.CustomAttributes.Add(_lci[4]);
                _treenode.CustomAttributes.Add(_lci[5]);
                _treenode.CustomAttributes.Add(_lci[6]);
                _treenode.CustomAttributes.Add(_lci[7]);
                _treenode.CustomAttributes.Add(_lci[8]);
                _treenode.Leaf = true;

                /*_treenode.NodeID = IDBSCTren.ToString();
                _treenode.Text = dBSC.BSC.Ma + "." + dBSC.BSC.Ten;
                //_treenode.Icon= Dat icon
                _treenode.Leaf = true;*/
            }
            else
            {
                if (dBSCP.ThongTinHienThi() != null)
                {
                    _lci = PhanTu(dBSCP.HtBSCP);
                    _treenode.NodeID = IDBSCTren.ToString();
                    _treenode.CustomAttributes.Add(_lci[0]);
                    _treenode.CustomAttributes.Add(_lci[1]);
                    _treenode.CustomAttributes.Add(_lci[2]);
                    _treenode.CustomAttributes.Add(_lci[3]);
                    _treenode.CustomAttributes.Add(_lci[4]);
                    _treenode.CustomAttributes.Add(_lci[5]);
                    _treenode.CustomAttributes.Add(_lci[6]);
                    _treenode.CustomAttributes.Add(_lci[7]);
                    _treenode.CustomAttributes.Add(_lci[8]);
                    _treenode.Leaf = false;
                }
                foreach (sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult pt in dBSCP.lstBSCPhong)
                {
                    _treenode.Children.Add(CayDanhSachBSC(TS,pt.IDBSC.Value));
                }
            }

            return _treenode;
        }

        private void HienThiBieu()
        {
            LaChon = false;
            daThamSo dTS = new daThamSo();
            dTS.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTS.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);//daPhien.NguoiDung.IDDonVi.Value;
            dTS.IDPhongBan = 0;// daPhien.NguoiDung.IDPhongBan.Value;
            dTS.IDNguoiDung = daPhien.NguoiDung.IDNhanVien.ToString();
            daChiTieuBSCPhong dBSCP = new daChiTieuBSCPhong();
            dBSCP.BSCP.Nam = dTS.Nam;
            dBSCP.BSCP.IDDonVi = dTS.IDDonVi;
            dBSCP.BSCP.IDPhongBan = dTS.IDPhongBan;
            dBSCP.BSCP.NguoiTao = dTS.IDNguoiDung;
            dBSCP.KhoiTao();

            DanhSachThangNam();
            DanhSachDonVi();

            tpBSC.Root.Clear();
            Node TN = new Node();
            TN = CayDanhSachBSC(dTS, 0);
            tpBSC.Root.Add(TN);
            tpBSC.Title = "Danh sách BSC của "+ slbDonVi.SelectedItem.Text + " Năm " + dTS.Nam.ToString();
            tpBSC.ExpandAll();
            tpBSC.Render();

            ucBK1.KhoiTaoDanhMuc();
            fdcNhapLieu.Render();
            tabBieuDo.Render();
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
            if (slbDonVi.SelectedItem.Value == null || slbNam.SelectedItem.Value == null)
            {
                return;
            }
            daChiTieuBSCPhong dBSCP = new daChiTieuBSCPhong();
            dBSCP.BSCP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dBSCP.BSCP.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);//daPhien.NguoiDung.IDDonVi;
            dBSCP.BSCP.IDPhongBan = 0; // daPhien.NguoiDung.IDPhongBan;
            dBSCP.BSCP.IDBSC = ucBK1.idBSC;

            dBSCP.BSCP.TrongSoChiTieu = ucBK1.TrongSo;
            dBSCP.BSCP.TrongSoChung = (dBSCP.LayTrongSoChung() * ucBK1.TrongSo / 100)*100;
            dBSCP.BSCP.MucTieu = ucBK1.MucTieu;
            dBSCP.BSCP.IDDonViTinh = ucBK1.DonViTinh;

            dBSCP.BSCP.IDTanSuatDo = ucBK1.TanSuatDo;
            dBSCP.BSCP.IDXuHuongYeuCau = ucBK1.XuHuongYeuCau;
            dBSCP.ThemSua();
            ucBK1.KhoiTao();

            HienThiBieu();
            LaChon = true;
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

            daChiTieuBSCPhong dBSCP = new daChiTieuBSCPhong();
            dBSCP.BSCP.IDBSC = int.Parse(tpBSC.SelectedNodes[0].NodeID);
            dBSCP.BSCP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dBSCP.BSCP.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);//daPhien.NguoiDung.IDDonVi;
            dBSCP.BSCP.IDPhongBan = 0;// daPhien.NguoiDung.IDPhongBan;
            dBSCP.ThongTinHienThi();
            ucBK1.idBSC = dBSCP.HtBSCP.IDBSC.Value;
            ucBK1.Ma = dBSCP.HtBSCP.Ma;
            ucBK1.Ten = dBSCP.HtBSCP.TenBSC;
            ucBK1.idChiTieuTren = dBSCP.HtBSCP.IDChiTieuTren.Value;
            ucBK1.MucTieu = dBSCP.HtBSCP.MucTieu.Value;
            ucBK1.DonViTinh = dBSCP.HtBSCP.IDDonViTinh.Value;
            ucBK1.TrongSo = dBSCP.HtBSCP.TrongSoChiTieu.Value * 100;
            
            ucBK1.TanSuatDo = dBSCP.HtBSCP.IDTanSuatDo.Value;
            ucBK1.XuHuongYeuCau = dBSCP.HtBSCP.IDXuHuongYeuCau.Value;
            


        }

        protected void slbThang_Change(object sender, DirectEventArgs e)
        {            
            if (slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null)
            {
                return;
            }
            //HienThiBieu();
            if (LaChon)
            {
                HienThiBieu();
            }
            
        }

        protected void btnHienThi_Click(object sender, DirectEventArgs e)
        {
            HienThiBieu();
            LaChon = true;
        }

        [DirectMethod(Namespace = "BangGiaoBSCX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangGiaoBSC)
        {
            daChiTieuBSCPhong dP = new daChiTieuBSCPhong();
            dP.BSCP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dP.BSCP.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dP.BSCP.IDPhongBan = 0;
            dP.BSCP.IDBSC = id;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangGiaoBSC.ToString());

            dP.BSCP.TrongSoChiTieu = decimal.Parse(node.Property("TrongSo").Value.ToString());
            dP.BSCP.MucTieu = decimal.Parse(node.Property("MucTieu").Value.ToString());
            
            dP.BSCP.TrongSoChung = (dP.LayTrongSoChung() * dP.BSCP.TrongSoChiTieu / 100) * 100;

            dP.CapNhat();

            tpBSC.GetNodeById(id).Set("TrongSoChung", dP.BSCP.TrongSoChung.ToString());

            tpBSC.GetNodeById(id).Commit();
        }
        #endregion
    }
}