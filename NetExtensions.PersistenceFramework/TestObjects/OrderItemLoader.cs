//using System;

//using NetExtensions.PersistenceFramework.AdoFactories;
//using NetExtensions.Models;

//namespace NetExtensions.PersistenceFramework.TestObjects
//{
////TODO: Create XML summary comment for OrderItemLoader
//    [Serializable]
//    public class OrderItemLoader : IValueLoader
//    {
//        #region Event Handlers
//        #endregion

//        #region Methods
//        public object Load()
//        {
//            OrderItemMapper mapper = new OrderItemMapper( new MsSqlFactory() );
//            Query q = new Query( typeof( OrderItem ) );
//            q.Add( Criteria.Where( "OrderID", true, Operator.Equals, this.i_OrderKey.GetValue() ) );
            
//            return mapper.FindObjectsMatching( q );
//        }
//        #endregion

//        #region Properties
//        #endregion

//        #region Private Methods
//        #endregion

//        #region Private Properties
//        #endregion

//        #region Construction and Finalization
//        public OrderItemLoader( Key keyForAnOrder )
//        {
//            this.i_OrderKey = keyForAnOrder;
//        }
//        #endregion

//        #region Data Elements
//        Key i_OrderKey;
//        #endregion

//        #region Constants
//        #endregion
//    }
//}
