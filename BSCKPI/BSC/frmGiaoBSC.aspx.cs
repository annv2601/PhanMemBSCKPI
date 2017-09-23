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

namespace BSCKPI.BSC
{
    public partial class frmGiaoBSC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.IDDonVi = 2;
                dTTNV.TTNV.IDPhongBan = 2;
                dTTNV.TTNV.IDNhanVien = Guid.Empty;
                daPhien.NguoiDung = dTTNV.TTNV;

                DanhSachThangNam();
                
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
            DataTable BDL = new DataTable();
            BDL.Columns.Add("ID", typeof(int));
            BDL.Columns.Add("Ten", typeof(string));
            int i;
            for(i=1;i<=12;i++)
            {
                BDL.Rows.Add(i, "Tháng " + i.ToString());
            }
            stoThang.DataSource = BDL;
            stoThang.DataBind();

            BDL.Rows.Clear();
            i = DateTime.Now.Year - 1;
            BDL.Rows.Add(i, "Năm " + i.ToString());
            i = i + 1;
            BDL.Rows.Add(i, "Năm " + i.ToString());
            stoNam.DataSource = BDL;
            stoNam.DataBind();
        }
        private List<ConfigItem> PhanTu(sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult pt)
        {
            List<ConfigItem> _lst = new List<ConfigItem>();
            ConfigItem _ci = new ConfigItem();

            _ci.Name = "Ma";
            _ci.Value = pt.Ma;
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

            dBSCP.BSCP.Thang = TS.Thang;
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
            dTS.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTS.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTS.IDDonVi = daPhien.NguoiDung.IDDonVi.Value;
            dTS.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;
            dTS.IDNguoiDung = daPhien.NguoiDung.IDNhanVien.ToString();
            daChiTieuBSCPhong dBSCP = new daChiTieuBSCPhong();
            dBSCP.BSCP.Thang = dTS.Thang;
            dBSCP.BSCP.Nam = dTS.Nam;
            dBSCP.BSCP.IDDonVi = dTS.IDDonVi;
            dBSCP.BSCP.IDPhongBan = dTS.IDPhongBan;
            dBSCP.BSCP.NguoiTao = dTS.IDNguoiDung;
            dBSCP.KhoiTao();

            DanhSachThangNam();

            tpBSC.Root.Clear();
            Node TN = new Node();
            TN = CayDanhSachBSC(dTS, 0);
            tpBSC.Root.Add(TN);
            tpBSC.Title = "Danh sách BSC Đơn vị tháng " + dTS.Thang.ToString() + " năm " + dTS.Nam.ToString();
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
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null)
            {
                return;
            }
            daChiTieuBSCPhong dBSCP = new daChiTieuBSCPhong();
            dBSCP.BSCP.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dBSCP.BSCP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dBSCP.BSCP.IDDonVi = daPhien.NguoiDung.IDDonVi;
            dBSCP.BSCP.IDPhongBan = daPhien.NguoiDung.IDPhongBan;
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
            tabBieuDo.Loader.LoadContent();
            #endregion

            //ucBK1.idChiTieuTren = int.Parse(tpBSC.SelectedNodes[0].NodeID);

            daChiTieuBSCPhong dBSCP = new daChiTieuBSCPhong();
            dBSCP.BSCP.IDBSC = int.Parse(tpBSC.SelectedNodes[0].NodeID);
            dBSCP.BSCP.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dBSCP.BSCP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dBSCP.BSCP.IDDonVi = daPhien.NguoiDung.IDDonVi;
            dBSCP.BSCP.IDPhongBan = daPhien.NguoiDung.IDPhongBan;
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
            if (slbThang.SelectedItem.Value==null || slbNam.SelectedItem.Value==null)
            {
                return;
            }
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
        #endregion
    }
}