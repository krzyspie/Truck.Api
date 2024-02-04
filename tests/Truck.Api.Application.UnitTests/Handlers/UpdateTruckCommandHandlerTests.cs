using Application.Truck.Update;
using Domain.Abstractions;
using Domain.Enums;
using MediatR;
using NSubstitute;

namespace Application.UnitTests.Handlers
{
    public class UpdateTruckCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsUnit()
        {
            // Arrange
            var id = 1;
            var code = "NewCode";
            var name = "NewName";
            var status = TruckStatus.OutOfService;
            var description = "NewDescription";
            var command = new UpdateTruckCommand(id, code, name, status, description);

            var truckRepository = Substitute.For<ITruckRepository>();
            var handler = new UpdateTruckCommandHandler(truckRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(Unit.Value, result);
            await truckRepository.Received(1).UpdateAsync(id, code, name, status.ToString(), description);
        }
    }
}
