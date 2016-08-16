using System;
using System.Collections;
using System.Data.Common;
using System.Reflection;

namespace NetExtensions.PersistenceFramework
{
    [Serializable]
    public class ColumnMap : object
    {
        #region Event Handlers
        #endregion

        #region Methods
        #endregion

        #region Properties
        public string ColumnName
        {
            get
            {
                return i_ColumnName;
            }
            set
            {
                i_ColumnName = value;
            }
        }

        public MemberInfo Member
        {
            get
            {
                return i_Member;
            }
            set
            {
                if( value.MemberType != MemberTypes.Field && value.MemberType != MemberTypes.Property )
                {
                    throw new ArgumentException( 
                        String.Format( "Member {0} must be a Field or Property, but was a {1}", value.Name, value.MemberType )
                        );
                }
                i_Member = value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public ColumnMap( string columnName, MemberInfo member )
        {
            this.ColumnName = columnName;
            this.Member  = member;
        }
        #endregion

        #region Data Elements
        private string      i_ColumnName;
        private MemberInfo  i_Member;
        #endregion

        #region Constants
        #endregion
    }
}
