using System;

namespace NetExtensions.Collections
{
    [Serializable]
    public class ObjectAddedEventArgs : EventArgs
    {
        #region Event Handlers
        #endregion

        #region Methods
        #endregion

        #region Properties
        public object AddedObject
        {
            get
            {
                return i_AddedObject;
            }
            set
            {
                i_AddedObject = value;
            }
        }

        public int AddedAtIndex
        {
            get
            {
                return i_AddedAtIndex;
            }
            set
            {
                i_AddedAtIndex = value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public ObjectAddedEventArgs( object addedObject, int index )
        {
            this.AddedObject    = addedObject;
            this.AddedAtIndex   = index;
        }
        #endregion

        #region Data Elements
        private object i_AddedObject;
        private int i_AddedAtIndex;
        #endregion

        #region Constants
        #endregion
    }
}
