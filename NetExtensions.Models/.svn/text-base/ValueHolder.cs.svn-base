using System;

namespace NetExtensions.Models
{
    [Serializable()]
    public class ValueHolder<TTypeToLazyLoad> : Object
    {
        #region Event Handlers
        #endregion

        #region Methods
        public void Clear()
        {
            this._value = default( TTypeToLazyLoad );
        }
        #endregion

        #region Properties
        public TTypeToLazyLoad Value
        {
            get
            {
                if( this._value == null )
                {
                    if( this._doLoadDelegate != null )
                    {
                        this._value = _doLoadDelegate();
                    }
                    else if( this._loader != null )
                    {
                        this._value = _loader.Load();
                    }
                    else
                    {
                        throw new InvalidOperationException( INVALID_STATE_EXCEPTION );
                    }                    
                }
                return _value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public ValueHolder( DoLoad<TTypeToLazyLoad> loader )
        {
            this._doLoadDelegate = loader;
        }

        public ValueHolder( IValueLoader<TTypeToLazyLoad> loader )
        {
            this._loader = loader;
        }
        #endregion

        #region Data Elements
        IValueLoader<TTypeToLazyLoad> _loader;
        private DoLoad<TTypeToLazyLoad> _doLoadDelegate;
        private TTypeToLazyLoad _value = default( TTypeToLazyLoad );
        #endregion

        #region Constants
        private const string INVALID_STATE_EXCEPTION = "This ValueHolder must have either a DoLoad delegate or an implementation of IValueLoader, neither of these were found.";
        #endregion
    }

    [Serializable()]
    public class ValueHolder : object
    {
        #region Event Handlers
        #endregion

        #region Methods
        public object GetValue()
        {
            if( this.i_Value == null )
            {
                this.i_Value = this.i_Loader.Load();
            }

            return this.i_Value;
        }
        #endregion

        #region Properties
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public ValueHolder( IValueLoader loader )
        {
            this.i_Loader = loader;
        }
        #endregion

        #region Data Elements
        private IValueLoader i_Loader;
        private object i_Value;
        #endregion

        #region Constants
        #endregion
    }
}
