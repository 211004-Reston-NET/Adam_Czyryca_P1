using System;
using TTGModel;
using Xunit;

namespace TTGTest
{
    public class UnitTest1
    {
        [Fact]
        public void CustomerShouldSetValidData()
        {
            //arrange
            Customer _custTest = new Customer();
            string name = "Tester";
            //act
            _custTest.Name = name;
            //assert
            Assert.NotNull(_custTest.Name);
            Assert.Equal(_custTest.Name, name);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("123test45")]
        [InlineData("```@\\`")]
        public void CustomerShouldFailwhenSetWithInvalidData(string p_input)
        {
            //arrange
            Customer _custTest = new Customer();

            //act && assert
            Assert.Throws<Exception>(() => _custTest.Name = p_input);

        }
        [Fact]
        public void StoreShouldSetValidData()
        {
            //arrange
            Store _storeTest = new Store();
            string name = "test store";
            //act
            _storeTest.Name = name;
            //assert
            Assert.NotNull(_storeTest.Name);
            Assert.Equal(_storeTest.Name, name);
        }

        [Fact]
        public void LineItemShouldSetValidData()
        {
            //arrange
            LineItem _LineItem = new LineItem();
            int num = 4;
            //act
            _LineItem.Quantity = num;
            //assert
            Assert.NotNull(_LineItem.Quantity);
            Assert.Equal(_LineItem.Quantity, num);
        }

        [Fact]
        public void ProductItemShouldSetValidData()
        {
            //arrange
            Product _Product = new Product();
            string test = "test";
            //act
            _Product.Name = test;
            //assert
            Assert.NotNull(_Product.Name);
            Assert.Equal(_Product.Name, test);
        }
        [Fact]
        public void OrderItemShouldSetValidData()
        {
            //arrange
            Orders _ord = new Orders();
            int test = 4;
            //act
            _ord.StoreFront = test;
            //assert
            Assert.NotNull(_ord.StoreFront);
            Assert.Equal(_ord.StoreFront, test);
        }
        [Fact]
        public void managerItemShouldSetValidData()
        {
            //arrange
            Manager _manager = new Manager();
            int test = 4;
            //act
            _manager.Store = test;
            //assert
            Assert.NotNull(_manager.Store);
            Assert.Equal(_manager.Store, test);
        }

        [Fact]
        public void ItemInOrderItemShouldSetValidData()
        {
            //arrange
            ItemsInOrder _iio = new ItemsInOrder();
            int test = 4;
            //act
            _iio.OrderId = test;
            //assert
            Assert.NotNull(_iio.OrderId);
            Assert.Equal(_iio.OrderId, test);
        }
    }
}
