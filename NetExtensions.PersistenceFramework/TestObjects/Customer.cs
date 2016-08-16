using System;
using System.Collections;

using NetExtensions.Models;

namespace NetExtensions.PersistenceFramework.TestObjects
{
    [Serializable]
    public class Customer : PersistentModel
    {
        #region Event Handlers
        #endregion

        #region Methods
        public void Add( Order anOrder )
        {
            this.i_Orders[anOrder] = anOrder;
        }

        public void Remove( Order anOrder )
        {
            this.i_Orders.Remove( anOrder );
        }
        #endregion

        #region Properties
        public string CompanyName
        {
            get
            {
                return i_CompanyName;
            }
            set
            {
                i_CompanyName = value;
            }
        }

        public string ContactName
        {
            get
            {
                return i_ContactName;
            }
            set
            {
                i_ContactName = value;
            }
        }

        public string TitleOfContact
        {
            get
            {
                return i_TitleOfContact;
            }
            set
            {
                i_TitleOfContact = value;
            }
        }

        public ICollection Orders
        {
            get
            {
                return (ICollection)this.i_Orders.Values;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Private Properties
        #endregion

        #region Construction and Finalization
        public Customer()
        {
        }
        #endregion

        #region Data Elements
        private string i_CompanyName;
        private string i_ContactName;
        private string i_TitleOfContact;
        private Hashtable i_Orders = new Hashtable();
        #endregion

        #region Constants
        #endregion
    }
}
