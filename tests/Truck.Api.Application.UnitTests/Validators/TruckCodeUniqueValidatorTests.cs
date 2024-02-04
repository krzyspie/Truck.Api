using Application.Common;
using Application.Truck.Update;
using Domain.Abstractions;
using FluentValidation;
using NSubstitute;

namespace Application.UnitTests.Validators
{
    public class TruckCodeUniqueValidatorTests
    {
        [Fact]
        public async Task IsValidAsync_UniqueCode_ReturnsTrue()
        {
            // Arrange
            var truckRepository = Substitute.For<ITruckRepository>();
            var validator = new TruckCodeUniqueValidator<UpdateTruckCommand>(truckRepository);

            var context = new ValidationContext<UpdateTruckCommand>(null);
            var cancellationToken = CancellationToken.None;

            truckRepository.IsCodeUsedAlready(Arg.Any<string>())
                .Returns(false);

            var code = "NewCode";

            // Act
            var result = await validator.IsValidAsync(context, code, cancellationToken);

            // Assert
            Assert.True(result);
            await truckRepository.Received(1).IsCodeUsedAlready("NewCode");
        }

        [Fact]
        public async Task IsValidAsync_DuplicateCode_ReturnsFalse()
        {
            // Arrange
            var truckRepository = Substitute.For<ITruckRepository>();
            var validator = new TruckCodeUniqueValidator<UpdateTruckCommand>(truckRepository);

            var context = new ValidationContext<UpdateTruckCommand>(null);
            var cancellationToken = CancellationToken.None;

            truckRepository.IsCodeUsedAlready(Arg.Any<string>())
                .Returns(true);

            var code = "ExistingCode";

            // Act
            var result = await validator.IsValidAsync(context, code, cancellationToken);

            // Assert
            Assert.False(result);
            await truckRepository.Received(1).IsCodeUsedAlready("ExistingCode");
        }
    }
}
