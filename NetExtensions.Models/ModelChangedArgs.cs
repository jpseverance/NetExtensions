using System;

namespace NetExtensions.Models
{
	[Serializable]
	public class ModelChangedArgs : EventArgs
	{
		#region Event Handlers
		#endregion

		#region Methods
		#endregion

		#region Properties
		public string ModifiedMember
		{
			get
			{
				return _modifiedMember;
			}
			set
			{
				_modifiedMember = value;
			}
		}

		public object OldValue
		{
			get
			{
				return _oldValue;
			}
			set
			{
				_oldValue = value;
			}
		}

		public object NewValue
		{
			get
			{
				return _newValue;
			}
			set
			{
				_newValue = value;
			}
		}
		#endregion

		#region Private Methods
		#endregion

		#region Private Properties
		#endregion

		#region Construction and Finalization
		public ModelChangedArgs()
		{
		}

		public ModelChangedArgs( string modifiedMember, object oldValue, object newValue )
		{
			this.ModifiedMember = modifiedMember;
			this.OldValue		= oldValue;
			this.NewValue		= newValue;
		}
		#endregion

		#region Data Elements
		private string _modifiedMember;
		private object _oldValue;
		private object _newValue;
		#endregion

		#region Constants
		#endregion
	}
}
