using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Reflection;

namespace NetExtensions.PersistenceFramework
{
    [Serializable]
    public class DataMap : object
    {
        #region Event Handlers
        #endregion

        #region Methods
        public void AddColumnMap( string columnName, MemberInfo domainMember )
        {
            i_ColumnList = String.Empty;
            this.PrimColumnMaps.Add( new ColumnMap( columnName, domainMember ) );
        }

        public void AddKeyField( string fieldName )
        {
            this.PrimKeyFields.Add( fieldName );
        }

        public string GetColumnList()
        {
            if( i_ColumnList == String.Empty )
            {
                StringBuilder builder = new StringBuilder( this.PrimColumnMaps.Count );
                int i = 0;

                foreach( string key in this.PrimKeyFields )
                {
                    if( i != 0 ) builder.Append( ", " );
                    builder.Append( key );
                    i++;
                }
                
                foreach( ColumnMap column in this.PrimColumnMaps )
                {
                    if( i != 0 ) builder.Append( ", " );
                    builder.Append( column.ColumnName );
                    i++;
                }

                i_ColumnList = builder.ToString();
            }
            return i_ColumnList;
        }
        #endregion

        #region Properties
        public Type DomainType
        {
            get
            {
                return i_DomainType;
            }
            set
            {
                i_DomainType = value;
            }
        }

        public string TableName
        {
            get
            {
                return i_TableName;
            }
            set
            {
                i_TableName = value;
            }
        }

        public IList ColumnMaps
        {
            get
            {
                return (IList)this.PrimColumnMaps.Clone();
            }
        }

        public IList KeyFields
        {
            get
            {
                return (IList)this.PrimKeyFields.Clone();
            }
        }
        #endregion

        #region Private Methods
        protected ArrayList PrimColumnMaps
        {
            get
            {
                return i_PrimColumnMaps;
            }
            set
            {
                i_PrimColumnMaps = value;
            }
        }

        protected ArrayList PrimKeyFields
        {
            get
            {
                return i_KeyFields;
            }
            set
            {
                i_KeyFields = value;
            }
        }
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public DataMap( Type domainType, string tableName )
        {
            this.DomainType = domainType;
            this.TableName  = tableName;
        }
        #endregion

        #region Data Elements
        private Type        i_DomainType;
        private string      i_TableName;
        private ArrayList   i_PrimColumnMaps   = new ArrayList();
        private string      i_ColumnList;
        private ArrayList   i_KeyFields        = new ArrayList();
        #endregion

        #region Constants
        #endregion
    }
}
