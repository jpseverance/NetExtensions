using System;
using System.Data;

namespace NetExtensions.PersistenceFramework
{
    [Serializable]
    public class SafeReader : IDataReader
    {
        #region Event Handlers
        #endregion

        #region Methods
        public void Dispose()
        {
            this.SourceReader.Dispose();
        }

        public bool NextResult()
        {
            return this.SourceReader.NextResult();
        }

        public void Close()
        {
            this.SourceReader.Close();
        }

        public bool Read()
        {
            return this.SourceReader.Read();
        }

        public object GetValue( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetValue( i ) ) )
            {
                return new Object();
            }
            return this.SourceReader.GetValue( i );
        }

        public object GetValue( string column )
        {
            return this.GetValue( this.GetOrdinal( column ) );
        }

        public object GetNullableValue( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetValue( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetValue( i );
        }

        public object GetNullableValue( string column )
        {
            return this.GetValue( this.GetOrdinal( column ) );
        }

        public bool IsDBNull( int i )
        {
            return this.SourceReader.IsDBNull( i );
        }

        public bool IsDBNull( string column )
        {
            return this.SourceReader.IsDBNull( this.GetOrdinal( column ) );
        }

        public bool IsNotDBNull( int i )
        {
            return !this.IsDBNull( i );
        }

        public bool IsNotDBNull( string column )
        {
            return !this.IsDBNull( column );
        }

        public long GetBytes( int i, long fieldOffset, byte[] buffer, int bufferoffset, int length )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetBytes( i, fieldOffset, buffer, bufferoffset, length ) ) )
            {
                return long.MinValue;
            }
            return this.SourceReader.GetBytes( i, fieldOffset, buffer, bufferoffset, length );
        }

        public long GetBytes( string column, long fieldOffset, byte[] buffer, int bufferoffset, int length )
        {
            return this.GetBytes( this.GetOrdinal( column ), fieldOffset, buffer, bufferoffset, length );
        }

        public long? GetNullableBytes( int i, long fieldOffset, byte[] buffer, int bufferoffset, int length )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetBytes( i, fieldOffset, buffer, bufferoffset, length ) ) )
            {
                return long.MinValue;
            }
            return this.SourceReader.GetBytes( i, fieldOffset, buffer, bufferoffset, length );
        }

        public long? GetNullableBytes( string column, long fieldOffset, byte[] buffer, int bufferoffset, int length )
        {
            return this.GetNullableBytes( this.GetOrdinal( column ), fieldOffset, buffer, bufferoffset, length );
        }

        public byte GetByte( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetByte( i ) ) )
            {
                return byte.MinValue;
            }
            return this.SourceReader.GetByte( i );
        }

        public byte GetByte( string column )
        {
            return this.GetByte( this.GetOrdinal( column ) );
        }

        public byte? GetNullableByte( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetByte( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetByte( i );
        }

        public byte? GetNullableByte( string column )
        {
            return this.GetNullableByte( this.GetOrdinal( column ) );
        }

        public Type GetFieldType( int i )
        {
            return this.SourceReader.GetFieldType( i );
        }

        public Type GetFieldType( string column )
        {
            return this.GetFieldType( this.GetOrdinal( column ) );
        }

        public decimal GetDecimal( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetDecimal( i ) ) )
            {
                return decimal.MinValue;
            }
            return this.SourceReader.GetDecimal( i );
        }

        public decimal GetDecimal( string column )
        {
            return this.GetDecimal( this.GetOrdinal( column ) );
        }

        public decimal? GetNullableDecimal( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetDecimal( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetDecimal( i );
        }

        public decimal? GetNullableDecimal( string column )
        {
            return this.GetNullableDecimal( this.GetOrdinal( column ) );
        }

        public int GetInt32( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetInt32( i ) ) )
            {
                return int.MinValue;
            }
            return this.SourceReader.GetInt32( i );
        }

        public int GetInt32( string column )
        {
            return this.GetInt32( this.GetOrdinal( column ) );
        }

        public int? GetNullableInt32( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetInt32( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetInt32( i );
        }

        public int? GetNullableInt32( string column )
        {
            return this.GetNullableInt32( this.GetOrdinal( column ) );
        }

        public int GetValues( object[] values )
        {
            return this.SourceReader.GetValues( values );
        }

        public string GetName( int i )
        {
            return this.SourceReader.GetName( i );
        }

        public long GetInt64( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetInt64( i ) ) )
            {
                return long.MinValue;
            }
            return this.SourceReader.GetInt64( i );
        }

        public long GetInt64( string column )
        {
            return this.GetInt64( this.GetOrdinal( column ) );
        }

        public long? GetNullableInt64( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetInt64( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetInt64( i );
        }

        public long? GetNullableInt64( string column )
        {
            return this.GetInt64( this.GetOrdinal( column ) );
        }

        public double GetDouble( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetDouble( i ) ) )
            {
                return double.MinValue;
            }
            return this.SourceReader.GetDouble( i );
        }

        public double GetDouble( string column )
        {
            return this.GetDouble( this.GetOrdinal( column ) );
        }

        public double? GetNullableDouble( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetDouble( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetDouble( i );
        }

        public double? GetNullableDouble( string column )
        {
            return this.GetDouble( this.GetOrdinal( column ) );
        }

        public bool GetBoolean( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetBoolean( i ) ) )
            {
                return false;
            }
            return this.SourceReader.GetBoolean( i );
        }

        public bool GetBoolean( string column )
        {
            return this.GetBoolean( this.GetOrdinal( column ) );
        }

        public bool? GetNullableBoolean( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetBoolean( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetBoolean( i );
        }

        public bool? GetNullableBoolean( string column )
        {
            return this.GetBoolean( this.GetOrdinal( column ) );
        }

        public Guid GetGuid( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetGuid( i ) ) )
            {
                return Guid.Empty;
            }
            return this.SourceReader.GetGuid( i );
        }

        public Guid GetGuid( string column )
        {
            return this.GetGuid( this.GetOrdinal( column ) );
        }

        public Guid? GetNullableGuid( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetGuid( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetGuid( i );
        }

        public Guid? GetNullableGuid( string column )
        {
            return this.GetNullableGuid( this.GetOrdinal( column ) );
        }

        public DateTime GetDateTime( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetDateTime( i ) ) )
            {
                return DateTime.MinValue;
            }
            return this.SourceReader.GetDateTime( i );
        }

        public DateTime GetDateTime( string column )
        {
            return this.GetDateTime( this.GetOrdinal( column ) );
        }

        public DateTime? GetNullableDateTime( int i )
        {
            DateTime? result = null;
            try
            {
                if( ! DBNull.Equals( DBNull.Value, this.SourceReader.GetDateTime( i ) ) )
                {
                    result = this.SourceReader.GetDateTime( i );
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public DateTime? GetNullableDateTime( string column )
        {
            return this.GetNullableDateTime( this.GetOrdinal( column ) );
        }

        public int GetOrdinal( string name )
        {
            return this.SourceReader.GetOrdinal( name );
        }

        public string GetDataTypeName( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetDataTypeName( i ) ) )
            {
                return String.Empty;
            }
            return this.SourceReader.GetDataTypeName( i );
        }

        public string GetDataTypeName( string column )
        {
            return this.GetDataTypeName( this.GetOrdinal( column ) );
        }

        public float GetFloat( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetFloat( i ) ) )
            {
                return float.MinValue;
            }
            return this.SourceReader.GetFloat( i );
        }

        public float GetFloat( string column )
        {
            return this.GetFloat( this.GetOrdinal( column ) );
        }

        public float? GetNullableFloat( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetFloat( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetFloat( i );
        }

        public float? GetNullableFloat( string column )
        {
            return this.GetNullableFloat( this.GetOrdinal( column ) );
        }

        public IDataReader GetData( int i )
        {
            return this.SourceReader.GetData( i );
        }

        public IDataReader GetData( string column )
        {
            return this.SourceReader.GetData( this.GetOrdinal( column ) );
        }

        public long GetChars( int i, long fieldoffset, char[] buffer, int bufferoffset, int length )
        {
            if( DBNull.Equals( 
                    DBNull.Value, 
                    this.SourceReader.GetChars( i, fieldoffset, buffer, bufferoffset, length )
                    )
                )
            {
                return long.MinValue;
            }
            return this.SourceReader.GetChars( i, fieldoffset, buffer, bufferoffset, length );
        }

        public long GetChars( string column, long fieldoffset, char[] buffer, int bufferoffset, int length )
        {
            return this.GetChars( this.GetOrdinal( column ), fieldoffset, buffer, bufferoffset, length );
        }

        public long? GetNullableChars( int i, long fieldoffset, char[] buffer, int bufferoffset, int length )
        {
            if( DBNull.Equals(
                    DBNull.Value,
                    this.SourceReader.GetChars( i, fieldoffset, buffer, bufferoffset, length )
                    )
                )
            {
                return null;
            }
            return this.SourceReader.GetChars( i, fieldoffset, buffer, bufferoffset, length );
        }

        public long? GetNullableChars( string column, long fieldoffset, char[] buffer, int bufferoffset, int length )
        {
            return this.GetNullableChars( this.GetOrdinal( column ), fieldoffset, buffer, bufferoffset, length );
        }

        public string GetString( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetString( i ) ) )
            {
                return String.Empty;
            }
            return this.SourceReader.GetString( i );
        }

        public string GetString( string column )
        {
            return this.GetString( this.GetOrdinal( column ) );
        }

        public char GetChar( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetChar( i ) ) )
            {
                return char.MinValue;
            }
            return this.SourceReader.GetChar( i );
        }

        public char GetChar( string column )
        {
            return this.GetChar( this.GetOrdinal( column ) );
        }

        public char? GetNullableChar( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetChar( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetChar( i );
        }

        public char? GetNullableChar( string column )
        {
            return this.GetNullableChar( this.GetOrdinal( column ) );
        }

        public short GetInt16( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetInt16( i ) ) )
            {
                return short.MinValue;
            }
            return this.SourceReader.GetInt16( i );
        }

        public short GetInt16( string column )
        {
            return this.GetInt16( this.GetOrdinal( column ) );
        }

        public short? GetNullableInt16( int i )
        {
            if( DBNull.Equals( DBNull.Value, this.SourceReader.GetInt16( i ) ) )
            {
                return null;
            }
            return this.SourceReader.GetInt16( i );
        }

        public short? GetNullableInt16( string column )
        {
            return this.GetNullableInt16( this.GetOrdinal( column ) );
        }

        public DataTable GetSchemaTable()
        {
            return this.SourceReader.GetSchemaTable();
        }
        #endregion

        #region Properties
        public object this[string name]
        {
            get
            {
                return this.SourceReader[name];
            }
        }

        object IDataRecord.this[int i]
        {
            get
            {
                return this.SourceReader[i];
            }
        }

        public int Depth
        {
            get
            {
                return this.SourceReader.Depth;
            }
        }

        public int RecordsAffected
        {
            get
            {
                return this.SourceReader.RecordsAffected;
            }
        }

        public bool IsClosed
        {
            get
            {
                return this.SourceReader.IsClosed;
            }
        }

        public int FieldCount
        {
            get
            {
                return this.SourceReader.FieldCount;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        protected IDataReader SourceReader
        {
            get
            {
                return i_SourceReader;
            }
            set
            {
                i_SourceReader = value;
            }
        }
        #endregion

        #region Construction and Finalization
        public SafeReader( IDataReader sourceReader )
        {
            this.i_SourceReader = sourceReader;
        }
        #endregion

        #region Data Elements
        private IDataReader i_SourceReader;
        #endregion

        #region Constants
        #endregion
    }
}