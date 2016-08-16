using System;
using System.Collections;

using NetExtensions.Models;

namespace NetExtensions.PersistenceFramework.TestObjects
{
    [Serializable]
    public class Order : PersistentModel
    {
        #region Event Handlers
        #endregion

        #region Methods
        #endregion

        #region Properties
        public int OrderId
        {
            get
            {
                return i_OrderId;
            }
            set
            {
                i_OrderId = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return i_OrderDate;
            }
            set
            {
                i_OrderDate = value;
            }
        }

        public float UnitPrice
        {
            get
            {
                return i_UnitPrice;
            }
            set
            {
                i_UnitPrice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return i_Quantity;
            }
            set
            {
                i_Quantity = value;
            }
        }

        public string ShipName
        {
            get
            {
                return i_ShipName;
            }
            set
            {
                i_ShipName = value;
            }
        }

        public ICollection OrderItems
        {
            get
            {
                if( i_OrderItemsHolder != null && i_OrderItems.Count == 0 )
                {
                    i_OrderItems = (ArrayList)i_OrderItemsHolder.GetValue();
                }
                return (ICollection)i_OrderItems.Clone();
            }
            set
            {
                this.i_OrderItems = new ArrayList( value );
            }
        }

        public int NumberOfLineItems
        {
            get{ return this.i_OrderItems.Count; }
        }

        public ValueHolder OrderItemsHolder
        {
            get
            {
                return i_OrderItemsHolder;
            }
            set
            {
                this.i_OrderItemsHolder = value;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public Order()
        {
        }
        #endregion

        #region Data Elements
        private int i_OrderId;
        private DateTime i_OrderDate;
        private float i_UnitPrice;
        private int i_Quantity;
        private string i_ShipName;
        private ArrayList i_OrderItems = new ArrayList();
        private ValueHolder i_OrderItemsHolder;
        #endregion

        #region Constants
        #endregion
    }
}
