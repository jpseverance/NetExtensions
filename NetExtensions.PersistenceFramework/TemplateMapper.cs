using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

using NetExtensions.PersistenceFramework.AdoFactories;
using NetExtensions.Models;

namespace NetExtensions.PersistenceFramework
{
    public abstract class TemplateMapper<TMappedType> : AbstractMapper
        where TMappedType : PersistentModel
    {
        #region Event Handlers
        #endregion

        #region Methods
        /// <summary>
        /// Answers whether the specified PersistentModel already exists
        /// in the persistence store.
        /// </summary>
        /// <param name="aModel">A model.</param>
        /// <returns></returns>
        public bool Exists( TMappedType aModel )
        {
            long result;
            IDbCommand cmd = null;

            try
            {
                cmd = this.ExistsCommandFor( aModel );
                IDbConnection conn = this.Connection;
                cmd.Connection = conn;
                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }
                result = (long)cmd.ExecuteScalar();
            }
            finally
            {
                this.Close( cmd );
            }

            if( result != 0 )
            {
                return true;
            }
            return false;
        }

        public virtual PersistentModel Save( TMappedType aModel )
        {
            PersistentModel result = default( TMappedType );

            if( this.Exists( aModel ) )
            {
                if( this.VersionIsUnchangedInDbFor( aModel ) )
                {
                    result = this.Update( aModel );
                }
                else
                {
                    throw new StaleObjectException( aModel );
                }
            }
            else
            {
                result = this.Insert( aModel );
            }

            return result;
        }

        protected virtual bool VersionIsUnchangedInDbFor( TMappedType aModel )
        {
            object result;
            IDbConnection conn = this.Connection;
            IDbCommand cmd = null;

            try
            {
                cmd = this.SelectVersionCommandFor( aModel );
                cmd.Connection = conn;
                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }
                result = cmd.ExecuteScalar();
            }
            finally
            {
                base.Close( cmd );
            }

            if( aModel.Version.Equals( result ) )
            {
                return true;
            }
            return false;
        }

        protected virtual TMappedType Insert( TMappedType aModel )
        {
            IDbConnection conn = this.Connection;
            IDbCommand cmd = null;
            IDataReader reader = null;
            TMappedType result = default( TMappedType );

            try
            {
                cmd = this.InsertCommandFor( aModel );
                cmd.Connection = conn;
                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }

                reader = cmd.ExecuteReader();
                if( reader.NextResult() )
                {
                    while( reader.Read() )
                    {
                        result = this.LoadFrom( reader );
                    }
                }
            }
            finally
            {
                base.Close( conn, cmd, reader );
            }

            return result;
        }

        protected virtual TMappedType Update( TMappedType aModel )
        {
            IDbConnection conn = this.Connection;
            IDbCommand cmd = null;
            TMappedType result = default( TMappedType );

            try
            {
                cmd = this.UpdateCommandFor( aModel );
                cmd.Connection = conn;
                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
                result = this.FindObjectWith( aModel.Key );
            }
            finally
            {
                base.Close( conn, cmd );
            }

            return result;
        }

        /// <summary>
        /// Finds all Persistent Models of the type specified in this Mapper's SelectAllCommand.
        /// </summary>
        /// <returns></returns>
        public virtual IList<TMappedType> FindAll()
        {
            IDbConnection conn = this.Connection;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<TMappedType> results = new List<TMappedType>();

            try
            {
                cmd = this.SelectAllCommand();
                cmd.Connection = conn;
                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }

                reader = cmd.ExecuteReader();
                while( reader.Read() )
                {
                    results.Add( this.LoadFrom( reader ) );
                }
            }
            finally
            {
                base.Close( conn, cmd, reader );
            }

            return results;
        }

        /// <summary>
        /// Finds all PersistentModels matching the supplied Query.  
        /// If there are no matches, an empty collection is returned.
        /// </summary>
        /// <param name="aQuery">A query.</param>
        /// <returns></returns>
        public virtual IList<TMappedType> FindObjectsMatching( Query aQuery )
        {
            IDbConnection conn = this.Connection;
            IDbCommand cmd = null;
            IDataReader reader = null;
            IList<TMappedType> results = new List<TMappedType>();

            try
            {
                cmd = this.SelectCommandFor( aQuery );
                cmd.Connection = conn;
                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }

                reader = cmd.ExecuteReader();
                while( reader.Read() )
                {
                    results.Add( this.LoadFrom( reader ) );
                }
            }
            finally
            {
                base.Close( conn, cmd, reader );
            }

            return results;
        }
        /// <summary>
        /// Find the Persistent Model with the supplied key in the persistence store
        /// if the Model exists.  If it does not exist, null is returned.
        /// </summary>
        /// <param name="aKey">A key.</param>
        /// <returns>PersistentModel for the supplied Key or null.</returns>
        public virtual TMappedType FindObjectWith( Key aKey )
        {
            IDbConnection conn = this.Connection;
            IDbCommand cmd = null;
            IDataReader reader = null;
            TMappedType result = default( TMappedType );

            try
            {
                cmd = this.SelectCommandFor( aKey );
                cmd.Connection = conn;

                if( conn.State != ConnectionState.Open )
                {
                    conn.Open();
                }

                reader = cmd.ExecuteReader();
                if( reader.Read() )
                {
                    result = this.LoadFrom( reader );
                }
            }
            finally
            {
                base.Close( conn, cmd, reader );
            }

            return result;
        }
        #endregion

        #region Properties
        #endregion

        #region Private Methods

        protected abstract IDbCommand DeleteCommandFor( TMappedType aModel );

        /// <summary>
        /// Used by the Exists( PersistentModel aModel ) Template Method to provide 
        /// the IDbCommand used to determine whether the PersistentModel 
        /// already exists in the database based on it's Key.
        /// </summary>
        /// <param name="aModel">A model.</param>
        /// <returns>An IDbCommand that will return a scalar value when 
        /// sent the message ExecuteScalar().  Typically a Command
        /// built from a "select count(*)..." type SQL statement.</returns>
        protected abstract IDbCommand ExistsCommandFor( TMappedType aModel );

        protected abstract IDbCommand InsertCommandFor( TMappedType aModel );

        /// <summary>
        /// Used by the "FindXXX" Template Methods to build the concrete instance of 
        /// the PersistentModel in the concrete implementation of this Mapper.
        /// </summary>
        /// <param name="reader">The reader containing results as specified in the SelectCommands.</param>
        /// <returns>A concrete derivative of PersistentModel populated from the IDataReader.</returns>
        protected abstract TMappedType LoadFrom( IDataReader reader );

        protected abstract IDbCommand SelectAllCommand();

        /// <summary>
        /// Used by the FindObjectWith( Key aKey ) Template Method.
        /// </summary>
        /// <param name="aKey">A key.</param>
        /// <returns>An IDbCommand which FindObjectWith aKey will use Execute a Reader against 
        /// and then Load the PersistentModel from that reader.</returns>
        protected abstract IDbCommand SelectCommandFor( Key aKey );

        protected abstract IDbCommand SelectCommandFor( Query aQuery );

        protected abstract IDbCommand SelectVersionCommandFor( TMappedType aModel );

        protected abstract IDbCommand UpdateCommandFor( TMappedType aModel );
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public TemplateMapper()
        {
        }

        public TemplateMapper( IAdoFactory adoFactory )
        {
            this.AdoFactory = adoFactory;
        }

        public TemplateMapper( IAdoFactory adoFactory, IDbConnection connection )
            : this( adoFactory )
        {
            this.Connection = connection;
        }

        public TemplateMapper( IAdoFactory adoFactory, IDbTransaction transAction )
            : this( adoFactory )
        {
            this.TransAction = transAction;
        }
        #endregion
    }
}
