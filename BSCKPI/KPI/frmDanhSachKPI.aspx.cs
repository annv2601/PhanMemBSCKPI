using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ChiTieuKPI;
using DaoBSCKPI.Khac;
using DaoBSCKPI.ChiTieuBSC;
using DaoBSCKPI.Database.ChiTieuBSC;
using DaoBSCKPI;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI
{
    public partial class frmDanhSachKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                DanhSachKPI();
                ucBK1.KhoiTao();

                Node TN = new Node();
                TN = CayDanhSachBSC(0);
                tpBSC.Root.Add(TN);
            }
        }

        #region Rieng
        private void DanhSachKPI()
        {
            daChiTieuKPI dKPI = new daChiTieuKPI();
            dKPI.KPI.IDDonVi = 0;
            stoKPI.DataSource = dKPI.DanhSach();
            stoKPI.DataBind();
        }

        private List<ConfigItem> PhanTu(sp_tblBKChiTieuBSC_ThongTinResult pt)
        {
            List<ConfigItem> _lst = new List<ConfigItem>();
            ConfigItem _ci = new ConfigItem();

            _ci.Name = "Ma";
            _ci.Value = pt.Ma;
            _lst.Add(_ci);

            _ci = new ConfigItem();
            _ci.Name = "Ten";
            _ci.Value = pt.TenHienThi;
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
            if (dBSC.lstBSC.Count == 0)
            {
                _lci = PhanTu(dBSC.ThongTin());

                _treenode.NodeID = IDBSCTren.ToString();
                _treenode.CustomAttributes.Add(_lci[0]);
                _treenode.CustomAttributes.Add(_lci[1]);
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

        }

        protected void grdKPI_Select(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            daChiTieuKPI dKPI = new daChiTieuKPI();
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    dKPI.KPI.ID = int.Parse(row["ID"]);
                }
                catch
                {
                    dKPI.KPI.ID = 0;
                }
            }
            if (dKPI.KPI.ID != 0)
            {
                dKPI.ThongTin();
                ucBK1.idBSC = dKPI.KPI.ID;
                ucBK1.Ma = dKPI.KPI.Ma;
                ucBK1.Ten = dKPI.KPI.Ten;
                ucBK1.MucTieu = dKPI.KPI.MucTieu.Value;
                ucBK1.DonViTinh = dKPI.KPI.IDDonViTinh.Value;
                ucBK1.TrongSo = dKPI.KPI.TrongSo.Value;
                ucBK1.Muc = dKPI.KPI.Muc.Value;
                ucBK1.TanSuatDo = dKPI.KPI.IDTanSuatDo.Value;
                ucBK1.XuHuongYeuCau = dKPI.KPI.IDXuHuongYeuCau.Value;
                ucBK1.STTsx = dKPI.KPI.STTsx.Value;
                ucBK1.InDam = dKPI.KPI.InDam.Value;
                ucBK1.InNghieng = dKPI.KPI.InNghieng.Value;
            }
        }
        protected void btnCapNhatBSC_Click(object sender, DirectEventArgs e)
        {
            daChiTieuKPI dKPI = new daChiTieuKPI();
            dKPI.KPI.ID = ucBK1.idBSC;
            dKPI.KPI.Ma = ucBK1.Ma;
            //dKPI.KPI.STT = ucBK1.STT;
            dKPI.KPI.Ten = ucBK1.Ten;
            dKPI.KPI.TrongSo = ucBK1.TrongSo;
            dKPI.KPI.MucTieu = ucBK1.MucTieu;
            dKPI.KPI.IDDonViTinh = ucBK1.DonViTinh;
            dKPI.KPI.Muc = ucBK1.Muc;
            dKPI.KPI.IDTanSuatDo = ucBK1.TanSuatDo;
            dKPI.KPI.IDXuHuongYeuCau = ucBK1.XuHuongYeuCau;
            dKPI.KPI.STTsx = ucBK1.STTsx;
            dKPI.KPI.InDam = ucBK1.InDam;
            dKPI.KPI.InNghieng = ucBK1.InNghieng;

            dKPI.KPI.IDDonVi = daPhien.NguoiDung.IDDonVi;
            dKPI.KPI.IDPhongBan = daPhien.NguoiDung.IDPhongBan;
            dKPI.KPI.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            dKPI.ThemSua();
            ucBK1.KhoiTao();
            DanhSachKPI();
        }

        [DirectMethod(Namespace = "BangKPIX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangKPI)
        {

        }

        protected void mnuitemKPIPheDuyet_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            int _TrangThai = 0;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    txtIDKPIPheDuyet.Text = row["ID"].ToString();
                    lblTenKPI.Text = row["Ten"].ToString();
                    _TrangThai = int.Parse(row["TrangThai"]==null?"0": row["TrangThai"]);
                }
                catch
                {
                    txtIDKPIPheDuyet.Text = "0";
                }
            }
            if (txtIDKPIPheDuyet.Text == "0")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn 1 KPI trước khi phê duyệt!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")                    
                });
            }
            else
            {
                if (_TrangThai == (int)daTrangThai.eTrangThai.Đã_Duyệt)
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Thông báo",
                        Message = "KPI này đã được phê duyệt!",
                        Buttons = MessageBox.Button.OK,
                        Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                    });
                }
                else
                {
                    chkChiTieuChung.Checked = false;
                    txtGhiChuTrangThai.Text = "";
                    wPheDuyet.Show();
                }
            }
        }

        protected void btnPheDuyet_Click(object sender, DirectEventArgs e)
        {
            daChiTieuKPI dKPI = new daChiTieuKPI();
            dKPI.KPI.ID = int.Parse(txtIDKPIPheDuyet.Text);
            dKPI.KPI.ChiTieuChung = chkChiTieuChung.Checked;
            dKPI.KPI.GhiChuTrangThai = txtGhiChuTrangThai.Text.Trim();
            dKPI.KPI.TrangThai = (int)daTrangThai.eTrangThai.Đã_Duyệt;
            dKPI.DoiTrangThai();

            txtIDKPIPheDuyet.Text = "0";
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "KPI đã được phê duyệt thành công!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO")
            });
            DanhSachKPI();
        }
        
        protected void mnuitemKPILienKetBSC_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            int _IDBSC = 0;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    txtIDKPILienKet.Text = row["ID"].ToString();
                    lblTenKPI.Text = row["Ten"].ToString();
                    _IDBSC = int.Parse(row["IDBSC"] == null ? "0" : row["IDBSC"]);
                }
                catch
                {
                    txtIDKPILienKet.Text = "0";
                }
            }
            if (txtIDKPILienKet.Text == "0")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn 1 KPI trước khi Liên kết!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                if (_IDBSC != 0)
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Thông báo",
                        Message = "KPI này đã được Liên kết!",
                        Buttons = MessageBox.Button.OK,
                        Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                    });
                }
                else
                {
                    if (tpBSC.SelectedNodes != null)
                    {
                        tpBSC.SelectedNodes.Clear();
                    }
                    wLienKetBSC.Show();
                }
            }
        }

        protected void  btnLienKetBSC_Click(object sender, DirectEventArgs e)
        {
            daChiTieuKPI dKPI = new daChiTieuKPI();
            dKPI.KPI.ID = int.Parse(txtIDKPILienKet.Text);
            dKPI.KPI.IDBSC= int.Parse(tpBSC.SelectedNodes[0].NodeID);
            dKPI.GanVoiBSC();

            txtIDKPILienKet.Text = "0";
            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "KPI đã được liên kết thành công!",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO")
            });
            DanhSachKPI();
        }

        protected Field OnCreateFilterableField(object sender, ColumnBase column, Field defaultField)
        {
            if (column.DataIndex == "Id")
            {
                ((TextField)defaultField).Icon = Icon.Magnifier;
            }

            return defaultField;
        }
        #endregion
    }
}