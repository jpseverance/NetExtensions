using System;

using NUnit.Framework;

using NetExtensions.PersistenceFramework.TestObjects;

namespace NetExtensions.PersistenceFramework
{
#if DEBUG
    //TODO: Create XML summary comment for CriteriaTests
    [TestFixture()]
    public class CriteriaTests
    {
        #region Constants
        #endregion

        #region SetUp and TearDown CriteriaTests
        [SetUp()]
        public void SetUpCriteriaTests()
        {
        }

        [TearDown()]
        public void TearDownCriteriaTests()
        {
        }
        #endregion

        #region Test Methods
        [Test()]
        public void Factories()
        {
            Query aQuery = Query.For( typeof( Person ) );
            aQuery.Add( Criteria.Where( "FirstName", false, Operator.Equals, "Fred" ) );
            aQuery.Add( Criteria.Where( "LastName", false, Operator.Like, "Jon%" ) );
            string whereClause = aQuery.GenerateWhereClause();
            
            Console.WriteLine( whereClause );
            
            Assert.AreEqual(
                "FirstName = 'Fred' And LastName Like 'Jon%'",
                whereClause
                );
        }
        #endregion

        #region Support Methods
        #endregion

        #region Data Elements
        #endregion
    }
#endif
}
