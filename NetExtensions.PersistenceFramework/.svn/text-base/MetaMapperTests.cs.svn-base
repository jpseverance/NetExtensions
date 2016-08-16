//using System;
//using System.Collections;
//using System.Data.SqlClient;

//using NUnit.Framework;

//using NetExtensions.Models;

//using NetExtensions.PersistenceFramework.AdoFactories;
//using NetExtensions.PersistenceFramework.TestObjects;

//namespace NetExtensions.PersistenceFramework
//{
//#if DEBUG
//    [TestFixture()]
//    public class MetaMapperTests
//    {
//        #region Constants
//        #endregion

//        #region SetUp and TearDown MetaMapperTests
//        [SetUp()]
//        public void SetUpMetaMapperTests()
//        {
//        }

//        [TearDown()]
//        public void TearDownMetaMapperTests()
//        {
//        }
//        #endregion

//        #region Test Methods
//        [Test()]
//        public void FindWithKey()
//        {
//            DataMap map = new DataMap( typeof( Order ), "Orders" );
//            map.AddKeyField( "OrderID" );
//            map.AddColumnMap( "OrderDate", typeof( Order ).GetProperty( "OrderDate" ) );
//            map.AddColumnMap( "ShipName", typeof( Order ).GetProperty( "ShipName" ) );

//            MetaMapper mapper = new MetaMapper( new MsSqlFactory(), map );
//            Order anOrder = mapper.FindObjectWith( new Key( 10255 ) ) as Order;

//            Console.WriteLine( anOrder.OrderDate );
//            Console.WriteLine( anOrder.ShipName );

//            Assert.AreEqual(
//                "Richter Supermarkt",
//                anOrder.ShipName
//                );

//            Assert.AreEqual( 
//                10255,
//                anOrder.Key.GetLongValue()
//                );
//        }

//        [Test()]
//        public void FindMatchingAQuery()
//        {
//            DataMap map = new DataMap( typeof( Order ), "Orders" );
//            map.AddKeyField( "OrderID" );
//            map.AddColumnMap( "OrderDate", typeof( Order ).GetProperty( "OrderDate" ) );
//            map.AddColumnMap( "ShipName", typeof( Order ).GetProperty( "ShipName" ) );
            
//            Query aQuery = new Query( typeof( Order ) );
//            aQuery.Add( Criteria.Where( "CustomerID", false, Operator.Equals, "HANAR" ) );

//            MetaMapper mapper = new MetaMapper( new MsSqlFactory(), map );
//            ArrayList orders = mapper.FindObjectsMatching( aQuery );

//            Assert.IsTrue( orders.Count == 14 );

//            Order anOrder = orders[0] as Order;

//            Assert.AreEqual(
//                "Hanari Carnes",
//                anOrder.ShipName
//                );

//            Assert.AreEqual(
//                10250,
//                anOrder.Key.GetLongValue()
//                );
//        }

//        [Test()]
//        public void SaveAnOrder()
//        {

//        }


//        #endregion

//        #region Support Methods
//        #endregion

//        #region Data Elements
//        #endregion
//    }
//#endif
//}
