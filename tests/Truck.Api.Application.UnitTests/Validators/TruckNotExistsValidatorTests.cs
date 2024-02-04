using Application.Common;
using Application.Truck.Update;
using Domain.Abstractions;
using FluentValidation;
using NSubstitute;

namespace Application.UnitTests.Validators
{
    public class TruckNotExistsValidatorTests
    {
        [Fact]
        public async Task IsValidAsync_TruckExists_IsValidTrue()
        {
            // Arrange
            var truckRepository = Substitute.For<ITruckRepository>();
            var validator = new TruckNotExistsValidator<UpdateTruckCommand>(truckRepository);

            var context = new ValidationContext<UpdateTruckCommand>(null);
            var cancellationToken = CancellationToken.None;

            truckRepository.GetByIdAsync(Arg.Any<int>())
                .Returns(new Domain.Entities.Truck());

            // Act
            var result = await validator.IsValidAsync(context, 1, cancellationToken);

            // Assert
            Assert.True(result);
            await truckRepository.Received(1).GetByIdAsync(1);
        }

        [Fact]
        public async Task IsValidAsync_TruckNotExists_IsValidFalse()
        {
            // Arrange
            var truckRepository = Substitute.For<ITruckRepository>();
            var validator = new TruckNotExistsValidator<UpdateTruckCommand>(truckRepository);

            var context = new ValidationContext<UpdateTruckCommand>(null);
            var cancellationToken = CancellationToken.None;

            truckRepository.GetByIdAsync(Arg.Any<int>())
                .Returns((Domain.Entities.Truck)null);

            // Act
            var result = await validator.IsValidAsync(context, 1, cancellationToken);

            // Assert
            Assert.False(result);
            await truckRepository.Received(1).GetByIdAsync(1);
        }
    }
}
