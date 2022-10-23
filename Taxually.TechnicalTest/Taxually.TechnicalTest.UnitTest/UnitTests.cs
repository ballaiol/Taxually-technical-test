using Moq;
using Taxually.TechnicalTest.BL.Interfaces;
using Taxually.TechnicalTest.BL.Models;
using Taxually.TechnicalTest.BL.Services;
using Taxually.TechnicalTest.DL.Interfaces;

namespace Taxually.TechnicalTest.UnitTest
{
    public class UnitTests
    {
        readonly Mock<IHttp> httpMock = new();
        readonly Mock<IQueue> queueMock = new();
        readonly Mock<ICsvBuilder> csvBuilderMock = new();
        readonly Mock<IXmlWriter> xmlWriterMock = new();

        [Fact]
        public async Task DispatchAsyncGBTestAsync()
        {
            //Arrange
            VatRegistrationDispatcher _dispatcher = new(
                httpMock.Object, 
                queueMock.Object, 
                csvBuilderMock.Object, 
                xmlWriterMock.Object);

            var request = new VatRegistrationRequest
            {
                Country = "GB"
            };

            //Act
            await _dispatcher.DispatchAsync(request);

            //Assert
            httpMock.Verify(mock => mock.PostAsync(It.IsAny<string>(), It.IsAny<VatRegistrationRequest>()), Times.Once());
            queueMock.Verify(mock => mock.EnqueueAsync(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never());
            csvBuilderMock.Verify(mock => mock.BuildCsv(It.IsAny<VatRegistrationRequest>()), Times.Never());
            xmlWriterMock.Verify(mock => mock.WriteXml(It.IsAny<VatRegistrationRequest>()), Times.Never());
        }

        [Fact]
        public async Task DispatchAsyncFRTestAsync()
        {
            //Arrange
            VatRegistrationDispatcher _dispatcher = new(
                httpMock.Object,
                queueMock.Object,
                csvBuilderMock.Object,
                xmlWriterMock.Object);

            var request = new VatRegistrationRequest
            {
                Country = "FR"
            };

            //Act
            await _dispatcher.DispatchAsync(request);

            //Assert
            httpMock.Verify(mock => mock.PostAsync(It.IsAny<string>(), It.IsAny<VatRegistrationRequest>()), Times.Never());
            queueMock.Verify(mock => mock.EnqueueAsync(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Once());
            csvBuilderMock.Verify(mock => mock.BuildCsv(It.IsAny<VatRegistrationRequest>()), Times.Once());
            xmlWriterMock.Verify(mock => mock.WriteXml(It.IsAny<VatRegistrationRequest>()), Times.Never());
        }

        [Fact]
        public async Task DispatchAsyncDETestAsync()
        {
            //Arrange
            VatRegistrationDispatcher _dispatcher = new(
                httpMock.Object,
                queueMock.Object,
                csvBuilderMock.Object,
                xmlWriterMock.Object);

            var request = new VatRegistrationRequest
            {
                Country = "DE"
            };

            //Act
            await _dispatcher.DispatchAsync(request);

            //Assert
            httpMock.Verify(mock => mock.PostAsync(It.IsAny<string>(), It.IsAny<VatRegistrationRequest>()), Times.Never());
            queueMock.Verify(mock => mock.EnqueueAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            csvBuilderMock.Verify(mock => mock.BuildCsv(It.IsAny<VatRegistrationRequest>()), Times.Never());
            xmlWriterMock.Verify(mock => mock.WriteXml(It.IsAny<VatRegistrationRequest>()), Times.Once());
        }

        [Fact]
        public async Task DispatchAsyncExceptionTestAsync()
        {
            //Arrange
            VatRegistrationDispatcher _dispatcher = new(
                httpMock.Object,
                queueMock.Object,
                csvBuilderMock.Object,
                xmlWriterMock.Object);

            var request = new VatRegistrationRequest
            {
                Country = "HU"
            };

            //Assert
            await Assert.ThrowsAsync<Exception>(() => _dispatcher.DispatchAsync(request));
        }
    }
}