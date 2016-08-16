using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using NUnit.Framework;

namespace NetExtensions.Collections
{
#if DEBUG
	//TODO: Create XML summary comment for SequenceTests
	[TestFixture()]
	public class SequenceTests
	{
		#region Constants
		#endregion

		#region SetUp and TearDown SequenceTests
		[SetUp()]
		public void SetUpSequenceTests()
		{
            Sequence seq = new Sequence();
            seq.Add( 12 );
            seq.Add( 13 );
            seq.Add( 14 );
            seq.Add( 15 );
            seq.Add( 16 );

            this.TestSequence = seq;
		}

		[TearDown()]
		public void TearDownSequenceTests()
		{
		}
		#endregion

		#region Test Methods
        [Test()]
        public void TestSelect()
        {
            Sequence seq = this.TestSequence;

            Sequence results = seq.Select( new BooleanEvaluataion( this.IsMatching ) ) as Sequence;

            Assert.IsTrue( results.Count == 2 );

            results = seq.Select(
                delegate( object current )
                {
                    int i = (int)current;

                    if( i > 13 && i < 16 )
                    {
                        return true;
                    }
                    return false;
                } ) as Sequence;
            Assert.IsTrue( results.Count == 2 );
        }

        [Test()]
        public void TestReject()
        {
            Sequence seq = this.TestSequence;

            Sequence results = seq.Reject( new BooleanEvaluataion( this.IsMatching ) ) as Sequence;

            Assert.IsTrue( results.Count == 3 );
        }

        [Test()]
        public void TestCollect()
        {
            Sequence seq = this.TestSequence;

            Sequence results = seq.Collect( new Evaluation( this.MultiplyByTwo ) ) as Sequence;

            Assert.IsTrue( seq.Count == results.Count );
            Assert.IsTrue( (int)results[0] == 24 );
            Assert.IsTrue( (int)results[4] == 32 );
        }

        [Test()]
        public void TestDetect()
        {
            Sequence seq = this.TestSequence;

            int result = (int)seq.Detect( new BooleanEvaluataion( this.IsMatching ) );

            Assert.IsTrue( result == 14 );
        }

        [Test()]
        public void TestDo()
        {
            Sequence seq = this.TestSequence;

            seq.Do( new Block( this.MultiplyByTwo ) );

            String str = "From an anonymous method: {0}";
            seq.Do( delegate( object e ) { Console.WriteLine( str, e.ToString() ); } );

            Console.WriteLine( seq[0] );
        }

        [Test()]
        public void TestAsStream()
        {
            Stream result = this.TestSequence.AsStream();
            
            //Print the stream, for grins
            while( result.Position != result.Length )
            {
                Console.WriteLine( result.ReadByte() );
            }

            result.Position = 0L;

            AbstractCollection collection = new BinaryFormatter().Deserialize( result ) as AbstractCollection;

            for( int i = 0; i < collection.Count; i++ )
            {
                Assert.IsTrue( (int)collection[i] == (int)this.TestSequence[i] );
            }
        }
		#endregion

		#region Support Methods
        public bool IsMatching( AbstractCollection sender, object current )
        {
            int i = (int)current;

            if( i > 13 && i < 16 )
            {
                return true;
            }
            return false;
        }

        public object MultiplyByTwo( AbstractCollection sender, object numberToMultiply )
        {
            return (int)numberToMultiply * 2;
        }

        public void MultiplyByTwo( object numberToMultiply )
        {
            Console.WriteLine( (int)numberToMultiply * 2 );
        }

        public Sequence TestSequence
        {
            get
            {
                return this.i_TestSequence;
            }
            set
            {
                this.i_TestSequence = value;
            }
        }
		#endregion

		#region Data Elements
        private Sequence i_TestSequence = new Sequence();
		#endregion
	}
#endif
}
