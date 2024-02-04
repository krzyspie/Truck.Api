using Application.Common;
using FluentValidation;

namespace Application.Truck.Update
{
    public class UpdateTruckCommandValidator : AbstractValidator<UpdateTruckCommand>
    {
        public UpdateTruckCommandValidator(
            TruckNotExistsValidator<UpdateTruckCommand> truckNotExistsValidator,
            TruckCodeUniqueValidator<UpdateTruckCommand> uniqueCodeValidator)
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.Code).Length(1, 7);
            RuleFor(x => x.Id).SetAsyncValidator(truckNotExistsValidator);
            RuleFor(x => x.Code).SetAsyncValidator(uniqueCodeValidator);
        }
    }
}
