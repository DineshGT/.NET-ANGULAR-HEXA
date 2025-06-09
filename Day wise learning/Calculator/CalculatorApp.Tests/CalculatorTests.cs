using CalculatorApp;
namespace CalculatorApp.Tests
{
    [TestFixture] // so this class is a test class.. CalculatorTests
    public class CalculatorTests
    {
        Calculator calculator;

        // [SetUp] //this will execute SetUp() method every time before executing each test method
        [OneTimeSetUp] //this will execute SetUp() method first time only before executing any test method
        public void Setup()
        {
            //Arrange
            calculator = new Calculator();
        }

        [Test] // this method is for testing
        [TestCase(10,5)] // input 2
        [TestCase(1,0)] // input 1
        public void Add_WhenCalled_Return_Sum(int a,int b)
        {
            //Act
           var actualResult= calculator.Add(a, b);

            var expectedResult = (a+b);
            //Assert
            Assert.AreEqual(expectedResult, actualResult); // return true if both are equal
        }

        [Test]
        [TestCase(10,5)]
        [TestCase(5,5)]
        public void Subtract_WhenCalled_Returns_Difference(int a, int b)
        {
            //Act
          var actualResult=  calculator.Subtract(a, b);

           var expectedResult = (a-b);
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10,5)]
        [TestCase(10,2)]
        public void Divide_TwoNumbers_ReturnsQuotient(int a, int b)
        {
            //Act
            var actualResult=calculator.Divide(a, b);
            var expectedResult = (a / b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Testcase(1, 5)]
        [Testcase(2, 10)]
        public void Multiple_TwoNumbers_ReturnsMultiple(int a, int b)
        {
            var actual = calculator.Multiple(a, b);
            var expected = (a * b);

            Assert.IsTrue(actual.Equals(expected));

        }


        [Test]
        [Ignore("Skip this test method because it is under progress")] // this will ignore this test result and display skipped.. 
        public void DivideByZero_ThrowsException()
        {
            //Act & Assert
          Assert.Throws<System.DivideByZeroException>(()=> calculator.Divide(10,0));
        }
    }
}