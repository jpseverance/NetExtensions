using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace NetExtensions.PersistenceFramework.AdoFactories
{
    public class ParameterBuilder
    {
        public IDataParameter BuildParameterFor( IDbCommand aCommand )
        {
            IDataParameter parameter = aCommand.CreateParameter();
            parameter.Direction = this._direction;
            parameter.DbType = this._dbType;
            parameter.ParameterName = this._parameterName;
            parameter.Value = this._value;

            return parameter;
        }

        public IDataParameter BuildParameterAndAddTo( IDbCommand aCommand )
        {
            IDataParameter parameter = this.BuildParameterFor( aCommand ); 
            aCommand.Parameters.Add( parameter );
            return parameter;
        }

        public DbType DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }

        public ParameterDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public string ParameterName
        {
            get { return _parameterName; }
            set { _parameterName = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public ParameterBuilder( string parameterName, object value, DbType dbType, ParameterDirection direction )
        {
            this.ParameterName = parameterName;
            this.Value = value;
            this.DbType = dbType;
            this.Direction = direction;
        }

        public ParameterBuilder( string parameterName, object value, DbType dbType )
            : this( parameterName, value, dbType, ParameterDirection.Input )
        {
        }

        public ParameterBuilder( string parameterName, object value )
            : this( parameterName, value, DbType.Object )
        {
        }

        private string _parameterName;
        private object _value;
        private DbType _dbType;
        private ParameterDirection _direction = ParameterDirection.Input;
    }
}
