﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaoBSCKPI.Database.CongViec
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BSCKPI")]
	public partial class linqNhiemVuTrongTamDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqNhiemVuTrongTamDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhiemVuTrongTamDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhiemVuTrongTamDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhiemVuTrongTamDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhiemVuTrongTamDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvNhiemVuTrongTam_DanhSach")]
		public ISingleResult<sp_tblcvNhiemVuTrongTam_DanhSachResult> sp_tblcvNhiemVuTrongTam_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan);
			return ((ISingleResult<sp_tblcvNhiemVuTrongTam_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvNhiemVuTrongTam_ThongTin")]
		public ISingleResult<sp_tblcvNhiemVuTrongTam_ThongTinResult> sp_tblcvNhiemVuTrongTam_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, thang, nam);
			return ((ISingleResult<sp_tblcvNhiemVuTrongTam_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvNhiemVuTrongTam_ThemSua")]
		public int sp_tblcvNhiemVuTrongTam_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TenCongViec", DbType="NVarChar(500)")] string tenCongViec, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieu", DbType="Decimal(18,2)")] System.Nullable<decimal> mucTieu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDTanSuatDo", DbType="Int")] System.Nullable<int> iDTanSuatDo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonViTinh", DbType="Int")] System.Nullable<int> iDDonViTinh, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDTrangThai", DbType="Int")] System.Nullable<int> iDTrangThai, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, thang, nam, iDNhanVien, tenCongViec, mucTieu, iDTanSuatDo, iDDonViTinh, iDTrangThai, nguoiTao);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblcvNhiemVuTrongTam_DanhSachResult
	{
		
		private int _ID;
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private string _TenNhanVien;
		
		private string _TenCongViec;
		
		private System.Nullable<int> _IDTanSuatDo;
		
		private string _TanSuatDo;
		
		private System.Nullable<int> _IDDonViTinh;
		
		private string _DonViTinh;
		
		private System.Nullable<decimal> _MucTieu;
		
		private System.Nullable<int> _IDTrangThai;
		
		private string _TrangThai;
		
		public sp_tblcvNhiemVuTrongTam_DanhSachResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhanVien", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDNhanVien
		{
			get
			{
				return this._IDNhanVien;
			}
			set
			{
				if ((this._IDNhanVien != value))
				{
					this._IDNhanVien = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNhanVien", DbType="NVarChar(50)")]
		public string TenNhanVien
		{
			get
			{
				return this._TenNhanVien;
			}
			set
			{
				if ((this._TenNhanVien != value))
				{
					this._TenNhanVien = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenCongViec", DbType="NVarChar(500)")]
		public string TenCongViec
		{
			get
			{
				return this._TenCongViec;
			}
			set
			{
				if ((this._TenCongViec != value))
				{
					this._TenCongViec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTanSuatDo", DbType="Int")]
		public System.Nullable<int> IDTanSuatDo
		{
			get
			{
				return this._IDTanSuatDo;
			}
			set
			{
				if ((this._IDTanSuatDo != value))
				{
					this._IDTanSuatDo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TanSuatDo", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonViTinh", DbType="Int")]
		public System.Nullable<int> IDDonViTinh
		{
			get
			{
				return this._IDDonViTinh;
			}
			set
			{
				if ((this._IDDonViTinh != value))
				{
					this._IDDonViTinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonViTinh", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieu", DbType="Decimal(18,2)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTrangThai", DbType="Int")]
		public System.Nullable<int> IDTrangThai
		{
			get
			{
				return this._IDTrangThai;
			}
			set
			{
				if ((this._IDTrangThai != value))
				{
					this._IDTrangThai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="NVarChar(50)")]
		public string TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this._TrangThai = value;
				}
			}
		}
	}
	
	public partial class sp_tblcvNhiemVuTrongTam_ThongTinResult
	{
		
		private int _ID;
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private string _TenCongViec;
		
		private System.Nullable<decimal> _MucTieu;
		
		private System.Nullable<int> _IDTanSuatDo;
		
		private System.Nullable<int> _IDDonViTinh;
		
		private System.Nullable<int> _IDTrangThai;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private System.Nullable<System.DateTime> _NgayTrangThai;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		public sp_tblcvNhiemVuTrongTam_ThongTinResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Thang", DbType="SmallInt")]
		public System.Nullable<short> Thang
		{
			get
			{
				return this._Thang;
			}
			set
			{
				if ((this._Thang != value))
				{
					this._Thang = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nam", DbType="Int")]
		public System.Nullable<int> Nam
		{
			get
			{
				return this._Nam;
			}
			set
			{
				if ((this._Nam != value))
				{
					this._Nam = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhanVien", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDNhanVien
		{
			get
			{
				return this._IDNhanVien;
			}
			set
			{
				if ((this._IDNhanVien != value))
				{
					this._IDNhanVien = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenCongViec", DbType="NVarChar(500)")]
		public string TenCongViec
		{
			get
			{
				return this._TenCongViec;
			}
			set
			{
				if ((this._TenCongViec != value))
				{
					this._TenCongViec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieu", DbType="Decimal(18,2)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTanSuatDo", DbType="Int")]
		public System.Nullable<int> IDTanSuatDo
		{
			get
			{
				return this._IDTanSuatDo;
			}
			set
			{
				if ((this._IDTanSuatDo != value))
				{
					this._IDTanSuatDo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonViTinh", DbType="Int")]
		public System.Nullable<int> IDDonViTinh
		{
			get
			{
				return this._IDDonViTinh;
			}
			set
			{
				if ((this._IDDonViTinh != value))
				{
					this._IDDonViTinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTrangThai", DbType="Int")]
		public System.Nullable<int> IDTrangThai
		{
			get
			{
				return this._IDTrangThai;
			}
			set
			{
				if ((this._IDTrangThai != value))
				{
					this._IDTrangThai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayTao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayTao
		{
			get
			{
				return this._NgayTao;
			}
			set
			{
				if ((this._NgayTao != value))
				{
					this._NgayTao = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySua", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgaySua
		{
			get
			{
				return this._NgaySua;
			}
			set
			{
				if ((this._NgaySua != value))
				{
					this._NgaySua = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayTrangThai", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayTrangThai
		{
			get
			{
				return this._NgayTrangThai;
			}
			set
			{
				if ((this._NgayTrangThai != value))
				{
					this._NgayTrangThai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiTao", DbType="NVarChar(30)")]
		public string NguoiTao
		{
			get
			{
				return this._NguoiTao;
			}
			set
			{
				if ((this._NguoiTao != value))
				{
					this._NguoiTao = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiSua", DbType="NVarChar(30)")]
		public string NguoiSua
		{
			get
			{
				return this._NguoiSua;
			}
			set
			{
				if ((this._NguoiSua != value))
				{
					this._NguoiSua = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
