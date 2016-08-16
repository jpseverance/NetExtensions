using System;
using System.Collections;

using NUnit.Framework;

namespace NetExtensions.Collections
{
#if DEBUG
	//TODO: Create XML summary comment for SetTests
	[TestFixture()]
	public class SetTests
	{
		#region Constants
		#endregion

		#region SetUp and TearDown SetTests
		[SetUp()]
		public void SetUpSetTests()
		{
			TestSet = new Set();
		}

		[TearDown()]
		public void TearDownSetTests()
		{
		}
		#endregion

		#region Test Methods
		//TODO: Create XML comments for Constructors
		[Test()]
		public void Constructors()
		{
			ArrayList list = new ArrayList();
			Object sample = new Object();
			list.Add( sample );
			list.Add( sample );
			list.Add( sample );
			list.Add( sample );
			list.Add( sample );

			Set aSet = new Set( list );

			Assert.IsTrue( aSet.NotEmpty() );
			Assert.IsFalse( aSet.IsEmpty() );
			Assert.IsTrue( aSet.Count == 1 );
		}

		//TODO: Create XML comments for Add
		[Test()]
		public void Add()
		{
			Assert.IsNotNull( TestSet );

			Object sample = new Object();
			TestSet.Add( sample );
			TestSet.Add( sample );
			TestSet.Add( sample );
			TestSet.Add( sample );
			TestSet.Add( sample );

			Assert.IsTrue( TestSet.NotEmpty() );
			Assert.IsFalse( TestSet.IsEmpty() );
			Assert.IsTrue( TestSet.Count == 1 );

			Object foo = new Object();

			TestSet.Add( foo );
			Assert.IsTrue( TestSet.Count == 2 );
		}

		//TODO: Create XML comments for TestAddMultiple
		[Test()]
		public void AddMultiple()
		{
			Assert.IsNotNull( TestSet );

			Object sample = new Object();
			TestSet.Add( sample );
			TestSet.Add( sample );
			TestSet.Add( sample );
			TestSet.Add( sample );
			TestSet.Add( sample );

			Assert.IsTrue( TestSet.NotEmpty() );
			Assert.IsFalse( TestSet.IsEmpty() );
			Assert.IsTrue( TestSet.Count == 1 );
		}
		#endregion

		#region Support Methods
		public Set TestSet
		{
			get
			{
				return i_TestSet;
			}
			set
			{
				i_TestSet = value;
			}
		}
		#endregion

		#region Data Elements
		private Set i_TestSet;
		#endregion
	}
#endif
}
