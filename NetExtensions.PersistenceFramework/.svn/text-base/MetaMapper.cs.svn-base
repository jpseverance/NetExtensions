//using System;
//using System.Collections;
//using System.Data;
//using System.Data.SqlClient;
//using System.Reflection;
//using System.Text;

//using NetExtensions.PersistenceFramework.AdoFactories;
//using NetExtensions.Models;

//namespace NetExtensions.PersistenceFramework
//{
//    [Serializable]
//    public class MetaMapper : TemplateMapper
//    {
//        #region Event Handlers
//        #endregion

//        #region Methods
//        #endregion

//        #region Properties
//        #endregion

//        #region Private Methods
//        protected override IDbCommand ExistsCommandFor( PersistentModel aModel )
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.Append( "select count( * ) from " );
//            sql.Append( this.DataMap.TableName );
//            sql.Append( " where " );
//            sql.Append( this.DataMap.KeyFields[0] );
//            sql.Append( " = " );
//            sql.Append( aModel.Key.GetValue() );

//            return base.BuildCommandFor( sql.ToString() );
//        }

//        protected override IDbCommand SelectCommandFor( Key aKey )
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.Append( "select " );
//            sql.Append( this.DataMap.GetColumnList() );
//            sql.Append( " from " );
//            sql.Append( this.DataMap.TableName );
//            sql.Append( " where " );
//            sql.Append( this.DataMap.KeyFields[0] );
//            sql.Append( " = " );
//            sql.Append( aKey.GetValue() );

//            return base.BuildCommandFor( sql.ToString() );
//        }

//        protected override IDbCommand SelectCommandFor( Query aQuery )
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.Append( "select " );
//            sql.Append( this.DataMap.GetColumnList() );
//            sql.Append( " from " );
//            sql.Append( this.DataMap.TableName );
//            sql.Append( " where " );
//            sql.Append( aQuery.GenerateWhereClause() );

//            return base.BuildCommandFor( sql.ToString() );
//        }

//        protected override PersistentModel LoadFrom( IDataReader reader )
//        {
//            PersistentModel result = (PersistentModel)Activator.CreateInstance( this.DataMap.DomainType );

//            int numberOfKeys = this.DataMap.KeyFields.Count;
//            ArrayList keys   = new ArrayList( this.DataMap.KeyFields );

//            object[] values = new object[numberOfKeys];
//            for( int i = 0; i < numberOfKeys; i++ )
//            {
//                values[i] = reader[keys[i].ToString()];
//            }
//            if( values.Length != 0 )
//            {
//                result.Key = new Key( values );
//            }

//            foreach( ColumnMap columnMap in this.DataMap.ColumnMaps )
//            {
//                object value = reader[columnMap.ColumnName];
//                if( columnMap.Member.MemberType == MemberTypes.Property )
//                {
//                    DataMap.DomainType.GetProperty( 
//                        columnMap.Member.Name 
//                        ).SetValue( result, value, null );
//                }
//                else if( columnMap.Member.MemberType == MemberTypes.Field )
//                {
//                    DataMap.DomainType.GetField( 
//                        columnMap.Member.Name 
//                        ).SetValue( result, value );
//                }
//            }

//            return result;
//        }

//        protected override IDbCommand SelectAllCommand()
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }

//        protected override IDbCommand InsertCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }

//        protected override IDbCommand UpdateCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }

//        protected override IDbCommand DeleteCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }

//        protected override IDbCommand SelectVersionCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }
//        #endregion

//        #region Private Properties
//        public DataMap DataMap
//        {
//            get
//            {
//                return i_DataMap;
//            }
//            set
//            {
//                i_DataMap = value;
//            }
//        }
//        #endregion

//        #region Construction and Finalization
//        public MetaMapper( IAdoFactory adoFactory, DataMap map, IDbConnection connection )
//        {
//            this.AdoFactory = adoFactory;
//            this.DataMap    = map;
//            this.Connection = connection;
//        }

//        public MetaMapper( IAdoFactory adoFactory, DataMap map )
//            : this( adoFactory, map, null )
//        {
//        }
        
//        #endregion

//        #region Data Elements
//        private DataMap i_DataMap;
//        #endregion

//        #region Constants
//        #endregion
//    }
//}
