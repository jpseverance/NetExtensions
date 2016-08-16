using System;
using System.Collections;
using System.Text;

namespace NetExtensions.PersistenceFramework
{
    [Serializable]
    public class Query : object
    {
        #region Event Handlers
        #endregion

        #region Methods
        public static Query For( Type type )
        {
            return new Query( type );
        }

        public void Add( Criteria aCriteria )
        {
            this.i_Criteria.Add( aCriteria );
        }

        public void Add( ICollection multipleCriteria )
        {
            this.i_Criteria.AddRange( multipleCriteria );
        }

        public void Remove( Criteria aCriteria )
        {
            this.i_Criteria.Remove( aCriteria );
        }

        public string GenerateWhereClause()
        {
            StringBuilder where = new StringBuilder();
            foreach( Criteria criteria in this.Criteria )
            {
                if( where.Length != 0 )
                {
                    where.Append( " And " );
                }
                where.Append( criteria.AsSqlWhereClause() ); 
            }

            return where.ToString();
        }
        #endregion

        #region Properties
        public Type Type
        {
            get
            {
                return i_Type;
            }
            set
            {
                i_Type = value;
            }
        }

        public ICollection Criteria
        {
            get
            {
                return (ICollection)i_Criteria.Clone();
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public Query( Type forType )
        {
            this.Type = forType;			
        }
        #endregion

        #region Data Elements
        private Type		i_Type;
        private ArrayList	i_Criteria = new ArrayList();
        #endregion

        #region Constants
        #endregion
    }
}
