using System;
using System.Collections;

namespace NetExtensions.Collections
{
	/// <summary>
	/// An OrderedSet is a set whose elements are ordered.
	/// </summary>
	[Serializable]
	public class OrderedSet : AbstractCollection
	{
		#region Event Handlers
		#endregion

		#region Methods
		#endregion

		#region Properties
		#endregion

		#region Private Methods
		#endregion

		#region Private Properties
		#endregion

		#region Construction and Finalization
		public OrderedSet( ICollection c ) : base( c )
		{
		}

		public OrderedSet( int capacity ) : base( capacity )
		{
		}

		public OrderedSet() : base()
		{
		}
		#endregion

		#region Data Elements
		#endregion

		#region Constants
		#endregion
	}
}
