using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoBSCKPI.Database.CongViecCaNhan
{
    public partial class clsCongViecCaNhan
    {
        private System.Nullable<int> _STT;

        private string _LanhDao;

        private string _NguoiThucHien;
        
        private System.Nullable<System.DateTime> _Ngay;

        private System.Nullable<System.DateTime> _NgayNhap;
        
        private string _HuongXuLy;

        private string _NoiDung;

        private string _YKienChiDao;

        private System.Nullable<System.DateTime> _NgayChiDao;

        public clsCongViecCaNhan()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_STT", DbType = "bigInt")]
        public System.Nullable<int> STT
        {
            get
            {
                return this._STT;
            }
            set
            {
                if ((this._STT != value))
                {
                    this._STT = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LanhDao", DbType = "NVarChar(50)")]
        public string LanhDao
        {
            get
            {
                return this._LanhDao;
            }
            set
            {
                if ((this._LanhDao != value))
                {
                    this._LanhDao = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_NguoiThucHien", DbType = "NVarChar(50)")]
        public string NguoiThucHien
        {
            get
            {
                return this._NguoiThucHien;
            }
            set
            {
                if ((this._NguoiThucHien != value))
                {
                    this._NguoiThucHien = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Ngay", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Ngay
        {
            get
            {
                return this._Ngay;
            }
            set
            {
                if ((this._Ngay != value))
                {
                    this._Ngay = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_NgayNhap", DbType = "DateTime")]
        public System.Nullable<System.DateTime> NgayNhap
        {
            get
            {
                return this._NgayNhap;
            }
            set
            {
                if ((this._NgayNhap != value))
                {
                    this._NgayNhap = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_HuongXuLy", DbType = "NVarChar(50)")]
        public string HuongXuLy
        {
            get
            {
                return this._HuongXuLy;
            }
            set
            {
                if ((this._HuongXuLy != value))
                {
                    this._HuongXuLy = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_NoiDung", DbType = "NVarChar(1000)")]
        public string NoiDung
        {
            get
            {
                return this._NoiDung;
            }
            set
            {
                if ((this._NoiDung != value))
                {
                    this._NoiDung = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_YKienChiDao", DbType = "NVarChar(500)")]
        public string YKienChiDao
        {
            get
            {
                return this._YKienChiDao;
            }
            set
            {
                if ((this._YKienChiDao != value))
                {
                    this._YKienChiDao = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_NgayChiDao", DbType = "DateTime")]
        public System.Nullable<System.DateTime> NgayChiDao
        {
            get
            {
                return this._NgayChiDao;
            }
            set
            {
                if ((this._NgayChiDao != value))
                {
                    this._NgayChiDao = value;
                }
            }
        }
        
    }
}
