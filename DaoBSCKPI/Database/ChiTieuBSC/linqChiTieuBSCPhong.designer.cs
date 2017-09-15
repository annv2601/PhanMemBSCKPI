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

namespace DaoBSCKPI.Database.ChiTieuBSC
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
	public partial class linqChiTieuBSCPhongDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqChiTieuBSCPhongDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_DanhSach")]
		public ISingleResult<sp_tblBKChiTieuBSCPhong_DanhSachResult> sp_tblBKChiTieuBSCPhong_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan);
			return ((ISingleResult<sp_tblBKChiTieuBSCPhong_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_ThemSua")]
		public int sp_tblBKChiTieuBSCPhong_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDBSC", DbType="Int")] System.Nullable<int> iDBSC, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDXuHuongYeuCau", DbType="Int")] System.Nullable<int> iDXuHuongYeuCau, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSoChung", DbType="Decimal(22,3)")] System.Nullable<decimal> trongSoChung, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSoChiTieu", DbType="Decimal(22,3)")] System.Nullable<decimal> trongSoChiTieu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieu", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan, iDBSC, iDXuHuongYeuCau, trongSoChung, trongSoChiTieu, mucTieu, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_ThongTin")]
		public ISingleResult<sp_tblBKChiTieuBSCPhong_ThongTinResult> sp_tblBKChiTieuBSCPhong_ThongTin()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<sp_tblBKChiTieuBSCPhong_ThongTinResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKChiTieuBSCPhong_DanhSachResult
	{
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDBSC;
		
		private string _Ma;
		
		private string _TenBSC;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private string _XuHuongYeuCau;
		
		private System.Nullable<decimal> _TrongSoChung;
		
		private System.Nullable<decimal> _TrongSoChiTieu;
		
		private System.Nullable<decimal> _MucTieu;
		
		public sp_tblBKChiTieuBSCPhong_DanhSachResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDBSC", DbType="Int")]
		public System.Nullable<int> IDBSC
		{
			get
			{
				return this._IDBSC;
			}
			set
			{
				if ((this._IDBSC != value))
				{
					this._IDBSC = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenBSC", DbType="NVarChar(250)")]
		public string TenBSC
		{
			get
			{
				return this._TenBSC;
			}
			set
			{
				if ((this._TenBSC != value))
				{
					this._TenBSC = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChung", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChung
		{
			get
			{
				return this._TrongSoChung;
			}
			set
			{
				if ((this._TrongSoChung != value))
				{
					this._TrongSoChung = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChiTieu", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChiTieu
		{
			get
			{
				return this._TrongSoChiTieu;
			}
			set
			{
				if ((this._TrongSoChiTieu != value))
				{
					this._TrongSoChiTieu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieu", DbType="Decimal(22,3)")]
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
	}
	
	public partial class sp_tblBKChiTieuBSCPhong_ThongTinResult
	{
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDBSC;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private System.Nullable<decimal> _TrongSoChung;
		
		private System.Nullable<decimal> _TrongSoChiTieu;
		
		private System.Nullable<decimal> _MucTieu;
		
		private string _NguoiTao;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		public sp_tblBKChiTieuBSCPhong_ThongTinResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDBSC", DbType="Int")]
		public System.Nullable<int> IDBSC
		{
			get
			{
				return this._IDBSC;
			}
			set
			{
				if ((this._IDBSC != value))
				{
					this._IDBSC = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChung", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChung
		{
			get
			{
				return this._TrongSoChung;
			}
			set
			{
				if ((this._TrongSoChung != value))
				{
					this._TrongSoChung = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChiTieu", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChiTieu
		{
			get
			{
				return this._TrongSoChiTieu;
			}
			set
			{
				if ((this._TrongSoChiTieu != value))
				{
					this._TrongSoChiTieu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieu", DbType="Decimal(22,3)")]
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
