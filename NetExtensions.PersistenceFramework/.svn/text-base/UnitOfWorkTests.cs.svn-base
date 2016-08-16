//using System;

//using NetExtensions.Models;
//using NetExtensions.PersistenceFramework.TestObjects;

//using NUnit.Framework;

//namespace NetExtensions.PersistenceFramework
//{
//#if DEBUG
//    //TODO: Create XML summary comment for UnitOfWorkTests
//    [TestFixture()]
//    public class UnitOfWorkTests
//    {
//        #region Constants
//        #endregion

//        #region SetUp and TearDown UnitOfWorkTests
//        [SetUp()]
//        public void SetUpUnitOfWorkTests()
//        {
//        }

//        [TearDown()]
//        public void TearDownUnitOfWorkTests()
//        {
//        }
//        #endregion

//        #region Test Methods
//        [Test()]
//        public void TestRegisterNew()
//        {
//            UnitOfWork work = new UnitOfWork();
            
//            work.RegisterNew( new Order() );
//            work.RegisterNew( new Order() );

//            Assert.AreEqual(
//                2,
//                work.NewObjects.Count
//                );
            
//            Order anOrder = new Order();
//            anOrder.Key = new Key( long.MaxValue );

//            work.RegisterNew( anOrder );
//            work.RegisterNew( anOrder );

//            Assert.AreEqual(
//                3,
//                work.NewObjects.Count
//                );

//            work.RegisterDeleted( anOrder );

//            Assert.AreEqual(
//                2,
//                work.NewObjects.Count
//                );

//            work.RegisterNew( anOrder );

//            Assert.AreEqual(
//                3,
//                work.NewObjects.Count
//                );
//        }
//        #endregion

//        #region Support Methods
//        #endregion

//        #region Data Elements
//        #endregion
//    }
//#endif
//}
