using Domain.Enums;
using FluentValidation;

namespace Application.Truck.Create
{
    public class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        public CreateTruckCommandValidator()
        {
            RuleFor(x => x.Code).Length(3, 10);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => (TruckStatus)x.Status).IsInEnum();
        }
    }
}
