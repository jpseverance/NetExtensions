//using System;
//using System.Configuration;

//namespace NetExtensions.PersistenceFramework
//{
//    [Serializable]
//    public class MapperFactory : object
//    {
//        #region Event Handlers
//        #endregion

//        #region Methods
//        public static AbstractMapper MapperFor( Type aDomainObject )
//        {
//            string mapper = ConfigurationManager.AppSettings[aDomainObject.ToString()];
//            return Activator.CreateInstance( Type.GetType( mapper ) ) as AbstractMapper;
//        }
//        #endregion

//        #region Properties
//        #endregion

//        #region Private Methods
//        #endregion

//        #region Private Properties
//        #endregion

//        #region Construction and Finalization
//        public MapperFactory()
//        {
//        }
//        #endregion

//        #region Data Elements
//        #endregion

//        #region Constants
//        #endregion
//    }
//}
