using Application.Truck.Get;
using Domain.Abstractions;
using Domain.Enums;
using NSubstitute;

namespace Application.UnitTests.Handlers
{
    public class GetTrucksQueryHandlerTests
    {
        [Theory]
        [InlineData("asc", "asc")]
        [InlineData("ascending", "asc")]
        [InlineData("desc", "desc")]
        [InlineData("descending", "desc")]
        public async Task Handle_ValidQuery_ReturnsTruckResponses(string sortDirectionSetByUser, string sortDirectionPassedToMethod)
        {
            // Arrange
            string filterBy = "Status";
            string filterValue = "Active";
            string sortBy = "Name";
            
            var query = new GetTrucksQuery(filterBy, filterValue, sortBy, sortDirectionSetByUser);

            var trucks = new List<Domain.Entities.Truck>
            {
                new() { Id = 1, Name = "Truck A", Status = TruckStatus.AtJob, Description = "Description A" },
                new() { Id = 2, Name = "Truck B", Status = TruckStatus.Returning, Description = "Description B" }
            };

            var truckRepository = Substitute.For<ITruckRepository>();
            truckRepository.Get(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns(trucks);

            var handler = new GetTrucksQueryHandler(truckRepository);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(trucks.Count, result.Count());

            for (int i = 0; i < trucks.Count; i++)
            {
                Assert.Equal(trucks[i].Id, result.ElementAt(i).Id);
                Assert.Equal(trucks[i].Name, result.ElementAt(i).Name);
                Assert.Equal(trucks[i].Status, result.ElementAt(i).Status);
                Assert.Equal(trucks[i].Description, result.ElementAt(i).Description);
            }

            await truckRepository.Received(1).Get(filterBy, filterValue, sortBy, sortDirectionPassedToMethod);
        }
    }
}
