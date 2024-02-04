using FluentValidation;

namespace Application.Truck.Get;
public class GetTrucksQueryValidator : AbstractValidator<GetTrucksQuery>
{
    public GetTrucksQueryValidator()
    {
        RuleFor(x => x.FilterBy)
            .NotEmpty()
            .NotNull()
            .Must(IsColumnNameValid);

        RuleFor(x => x.SortBy)
            .NotEmpty()
            .NotNull()
            .Must(IsColumnNameValid);

        RuleFor(x => x.SortDirection)
            .NotEmpty()
            .NotNull()
            .Must(IsSortDirectionValid);
    }

    private static bool IsColumnNameValid(string columnName)
    {
        var validColumnNames = new List<string> { "Code", "Name", "Status", "Description", "DateCreated", "DateModified" };

        return validColumnNames.Contains(columnName);
    }

    private static bool IsSortDirectionValid(string sortDirection)
    {
        var validDirections = new List<string> { "asc", "desc", "ascending", "descending" };

        return validDirections.Contains(sortDirection.ToLower());
    }
}
