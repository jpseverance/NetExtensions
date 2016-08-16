using System;
using System.Collections;

namespace NetExtensions.Collections
{
	/// <summary>
	/// A Set is a collection of objects of any type.  A set does not contain
	/// duplicate elements; any instance can be present only once.  
	/// Elements in a set are not ordered.
	/// </summary>
	[Serializable]
	public class Set : AbstractCollection
	{
		#region Event Handlers
		#endregion

		#region Methods
		/// <summary>
		/// Adds the object to the collection.  If the object already
		/// exists in the collection then the object will not be added
		/// again and Int32.MinValue will be returned.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override int Add( object value )
		{
			if( base.Excludes( value ) )
			{
				return base.Add( value );
			}
			return Int32.MinValue;
		}
	
		public override object this[int index]
		{
			get
			{
				return base[index];
			}
			set
			{
				if( base.Excludes( value ) )
				{
					base[index] = value;
				}
			}
		}
	
		/// <summary>
		/// Inserts an object at the given index if the object does
		/// not already exist in the collection.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public override void Insert( int index, object value )
		{
			if( base.Excludes( value ) )
			{
				base.Insert( index, value );
			}
		}
		#endregion

		#region Properties
		#endregion

		#region Private Methods
		#endregion

		#region Private Properties
		#endregion

		#region Construction and Finalization
		public Set( ICollection c )
		{
			foreach( object o in c )
			{
				if( base.Excludes( o ) )
				{
					base.Add( o );
				}
			}
		}

		public Set( int capacity ) : base( capacity )
		{
		}

		public Set() : base()
		{
		}
		#endregion

		#region Data Elements
		#endregion

		#region Constants
		#endregion
	}
}
