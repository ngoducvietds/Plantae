﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Plantae.Core
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Plantae")]
	public partial class PlantaeModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCONTA(CONTA instance);
    partial void UpdateCONTA(CONTA instance);
    partial void DeleteCONTA(CONTA instance);
    #endregion
		
		public PlantaeModelDataContext() : 
				base(global::Plantae.Core.Properties.Settings.Default.PlantaeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PlantaeModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PlantaeModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PlantaeModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PlantaeModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CONTA> CONTAs
		{
			get
			{
				return this.GetTable<CONTA>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CONTA")]
	public partial class CONTA : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ContaID;
		
		private string _Nome;
		
		private System.DateTime _DataInicial;
		
		private decimal _SaldoInicial;
		
		private string _Owner;
		
		private System.Guid _Guid;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnContaIDChanging(long value);
    partial void OnContaIDChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnDataInicialChanging(System.DateTime value);
    partial void OnDataInicialChanged();
    partial void OnSaldoInicialChanging(decimal value);
    partial void OnSaldoInicialChanged();
    partial void OnOwnerChanging(string value);
    partial void OnOwnerChanged();
    partial void OnGuidChanging(System.Guid value);
    partial void OnGuidChanged();
    #endregion
		
		public CONTA()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContaID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ContaID
		{
			get
			{
				return this._ContaID;
			}
			set
			{
				if ((this._ContaID != value))
				{
					this.OnContaIDChanging(value);
					this.SendPropertyChanging();
					this._ContaID = value;
					this.SendPropertyChanged("ContaID");
					this.OnContaIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nome", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Nome
		{
			get
			{
				return this._Nome;
			}
			set
			{
				if ((this._Nome != value))
				{
					this.OnNomeChanging(value);
					this.SendPropertyChanging();
					this._Nome = value;
					this.SendPropertyChanged("Nome");
					this.OnNomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataInicial", DbType="Date NOT NULL")]
		public System.DateTime DataInicial
		{
			get
			{
				return this._DataInicial;
			}
			set
			{
				if ((this._DataInicial != value))
				{
					this.OnDataInicialChanging(value);
					this.SendPropertyChanging();
					this._DataInicial = value;
					this.SendPropertyChanged("DataInicial");
					this.OnDataInicialChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SaldoInicial", DbType="Decimal(18,0) NOT NULL")]
		public decimal SaldoInicial
		{
			get
			{
				return this._SaldoInicial;
			}
			set
			{
				if ((this._SaldoInicial != value))
				{
					this.OnSaldoInicialChanging(value);
					this.SendPropertyChanging();
					this._SaldoInicial = value;
					this.SendPropertyChanged("SaldoInicial");
					this.OnSaldoInicialChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Owner", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Owner
		{
			get
			{
				return this._Owner;
			}
			set
			{
				if ((this._Owner != value))
				{
					this.OnOwnerChanging(value);
					this.SendPropertyChanging();
					this._Owner = value;
					this.SendPropertyChanged("Owner");
					this.OnOwnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Guid", AutoSync=AutoSync.OnInsert, DbType="UniqueIdentifier NOT NULL", IsDbGenerated=true)]
		public System.Guid Guid
		{
			get
			{
				return this._Guid;
			}
			set
			{
				if ((this._Guid != value))
				{
					this.OnGuidChanging(value);
					this.SendPropertyChanging();
					this._Guid = value;
					this.SendPropertyChanged("Guid");
					this.OnGuidChanged();
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