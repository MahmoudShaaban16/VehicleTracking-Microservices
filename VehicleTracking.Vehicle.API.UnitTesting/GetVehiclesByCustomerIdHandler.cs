using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using VehicleTracking.Vehicle.API.Queries;
using VehicleTracking.Vehicle.API.Repositories;

namespace Tests
{
    public class GetVehiclesByCustomerHandlerTests
    {
        private Mock<IVehicleRepository> vehicleRepositoryMock;
        [SetUp]
        public void Setup()
        {
            vehicleRepositoryMock = new Mock<IVehicleRepository>();
        }

        [Test]
        public async Task TestGetVehiclesByCustomerHandlerDoesReturnNull()
        {
            var customerId = 1;
            vehicleRepositoryMock.Setup(x => x.Get(customerId)).Returns(new System.Collections.Generic.List<VehicleTracking.Vehicle.API.Models.Vehicle>() { new VehicleTracking.Vehicle.API.Models.Vehicle() { Id = 1, RegNumber = "X123a", VehicleNumber = "V12233" } });

            var vehicleNamesHandler = new GetVehiclesByCustomerQueryHandler(vehicleRepositoryMock.Object);
            var vehiclesResult = await vehicleNamesHandler.Handle(new GetVehiclesByCustomerQuery() {CustomerId=customerId }, new System.Threading.CancellationToken());
            Assert.NotNull(vehiclesResult);
        }

        [Test]
        public async Task TestGetvehicleNamesHandlerIncludeNameOfvehicle()
        {

            var customerId = 1;
            vehicleRepositoryMock.Setup(x => x.Get(customerId)).Returns(new System.Collections.Generic.List<VehicleTracking.Vehicle.API.Models.Vehicle>() { new VehicleTracking.Vehicle.API.Models.Vehicle() { Id = 1, RegNumber = "X123a", VehicleNumber = "V12233" } });

            var vehicleNamesHandler = new GetVehiclesByCustomerQueryHandler(vehicleRepositoryMock.Object);
            var vehiclesResult = await vehicleNamesHandler.Handle(new GetVehiclesByCustomerQuery() { CustomerId = customerId }, new System.Threading.CancellationToken());
            Assert.GreaterOrEqual(vehiclesResult.Vehicles.Count, 1);
            Assert.AreEqual(vehiclesResult.Vehicles[0].Id, 1);
        }
    }
}