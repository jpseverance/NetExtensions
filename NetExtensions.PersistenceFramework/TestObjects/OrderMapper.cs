//using System;
//using System.Collections;
//using System.Data;

//using NetExtensions.PersistenceFramework.AdoFactories;
//using NetExtensions.Models;

//namespace NetExtensions.PersistenceFramework.TestObjects
//{
//    [Serializable]
//    public class OrderMapper : TemplateMapper
//    {
//        #region Event Handlers
//        #endregion

//        #region Methods
//        public ArrayList FindOrdersFor( Customer aCustomer )
//        {
//            Query q = Query.For( typeof( Order ) );
//            q.Add( Criteria.Where( "CustomerID", false, Operator.Equals, aCustomer.Key.GetValue() ) );

//            return this.FindObjectsMatching( q );
//        }

//        public ArrayList BuildOrdersFrom( IDataReader reader )
//        {
//            ArrayList results = new ArrayList();
//            while( reader.Read() )
//            {
//                results.Add( this.LoadFrom( reader ) );
//            }

//            return results;
//        }
//        #endregion

//        #region Properties
//        #endregion

//        #region Private Methods
//        protected override PersistentModel LoadFrom( System.Data.IDataReader reader )
//        {
//            Order anOrder       = new Order();
//            anOrder.Key         = new Key( reader["OrderID"] );
//            anOrder.OrderDate   = DateTime.Parse( reader["OrderDate"].ToString() );
//            anOrder.OrderId     = (int)reader["OrderID"];
//            anOrder.ShipName    = reader["ShipName"].ToString();
//            anOrder.OrderItemsHolder = new ValueHolder( new OrderItemLoader( anOrder.Key ) );

//            return anOrder;
//        }

//        protected override IDbCommand ExistsCommandFor( PersistentModel aModel )
//        {
//            return null;
//        }


//        protected override System.Data.IDbCommand SelectCommandFor( Key aKey )
//        {
//            String sql = String.Format( "select * from Orders where OrderID = {0} order by OrderID", aKey.GetValue() );
            
//            IDbCommand cmd = AdoFactory.CreateCommand();
//            cmd.CommandText = sql;

//            return cmd;
//        }

//        protected override System.Data.IDbCommand SelectCommandFor( Query aQuery )
//        {
//            if( aQuery.Type != typeof( Order ) )
//            {
//                throw new ArgumentException( 
//                    String.Format( 
//                        "CustomerMapper's SelectCommandFor aQuery expect's the query's Type to be of Order, but it was of type {0}.", aQuery.Type.ToString() 
//                        )
//                    );
//            }
            
//            IDbCommand cmd = this.AdoFactory.CreateCommand();
//            string sql = "select * from Orders where " + aQuery.GenerateWhereClause() + " order by OrderID";
//            cmd.CommandText = sql;

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
//        public OrderMapper( IAdoFactory adoFactory ) : base( adoFactory )
//        {
//        }
//        #endregion

//        #region Data Elements
//        #endregion

//        #region Constants
//        #endregion
//    }
//}
