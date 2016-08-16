//using System;
//using System.Collections;

//using NUnit.Framework;

//using NetExtensions.PersistenceFramework;
//using NetExtensions.PersistenceFramework.AdoFactories;

//using NetExtensions.Models;

//namespace NetExtensions.PersistenceFramework.TestObjects
//{
//#if DEBUG
//    [TestFixture()]
//    public class CustomerMapperTests
//    {
//        #region Constants
//        #endregion

//        #region SetUp and TearDown PersonMapperTests
//        [SetUp()]
//        public void SetUpCustomerMapperTests()
//        {
//        }

//        [TearDown()]
//        public void TearDownCustomerMapperTests()
//        {
//        }
//        #endregion

//        #region Test Methods
//        [Test()]
//        public void TestFindCustomerWithAKey()
//        {
//            CustomerMapper mapper = new CustomerMapper( new MsSqlFactory() );
//            Customer aCustomer = (Customer)mapper.FindObjectWith( new Key( "BONAP" ) );

//            Assert.IsNotNull( aCustomer );

//            Assert.AreEqual(
//                "Bon app'",
//                aCustomer.CompanyName
//                );

//            Assert.AreEqual(
//                "Laurence Lebihan",
//                aCustomer.ContactName
//                );

//            Assert.IsTrue( aCustomer.Orders.Count == 17 );
//        }

//        [Test()]
//        public void TestFindCustomerMatchingAQuery()
//        {
//            try
//            {
//                Query q = new Query( typeof( Customer ) );
//                q.Add( Criteria.Where( "CustomerID", false, Operator.Equals, "BONAP" ) );
            
//                CustomerMapper mapper = new CustomerMapper( new MsSqlFactory() );
//                Customer aCustomer = mapper.FindObjectsMatching( q )[0] as Customer;

//                Assert.IsNotNull( aCustomer, "aCustomer was Null" );

//                Assert.AreEqual(
//                    String.Format( "Company's name is {0}, expected {1}", aCustomer.CompanyName, "Bon app'" ),
//                    "Bon app'",
//                    aCustomer.CompanyName
//                    );

//                Assert.AreEqual(
//                    String.Format( "Contact's name is {0}, epxected {1}", aCustomer.ContactName, "Laurence Lebihan" ),
//                    "Laurence Lebihan",
//                    aCustomer.ContactName
//                    );

//                Assert.IsTrue( 
//                    aCustomer.Orders.Count == 17,
//                    "Expected aCustomer.Orders.Count to be 17"
//                    );

//                ArrayList orders = new ArrayList( aCustomer.Orders );
               
//                Console.WriteLine( ((Order)orders[1]).Key.GetValue() );
//                Assert.IsTrue(
//                    ((Order)orders[1]).OrderItems.Count > 1,
//                    String.Format( "Expected there to be more than 1 order items for Order {0}, but there were {1}", ((Order)orders[1]).Key.GetValue(), ((Order)orders[1]).OrderItems.Count )
//                    );
//            }
//            catch( Exception e )
//            {
//                Console.WriteLine( "Message: {0} ", e.Message );
//                Console.WriteLine( "Source: {0}", e.Source );
//                Console.WriteLine( "TargetSite: {0}", e.TargetSite );
//                Console.WriteLine( "StackTrace: {0}", e.StackTrace );
//                Console.WriteLine( "InnerException: {0}", e.InnerException );
//                throw;
//            }
//        }

//        [Test()]
//        public void SaveNewCustomer()
//        {
//            Customer newCustomer = new Customer();
//            newCustomer.Key         = new Key( "FRED" );
//            newCustomer.CompanyName = "Fred's Fish Head";
//            newCustomer.ContactName = "Fred Fishmonger";

//            CustomerMapper mapper = new CustomerMapper( new MsSqlFactory() );
//            mapper.Save( newCustomer );

            
//        }
//        #endregion

//        #region Support Methods
//        #endregion

//        #region Data Elements
//        #endregion
//    }
//#endif
//}
