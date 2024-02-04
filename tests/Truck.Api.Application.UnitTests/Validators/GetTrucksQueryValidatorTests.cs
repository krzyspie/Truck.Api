using Application.Truck.Get;
using FluentValidation.TestHelper;

namespace Application.UnitTests.Validators
{
    public class GetTrucksQueryValidatorTests
    {
        [Theory]
        [InlineData("Code")]
        [InlineData("Name")]
        [InlineData("Status")]
        [InlineData("Description")]
        [InlineData("DateCreated")]
        [InlineData("DateModified")]
        public void Validate_ValidColumnNames_ReturnsNoErrors(string columnName)
        {
            // Arrange
            var validator = new GetTrucksQueryValidator();
            var query = new GetTrucksQuery(columnName, "valueTest", columnName, "asc");

            // Act 
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.FilterBy);
            result.ShouldNotHaveValidationErrorFor(x => x.SortBy);
            result.ShouldNotHaveValidationErrorFor(x => x.SortDirection);
        }

        [Theory]
        [InlineData("InvalidColumn")]
        public void Validate_InvalidColumnName_ReturnsValidationError(string columnName)
        {
            // Arrange
            var validator = new GetTrucksQueryValidator();
            var query = new GetTrucksQuery(columnName, "valueTest", columnName, "asc");

            // Act
            var result = validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FilterBy);
            result.ShouldHaveValidationErrorFor(x => x.SortBy);
            result.ShouldNotHaveValidationErrorFor(x => x.SortDirection);
        }

        [Theory]
        [InlineData("asc")]
        [InlineData("desc")]
        [InlineData("ascending")]
        [InlineData("descending")]
        public void Validate_ValidSortDirection_ReturnsNoErrors(string sortDirection)
        {
            // Arrange
            var validator = new GetTrucksQueryValidator();
            var query = new GetTrucksQuery("Code", "valueTest", "Code", sortDirection);

            // Act 
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.FilterBy);
            result.ShouldNotHaveValidationErrorFor(x => x.SortBy);
            result.ShouldNotHaveValidationErrorFor(x => x.SortDirection);
        }

        [Theory]
        [InlineData("InvalidDirection")]
        public void Validate_InvalidSortDirection_ReturnsValidationError(string sortDirection)
        {
            // Arrange
            var validator = new GetTrucksQueryValidator();
            var query = new GetTrucksQuery("Code", "valueTest", "Code", sortDirection);

            // Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.FilterBy);
            result.ShouldNotHaveValidationErrorFor(x => x.SortBy);
            result.ShouldHaveValidationErrorFor(x => x.SortDirection);
        }
    }
}
