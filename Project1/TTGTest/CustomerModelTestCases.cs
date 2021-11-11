using Xunit;
using Microsoft.EntityFrameworkCore;
using TTGDL;
using TTGModel;
using System.Collections.Generic;
using System.Linq;

namespace TTGTest
{
    public class CustomerTest
    {
        private readonly DbContextOptions<database1Context> _options;

        public CustomerTest()
        {
            _options = new DbContextOptionsBuilder<database1Context>()
                        .UseSqlite("Filename =Test.db").Options;
            Seed();
        }

        [Fact]
        public void GetAllCustomersTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                ICustRepository repo = new CustomerCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Customer> test = repo.GetAllCustomers();

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.Equal(2, test.Count);
                Assert.Equal("Tester Balthezar", test[0].Name);
            }
        }

        [Fact]
        public void GetMatchingCustomerTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                ICustRepository repo = new CustomerCloudRepo(context);
                Customer test = context.Customers.Find(1);
                //Act -- a call to the method that is being tested 
                Customer found = repo.GetMatchingCustomer(test.Id);

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.Equal("Tester Balthezar", test.Name);
            }
        }

        [Fact]
        public void DeleteCustomerTest()
        {
            using (var context = new database1Context(_options))
            {
                //Arrange
                ICustRepository repo = new CustomerCloudRepo(context);
                Customer cust = context.Customers.Find(1);

                //Act
                repo.DeleteCustomer(cust);
            }
            using (var context = new database1Context(_options))
            {
                //Assert
                List<Customer> ListOfCust = context.Customers.ToList();

                Assert.Single(ListOfCust);
                Assert.Null(context.Customers.Find(1));
            }
        }
        [Fact]
        public void AddCustomerTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                ICustRepository repo = new CustomerCloudRepo(context);
                Customer AddedCust = new Customer
                {
                    Name = "Adam",
                    Address = "test street",
                    EmailPhone = "test@testing.com"
                };

                //Act -- a call to the method that is being tested 
                repo.AddCustomer(AddedCust);
            }
            //Assert -- expected outcome of Act
            using (var context = new database1Context(_options))
            {
                Customer result = context.Customers.Find(3);

                Assert.NotNull(result);
                Assert.Equal("Adam", result.Name);
            }
        }

        private void Seed()
        {
            //using to block to automaticaly close the resorce that is used to connect to this db after seeding data to it
            using (var context = new database1Context(_options))
            {
                //delete inmemory database at start to eliminate any previous data and confirm you are workinf in a pristine atabase
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange
                (
                    new Customer
                    {
                        Name = "Tester Balthezar",
                        Address = "754 location dr",
                        EmailPhone = "B@lthezar.com"
                    },
                    new Customer
                    {
                        Name = "Tester Alister",
                        Address = "34 location ave",
                        EmailPhone = "test@Customer.com"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}