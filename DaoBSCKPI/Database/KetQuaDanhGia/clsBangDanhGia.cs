using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoBSCKPI.Database.KetQuaDanhGia
{
    public partial class clsBangDanhGia
    {

        private System.Nullable<int> _IDNhom;

        private string _TenNhom;

        private System.Nullable<int> _ID;

        private string _ThuTu;

        private string _Ten;

        private System.Nullable<decimal> _TrongSoNhom;

        private System.Nullable<decimal> _MucTieu;

        private string _TanSuatDo;

        private string _DonViTinh;

        private System.Nullable<decimal> _TrongSo;

        private System.Nullable<decimal> _KetQua;

        private System.Nullable<int> _Diem;

        private string _DienGiai;

        private System.Nullable<int> _LoaiChiTieu;

        private System.Nullable<decimal> _STTsx;

        private System.Nullable<long> _STT;

        private System.Nullable<bool> _NhapDiem;

        public clsBangDanhGia()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDNhom", DbType = "Int")]
        public System.Nullable<int> IDNhom
        {
            get
            {
                return this._IDNhom;
            }
            set
            {
                if ((this._IDNhom != value))
                {
                    this._IDNhom = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TenNhom", DbType = "NVarChar(50)")]
        public string TenNhom
        {
            get
            {
                return this._TenNhom;
            }
            set
            {
                if ((this._TenNhom != value))
                {
                    this._TenNhom = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "Int")]
        public System.Nullable<int> ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ThuTu", DbType = "NVarChar(5)")]
        public string ThuTu
        {
            get
            {
                return this._ThuTu;
            }
            set
            {
                if ((this._ThuTu != value))
                {
                    this._ThuTu = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Ten", DbType = "NVarChar(50)")]
        public string Ten
        {
            get
            {
                return this._Ten;
            }
            set
            {
                if ((this._Ten != value))
                {
                    this._Ten = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TrongSoNhom", DbType = "Decimal(22,3)")]
        public System.Nullable<decimal> TrongSoNhom
        {
            get
            {
                return this._TrongSoNhom;
            }
            set
            {
                if ((this._TrongSoNhom != value))
                {
                    this._TrongSoNhom = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MucTieu", DbType = "Decimal(22,3)")]
        public System.Nullable<decimal> MucTieu
        {
            get
            {
                return this._MucTieu;
            }
            set
            {
                if ((this._MucTieu != value))
                {
                    this._MucTieu = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TanSuatDo", DbType = "NVarChar(50)")]
        public string TanSuatDo
        {
            get
            {
                return this._TanSuatDo;
            }
            set
            {
                if ((this._TanSuatDo != value))
                {
                    this._TanSuatDo = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DonViTinh", DbType = "NVarChar(50)")]
        public string DonViTinh
        {
            get
            {
                return this._DonViTinh;
            }
            set
            {
                if ((this._DonViTinh != value))
                {
                    this._DonViTinh = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TrongSo", DbType = "Decimal(22,3)")]
        public System.Nullable<decimal> TrongSo
        {
            get
            {
                return this._TrongSo;
            }
            set
            {
                if ((this._TrongSo != value))
                {
                    this._TrongSo = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_KetQua", DbType = "Decimal(22,3)")]
        public System.Nullable<decimal> KetQua
        {
            get
            {
                return this._KetQua;
            }
            set
            {
                if ((this._KetQua != value))
                {
                    this._KetQua = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Diem", DbType = "Int")]
        public System.Nullable<int> Diem
        {
            get
            {
                return this._Diem;
            }
            set
            {
                if ((this._Diem != value))
                {
                    this._Diem = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DienGiai", DbType = "NVarChar(200)")]
        public string DienGiai
        {
            get
            {
                return this._DienGiai;
            }
            set
            {
                if ((this._DienGiai != value))
                {
                    this._DienGiai = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LoaiChiTieu", DbType = "Int")]
        public System.Nullable<int> LoaiChiTieu
        {
            get
            {
                return this._LoaiChiTieu;
            }
            set
            {
                if ((this._LoaiChiTieu != value))
                {
                    this._LoaiChiTieu = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_STTsx", DbType = "Decimal(8,3)")]
        public System.Nullable<decimal> STTsx
        {
            get
            {
                return this._STTsx;
            }
            set
            {
                if ((this._STTsx != value))
                {
                    this._STTsx = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_STT", DbType = "BigInt")]
        public System.Nullable<long> STT
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_NhapDiem", DbType ="Bit")]
        public System.Nullable<bool> NhapDiem
        {
            get
            {
                return this._NhapDiem;
            }
            set
            {
                if ((this._NhapDiem != value))
                {
                    this._NhapDiem = value;
                }
            }
        }
    }

    public partial class clsBangPhanBo
    {

        private System.Nullable<int> _IDNhom;

        private string _TenNhom;

        private System.Nullable<int> _ID;

        private string _ThuTu;

        private string _Ten;

        private System.Nullable<decimal> _TrongSoNhom;

        private System.Nullable<decimal> _MucTieu;

        private string _TanSuatDo;

        private string _XuHuong;

        private string _DonViTinh;

        private System.Nullable<decimal> _TrongSo;
        
        private System.Nullable<int> _LoaiChiTieu;

        private System.Nullable<decimal> _STTsx;

        private string _Ma;

        private System.Nullable<bool> _Dam;

        private System.Nullable<long> _STT;
                
        public clsBangPhanBo()
        {
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_IDNhom", DbType = "Int")]
        public System.Nullable<int> IDNhom
        {
            get
            {
                return this._IDNhom;
            }
            set
            {
                if ((this._IDNhom != value))
                {
                    this._IDNhom = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TenNhom", DbType = "NVarChar(50)")]
        public string TenNhom
        {
            get
            {
                return this._TenNhom;
            }
            set
            {
                if ((this._TenNhom != value))
                {
                    this._TenNhom = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", DbType = "Int")]
        public System.Nullable<int> ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ThuTu", DbType = "NVarChar(5)")]
        public string ThuTu
        {
            get
            {
                return this._ThuTu;
            }
            set
            {
                if ((this._ThuTu != value))
                {
                    this._ThuTu = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Ten", DbType = "NVarChar(50)")]
        public string Ten
        {
            get
            {
                return this._Ten;
            }
            set
            {
                if ((this._Ten != value))
                {
                    this._Ten = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TrongSoNhom", DbType = "Decimal(22,3)")]
        public System.Nullable<decimal> TrongSoNhom
        {
            get
            {
                return this._TrongSoNhom;
            }
            set
            {
                if ((this._TrongSoNhom != value))
                {
                    this._TrongSoNhom = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_MucTieu", DbType = "Decimal(22,3)")]
        public System.Nullable<decimal> MucTieu
        {
            get
            {
                return this._MucTieu;
            }
            set
            {
                if ((this._MucTieu != value))
                {
                    this._MucTieu = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TanSuatDo", DbType = "NVarChar(50)")]
        public string TanSuatDo
        {
            get
            {
                return this._TanSuatDo;
            }
            set
            {
                if ((this._TanSuatDo != value))
                {
                    this._TanSuatDo = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_XuHuong", DbType = "NVarChar(50)")]
        public string XuHuong
        {
            get
            {
                return this._XuHuong;
            }
            set
            {
                if ((this._XuHuong != value))
                {
                    this._XuHuong = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DonViTinh", DbType = "NVarChar(50)")]
        public string DonViTinh
        {
            get
            {
                return this._DonViTinh;
            }
            set
            {
                if ((this._DonViTinh != value))
                {
                    this._DonViTinh = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_TrongSo", DbType = "Decimal(22,3)")]
        public System.Nullable<decimal> TrongSo
        {
            get
            {
                return this._TrongSo;
            }
            set
            {
                if ((this._TrongSo != value))
                {
                    this._TrongSo = value;
                }
            }
        }
        
        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_LoaiChiTieu", DbType = "Int")]
        public System.Nullable<int> LoaiChiTieu
        {
            get
            {
                return this._LoaiChiTieu;
            }
            set
            {
                if ((this._LoaiChiTieu != value))
                {
                    this._LoaiChiTieu = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_STTsx", DbType = "Decimal(8,3)")]
        public System.Nullable<decimal> STTsx
        {
            get
            {
                return this._STTsx;
            }
            set
            {
                if ((this._STTsx != value))
                {
                    this._STTsx = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Ma", DbType = "NVarChar(10)")]
        public string Ma
        {
            get
            {
                return this._Ma;
            }
            set
            {
                if ((this._Ma != value))
                {
                    this._Ma = value;
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_STT", DbType = "BigInt")]
        public System.Nullable<long> STT
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Dam", DbType = "Bit")]
        public System.Nullable<bool> Dam
        {
            get
            {
                return this._Dam;
            }
            set
            {
                if ((this._Dam != value))
                {
                    this._Dam = value;
                }
            }
        }
    }
}
