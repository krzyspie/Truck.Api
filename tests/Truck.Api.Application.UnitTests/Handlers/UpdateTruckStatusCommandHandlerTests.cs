using Application.Truck.Update;
using Domain.Abstractions;
using Domain.Enums;
using MediatR;
using NSubstitute;

namespace Application.UnitTests.Handlers
{
    public class UpdateTruckStatusCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsUnit()
        {
            // Arrange
            var id = 22;
            var status = TruckStatus.ToJob;

            var command = new UpdateTruckStatusCommand(id, status);

            var truckRepository = Substitute.For<ITruckRepository>();
            var handler = new UpdateTruckStatusCommandHandler(truckRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(Unit.Value, result);
            await truckRepository.Received(1).UpdateStatusAync(id, status.ToString());
        }
    }
}
