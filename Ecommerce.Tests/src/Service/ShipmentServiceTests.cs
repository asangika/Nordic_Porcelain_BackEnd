using Ecommerce.Domain.src.Entities.ShipmentAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Service.src.ShipmentService;
using Moq;

namespace Ecommerce.Tests.src.Service
{
    public class ShipmentServiceTests
    {
        private readonly Mock<IShipmentRepository> _mockShipmentRepository;
        private readonly ShipmentManagement _shipmentService;
        public ShipmentServiceTests()
        {
            _mockShipmentRepository = new Mock<IShipmentRepository>();
            _shipmentService = new ShipmentManagement(_mockShipmentRepository.Object);
        }

        [Fact]
        public async Task GetShipmentsByOrderIdAsync_ShipmentsExist_ReturnsShipmentDtos()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var addressId = Guid.NewGuid();
            var shipments = new List<Shipment>
            {
                new Shipment { Id = Guid.NewGuid(), OrderId = orderId, TrackingNumber = "TRACK123", ShipmentDate = DateTime.UtcNow, AddressId =  addressId},
                new Shipment { Id = Guid.NewGuid(), OrderId = orderId, TrackingNumber = "TRACK456", ShipmentDate = DateTime.UtcNow, AddressId =  addressId }
            };

            _mockShipmentRepository.Setup(repo => repo.GetShipmentsByOrderIdAsync(orderId))
                .ReturnsAsync(shipments);

            // Act
            var result = await _shipmentService.GetShipmentsByOrderIdAsync(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("TRACK123", result.First().TrackingNumber);
        }

        [Fact]
        public async Task GetShipmentsByOrderIdAsync_NoShipmentsExist_ReturnsEmptyList()
        {
            // Arrange
            var orderId = Guid.NewGuid();

            _mockShipmentRepository.Setup(repo => repo.GetShipmentsByOrderIdAsync(orderId))
                .ReturnsAsync(new List<Shipment>());

            // Act
            var result = await _shipmentService.GetShipmentsByOrderIdAsync(orderId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}