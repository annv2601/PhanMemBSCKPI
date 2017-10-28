using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSCKPI.CongViecCaNhan
{
    public partial class uccvcnGiaHan : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public decimal MaCongViec
        {
            get { return decimal.Parse(txtMaCongViec.Text); }
            set { txtMaCongViec.Text = value.ToString(); }
        }

        public Guid NguoiThucHien
        {
            get { return Guid.Parse(txtNguoiThucHien.Text); }
            set { txtNguoiThucHien.Text = value.ToString(); }
        }

        public DateTime HanNgayCu
        {
            get { return txtNgayHanCu.SelectedDate; }
            set { txtNgayHanCu.SelectedDate = value; }
        }

        public TimeSpan HanGioCu
        {
            get { return txtGioHanCu.SelectedTime; }
            set { txtGioHanCu.SelectedTime = value; }
        }

        public DateTime HanNgayMoi
        {
            get { return txtNgayHanMoi.SelectedDate; }
            set { txtNgayHanMoi.SelectedDate = value; }
        }

        public TimeSpan HanGioMoi
        {
            get { return txtGioHanMoi.SelectedTime; }
            set { txtGioHanMoi.SelectedTime = value; }
        }

        public string LyDo
        {
            get { return txtLyDo.Text.Trim(); }
            set { txtLyDo.Text = value; }
        }

        public void KhoiTao()
        {
            MaCongViec = 0;
            NguoiThucHien = Guid.Empty;
            LyDo = "";
            HanNgayCu = DateTime.Now;
            HanNgayMoi = DateTime.Now;
        }
    }
}