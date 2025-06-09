using EcommApp;
namespace EcommApp.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private ProductService _service;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _service = new ProductService();
        }

        [Order(2)]
        [Test]
        public void Test_AddProduct()
        {
            //Act
            _service.AddProduct(new Product { ProductId = 3, ProductName = "Laptop", ListPrice = 10000 });
            var expectedResult = 3;
            var actualResult = _service.GetAllProducts().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Order(3)]
        [TestCase(1, "Pen")]
        [TestCase(2, "Notebook")]
        public void GetProductById_ShouldReturnCorrectProduct(int id, string expectedName)
        {
            var result = _service.GetProductById(id);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedName, result.ProductName);
        }

        [Order(4)]
        [TestCase("Pen", 1)]
        [TestCase("Notebook", 2)]
        public void GetProductByName_ShouldReturnCorrectProduct(string name, int expectedId)
        {
            var result = _service.GetProductByName(name);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedId, result.ProductId);
        }

        [Order(5)]
        [TestCase(1, true)]
        [TestCase(99, false)]
        //[Ignore("This test is skipped temporarily due to redesign of RemoveProduct logic.")]
        public void RemoveProduct_ShouldReturnCorrectResult(int id, bool expected)
        {
            var existProduct = _service.GetProductById(id);
            if (existProduct != null)
            {
                var result = _service.RemoveProduct(id);
                Assert.AreEqual(expected, result);
            }
            else
            {
                Assert.Fail();
            }
          
        }

        [Order(1)]
        [Test]
        public void GetProductsSortedByName_ShouldReturnArrayInOrder()
        {
            var sorted = _service.GetProductsSortedByName();
            string[] expectedOrder = { "Notebook", "Pen" };

            CollectionAssert.AreEqual(expectedOrder, sorted.Select(p => p.ProductName).ToArray());
        }


    }
}