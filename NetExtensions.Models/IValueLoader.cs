using System;

namespace NetExtensions.Models
{
    public interface IValueLoader
    {
        #region Event Handlers
        #endregion

        #region Methods
        object Load();
        #endregion

        #region Properties
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        #endregion

        #region Data Elements
        #endregion

        #region Constants
        #endregion
    }

    public interface IValueLoader<TTypeToLoad>
    {
        TTypeToLoad Load();
    }
}
