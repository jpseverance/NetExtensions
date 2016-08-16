using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace NetExtensions.Models
{
#if DEBUG
	[TestFixture()]
	public class ValueHolderTests
	{

		#region SetUp and TearDown ValueHolderTests
		[SetUp()]
		public void SetUpValueHolderTests()
		{
		}

		[TearDown()]
		public void TearDownValueHolderTests()
		{
		}
		#endregion

		#region Test Methods
        [Test]
        public void TestTypedValueHolderWithDoLoadDelegate()
        {
            // 12 is a number known to return a Person with Addresses.
            Person personWithAddresses = new PersonMapper().FindPersonWithIdLazyLoadAddressesWithDoLoadDelegate( 12 );
            Assert.IsNotNull( personWithAddresses.Addresses );
            Assert.IsTrue( personWithAddresses.Addresses.Count == 2 );

            // Print the addresses for grins
            foreach( Address a in personWithAddresses.Addresses )
            {
                Console.WriteLine( "{0}, {1}", a.Street, a.City );
            }

            // 13 is a number that does not correspond to a Person with Addresses
            Person personWithoutAddresses = new PersonMapper().FindPersonWithIdLazyLoadAddressesWithDoLoadDelegate( 13 );
            Assert.IsNotNull( personWithoutAddresses.Addresses );
            Assert.IsTrue( personWithoutAddresses.Addresses.Count == 0 );           
        }

        [Test()]
        public void TestTypedValueHolderWithIValueLoader()
        {
            // 12 is a number known to return a Person with Addresses.
            Person personWithAddresses = new PersonMapper().FindPersonWithIdLazyLoadAddressesWithConcreteValueLoader( 12 );
            Assert.IsNotNull( personWithAddresses.Addresses );
            Assert.IsTrue( personWithAddresses.Addresses.Count == 2 );

            // Print the addresses for grins
            foreach( Address a in personWithAddresses.Addresses )
            {
                Console.WriteLine( "{0}, {1}", a.Street, a.City );
            }

            // 13 is a number that does not correspond to a Person with Addresses
            Person personWithoutAddresses = new PersonMapper().FindPersonWithIdLazyLoadAddressesWithConcreteValueLoader( 13 );
            Assert.IsNotNull( personWithoutAddresses.Addresses );
            Assert.IsTrue( personWithoutAddresses.Addresses.Count == 0 );    
        }
		#endregion

		#region Support Methods and Properties
		#endregion

		#region Fields
		#endregion

		#region Constants
		#endregion

        #region internal classes for testing
        internal class PersonMapper
        {
            public Person FindPersonWithIdLazyLoadAddressesWithDoLoadDelegate( int id )
            {
                DoLoad<IList<Address>> doLoad = delegate()
                {
                    return new AddressMapper().FindAddressesFor( id );
                };

                ValueHolder<IList<Address>> addressesHolder = new ValueHolder<IList<Address>>( doLoad );

                Person p = new Person( id, "Fred", addressesHolder );

                return p;
            }

            public Person FindPersonWithIdLazyLoadAddressesWithConcreteValueLoader( int id )
            {
                Person p = new Person( id, "Fred", new ValueHolder<IList<Address>>( new AddressesLoader( id ) ) );
                return p;
            }
        }

        internal class AddressesLoader : IValueLoader<IList<Address>>
        {
            public IList<Address> Load()
            {
                return new AddressMapper().FindAddressesFor( _personId );
            }

            public AddressesLoader( int forPersonId )
            {
                this._personId = forPersonId;
            }

            private int _personId;
        }

        internal class AddressMapper
        {
            public IList<Address> FindAddressesFor( int personId )
            {
                IList<Address> addresses = new List<Address>();
                if( personId == 12 )
                {
                    addresses.Add( new Address( "11130 Clearstream", "Frisco" ) );
                    addresses.Add( new Address( "123 Bellveue", "Dallas" ) );
                }
                return addresses;
            }
        }

        internal class Person
        {
            private ValueHolder<IList<Address>> _addressesLoader;

            public readonly int Id;
            public readonly string Name;

            public IList<Address> Addresses
            {
                get
                {
                    return this._addressesLoader.Value;
                }
            }

            internal Person( int id, string name, ValueHolder<IList<Address>> addressesHolder )
            {
                this.Id = id;
                this.Name = name;
                this._addressesLoader = addressesHolder;
            }
        }

        internal class Address
        {
            public string Street;
            public string City;

            internal Address( string street, string city )
            {
                this.Street = street;
                this.City = city;
            }
        }
        #endregion
	}
#endif
}
