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

namespace DaoBSCKPI.Database.KeHoachDanhGia
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
	public partial class linqKeHoachDanhGiaTheoChucVuDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqKeHoachDanhGiaTheoChucVuDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqKeHoachDanhGiaTheoChucVuDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKeHoachDanhGiaTheoChucVuDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKeHoachDanhGiaTheoChucVuDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKeHoachDanhGiaTheoChucVuDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach")]
		public ISingleResult<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult> sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDKeHoach);
			return ((ISingleResult<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKeHoachDanhGiatheochucvu_ThemSua")]
		public int sp_tblBKKeHoachDanhGiatheochucvu_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChucVu", DbType="Int")] System.Nullable<int> iDChucVu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChucDanh", DbType="Int")] System.Nullable<int> iDChucDanh, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TuNgay", DbType="Date")] System.Nullable<System.DateTime> tuNgay, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DenNgay", DbType="Date")] System.Nullable<System.DateTime> denNgay)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDKeHoach, iDChucVu, iDChucDanh, tuNgay, denNgay);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanh")]
		public ISingleResult<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanhResult> sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanh([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDKeHoach);
			return ((ISingleResult<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanhResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVu")]
		public ISingleResult<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVuResult> sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVu([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDKeHoach);
			return ((ISingleResult<sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVuResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKeHoachDanhGiaTheoChucVu_Xoa")]
		public int sp_tblBKKeHoachDanhGiaTheoChucVu_Xoa([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChucVu", DbType="Int")] System.Nullable<int> iDChucVu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDKeHoach, iDChucVu);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKeHoachDanhGiaTheoChucVu_XoaChucDanh")]
		public int sp_tblBKKeHoachDanhGiaTheoChucVu_XoaChucDanh([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChucDanh", DbType="Int")] System.Nullable<int> iDChucDanh)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDKeHoach, iDChucDanh);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult
	{
		
		private int _IDKeHoach;
		
		private System.Nullable<int> _IDChucVu;
		
		private string _ChucVu;
		
		private System.Nullable<int> _IDChucDanh;
		
		private string _ChucDanh;
		
		private System.Nullable<System.DateTime> _TuNgay;
		
		private System.Nullable<System.DateTime> _DenNgay;
		
		private System.Nullable<System.DateTime> _NgayHeThong;
		
		public sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSachResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKeHoach", DbType="Int NOT NULL")]
		public int IDKeHoach
		{
			get
			{
				return this._IDKeHoach;
			}
			set
			{
				if ((this._IDKeHoach != value))
				{
					this._IDKeHoach = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChucVu", DbType="Int")]
		public System.Nullable<int> IDChucVu
		{
			get
			{
				return this._IDChucVu;
			}
			set
			{
				if ((this._IDChucVu != value))
				{
					this._IDChucVu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChucVu", DbType="NVarChar(50)")]
		public string ChucVu
		{
			get
			{
				return this._ChucVu;
			}
			set
			{
				if ((this._ChucVu != value))
				{
					this._ChucVu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChucDanh", DbType="Int")]
		public System.Nullable<int> IDChucDanh
		{
			get
			{
				return this._IDChucDanh;
			}
			set
			{
				if ((this._IDChucDanh != value))
				{
					this._IDChucDanh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChucDanh", DbType="NVarChar(50)")]
		public string ChucDanh
		{
			get
			{
				return this._ChucDanh;
			}
			set
			{
				if ((this._ChucDanh != value))
				{
					this._ChucDanh = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayHeThong", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayHeThong
		{
			get
			{
				return this._NgayHeThong;
			}
			set
			{
				if ((this._NgayHeThong != value))
				{
					this._NgayHeThong = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanhResult
	{
		
		private int _IDChucDanh;
		
		private string _ChucDanh;
		
		private System.Nullable<bool> _DaChonCD;
		
		public sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucDanhResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChucDanh", DbType="Int NOT NULL")]
		public int IDChucDanh
		{
			get
			{
				return this._IDChucDanh;
			}
			set
			{
				if ((this._IDChucDanh != value))
				{
					this._IDChucDanh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChucDanh", DbType="NVarChar(50)")]
		public string ChucDanh
		{
			get
			{
				return this._ChucDanh;
			}
			set
			{
				if ((this._ChucDanh != value))
				{
					this._ChucDanh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DaChonCD", DbType="Bit")]
		public System.Nullable<bool> DaChonCD
		{
			get
			{
				return this._DaChonCD;
			}
			set
			{
				if ((this._DaChonCD != value))
				{
					this._DaChonCD = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVuResult
	{
		
		private int _IDChucVu;
		
		private string _ChucVu;
		
		private System.Nullable<bool> _DaChonCV;
		
		public sp_tblBKKeHoachDanhGiaTheoChucVu_DanhSach_ChucVuResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChucVu", DbType="Int NOT NULL")]
		public int IDChucVu
		{
			get
			{
				return this._IDChucVu;
			}
			set
			{
				if ((this._IDChucVu != value))
				{
					this._IDChucVu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChucVu", DbType="NVarChar(50)")]
		public string ChucVu
		{
			get
			{
				return this._ChucVu;
			}
			set
			{
				if ((this._ChucVu != value))
				{
					this._ChucVu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DaChonCV", DbType="Bit")]
		public System.Nullable<bool> DaChonCV
		{
			get
			{
				return this._DaChonCV;
			}
			set
			{
				if ((this._DaChonCV != value))
				{
					this._DaChonCV = value;
				}
			}
		}
	}
}
#pragma warning restore 1591