using System;

namespace NetExtensions.Models
{
    [Serializable]
    public struct PersistentValue : IPersistentObject
    {
        #region Event Handlers
        #endregion

        #region Methods
        #endregion

        #region Properties
        public Key Key
        {
            get
            {
                return this.i_Key;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public PersistentValue( Key key )
        {
            this.i_Key = key;
        }
        #endregion

        #region Data Elements
        private Key i_Key;
        #endregion

        #region Constants
        #endregion
    }
}
