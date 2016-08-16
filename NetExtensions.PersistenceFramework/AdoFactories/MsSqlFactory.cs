using System;
using System.Data;
using System.Data.SqlClient;

namespace NetExtensions.PersistenceFramework.AdoFactories
{
    [Serializable]
    public class MsSqlFactory : IAdoFactory
    {
        #region Event Handlers
        #endregion

        #region Methods
        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }
        #endregion

        #region Properties
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public MsSqlFactory()
        {
        }
        #endregion

        #region Data Elements
        #endregion

        #region Constants
        #endregion
    }
}
