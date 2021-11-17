using Xunit;
using Microsoft.EntityFrameworkCore;
using TTGDL;
using TTGModel;
using System.Collections.Generic;
using System.Linq;

namespace TTGTest
{
    public class ProductTest
    {
        private readonly DbContextOptions<database1Context> _options;

        public ProductTest()
        {
            _options = new DbContextOptionsBuilder<database1Context>()
                        .UseSqlite("Filename =prodTest.db").Options;
            Seed();
        }


        [Fact]
        public void GetproductByIdTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IProductRepo repo = new ProductCloudRepo(context);
                Product test = context.Products.Find(1);
                //Act -- a call to the method that is being tested 
                Product found = repo.GetProductByID(test.Id);

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.NotNull(found);
                Assert.Equal("testprod1", found.Name);

            }

        }

        [Fact]
        public void GetAllProdutsTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IProductRepo repo = new ProductCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Product> test = repo.GetAllProducts();

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.Equal(2, test.Count);
                Assert.Equal("testprod1", test[0].Name);
            }
        }

        [Fact]
        public void AddProductTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IProductRepo repo = new ProductCloudRepo(context);
                Product AddedProd = new Product
                {
                    Name = "test",
                    Price = 30.40,
                    Description = "words",
                    Catagory = "testing"
                };

                //Act -- a call to the method that is being tested 
                repo.AddProduct(AddedProd);
            }
            //Assert -- expected outcome of Act
            using (var context = new database1Context(_options))
            {
                Product result = context.Products.Find(3);

                Assert.NotNull(result);
                Assert.Equal("test", result.Name);
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

                context.Products.AddRange
                (
                    new Product
                    {
                        Name = "testprod1",
                        Price= 10.40,
                        Description="some words",
                        Catagory="testing"
                    },
                    new Product
                    {
                        Name = "testprod2",
                        Price = 20.40,
                        Description = "more words",
                        Catagory = "testing"
                    }
                );

                context.SaveChanges();
            }
        }




    }
}
