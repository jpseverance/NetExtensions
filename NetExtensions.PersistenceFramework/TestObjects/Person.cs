using System;
using NetExtensions.Models;

namespace NetExtensions.PersistenceFramework.TestObjects
{
//TODO: Create XML summary comment for Person
    [Serializable]
    public class Person : object
    {
        #region Event Handlers
        #endregion

        #region Methods
        #endregion

        #region Properties
        public string FirstName
        {
            get
            {
                return i_FirstName;
            }
            set
            {
                i_FirstName = value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public Person()
        {
        }
        #endregion

        #region Data Elements
        private string i_FirstName;
        #endregion

        #region Constants
        #endregion
    }
}
