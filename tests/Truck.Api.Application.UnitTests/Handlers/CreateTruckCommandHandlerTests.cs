using Application.Truck.Create;
using Domain.Abstractions;
using Domain.Enums;
using NSubstitute;

namespace Application.UnitTests.Handlers
{
    public class CreateTruckCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsTruckId()
        {
            // Arrange
            string code = "Truck123";
            string name = "Test Truck";
            TruckStatus truckStatus = TruckStatus.Loading;
            string description = "Test Description";

            var command = new CreateTruckCommand(code, name, truckStatus, description);

            var truckRepository = Substitute.For<ITruckRepository>();
            truckRepository.CreateAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns(123);

            var handler = new CreateTruckCommandHandler(truckRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(123, result);
            await truckRepository.Received(1).CreateAsync(code, name, truckStatus.ToString(), description);
        }
    }
}