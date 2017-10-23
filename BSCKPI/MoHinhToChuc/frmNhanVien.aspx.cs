using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DonVi;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.MoHinhToChuc
{
    public partial class frmNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachDonVi(DateTime.Now,daPhien.NguoiDung.IDDonVi.Value);
            }
        }

        #region Rieng
        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();

            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();            
        }

        private void DanhSachDonVi(DateTime rNgay,int rIDDVQL)
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = rNgay;
            dMHDV.MHDV.IDDonViQuanLy = rIDDVQL;
            stoDonVi.DataSource = dMHDV.DanhSach();
            stoDonVi.DataBind();
        }
        #endregion

        #region Su Kien Danh Sach
        protected void DanhSachNhanVien(object sender, StoreReadDataEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null||slbPhongBan.SelectedItem.Value==null)
            {
                return;
            }
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dTTNV.TTNV.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
            dTTNV.TTNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            dTTNV.KhoiTao(); //Kiem tra neu chua co thi khoi tao luon

            stoNhanVien.DataSource = dTTNV.DanhSach();
            stoNhanVien.DataBind();
        }

        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            daMoHinhPhongBan dMHPB = new daMoHinhPhongBan();
            dMHPB.MHPB.TuNgay = DateTime.Now;
            dMHPB.MHPB.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            stoPhong.DataSource = dMHPB.DanhSachDDL();
            stoPhong.DataBind();
        }
        #endregion

        #region Su kien Nut bam
        protected void btnThemMoiNhanVien_Click(object sender, DirectEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null||slbPhongBan.SelectedItem.Value==null)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị Đơn vị và phòng ban trước",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnThemMoiNhanVien.ClientID,
                    Fn = new JFunction { Fn = "showResult" }
                });
                return;
            }
            ucNV1.KhoiTao();
            wNhanVien.Title = "Thêm nhân viên mới";
            wNhanVien.Show();
        }

        protected void btnCapNhatNhanVien_Click(object sender, DirectEventArgs e)
        {
            daNhanVien dNV = new daNhanVien();
            daThongTinNhanVien dTNV = new daThongTinNhanVien();

            dNV.NV.IDNhanVien = ucNV1.IDNhanVien;
            dNV.NV.HoDem = ucNV1.HoDem;
            dNV.NV.Ten = ucNV1.Ten;
            dNV.NV.TenNhanVien = ucNV1.TenNhanVien;
            if(ucNV1.NgaySinh>DateTime.Now.AddYears(-18))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Nhân viên này chưa đủ tuổi lao động",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatNhanVien.ClientID
                });
                return;
            }
            dNV.NV.NgaySinh = ucNV1.NgaySinh;
            dNV.NV.GioiTinh = ucNV1.GioiTinh;
            dNV.NV.DienThoaiDiDong = ucNV1.DienThoaiDiDong;
            try
            {
                var mail = new System.Net.Mail.MailAddress(ucNV1.Email);
            }
            catch
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Địa chỉ Email không đúng",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatNhanVien.ClientID
                });
                return;
            }
            dNV.NV.Email = ucNV1.Email;
            dNV.NV.MaNhanVien = ucNV1.MaNhanVien;
            dNV.NV.HoatDong = true;
            dNV.NV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            if(dNV.NV.HoDem=="" || dNV.NV.Ten==""||dNV.NV.Email=="")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải nhập đủ thông tin",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatNhanVien.ClientID
                });

                return;
            }
            dTNV.TTNV.IDNhanVien = dNV.ThemSua();
            dTNV.TTNV.IDChucDanh = ucNV1.IDChucDanh;
            dTNV.TTNV.IDChucVu = ucNV1.IDChucVu;
            dTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dTNV.TTNV.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
            dTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTNV.TTNV.TenNhanVien = dNV.NV.TenNhanVien;
            dTNV.TTNV.MoTaCongViec = ucNV1.MoTaCongViec;
            dTNV.TTNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dTNV.ThemSua();

            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "Đã cập nhật thông tin nhân viên "+dNV.NV.TenNhanVien+" thành công",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO"),
                AnimEl = this.btnCapNhatNhanVien.ClientID
            });

            ucNV1.KhoiTao();
        }
        #endregion

        #region Su kien menu
        protected void mnuitemThongTin_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            ucNV1.IDNhanVien = Guid.Empty;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    ucNV1.IDNhanVien = Guid.Parse(row["IDNhanVien"].ToString());
                    ucNV1.HoDem = row["HoDem"].ToString();
                    ucNV1.Ten = row["Ten"].ToString();
                    ucNV1.Email = row["Email"].ToString();
                    ucNV1.DienThoaiDiDong = row["DienThoaiDiDong"].ToString();
                    ucNV1.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                    ucNV1.GioiTinh =bool.Parse(row["GioiTinh"].ToString());
                    ucNV1.IDChucDanh =int.Parse(row["IDChucDanh"].ToString());
                    ucNV1.IDChucVu =int.Parse(row["IDChucVu"].ToString());
                    ucNV1.MoTaCongViec = row["MoTaCongViec"].ToString();
                    ucNV1.MaNhanVien = row["MaNhanVien"].ToString();
                }
                catch
                {
                    ucNV1.IDNhanVien = Guid.Empty;
                }
            }
            if(ucNV1.IDNhanVien==Guid.Empty)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một nhân viên trước khi xem hoặc sửa",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                wNhanVien.Show();
            }
        }

        protected void mnuitemNhanVienXoa_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            string _TenNV = "";
            ucNV1.IDNhanVien = Guid.Empty;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    ucNV1.IDNhanVien = Guid.Parse(row["IDNhanVien"].ToString());
                    _TenNV = row["TenNhanVien"].ToString();
                }
                catch
                {
                    ucNV1.IDNhanVien = Guid.Empty;
                }
            }
            if (ucNV1.IDNhanVien == Guid.Empty)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một nhân viên trước khi xóa",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                X.MessageBox.Confirm("Xóa nhân viên", "Anh chị có chắc chắn muốn XÓA nhân viên "+_TenNV+" này không?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoYes()",
                        Text = "Đồng ý Xóa"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNo()",
                        Text = "Hủy bỏ"
                    }
                }).Show();
            }
        }
        [DirectMethod]
        public void DoYes()
        {
            daThongTinNhanVien dTNV = new daThongTinNhanVien();
            dTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dTNV.TTNV.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
            dTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTNV.TTNV.IDNhanVien = ucNV1.IDNhanVien;
            dTNV.Xoa();
            stoNhanVien.Reload();
            ucNV1.IDNhanVien = Guid.Empty;

            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "Đã XÓA nhân viên thành công",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
            });
        }

        [DirectMethod]
        public void DoNo()
        {
            ucNV1.IDNhanVien = Guid.Empty;
        }

        #endregion
    }
}