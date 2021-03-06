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

namespace test
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HomeStat")]
	public partial class HomeStatDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertgeo(geo instance);
    partial void Updategeo(geo instance);
    partial void Deletegeo(geo instance);
    #endregion
		
		public HomeStatDataContext() : 
				base(global::test.Properties.Settings.Default.HomeStatConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HomeStatDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HomeStatDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HomeStatDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HomeStatDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<geo> geo
		{
			get
			{
				return this.GetTable<geo>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="cau.geo")]
	public partial class geo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private decimal _UNIQUE_KEY;
		
		private System.DateTime _CREATED_DATE;
		
		private string _AGENCY;
		
		private string _COMPLAINT_TYPE;
		
		private string _DESCRIPTOR_1;
		
		private string _COMMUNITY_BOARD;
		
		private string _BOROUGH;
		
		private System.Nullable<decimal> _LAT;
		
		private System.Nullable<decimal> _LON;
		
		private System.DateTime _LAST_UPDATE_DATE;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUNIQUE_KEYChanging(decimal value);
    partial void OnUNIQUE_KEYChanged();
    partial void OnCREATED_DATEChanging(System.DateTime value);
    partial void OnCREATED_DATEChanged();
    partial void OnAGENCYChanging(string value);
    partial void OnAGENCYChanged();
    partial void OnCOMPLAINT_TYPEChanging(string value);
    partial void OnCOMPLAINT_TYPEChanged();
    partial void OnDESCRIPTOR_1Changing(string value);
    partial void OnDESCRIPTOR_1Changed();
    partial void OnCOMMUNITY_BOARDChanging(string value);
    partial void OnCOMMUNITY_BOARDChanged();
    partial void OnBOROUGHChanging(string value);
    partial void OnBOROUGHChanged();
    partial void OnLATChanging(System.Nullable<decimal> value);
    partial void OnLATChanged();
    partial void OnLONChanging(System.Nullable<decimal> value);
    partial void OnLONChanged();
    partial void OnLAST_UPDATE_DATEChanging(System.DateTime value);
    partial void OnLAST_UPDATE_DATEChanged();
    #endregion
		
		public geo()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UNIQUE_KEY", DbType="Decimal(10,0) NOT NULL", IsPrimaryKey=true)]
		public decimal UNIQUE_KEY
		{
			get
			{
				return this._UNIQUE_KEY;
			}
			set
			{
				if ((this._UNIQUE_KEY != value))
				{
					this.OnUNIQUE_KEYChanging(value);
					this.SendPropertyChanging();
					this._UNIQUE_KEY = value;
					this.SendPropertyChanged("UNIQUE_KEY");
					this.OnUNIQUE_KEYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATED_DATE", DbType="DateTime NOT NULL")]
		public System.DateTime CREATED_DATE
		{
			get
			{
				return this._CREATED_DATE;
			}
			set
			{
				if ((this._CREATED_DATE != value))
				{
					this.OnCREATED_DATEChanging(value);
					this.SendPropertyChanging();
					this._CREATED_DATE = value;
					this.SendPropertyChanged("CREATED_DATE");
					this.OnCREATED_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AGENCY", DbType="VarChar(3) NOT NULL", CanBeNull=false)]
		public string AGENCY
		{
			get
			{
				return this._AGENCY;
			}
			set
			{
				if ((this._AGENCY != value))
				{
					this.OnAGENCYChanging(value);
					this.SendPropertyChanging();
					this._AGENCY = value;
					this.SendPropertyChanged("AGENCY");
					this.OnAGENCYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COMPLAINT_TYPE", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string COMPLAINT_TYPE
		{
			get
			{
				return this._COMPLAINT_TYPE;
			}
			set
			{
				if ((this._COMPLAINT_TYPE != value))
				{
					this.OnCOMPLAINT_TYPEChanging(value);
					this.SendPropertyChanging();
					this._COMPLAINT_TYPE = value;
					this.SendPropertyChanged("COMPLAINT_TYPE");
					this.OnCOMPLAINT_TYPEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DESCRIPTOR_1", DbType="VarChar(80) NOT NULL", CanBeNull=false)]
		public string DESCRIPTOR_1
		{
			get
			{
				return this._DESCRIPTOR_1;
			}
			set
			{
				if ((this._DESCRIPTOR_1 != value))
				{
					this.OnDESCRIPTOR_1Changing(value);
					this.SendPropertyChanging();
					this._DESCRIPTOR_1 = value;
					this.SendPropertyChanged("DESCRIPTOR_1");
					this.OnDESCRIPTOR_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COMMUNITY_BOARD", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
		public string COMMUNITY_BOARD
		{
			get
			{
				return this._COMMUNITY_BOARD;
			}
			set
			{
				if ((this._COMMUNITY_BOARD != value))
				{
					this.OnCOMMUNITY_BOARDChanging(value);
					this.SendPropertyChanging();
					this._COMMUNITY_BOARD = value;
					this.SendPropertyChanged("COMMUNITY_BOARD");
					this.OnCOMMUNITY_BOARDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BOROUGH", DbType="VarChar(13) NOT NULL", CanBeNull=false)]
		public string BOROUGH
		{
			get
			{
				return this._BOROUGH;
			}
			set
			{
				if ((this._BOROUGH != value))
				{
					this.OnBOROUGHChanging(value);
					this.SendPropertyChanging();
					this._BOROUGH = value;
					this.SendPropertyChanged("BOROUGH");
					this.OnBOROUGHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LAT", DbType="Decimal(9,7)")]
		public System.Nullable<decimal> LAT
		{
			get
			{
				return this._LAT;
			}
			set
			{
				if ((this._LAT != value))
				{
					this.OnLATChanging(value);
					this.SendPropertyChanging();
					this._LAT = value;
					this.SendPropertyChanged("LAT");
					this.OnLATChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LON", DbType="Decimal(9,7)")]
		public System.Nullable<decimal> LON
		{
			get
			{
				return this._LON;
			}
			set
			{
				if ((this._LON != value))
				{
					this.OnLONChanging(value);
					this.SendPropertyChanging();
					this._LON = value;
					this.SendPropertyChanged("LON");
					this.OnLONChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LAST_UPDATE_DATE", DbType="DateTime NOT NULL")]
		public System.DateTime LAST_UPDATE_DATE
		{
			get
			{
				return this._LAST_UPDATE_DATE;
			}
			set
			{
				if ((this._LAST_UPDATE_DATE != value))
				{
					this.OnLAST_UPDATE_DATEChanging(value);
					this.SendPropertyChanging();
					this._LAST_UPDATE_DATE = value;
					this.SendPropertyChanged("LAST_UPDATE_DATE");
					this.OnLAST_UPDATE_DATEChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
