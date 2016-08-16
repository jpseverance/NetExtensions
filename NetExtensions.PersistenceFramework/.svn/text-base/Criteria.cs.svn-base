using System;

namespace NetExtensions.PersistenceFramework
{
    [Serializable]
    public class Criteria : object
    {
        #region Event Handlers
        #endregion

        #region Methods
        public static Criteria Where( string fieldName, bool isNumericType, Operator anOperator, object value )
        {
            Criteria criteria = new Criteria();
            criteria.IsNumericType = isNumericType;
            criteria.FieldName = fieldName;
            criteria.Operator = anOperator;
            criteria.Value    = value;

            return criteria;
        }

        public string AsSqlWhereClause()
        {
            return String.Format( 
                "{0} {1} {2}{3}{2}", 
                this.FieldName, 
                this.SqlOperatorFor( this.Operator ),
                this.IsNumericType ? String.Empty : "'",
                this.Value 
                );
        }
        #endregion

        #region Properties
        public string FieldName
        {
            get
            {
                return i_FieldName;
            }
            set
            {
                i_FieldName = value;
            }
        }

        public bool IsNumericType
        {
            get
            {
                return i_IsNumericType;
            }
            set
            {
                i_IsNumericType = value;
            }
        }

        public Operator Operator
        {
            get
            {
                return i_Operator;
            }
            set
            {
                i_Operator = value;
            }
        }

        public object Value
        {
            get
            {
                return i_Value;
            }
            set
            {
                i_Value = value;
            }
        }
        #endregion

        #region Private Methods
        protected string SqlOperatorFor( Operator anOperator )
        {
            string result;

            switch( anOperator )
            {
                case Operator.Equals:
                    result = "=";
                    break;
                case Operator.GreaterThen:
                    result = ">";
                    break;
                case Operator.GreaterThenOrEqualTo:
                    result = ">=";
                    break;
                case Operator.LessThen:
                    result = "<";
                    break;
                case Operator.LessThenOrEqualTo:
                    result = "<=";
                    break;
                case Operator.Like:
                    result = "Like";
                    break;
                case Operator.NotEqualTo:
                    result = "<>";
                    break;
                default:
                    result = "=";
                    break;
            }
            
            return result;
        }
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public Criteria()
        {
        }
        #endregion

        #region Data Elements
        private Operator i_Operator;
        private string   i_FieldName;
        private object   i_Value;
        private bool     i_IsNumericType;
        #endregion

        #region Constants
        #endregion
    }
}
