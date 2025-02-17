using BackEndAutomation.DataProcessorCodes;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BackEndAutomation.Tests
{
    [TestFixture]
    public class DataProcessorTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.That(2 + 2, Is.EqualTo(5));
        }

        [Test]
        public void ProcessData_ShouldReturnUpperCaseData()
        {
            // Arrange
            var mockService = new Mock<IExternalService>();
            mockService.Setup(s => s.FetchData()).Returns("test data");
            var processor = new DataProcessor(mockService.Object);
            // Act
            var result = processor.ProcessData();
            // Assert
            Assert.That(result, Is.EqualTo("TEST DATA"));
        }

        [Test]
        public void ProcessData_Cobine()
        {
            // Arrange
            var mockService = new Mock<IExternalService>();
            //mockService.Setup(s => s.FetchData()).Returns("test data");
            mockService.Setup(s => s.FetchData()).Throws(new Exception("Service unavailable"));
            var processor = new DataProcessor(mockService.Object);
            // Act
            var result = processor.ProcessData();
            // Assert
            Assert.That(result, Is.EqualTo("TEST DATA"));
        }

        [Test]
        public void ProcessData_ShouldHandleServiceFailure()
        {
            // Arrange
            var mockService = new Mock<IExternalService>();
            mockService.Setup(s => s.FetchData()).Throws(new Exception("Service unavailable"));
            var processor = new DataProcessor(mockService.Object);
            // Assert
            Assert.Throws<Exception>(() => processor.ProcessData());
        }
    }
}
