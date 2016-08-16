using System;

namespace NetExtensions.Models
{
    [Serializable]
    public abstract class PersistentModel : AbstractModel, IPersistentObject
    {
        #region Event Handlers
        #endregion

        #region Methods
        public object GetKeyValueOrNullIfNew()
        {
            object result;
            object keyValue = this.Key.GetValue();
            
            if( this.Key.Equals( NEW_KEY ) )
            {
                result = DBNull.Value;
            }
            else
            {
                result = this.Key.GetValue();
            }

            return result;
        }
        #endregion

        #region Properties
        public Key Key
        {
            get
            {
                return i_Key;
            }
            set
            {
                i_Key = value;
            }
        }

        public object Version
        {
            get
            {
                return i_Version;
            }
            set
            {
                i_Version = value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public PersistentModel()
        {
            this.Key	    = NEW_KEY;
            this.Version    = NEW_VERSION;
        }

        public PersistentModel( Key key, object version )
        {
            this.Key	 = key;
            this.Version = version;
        }
        #endregion

        #region Data Elements
        private Key     i_Key;
        private object  i_Version;
        #endregion

        #region Constants
        public static readonly Key     NEW_KEY     = new Key( 0L );
        public static readonly object  NEW_VERSION	= 0L;
        #endregion
    }
}
