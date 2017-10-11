using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSCKPI.UIHelper
{
    public static class daTienIch
    {
        public static DateTime NgayDauThang(DateTime rNgay)
        {
            return DateTime.Parse(rNgay.Month.ToString()+"/01/"+rNgay.Year.ToString());
        }

        public static DateTime NgayCuoiThang(DateTime rNgay)
        {
            DateTime _Ngay;
            _Ngay = NgayDauThang(rNgay);
            _Ngay = _Ngay.AddMonths(1);
            return _Ngay.AddDays(-1);
        }
    }
}