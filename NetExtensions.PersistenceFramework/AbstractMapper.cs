using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

using NetExtensions.PersistenceFramework.AdoFactories;
using NetExtensions.Models;

namespace NetExtensions.PersistenceFramework
{
    [Serializable]
    public abstract class AbstractMapper : Object
    {
        #region Event Handlers
        #endregion

        #region Methods
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the connection.  When the Connection is retrieved, if no 
        /// instance has been previously set, this property will attempt to build a connection
        /// from the connection string specified as "DBConnection" in this assembly's
        /// .config file.
        /// </summary>
        /// <value>The connection.</value>
        public IDbConnection Connection
        {
            get
            {
                if( this.i_Connection == null )
                {
                    string cxnString = ConfigurationManager.AppSettings[CONNECTION_STRING_KEY];
                    i_Connection = this.AdoFactory.CreateConnection();
                    i_Connection.ConnectionString = cxnString;
                }
                return (IDbConnection)i_Connection;
            }
            set
            {
                i_Connection = value;
            }
        }

        /// <summary>
        /// Gets or sets the transAction.  When setting the TransAction, 
        /// this Mapper's Connection will be set to that of the TransAction's Connection.
        /// </summary>
        /// <value>The transAction.</value>
        public IDbTransaction TransAction
        {
            get
            {
                return i_TransAction;
            }
            set
            {
                this.Connection = value.Connection;
                i_TransAction = value;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Builds an IDbCommand object for the supplied SQL string.  
        /// CommandType.Text is used as the CommandType.
        /// </summary>
        /// <param name="sql">A SQL statement.</param>
        /// <returns></returns>
        protected IDbCommand BuildCommandFor( string sql )
        {
            return this.BuildCommandFor( sql, CommandType.Text );
        }

        /// <summary>
        /// Builds an IDbCommand object for the supplied SQL string with Command Parameters
        /// built from the supplied ParameterBuilder(s).  CommandType.Text is assumed 
        /// and used for the Command's Command Type.
        /// </summary>
        /// <param name="sql">A SQL statement.</param>
        /// <param name="parameterBuilders">Parameter builders from which IDataParameters 
        /// should be built and added to the Command object.</param>
        /// <returns></returns>
        protected IDbCommand BuildCommandFor( string sql, params ParameterBuilder[] parameterBuilders )
        {
            IDbCommand cmd = this.BuildCommandFor( sql );
            foreach( ParameterBuilder builder in parameterBuilders )
            {
                builder.BuildParameterAndAddTo( cmd );
            }
            return cmd;
        }

        /// <summary>
        /// Builds an IDbCommand object for the supplied SQL string with 
        /// the specified CommandType as the kind of command.
        /// </summary>
        /// <param name="sql">A SQL statement.</param>
        /// <param name="kindOfCommand">The CommandType to use for the returned IDbCommand.</param>
        /// <returns></returns>
        protected IDbCommand BuildCommandFor( string sql, CommandType kindOfCommand )
        {
            IDbCommand cmd = this.Connection.CreateCommand();

            cmd.CommandText = sql;

            if( this.TransAction != null )
            {
                cmd.Transaction = this.TransAction;
            }

            cmd.Connection = this.Connection;

            return cmd;
        }

        /// <summary>
        /// Builds an IDbCommand object for the supplied SQL string using 
        /// the specified CommandType as the kind of command and with Command Parameters
        /// built from the supplied ParameterBuilder(s).
        /// </summary>
        /// <param name="sql">A SQL statement.</param>
        /// <param name="kindOfCommand">The CommandType to use for the returned IDbCommand.</param>
        /// <param name="parameterBuilders">Parameter builders from which IDataParameters 
        /// should be built and added to the Command object.</param>
        /// <returns></returns>
        protected IDbCommand BuildCommandFor( string sql, CommandType kindOfCommand, params ParameterBuilder[] parameterBuilders )
        {
            IDbCommand cmd = this.BuildCommandFor( sql, kindOfCommand );
            foreach( ParameterBuilder builder in parameterBuilders )
            {
                builder.BuildParameterAndAddTo( cmd );
            }
            return cmd;
        }

        /// <summary>
        /// Closes the specified IDbConnection if it is not null.
        /// </summary>
        /// <param name="conn">The IDbConnection to Close.</param>
        protected virtual void Close( IDbConnection conn )
        {
            if( conn != null )
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Closes the specified IDbCommand if it is not null.
        /// </summary>
        /// <param name="cmd">The IDbCommand to Close.</param>
        protected virtual void Close( IDbCommand cmd )
        {
            if( cmd != null )
            {
                cmd.Dispose();
            }
        }

        /// <summary>
        /// Closes the specified IDataReader if it is not null.
        /// </summary>
        /// <param name="reader">The IDataReader to Close.</param>
        protected virtual void Close( IDataReader reader )
        {
            if( reader != null )
            {
                reader.Close();
            }
        }

        /// <summary>
        /// Closes the specified IDbConnection and IDbCommand if they are not null.
        /// </summary>
        /// <param name="conn">The IDbConnection to Close.</param>
        /// <param name="cmd">The IDbCommand to Close.</param>
        protected virtual void Close( IDbConnection conn, IDbCommand cmd )
        {
            this.Close( conn );
            this.Close( cmd );
        }

        /// <summary>
        /// Closes the specified IDbConnection, IDbCommand, and IDataReader
        /// if they are not null.
        /// </summary>
        /// <param name="conn">The IDbConnection to Close.</param>
        /// <param name="cmd">The IDbCommand to Close.</param>
        /// <param name="reader">The IDataReader to Close.</param>
        protected virtual void Close( IDbConnection conn, IDbCommand cmd, IDataReader reader )
        {
            this.Close( conn );
            this.Close( cmd );
            this.Close( reader );
        }

        protected virtual IDataReader ExecuteReaderOn( IDbCommand cmd )
        {
            IDbConnection conn = this.Connection;
            IDataReader reader = null;

            try
            {
                cmd.Connection = conn;
                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }

                reader = cmd.ExecuteReader();
            }
            catch
            {
                this.Close( conn, cmd, reader );
                throw;
            }

            return reader;
        }
        #endregion

        #region Private Properties
        protected IAdoFactory AdoFactory
        {
            get
            {
                if( this.i_AdoFactory == null )
                {
                    string adoFactoryType = ConfigurationManager.AppSettings[ADO_FACTORY_KEY];
                    this.i_AdoFactory = Activator.CreateInstance( Type.GetType( adoFactoryType ) ) as IAdoFactory;
                }
                return i_AdoFactory;
            }
            set
            {
                i_AdoFactory = value;
            }
        }
        #endregion

        #region Construction and Finalization
        public AbstractMapper()
        {
        }

        public AbstractMapper( IAdoFactory adoFactory )
        {
            this.AdoFactory = adoFactory;
        }

        public AbstractMapper( IAdoFactory adoFactory, IDbConnection connection )
            : this( adoFactory )
        {
            this.Connection = connection;
        }

        public AbstractMapper( IAdoFactory adoFactory, IDbTransaction transAction )
            : this( adoFactory )
        {
            this.TransAction = transAction;
        }
        #endregion

        #region Data Elements
        private IDbConnection i_Connection;
        private IDbTransaction i_TransAction;
        private IAdoFactory i_AdoFactory;
        #endregion

        #region Constants
        private const string
            CONNECTION_STRING_KEY = "DBConnection",
            ADO_FACTORY_KEY = "AdoFactory";
        #endregion
    }
}
