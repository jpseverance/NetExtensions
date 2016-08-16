using System;

using NUnit.Framework;

namespace NetExtensions.Collections
{
#if DEBUG
	//TODO: Create XML summary comment for BagTests
	[TestFixture()]
	public class BagTests
	{
		#region Constants
		#endregion

		#region SetUp and TearDown BagTests
		[SetUp()]
		public void SetUpBagTests()
		{
			TestBag = new Bag();
		}

		[TearDown()]
		public void TearDownBagTests()
		{
		}
		#endregion

		#region Test Methods
		//TODO: Create XML comments for AddMultiple
		[Test()]
		public void AddMultiple()
		{
			Assert.IsNotNull( TestBag );

			Object sample = new Object();
			TestBag.Add( sample );
			TestBag.Add( sample );
			TestBag.Add( sample );
			TestBag.Add( sample );
			TestBag.Add( sample );

			Assert.IsTrue( TestBag.NotEmpty() );
			Assert.IsFalse( TestBag.IsEmpty() );
			Assert.IsTrue( TestBag.Count == 5 );
		}
		#endregion

		#region Support Methods
		private Bag TestBag
		{
			get
			{
				return i_TestBag;
			}
			set
			{
				i_TestBag = value;
			}
		}
		#endregion

		#region Data Elements
		private Bag i_TestBag;
		#endregion
	}
#endif
}
