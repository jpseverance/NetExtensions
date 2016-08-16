using System;
using System.Reflection;

using NetExtensions.PersistenceFramework.TestObjects;

using NUnit.Framework;

namespace NetExtensions.PersistenceFramework
{
#if DEBUG
    [TestFixture()]
    public class DataMapTests
    {
        #region Constants
        #endregion

        #region SetUp and TearDown DataMapTests
        [SetUp()]
        public void SetUpDataMapTests()
        {
        }

        [TearDown()]
        public void TearDownDataMapTests()
        {
        }
        #endregion

        #region Test Methods
        [Test()]
        public void TestColumMapping()
        {
            Type orderType = typeof( Order );
            DataMap map = new DataMap( orderType, "People" );
            map.AddColumnMap( "OrderId", orderType.GetProperty( "OrderId" ) );
            map.AddColumnMap( "OrderDate", orderType.GetProperty( "OrderDate" ) );

            Assert.AreEqual( "OrderId, OrderDate", map.GetColumnList() );
        }
        #endregion

        #region Support Methods
        #endregion

        #region Data Elements
        #endregion
    }
#endif
}
