using Application.Common;
using FluentValidation;

namespace Application.Truck.Create
{
    public class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        public CreateTruckCommandValidator(TruckCodeUniqueValidator<CreateTruckCommand> uniqueCodeValidator)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.Code).Length(1, 7);
            RuleFor(x => x.Code).SetAsyncValidator(uniqueCodeValidator);
            
        }
    }
}
