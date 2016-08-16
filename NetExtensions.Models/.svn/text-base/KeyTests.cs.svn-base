using System;
using NUnit.Framework;

namespace NetExtensions.Models
{
#if DEBUG
    //TODO: Create XML summary comment for KeyTests
    [TestFixture()]
    public class KeyTests
    {
        #region Constants
        #endregion

        #region SetUp and TearDown KeyTests
        [SetUp()]
        public void SetUpKeyTests()
        {
        }

        [TearDown()]
        public void TearDownKeyTests()
        {
        }
        #endregion

        #region Test Methods
        [Test()]
        public void TestConstructors()
        {
            Key key = new Key( 12L );
            string msg = "Key should be 12L";
            
            Assert.AreEqual( 12L, key.GetLongValue(), msg );
            Assert.AreEqual( 12L, key.GetLongValueAt( 0 ), msg );
            Assert.AreEqual( 12L, (long)key.GetValue(), msg );
            Assert.AreEqual( 12L, (long)key.GetValueAt( 0 ), msg );

            key = new Key( "asdf" );
            Assert.AreEqual( "asdf", key.GetValue().ToString() );
            Assert.AreEqual( "asdf", key.GetValueAt( 0 ).ToString() );

            object[] args = new object[4] { 1, "2", "foo", 4 };
            key = new Key( args );
            Assert.AreEqual( 1L, key.GetLongValueAt( 0 ) );
            Assert.AreEqual( 1, key[0] );
            Assert.AreEqual( 2L, key.GetLongValueAt( 1 ) );
            Assert.AreEqual( 1, (int)key.GetValueAt( 0 ) );
            Assert.AreEqual( "2", key[1] );
            Assert.AreEqual( "2", key.GetValueAt( 1 ) );
            Assert.AreEqual( "foo", key.GetValueAt( 2 ) );
            Assert.AreEqual( "foo", key[2] );
        }

        [Test()]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestNullObjectException()
        {
            Key key = new Key( null );
        }

        [Test()]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestMutliArgNullException1()
        {
            Key key = new Key( 1, null );
        }

        [Test()]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestMutliArgNullException2()
        {
            Key key = new Key( null, 1 );
        }

        [Test()]
        [ExpectedException( typeof( ArgumentNullException ) )]
        public void TestObjectArrayNullException()
        {
            object[] nullObjects = null;
            Key key = new Key( nullObjects );
        }

        [Test()]
        [ExpectedException( typeof( InvalidOperationException ) )]
        public void TestGetValueWithMoreThanOneValue()
        {
            object[] args = new object[4] { 1, 2, 3, 4 };
            Key key = new Key( args );
            Assert.AreEqual( 1, key.GetValue() );
        }
        #endregion

        #region Support Methods
        #endregion

        #region Data Elements
        #endregion
    }
#endif
}
