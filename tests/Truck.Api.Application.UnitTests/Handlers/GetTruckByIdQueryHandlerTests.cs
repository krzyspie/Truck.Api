using Application.Truck.Get;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Exceptions;
using NSubstitute;

namespace Application.UnitTests.Handlers
{
    public class GetTruckByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidQuery_ReturnsTruckResponse()
        {
            // Arrange
            var query = new GetTruckByIdQuery(1);
            var truck = new Domain.Entities.Truck
            {
                Id = 1, 
                Name = "Test Truck", 
                Status = TruckStatus.AtJob, 
                Description = "Test Description" 
            };

            var truckRepository = Substitute.For<ITruckRepository>();
            truckRepository.GetByIdAsync(Arg.Any<int>())
                .Returns(truck);

            var handler = new GetTruckByIdQueryHandler(truckRepository);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(truck.Name, result.Name);
            Assert.Equal(truck.Id, result.Id);
            Assert.Equal(truck.Code, result.Code);
            Assert.Equal(truck.Description, result.Description);
            Assert.Equal(truck.Status, result.Status);

            await truckRepository.Received(1).GetByIdAsync(1);
        }

        [Fact]
        public async Task Handle_TruckNotFound_ThrowsException()
        {
            // Arrange
            var query = new GetTruckByIdQuery(2);

            var truckRepository = Substitute.For<ITruckRepository>();
            truckRepository.GetByIdAsync(Arg.Any<int>())
                .Returns((Domain.Entities.Truck)null);

            var handler = new GetTruckByIdQueryHandler(truckRepository);

            // Act and Assert
            await Assert.ThrowsAsync<TruckNotFoundException>(() => handler.Handle(query, CancellationToken.None));
            await truckRepository.Received(1).GetByIdAsync(2);
        }
    }

}
