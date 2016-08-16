using System;
using System.Collections.Generic;
using System.Text;

using NetExtensions.Models;

namespace NetExtensions.PersistenceFramework
{
    public class StaleObjectException : ApplicationException
    {
        public PersistentModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public StaleObjectException( PersistentModel staleModel )
            : base( String.Format( STALE_OBJECT_MESSAGE, staleModel.GetType().ToString() ) )
        {
            this.Model = staleModel;
        }

        private PersistentModel _model;
        private const string STALE_OBJECT_MESSAGE = "{0} has been updated in the database since it was previously read into this instance.";
    }
}
