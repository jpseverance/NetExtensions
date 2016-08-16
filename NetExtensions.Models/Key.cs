using System;

namespace NetExtensions.Models
{
    [Serializable]
    public class Key : object
    {
        #region Event Handlers
        #endregion

        #region Methods
        public object this[int index]
        {
            get
            {
                return this.i_values[index];
            }
        }

        public object GetValue()
        {
            this.AssertSingleKey();
            return this.i_values[0];
        }

        public object GetValueAt( int index )
        {
            return this.i_values[index];
        }

        public long GetLongValue()
        {
            this.AssertSingleKey();
            return this.GetLongValueAt( 0 );
        }

        public long GetLongValueAt( int index )
        {
            try
            {
                return Convert.ToInt64( this.i_values[index] );
            }
            catch( Exception e )
            {
                throw new InvalidOperationException( 
                    String.Format( "Cannot convert value at index of {0} to System.Type {1}", index, typeof(long) ),
                    e
                    );
            }            
        }
        #endregion

        #region Properties
        #endregion

        #region Private Methods
        private void AssertSingleKey()
        {
            if( this.i_values.Length > 1 )
            {
                throw new InvalidOperationException( "Key contains more than one value" );
            }
        }
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public Key( long oid )
        {
            this.i_values = new Object[1];
            this.i_values[0] = oid;
        }

        public Key( object value )
        {
            if( value == null )
            {
                throw new ArgumentNullException( "field", "Cannot have a null key" );
            }
            this.i_values = new Object[1];
            this.i_values[0] = value;
        }

        public Key( object arg1, object arg2 )
        {
            if( arg1 == null )
            {
                throw new ArgumentNullException( "arg1", "Cannot have a null key" );
            }

            if( arg2 == null )
            {
                throw new ArgumentNullException( "arg2", "Cannot have a null key" );
            }

            this.i_values = new Object[2];
            this.i_values[0] = arg1;
            this.i_values[1] = arg2;
        }

        public Key( object[] args )
        {
            if( args == null )
            {
                throw new ArgumentNullException( "args", "Cannot have a null key" );
            }

            this.i_values = args;
        }
        #endregion

        #region Data Elements
        private object[] i_values;
        #endregion

        #region Constants
        #endregion
    }
}
