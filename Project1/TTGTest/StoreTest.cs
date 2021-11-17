using Xunit;
using Microsoft.EntityFrameworkCore;
using TTGDL;
using TTGModel;
using System.Collections.Generic;
using System.Linq;

namespace TTGTest
{
    public class StoreTest
    {
        private readonly DbContextOptions<database1Context> _options;

        public StoreTest()
        {
            _options = new DbContextOptionsBuilder<database1Context>()
                        .UseSqlite("Filename =storeTest.db").Options;
            Seed();
        }


        [Fact]
        public void GetStoreByIdTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IStoreRepository repo = new StoreCloudRepo(context);
                Store test = context.Stores.Find(1);
                //Act -- a call to the method that is being tested 
                Store found = repo.GetStoreById(test.Id);

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.NotNull(found);
                Assert.Equal("Aquisitions Inc", found.Name);

            }

        }

        [Fact]
        public void GetAllCustomersTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IStoreRepository repo = new StoreCloudRepo(context);

                //Act -- a call to the method that is being tested 
                List<Store> test = repo.GetAllStores();

                //Assert -- expected outcome of Act
                //Equal(number of customers expected, #of customers retrevied from GetAllCustomers)
                Assert.Equal(2, test.Count);
                Assert.Equal("Aquisitions Inc", test[0].Name);
            }
        }


        [Fact]
        public void AddStoreTest()
        {
            using (var context = new database1Context(_options))
            {
                //arrange -- define/ set up what is needed for the Act
                IStoreRepository repo = new StoreCloudRepo(context);
                Store AddedStore = new Store
                {
                    Name = "test store",
                    Address = "test ave",
           
                };

                //Act -- a call to the method that is being tested 
                repo.AddStore(AddedStore);
            }
            //Assert -- expected outcome of Act
            using (var context = new database1Context(_options))
            {
                Store result = context.Stores.Find(3);

                Assert.NotNull(result);
                Assert.Equal("test store", result.Name);
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

                    context.Stores.AddRange
                    (
                        new Store
                        {
                            Name = "Aquisitions Inc",
                            Address = "Red Larch",
                        },
                        new Store
                        {
                            Name = "Galactic games",
                            Address = "universe ave",
                        }
                    );

                    context.SaveChanges();
                }
            }




        }
}
