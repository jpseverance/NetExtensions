//using System;
//using System.Collections;
//using System.Data;
//using System.Text;

//using NetExtensions.PersistenceFramework.AdoFactories;
//using NetExtensions.Models;

//namespace NetExtensions.PersistenceFramework.TestObjects
//{
//    [Serializable]
//    public class CustomerMapper : TemplateMapper
//    {
//        #region Event Handlers
//        #endregion

//        #region Methods
//        public void Save( Customer aCustomer )
//        {
//            //1. Construct a transAction
//            //2. If the object already exists in the db, update it
//            //3. If not in the db, insert it

//            IDbTransaction txn = null;
//            IDbCommand cmd = null;
//            int numUpdated;

//            try
//            {
//                this.Connection.Open();
//                txn = this.Connection.BeginTransAction();
//                CustomerMapper mapper = new CustomerMapper( new MsSqlFactory(), txn );
//                if( mapper.Exists( aCustomer ) )
//                {
//                    StringBuilder update = new StringBuilder();
//                    update.Append( "update Customers set " );
//                    update.Append( "CompanyName = '" );
//                    update.Append( aCustomer.CompanyName.Replace( "'", "''" ) );
//                    update.Append( "' " );
//                    update.Append( "where CustomerID = '" );
//                    update.Append( aCustomer.Key.GetValue() );
//                    update.Append( "'" );

//                    cmd = mapper.BuildCommandFor( update.ToString() );
//                    numUpdated = cmd.ExecuteNonQuery();

//                    Console.WriteLine( numUpdated );

//                    if( numUpdated == 1 )
//                    {
//                        txn.Commit();
//                    }
//                }
//                else
//                {
//                    StringBuilder insert = new StringBuilder();
//                    insert.Append( "insert into Customers( CustomerID, CompanyName, ContactName ) " );
//                    insert.Append( String.Format( "values( '{0}', '{1}', '{2}' )", aCustomer.Key.GetValue(), aCustomer.CompanyName.Replace("'", "''"), aCustomer.ContactName ) );

//                    cmd = mapper.BuildCommandFor( insert.ToString() );
//                    numUpdated = cmd.ExecuteNonQuery();

//                    Console.WriteLine( numUpdated );

//                    if( numUpdated == 1 )
//                    {
//                        txn.Commit();
//                    }
//                }
//            }
//            catch( Exception e )
//            {
//                Console.WriteLine( e.StackTrace );
//                txn.Rollback();
//                throw;
//            }
//            finally
//            {
//                cmd.Connection.Close();
//            }
//        }
//        #endregion

//        #region Properties
//        #endregion

//        #region Private Methods
//        protected override IDbCommand ExistsCommandFor( PersistentModel aModel )
//        {
//            StringBuilder select = new StringBuilder();
//            select.Append( "select count(*) from Customers where CustomerID = '" );
//            select.Append( aModel.Key.GetValue() );
//            select.Append( "'" );

//            return this.BuildCommandFor( select.ToString() );
//        }

//        protected override PersistentModel LoadFrom( System.Data.IDataReader reader )
//        {
//            Customer aCustomer       = new Customer();
//            aCustomer.Key            = new Key( reader["CustomerID"] );
//            aCustomer.CompanyName    = reader["CompanyName"].ToString();
//            aCustomer.ContactName    = reader["ContactName"].ToString();
//            aCustomer.TitleOfContact = reader["ContactTitle"].ToString();

//            if( reader.NextResult() )
//            {
//                OrderMapper anOrderMapper = new OrderMapper( this.AdoFactory );
//                foreach( Order order in anOrderMapper.BuildOrdersFrom( reader ) )
//                {
//                    aCustomer.Add( order );
//                }
//            }

//            return aCustomer;
//        }

//        protected override IDbCommand SelectCommandFor( Key aKey )
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.Append( "select * from Customers where CustomerID = '" );
//            sql.Append( aKey.GetValue() );
//            sql.Append( "'; " ); 
//            sql.Append( "select * from Orders where CustomerID = '" );
//            sql.Append( aKey.GetValue() );
//            sql.Append( "' " );
//            sql.Append( "order by OrderDate;" );
            
//            return this.BuildCommandFor( sql.ToString() );
//        }

//        protected override IDbCommand SelectCommandFor( Query aQuery )
//        {
//            StringBuilder sql = new StringBuilder();
//            sql.Append( "select * from Customers where " );
//            sql.Append( aQuery.GenerateWhereClause() );
//            sql.Append( "; " ); 
//            sql.Append( "select * from Orders where " );
//            sql.Append( aQuery.GenerateWhereClause() );
//            sql.Append( " order by OrderDate;" );

//            return this.BuildCommandFor( sql.ToString() );
//        }

//        protected override IDbCommand SelectAllCommand()
//        {
//            return null;
//        }

//        protected override IDbCommand InsertCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }

//        protected override IDbCommand UpdateCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }

//        protected override IDbCommand DeleteCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }

//        protected override IDbCommand SelectVersionCommandFor( PersistentModel aModel )
//        {
//            throw new Exception( "The method or operation is not implemented." );
//        }
//        #endregion

//        #region Private Properties
//        #endregion

//        #region Construction and Finalization
//        public CustomerMapper( IAdoFactory adoFactory )
//            : base( adoFactory )
//        {
//        }

//        public CustomerMapper( IAdoFactory adoFactory, IDbConnection cxn )
//            : base( adoFactory, cxn )
//        {
//        }

//        public CustomerMapper( IAdoFactory adoFactory, IDbTransaction txn )
//            : base( adoFactory, txn )
//        {
//        }
//        #endregion

//        #region Data Elements
//        #endregion

//        #region Constants
//        #endregion
//    }
//}
