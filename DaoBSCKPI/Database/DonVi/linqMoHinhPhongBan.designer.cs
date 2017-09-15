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

namespace DaoBSCKPI.Database.DonVi
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
	public partial class linqMoHinhPhongBanDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqMoHinhPhongBanDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqMoHinhPhongBanDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqMoHinhPhongBanDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqMoHinhPhongBanDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqMoHinhPhongBanDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblMoHinhPhongBan_DanhSach")]
		public ISingleResult<sp_tblMoHinhPhongBan_DanhSachResult> sp_tblMoHinhPhongBan_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Ngay", DbType="Date")] System.Nullable<System.DateTime> ngay)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDDonVi, ngay);
			return ((ISingleResult<sp_tblMoHinhPhongBan_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblMoHinhPhongBan_SuaDenNgay")]
		public int sp_tblMoHinhPhongBan_SuaDenNgay([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DenNgay", DbType="Date")] System.Nullable<System.DateTime> denNgay)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDDonVi, iDPhongBan, denNgay);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblMoHinhPhongBan_ThemSua")]
		public int sp_tblMoHinhPhongBan_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="STTsx", DbType="Decimal(8,1)")] System.Nullable<decimal> sTTsx, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TuNgay", DbType="Date")] System.Nullable<System.DateTime> tuNgay, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DenNgay", DbType="Date")] System.Nullable<System.DateTime> denNgay, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDDonVi, iDPhongBan, sTTsx, tuNgay, denNgay, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblMoHinhPhongBan_ThongTin")]
		public ISingleResult<sp_tblMoHinhPhongBan_ThongTinResult> sp_tblMoHinhPhongBan_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Ngay", DbType="Date")] System.Nullable<System.DateTime> ngay)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDDonVi, iDPhongBan, ngay);
			return ((ISingleResult<sp_tblMoHinhPhongBan_ThongTinResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblMoHinhPhongBan_DanhSachResult
	{
		
		private int _IDDonVi;
		
		private int _IDPhongBan;
		
		private string _TenPhongBan;
		
		private System.Nullable<decimal> _STTsx;
		
		private System.Nullable<System.DateTime> _TuNgay;
		
		private System.Nullable<System.DateTime> _DenNgay;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private string _NguoiTao;
		
		public sp_tblMoHinhPhongBan_DanhSachResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonVi", DbType="Int NOT NULL")]
		public int IDDonVi
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhongBan", DbType="Int NOT NULL")]
		public int IDPhongBan
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenPhongBan", DbType="NVarChar(50)")]
		public string TenPhongBan
		{
			get
			{
				return this._TenPhongBan;
			}
			set
			{
				if ((this._TenPhongBan != value))
				{
					this._TenPhongBan = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STTsx", DbType="Decimal(8,1)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuNgay", DbType="Date")]
		public System.Nullable<System.DateTime> TuNgay
		{
			get
			{
				return this._TuNgay;
			}
			set
			{
				if ((this._TuNgay != value))
				{
					this._TuNgay = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DenNgay", DbType="Date")]
		public System.Nullable<System.DateTime> DenNgay
		{
			get
			{
				return this._DenNgay;
			}
			set
			{
				if ((this._DenNgay != value))
				{
					this._DenNgay = value;
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
	}
	
	public partial class sp_tblMoHinhPhongBan_ThongTinResult
	{
		
		private int _IDDonVi;
		
		private int _IDPhongBan;
		
		private System.Nullable<decimal> _STTsx;
		
		private System.Nullable<System.DateTime> _TuNgay;
		
		private System.Nullable<System.DateTime> _DenNgay;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private string _NguoiTao;
		
		public sp_tblMoHinhPhongBan_ThongTinResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonVi", DbType="Int NOT NULL")]
		public int IDDonVi
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhongBan", DbType="Int NOT NULL")]
		public int IDPhongBan
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STTsx", DbType="Decimal(8,1)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuNgay", DbType="Date")]
		public System.Nullable<System.DateTime> TuNgay
		{
			get
			{
				return this._TuNgay;
			}
			set
			{
				if ((this._TuNgay != value))
				{
					this._TuNgay = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DenNgay", DbType="Date")]
		public System.Nullable<System.DateTime> DenNgay
		{
			get
			{
				return this._DenNgay;
			}
			set
			{
				if ((this._DenNgay != value))
				{
					this._DenNgay = value;
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
	}
}
#pragma warning restore 1591
