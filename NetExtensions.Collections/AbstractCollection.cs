using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace NetExtensions.Collections
{
    [Serializable]
    public abstract class AbstractCollection : Object, ICollection, IEnumerable, IList
    {
        #region Events
        public event EventHandler AddingObject
        {
            add
            {
                this.i_AddingObject += value;
            }
            remove
            {
                this.i_AddingObject -= value;
            }
        }

        public event EventHandler ObjectAdded
        {
            add
            {
                this.i_ObjectAdded += value;
            }
            remove
            {
                this.i_ObjectAdded -= value;
            }
        }

        public event EventHandler RemovingObject
        {
            add
            {
                this.i_RemovingObject += value;
            }
            remove
            {
                this.i_RemovingObject -= value;
            }
        }

        public event EventHandler ObjectRemoved
        {
            add
            {
                this.i_ObjectRemoved += value;
            }
            remove
            {
                this.i_ObjectRemoved -= value;
            }
        }
        #endregion
        
        #region Event Handlers
        #endregion

        #region Methods

        #region IEnumerable Members
        public virtual IEnumerator GetEnumerator()
        {
            return this.CollectionSource.GetEnumerator();
        }
        #endregion

        #region ICollection Members
        public virtual bool IsSynchronized
        {
            get
            {
                return this.CollectionSource.IsSynchronized;
            }
        }

        public virtual int Count
        {
            get
            {
                return this.CollectionSource.Count;
            }
        }

        public virtual void CopyTo( Array array, int index )
        {
            this.CollectionSource.CopyTo( array, index );
        }

        public virtual object SyncRoot
        {
            get
            {
                return this.CollectionSource.SyncRoot;
            }
        }
        #endregion

        #region IList Members
        public virtual bool IsReadOnly
        {
            get
            {
                return this.CollectionSource.IsReadOnly;
            }
        }

        public virtual object this[int index]
        {
            get
            {
                return this.CollectionSource[index];
            }
            set
            {
                this.RaiseAddingObjectEvent( value );
                this.CollectionSource[index] = value;
                this.RaiseObjectAddedEvent( value, index );
            }
        }

        public virtual void RemoveAt( int index )
        {
            object removed = this[index];
            this.RaiseRemovingObjectEvent( removed );
            this.CollectionSource.RemoveAt( index );
            this.RaiseObjectRemovedEvent( removed );
        }

        public virtual void Insert( int index, object value )
        {
            this.RaiseAddingObjectEvent( value );
            this.CollectionSource.Insert( index, value );
            this.RaiseObjectAddedEvent( value, index );
        }

        public virtual void Remove( object value )
        {
            this.RaiseRemovingObjectEvent( value );
            this.CollectionSource.Remove( value );
            this.RaiseObjectRemovedEvent( value );
        }

        public virtual bool Contains( object value )
        {
            return this.CollectionSource.Contains( value );
        }

        public virtual void Clear()
        {
            this.CollectionSource.Clear();
        }

        public virtual int IndexOf( object value )
        {
            return this.CollectionSource.IndexOf( value );
        }

        public virtual int Add( object value )
        {
            this.RaiseAddingObjectEvent( value );
            int index = this.CollectionSource.Add( value );
            this.RaiseObjectAddedEvent( value, index );

            return index;
        }

        public virtual bool IsFixedSize
        {
            get
            {
                return this.CollectionSource.IsFixedSize;
            }
        }
        #endregion

        #region ArrayList Methods
        /// <summary>
        /// Creates an ArrayList wrapper for a specific IList.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static ArrayList Adapter( IList list )
        {
            return ArrayList.Adapter( list );
        }

        /// <summary>
        /// Adds the elements of an ICollection to this collection.
        /// </summary>
        /// <param name="c"></param>
        public virtual void AddRange( ICollection c )
        {
            foreach( object o in c )
            {
                this.Add( o );
            }
        }

        /// <summary>
        /// Searches the entire collection for an element using the default comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual int BinarySearch( object value )
        {
            return this.CollectionSource.BinarySearch( value );
        }
        
        /// <summary>
        /// Searches the entire collection for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public virtual int BinarySearch( object value, IComparer comparer )
        {
            return this.CollectionSource.BinarySearch( value, comparer );
        }

        /// <summary>
        /// Searches a section of the collection for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range to search.</param>
        /// <param name="count">The length of the range to search.</param>
        /// <param name="value">The Object to locate. The value can be a null reference (Nothing in Visual Basic).</param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements. 
        ///-or- 
        ///A null reference (Nothing in Visual Basic) to use the default comparer that is the IComparable implementation of each element. 
        ///</param>
        /// <returns></returns>
        public virtual int BinarySearch( int index, int count, object value, IComparer comparer )
        {
            return this.CollectionSource.BinarySearch( index, count, value, comparer );
        }

        /// <summary>
        /// Creates a shallow copy of this collection
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

        #region Ocl Iterators
        public virtual void Do( Block aBlock )
        {
            if( aBlock != null )
            {
                AbstractCollection clone = this.Clone() as AbstractCollection;

                foreach( object o in clone )
                {
                    aBlock( o );
                }
            }
        }

        public virtual AbstractCollection Collect( Evaluation eval )
        {
            AbstractCollection results = Activator.CreateInstance( this.GetType() ) as AbstractCollection;

            if( eval != null )
            {
                AbstractCollection clone = this.Clone() as AbstractCollection;

                foreach( object o in clone )
                {
                    results.Add( eval( clone, o ) );
                }
            }

            return results;
        }

        public virtual object Detect( BooleanEvaluataion matching )
        {
            if( matching != null )
            {
                AbstractCollection clone = this.Clone() as AbstractCollection;

                foreach( object o in clone )
                {
                    if( matching( clone, o ) )
                    {
                        return o;
                    }
                }
            }
            return null;
        }

        public virtual AbstractCollection Select( BooleanEvaluataion matching )
        {
            AbstractCollection results = Activator.CreateInstance( this.GetType() ) as AbstractCollection;
            if( matching != null )
            {
                AbstractCollection clone = this.Clone() as AbstractCollection;

                foreach( object o in clone )
                {
                    if( matching( clone, o ) )
                    {
                        results.Add( o );
                    }
                }
            }

            return results;
        }

        public virtual AbstractCollection Select( BooleanEvaluataionBlock matching )
        {
            AbstractCollection results = Activator.CreateInstance( this.GetType() ) as AbstractCollection;
            if( matching != null )
            {
                AbstractCollection clone = this.Clone() as AbstractCollection;

                foreach( object o in clone )
                {
                    if( matching( o ) )
                    {
                        results.Add( o );
                    }
                }
            }

            return results;
        }

        public virtual AbstractCollection Reject( BooleanEvaluataion matching )
        {
            AbstractCollection results = Activator.CreateInstance( this.GetType() ) as AbstractCollection;

            if( matching != null )
            {
                AbstractCollection clone = this.Clone() as AbstractCollection;

                foreach( object o in clone )
                {
                    if( !matching( clone, o ) )
                    {
                        results.Add( o );
                    }
                }
            }

            return results;
        }
        #endregion

        #region Ocl Methods
        /// <summary>
        /// The number of occurrences of the object in the collection.
        /// </summary>
        /// <param name="anObject"></param>
        /// <returns></returns>
        public virtual int CountOf( object anObject )
        {
            int numberFound = 0;

            foreach( object o in this )
            {
                if( o == anObject )
                {
                    numberFound++;
                }
            }

            return numberFound;
        }
		
        /// <summary>
        /// True if anObject is not an element of this collection.
        /// </summary>
        /// <param name="anObject"></param>
        /// <returns></returns>
        public virtual bool Excludes( object anObject )
        {
            if( this.Contains( anObject ) )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// True if all elements of the parameter 
        /// collection are not present in this collection.
        /// </summary>
        /// <param name="aCollection"></param>
        /// <returns></returns>
        public virtual bool ExcludesAll( AbstractCollection aCollection )
        {
            foreach( Object anObject in aCollection )
            {
                if( this.Contains( anObject ) )
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// True if the object is an element of the collection
        /// </summary>
        /// <param name="anObject"></param>
        /// <returns></returns>
        public virtual bool Includes( Object anObject )
        {
            return this.Contains( anObject );
        }

        /// <summary>
        /// True if all elements of the parameter collection 
        /// are present in the current collection.
        /// </summary>
        /// <param name="aCollection"></param>
        /// <returns></returns>
        public virtual bool IncludesAll( AbstractCollection aCollection )
        {
            foreach( Object anObject in aCollection )
            {
                if( !this.Contains( anObject ) )
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// True if the collection contains no elements.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsEmpty()
        {
            if( this.Count == 0 )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// True if the collection contains one or more elements
        /// </summary>
        /// <returns></returns>
        public virtual bool NotEmpty()
        {
            if( !this.IsEmpty() )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// The number of elements in the collection
        /// </summary>
        /// <returns></returns>
        public virtual int Size()
        {
            return this.Count;
        }

        /// <summary>
        /// The addition of all elements in the collection.
        /// The elements must be of a type supporting addition.
        /// </summary>
        /// <returns></returns>
        public virtual int Sum()
        {
            int result = 0;
            foreach( object o in this )
            {
                result += Convert.ToInt32( o );
            }
			
            return result;
        }
        #endregion

        /// <summary>
        /// Return a Clone of this collection as a System.Collections.ArrayList.
        /// </summary>
        /// <returns></returns>
        public ArrayList AsArrayList()
        {
            return (ArrayList)this.CollectionSource.Clone();
        }

        /// <summary>
        /// Returns a serialized copy of this collection as a memory stream.
        /// </summary>
        /// <returns></returns>
        public Stream AsStream()
        {
            MemoryStream stream = new MemoryStream();

            AbstractCollection copy = this.Clone() as AbstractCollection;

            lock( copy.SyncRoot )
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize( stream, copy );
                stream.Position = 0L;
            }

            return stream;
        }

        public AbstractCollection Intersect( AbstractCollection anotherCollection )
        {
            Set results = new Set();

            foreach( object o in anotherCollection )
            {
                if( this.Contains( o ) )
                {
                    results.Add( o );
                }
            }

            foreach( object o in this )
            {
                if( anotherCollection.Contains( o ) )
                {
                    results.Add( o );
                }
            }

            return results;
        }
        #endregion

        #region Properties
        public virtual int Capacity 
        {
            get
            {
                return this.CollectionSource.Capacity;
            }
            set
            {
                this.CollectionSource.Capacity = value;
            }
        }
        #endregion

        #region Private Methods
        protected virtual void RaiseAddingObjectEvent( object added )
        {
            if( this.i_AddingObject != null )
            {
                AddingObjectEventArgs args = new AddingObjectEventArgs( added );
                this.i_AddingObject( this, args );
            }
        }

        protected virtual void RaiseObjectAddedEvent( object added, int atIndex )
        {
            if( this.i_ObjectAdded != null )
            {
                ObjectAddedEventArgs args = new ObjectAddedEventArgs( added, atIndex );
                this.i_ObjectAdded( this, args );
            }
        }

        protected virtual void RaiseRemovingObjectEvent( object removed )
        {
            if( this.i_RemovingObject != null )
            {
                RemovingObjectEventArgs args = new RemovingObjectEventArgs( removed );
                this.i_RemovingObject( removed, args );
            }
        }

        protected virtual void RaiseObjectRemovedEvent( object removed )
        {
            if( this.i_ObjectRemoved != null )
            {
                ObjectRemovedEventArgs args = new ObjectRemovedEventArgs( removed );
                this.i_ObjectRemoved( this, args );
            }
        }
        #endregion

        #region Private Properties
        protected ArrayList CollectionSource
        {
            get
            {
                return i_CollectionSource;
            }
            set
            {
                i_CollectionSource = value;
            }
        }
        #endregion

        #region Construction and Finalization
        public AbstractCollection( ICollection c )
        {
            this.CollectionSource = new ArrayList( c );
        }

        public AbstractCollection( int capacity )
        {
            this.CollectionSource = new ArrayList( capacity );
        }

        public AbstractCollection()
        {
            this.CollectionSource = new ArrayList();
        }
        #endregion

        #region Data Elements
        private ArrayList i_CollectionSource;
        private event EventHandler i_AddingObject;
        private event EventHandler i_ObjectAdded;
        private event EventHandler i_RemovingObject;
        private event EventHandler i_ObjectRemoved;
        #endregion

        #region Constants
        #endregion
    }
}
