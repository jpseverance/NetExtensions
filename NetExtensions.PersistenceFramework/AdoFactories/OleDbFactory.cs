using System;
using System.Data;
using System.Data.OleDb;

namespace NetExtensions.PersistenceFramework.AdoFactories
{
    [Serializable]
    public class OleDbFactory : IAdoFactory
    {
        #region Event Handlers
        #endregion

        #region Methods
        public System.Data.IDbConnection CreateConnection()
        {
            return new OleDbConnection();
        }

        public System.Data.IDbCommand CreateCommand()
        {
            return new OleDbCommand();
        }
        #endregion

        #region Properties
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public OleDbFactory()
        {
        }
        #endregion

        #region Data Elements
        #endregion

        #region Constants
        #endregion
    }
}
