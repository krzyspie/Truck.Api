using Application.Common;
using Application.Truck.Update;
using Domain.Abstractions;
using Domain.Enums;
using FluentValidation;
using NSubstitute;
using System.Reflection;

namespace Application.UnitTests.Validators
{
    public class TruckStatusValidatorTests
    {
        [Theory]
        [InlineData(TruckStatus.Loading, TruckStatus.ToJob, 1)]
        [InlineData(TruckStatus.ToJob, TruckStatus.AtJob, 1)]
        [InlineData(TruckStatus.AtJob, TruckStatus.Returning, 1)]
        [InlineData(TruckStatus.Returning, TruckStatus.Loading, 1)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.ToJob, 1)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.AtJob, 1)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.Returning, 1)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.Loading, 1)]
        [InlineData(TruckStatus.ToJob, TruckStatus.OutOfService, 0)]
        [InlineData(TruckStatus.AtJob, TruckStatus.OutOfService, 0)]
        [InlineData(TruckStatus.Returning, TruckStatus.OutOfService, 0)]
        [InlineData(TruckStatus.Loading, TruckStatus.OutOfService, 0)]
        [InlineData(TruckStatus.Loading, TruckStatus.Loading, 1)]
        [InlineData(TruckStatus.OutOfService, TruckStatus.OutOfService, 0)]
        [InlineData(TruckStatus.ToJob, TruckStatus.ToJob, 1)]
        [InlineData(TruckStatus.AtJob, TruckStatus.AtJob, 1)]
        [InlineData(TruckStatus.Returning, TruckStatus.Returning, 1)]
        public async Task IsValidAsync_ValidStatus_ReturnsTrue(TruckStatus from, TruckStatus to, int callsNumber)
        {
            // Arrange
            var id = 1;
            var truckRepository = Substitute.For<ITruckRepository>();
            var validator = new TruckStatusValidator<UpdateTruckStatusCommand>(truckRepository);

            var context = new ValidationContext<UpdateTruckStatusCommand>(null);
            var cancellationToken = CancellationToken.None;

            var truck = new Domain.Entities.Truck { Id = id, Status = from };
            truckRepository.GetByIdAsync(Arg.Any<int>())
                .Returns(truck);

            var model = new TruckStatusModel(id, to);

            // Act
            var result = await validator.IsValidAsync(context, model, cancellationToken);

            // Assert
            Assert.True(result);
            await truckRepository.Received(callsNumber).GetByIdAsync(id);
        }

        [Theory]
        [InlineData(TruckStatus.Loading, TruckStatus.AtJob)]
        [InlineData(TruckStatus.Loading, TruckStatus.Returning)]
        [InlineData(TruckStatus.ToJob, TruckStatus.Loading)]
        [InlineData(TruckStatus.ToJob, TruckStatus.Returning)]
        [InlineData(TruckStatus.AtJob, TruckStatus.Loading)]
        [InlineData(TruckStatus.AtJob, TruckStatus.ToJob)]
        [InlineData(TruckStatus.Returning, TruckStatus.ToJob)]
        [InlineData(TruckStatus.Returning, TruckStatus.AtJob)]
        public async Task IsValidAsync_InvalidStatus_ReturnsFalse(TruckStatus from, TruckStatus to)
        {
            // Arrange
            var id = 1;
            var truckRepository = Substitute.For<ITruckRepository>();
            var validator = new TruckStatusValidator<UpdateTruckStatusCommand>(truckRepository);

            var context = new ValidationContext<UpdateTruckStatusCommand>(null);
            var cancellationToken = CancellationToken.None;

            var truck = new Domain.Entities.Truck { Id = id, Status = from };
            truckRepository.GetByIdAsync(Arg.Any<int>())
                .Returns(truck);

            var model = new TruckStatusModel(id, to);

            // Act
            var result = await validator.IsValidAsync(context, model, cancellationToken);

            // Assert
            Assert.False(result);
            await truckRepository.Received(1).GetByIdAsync(id);
        }

        [Fact]
        public async Task IsValidAsync_TruckNotFound_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var truckRepository = Substitute.For<ITruckRepository>();
            var validator = new TruckStatusValidator<UpdateTruckStatusCommand>(truckRepository);

            var context = new ValidationContext<UpdateTruckStatusCommand>(null);
            var cancellationToken = CancellationToken.None;

            truckRepository.GetByIdAsync(Arg.Any<int>())
                .Returns((Domain.Entities.Truck)null);

            var model = new TruckStatusModel(id, TruckStatus.Returning);

            // Act
            var result = await validator.IsValidAsync(context, model, cancellationToken);

            // Assert
            Assert.True(result);
            await truckRepository.Received(1).GetByIdAsync(id);
        }
    }
}
