using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using VehicleTracking.Customer.API.Infrastructure.EF;
using VehicleTracking.Customer.API.Queries;

namespace Tests
{
    public class GetAllCustomerNamesHandlerTests
    {
        private  Mock<ICustomerRepository> customerRepositoryMock;
        [SetUp]
        public void Setup()
        {
            customerRepositoryMock = new Mock<ICustomerRepository>();
        }

        [Test]
        public async Task TestGetCustomerNamesHandlerDoesReturnNull()
        {
            
            customerRepositoryMock.Setup(x => x.Get()).Returns(new System.Collections.Generic.List<VehicleTracking.Customer.API.Models.Customer>() { new VehicleTracking.Customer.API.Models.Customer() { Id = 1, Address = "Cairo", Name = "Customer 1" } });
            var customerNamesHandler = new GetAllCustomerNamesHandler(customerRepositoryMock.Object);
            var customersResult = await customerNamesHandler.Handle(new GetAllCustomerNamesQuery(), new System.Threading.CancellationToken());
            Assert.NotNull(customersResult);
        }

        [Test]
        public async Task TestGetCustomerNamesHandlerIncludeNameOfCustomer()
        {

            customerRepositoryMock.Setup(x => x.Get()).Returns(new System.Collections.Generic.List<VehicleTracking.Customer.API.Models.Customer>() { new VehicleTracking.Customer.API.Models.Customer() { Id = 1, Address = "Cairo", Name = "Customer 1" } });
            var customerNamesHandler = new GetAllCustomerNamesHandler(customerRepositoryMock.Object);
            var customersResult = await customerNamesHandler.Handle(new GetAllCustomerNamesQuery(), new System.Threading.CancellationToken());
            Assert.AreEqual(customersResult.CustomerNames.Count,1);
            Assert.AreEqual(customersResult.CustomerNames[0].CustomerName, "Customer 1");
        }
    }
}