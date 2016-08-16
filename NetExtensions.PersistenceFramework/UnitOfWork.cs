//using System;
//using System.Collections;

//using NetExtensions.Models;

//namespace NetExtensions.PersistenceFramework
//{
//    [Serializable]
//    public class UnitOfWork : object
//    {
//        #region Event Handlers
//        #endregion

//        #region Methods
//        public virtual void Commit()
//        {

//        }

//        public PersistentModel FindMatching( Query aQuery )
//        {
//            return null;
//        }

//        public PersistentModel FindWith( Type typeOfObject, Key aKey )
//        {
//            return null;
//        }

//        public virtual void RegisterNew( PersistentModel model )
//        {
//            this.EnsureNotNull( model );

//            this.i_deletedObjects.Remove( model );
//            this.i_dirtyObjects.Remove( model );
//            this.i_newObjects[model] = model;
//        }

//        public virtual void RegisterDirty( PersistentModel model )
//        {
//            this.EnsureNotNull( model );

//            if( model.Key == PersistentModel.NEW_KEY )
//            {
//                this.RegisterNew( model );
//                return;
//            }

//            this.i_deletedObjects.Remove( model );
//            this.i_newObjects[model] = model;
//        }

//        public virtual void RegisterDeleted( PersistentModel model )
//        {
//            this.EnsureNotNull( model );

//            this.i_newObjects.Remove( model );
//            this.i_dirtyObjects.Remove( model );

//            this.i_deletedObjects[model] = model;
//        }
//        #endregion

//        #region Properties
//        public ICollection NewObjects
//        {
//            get
//            {
//                return this.CollectionFrom( this.i_newObjects );
//            }
//        }

//        public ICollection DirtyObjects
//        {
//            get
//            {
//                return this.CollectionFrom( this.i_dirtyObjects );
//            }
//        }

//        public ICollection DeletedObjects
//        {
//            get
//            {
//                return this.CollectionFrom( this.i_deletedObjects );
//            }
//        }
//        #endregion

//        #region Private Methods
//        private ICollection CollectionFrom( Hashtable aHashtable )
//        {
//            ArrayList results = new ArrayList();
//            foreach( DictionaryEntry entry in aHashtable )
//            {
//                results.Add( entry.Value );
//            }

//            return (ICollection)results;
//        }

//        private void EnsureNotNull( PersistentModel model )
//        {
//            if( model == null )
//            {
//                throw new ArgumentNullException( "model", "model cannot be null" );
//            }
//        }
//        #endregion

//        #region Private Properties
//        #endregion

//        #region Construction and Finalization
//        public UnitOfWork()
//        {
//        }
//        #endregion

//        #region Data Elements
//        private Hashtable i_newObjects      = new Hashtable();
//        private Hashtable i_dirtyObjects    = new Hashtable();
//        private Hashtable i_deletedObjects  = new Hashtable();
//        #endregion

//        #region Constants
//        #endregion
//    }
//}
