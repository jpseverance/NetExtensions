using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetExtensions.Models
{
	[Serializable]
	public abstract class AbstractModel : object
	{
		#region Events
		public event ModelChangedEventHandler ModelChanged
		{
			add
			{
				this._modelChanged += value;
			}
			remove
			{
				this._modelChanged -= value;
			}
		}
		#endregion

		#region Event Handlers
		#endregion

		#region Methods
        public virtual AbstractModel DeepCopy()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize( stream, this );

            stream.Position = 0;
            AbstractModel result = formatter.Deserialize( stream ) as AbstractModel;
            
            stream.Close();
            
            return result;
        }

		public virtual void NotifyListeners()
		{
            this.NotifyListenersWith( new NullModelChangedArgs() );
		}
		#endregion

		#region Properties
		#endregion

		#region Private Methods
        protected void NotifyListenersWith( ModelChangedArgs args )
        {
            if( this._modelChanged != null )
            {
                this._modelChanged( this, args );
            }
        }
		#endregion

		#region Private Properties
		#endregion

		#region Construction and Finalization
		public AbstractModel()
		{
		}
		#endregion

		#region Data Elements
		private event ModelChangedEventHandler _modelChanged;
		#endregion

		#region Constants
		#endregion
	}
}
