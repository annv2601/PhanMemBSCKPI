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

namespace DaoBSCKPI.Database.ChiTieuKPI
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
	public partial class linqChiTieuKPIPhongDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqChiTieuKPIPhongDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuKPIPhongDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuKPIPhongDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuKPIPhongDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuKPIPhongDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuKPIPhong_DanhSach")]
		public ISingleResult<sp_tblBKChiTieuKPIPhong_DanhSachResult> sp_tblBKChiTieuKPIPhong_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan);
			return ((ISingleResult<sp_tblBKChiTieuKPIPhong_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuKPIPhong_Xoa")]
		public int sp_tblBKChiTieuKPIPhong_Xoa([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKPI", DbType="Int")] System.Nullable<int> iDKPI)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDKPI);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuKPIPhong_KhoiTao")]
		public int sp_tblBKChiTieuKPIPhong_KhoiTao([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuKPIPhong_ThemSua")]
		public int sp_tblBKChiTieuKPIPhong_ThemSua(
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKPI", DbType="Int")] System.Nullable<int> iDKPI, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDXuHuongYeuCau", DbType="Int")] System.Nullable<int> iDXuHuongYeuCau, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuNam", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuNam, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang1", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang1, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang2", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang2, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang3", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang3, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang4", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang4, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang5", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang5, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang6", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang6, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang7", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang7, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang8", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang8, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang9", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang9, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang10", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang10, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang11", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang11, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieuThang12", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieuThang12, 
					[global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDKPI, iDXuHuongYeuCau, mucTieuNam, mucTieuThang1, mucTieuThang2, mucTieuThang3, mucTieuThang4, mucTieuThang5, mucTieuThang6, mucTieuThang7, mucTieuThang8, mucTieuThang9, mucTieuThang10, mucTieuThang11, mucTieuThang12, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuKPIPhong_ThongTin")]
		public ISingleResult<sp_tblBKChiTieuKPIPhong_ThongTinResult> sp_tblBKChiTieuKPIPhong_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKPI", DbType="Int")] System.Nullable<int> iDKPI)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDKPI);
			return ((ISingleResult<sp_tblBKChiTieuKPIPhong_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuKPIPhong_CapNhatMucTieuNam")]
		public int sp_tblBKChiTieuKPIPhong_CapNhatMucTieuNam([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKChiTieuKPIPhong_DanhSachResult
	{
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDKPI;
		
		private string _Ma;
		
		private string _TenKPI;
		
		private string _DonViTinh;
		
		private string _TanSuatDo;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private string _XuHuongYeuCau;
		
		private System.Nullable<decimal> _MucTieuNam;
		
		private System.Nullable<decimal> _MucTieuThang1;
		
		private System.Nullable<decimal> _MucTieuThang2;
		
		private System.Nullable<decimal> _MucTieuThang3;
		
		private System.Nullable<decimal> _MucTieuThang4;
		
		private System.Nullable<decimal> _MucTieuThang5;
		
		private System.Nullable<decimal> _MucTieuThang6;
		
		private System.Nullable<decimal> _MucTieuThang7;
		
		private System.Nullable<decimal> _MucTieuThang8;
		
		private System.Nullable<decimal> _MucTieuThang9;
		
		private System.Nullable<decimal> _MucTieuThang10;
		
		private System.Nullable<decimal> _MucTieuThang11;
		
		private System.Nullable<decimal> _MucTieuThang12;
		
		public sp_tblBKChiTieuKPIPhong_DanhSachResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonVi", DbType="Int")]
		public System.Nullable<int> IDDonVi
		{
			get
			{
				return this._IDDonVi;
			}
			set
			{
				if ((this._IDDonVi != value))
				{
					this._IDDonVi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhongBan", DbType="Int")]
		public System.Nullable<int> IDPhongBan
		{
			get
			{
				return this._IDPhongBan;
			}
			set
			{
				if ((this._IDPhongBan != value))
				{
					this._IDPhongBan = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKPI", DbType="Int")]
		public System.Nullable<int> IDKPI
		{
			get
			{
				return this._IDKPI;
			}
			set
			{
				if ((this._IDKPI != value))
				{
					this._IDKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ma", DbType="NVarChar(15)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenKPI", DbType="NVarChar(250)")]
		public string TenKPI
		{
			get
			{
				return this._TenKPI;
			}
			set
			{
				if ((this._TenKPI != value))
				{
					this._TenKPI = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDXuHuongYeuCau", DbType="Int")]
		public System.Nullable<int> IDXuHuongYeuCau
		{
			get
			{
				return this._IDXuHuongYeuCau;
			}
			set
			{
				if ((this._IDXuHuongYeuCau != value))
				{
					this._IDXuHuongYeuCau = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XuHuongYeuCau", DbType="NVarChar(50)")]
		public string XuHuongYeuCau
		{
			get
			{
				return this._XuHuongYeuCau;
			}
			set
			{
				if ((this._XuHuongYeuCau != value))
				{
					this._XuHuongYeuCau = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuNam", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuNam
		{
			get
			{
				return this._MucTieuNam;
			}
			set
			{
				if ((this._MucTieuNam != value))
				{
					this._MucTieuNam = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang1", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang1
		{
			get
			{
				return this._MucTieuThang1;
			}
			set
			{
				if ((this._MucTieuThang1 != value))
				{
					this._MucTieuThang1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang2", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang2
		{
			get
			{
				return this._MucTieuThang2;
			}
			set
			{
				if ((this._MucTieuThang2 != value))
				{
					this._MucTieuThang2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang3", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang3
		{
			get
			{
				return this._MucTieuThang3;
			}
			set
			{
				if ((this._MucTieuThang3 != value))
				{
					this._MucTieuThang3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang4", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang4
		{
			get
			{
				return this._MucTieuThang4;
			}
			set
			{
				if ((this._MucTieuThang4 != value))
				{
					this._MucTieuThang4 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang5", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang5
		{
			get
			{
				return this._MucTieuThang5;
			}
			set
			{
				if ((this._MucTieuThang5 != value))
				{
					this._MucTieuThang5 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang6", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang6
		{
			get
			{
				return this._MucTieuThang6;
			}
			set
			{
				if ((this._MucTieuThang6 != value))
				{
					this._MucTieuThang6 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang7", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang7
		{
			get
			{
				return this._MucTieuThang7;
			}
			set
			{
				if ((this._MucTieuThang7 != value))
				{
					this._MucTieuThang7 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang8", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang8
		{
			get
			{
				return this._MucTieuThang8;
			}
			set
			{
				if ((this._MucTieuThang8 != value))
				{
					this._MucTieuThang8 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang9", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang9
		{
			get
			{
				return this._MucTieuThang9;
			}
			set
			{
				if ((this._MucTieuThang9 != value))
				{
					this._MucTieuThang9 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang10", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang10
		{
			get
			{
				return this._MucTieuThang10;
			}
			set
			{
				if ((this._MucTieuThang10 != value))
				{
					this._MucTieuThang10 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang11", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang11
		{
			get
			{
				return this._MucTieuThang11;
			}
			set
			{
				if ((this._MucTieuThang11 != value))
				{
					this._MucTieuThang11 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang12", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang12
		{
			get
			{
				return this._MucTieuThang12;
			}
			set
			{
				if ((this._MucTieuThang12 != value))
				{
					this._MucTieuThang12 = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKChiTieuKPIPhong_ThongTinResult
	{
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDKPI;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private System.Nullable<decimal> _MucTieuNam;
		
		private System.Nullable<decimal> _MucTieuThang1;
		
		private System.Nullable<decimal> _MucTieuThang2;
		
		private System.Nullable<decimal> _MucTieuThang3;
		
		private System.Nullable<decimal> _MucTieuThang4;
		
		private System.Nullable<decimal> _MucTieuThang5;
		
		private System.Nullable<decimal> _MucTieuThang6;
		
		private System.Nullable<decimal> _MucTieuThang7;
		
		private System.Nullable<decimal> _MucTieuThang8;
		
		private System.Nullable<decimal> _MucTieuThang9;
		
		private System.Nullable<decimal> _MucTieuThang10;
		
		private System.Nullable<decimal> _MucTieuThang11;
		
		private System.Nullable<decimal> _MucTieuThang12;
		
		private string _NguoiTao;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		public sp_tblBKChiTieuKPIPhong_ThongTinResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonVi", DbType="Int")]
		public System.Nullable<int> IDDonVi
		{
			get
			{
				return this._IDDonVi;
			}
			set
			{
				if ((this._IDDonVi != value))
				{
					this._IDDonVi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhongBan", DbType="Int")]
		public System.Nullable<int> IDPhongBan
		{
			get
			{
				return this._IDPhongBan;
			}
			set
			{
				if ((this._IDPhongBan != value))
				{
					this._IDPhongBan = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKPI", DbType="Int")]
		public System.Nullable<int> IDKPI
		{
			get
			{
				return this._IDKPI;
			}
			set
			{
				if ((this._IDKPI != value))
				{
					this._IDKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDXuHuongYeuCau", DbType="Int")]
		public System.Nullable<int> IDXuHuongYeuCau
		{
			get
			{
				return this._IDXuHuongYeuCau;
			}
			set
			{
				if ((this._IDXuHuongYeuCau != value))
				{
					this._IDXuHuongYeuCau = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuNam", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuNam
		{
			get
			{
				return this._MucTieuNam;
			}
			set
			{
				if ((this._MucTieuNam != value))
				{
					this._MucTieuNam = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang1", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang1
		{
			get
			{
				return this._MucTieuThang1;
			}
			set
			{
				if ((this._MucTieuThang1 != value))
				{
					this._MucTieuThang1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang2", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang2
		{
			get
			{
				return this._MucTieuThang2;
			}
			set
			{
				if ((this._MucTieuThang2 != value))
				{
					this._MucTieuThang2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang3", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang3
		{
			get
			{
				return this._MucTieuThang3;
			}
			set
			{
				if ((this._MucTieuThang3 != value))
				{
					this._MucTieuThang3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang4", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang4
		{
			get
			{
				return this._MucTieuThang4;
			}
			set
			{
				if ((this._MucTieuThang4 != value))
				{
					this._MucTieuThang4 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang5", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang5
		{
			get
			{
				return this._MucTieuThang5;
			}
			set
			{
				if ((this._MucTieuThang5 != value))
				{
					this._MucTieuThang5 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang6", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang6
		{
			get
			{
				return this._MucTieuThang6;
			}
			set
			{
				if ((this._MucTieuThang6 != value))
				{
					this._MucTieuThang6 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang7", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang7
		{
			get
			{
				return this._MucTieuThang7;
			}
			set
			{
				if ((this._MucTieuThang7 != value))
				{
					this._MucTieuThang7 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang8", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang8
		{
			get
			{
				return this._MucTieuThang8;
			}
			set
			{
				if ((this._MucTieuThang8 != value))
				{
					this._MucTieuThang8 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang9", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang9
		{
			get
			{
				return this._MucTieuThang9;
			}
			set
			{
				if ((this._MucTieuThang9 != value))
				{
					this._MucTieuThang9 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang10", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang10
		{
			get
			{
				return this._MucTieuThang10;
			}
			set
			{
				if ((this._MucTieuThang10 != value))
				{
					this._MucTieuThang10 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang11", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang11
		{
			get
			{
				return this._MucTieuThang11;
			}
			set
			{
				if ((this._MucTieuThang11 != value))
				{
					this._MucTieuThang11 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieuThang12", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieuThang12
		{
			get
			{
				return this._MucTieuThang12;
			}
			set
			{
				if ((this._MucTieuThang12 != value))
				{
					this._MucTieuThang12 = value;
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
	}
}
#pragma warning restore 1591
