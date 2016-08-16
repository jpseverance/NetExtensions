//using System;
//using System.Data;
//using System.Text;

//using NetExtensions.PersistenceFramework.AdoFactories;
//using NetExtensions.Models;

//namespace NetExtensions.PersistenceFramework.TestObjects
//{
//    [Serializable]
//    public class OrderItemMapper : TemplateMapper
//    {
//        #region Event Handlers
//        #endregion

//        #region Methods
//        #endregion

//        #region Properties
//        #endregion

//        #region Private Methods
//        protected override PersistentModel LoadFrom( IDataReader reader )
//        {
//            OrderItem item = new OrderItem();
//            item.Key                = new Key( reader["OrderID"], reader["ProductID"] );
//            item.Discount           = (float)reader["Discount"];
//            item.QuantityPurchased  = (short)reader["Quantity"];

//            return item;
//        }

//        protected override IDbCommand ExistsCommandFor( PersistentModel aModel )
//        {
//            return null;
//        }

//        protected override IDbCommand SelectCommandFor( Key aKey )
//        {
//            return null;
//        }

//        protected override IDbCommand SelectCommandFor( Query aQuery )
//        {
//            StringBuilder builder = new StringBuilder();
//            builder.Append( "select * from [Order Details] where " );
//            builder.Append( aQuery.GenerateWhereClause() );
//            builder.Append( " order by OrderID, ProductID" );
            
//            IDbCommand cmd = AdoFactory.CreateCommand();
//            cmd.CommandText = builder.ToString();

//            return cmd;
//        }

//        protected override IDbCommand SelectAllCommand()
//        {
//            return null;
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
//        #endregion

//        #region Construction and Finalization
//        public OrderItemMapper()
//        {
//        }

//        public OrderItemMapper( IAdoFactory adoFactory ) : base( adoFactory )
//        {
//        }
//        #endregion

//        #region Data Elements
//        #endregion

//        #region Constants
//        #endregion
//    }
//}
