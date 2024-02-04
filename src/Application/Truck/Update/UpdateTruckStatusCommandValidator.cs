using Application.Common;
using FluentValidation;

namespace Application.Truck.Update
{
    public class UpdateTruckStatusCommandValidator : AbstractValidator<UpdateTruckStatusCommand>
    {
        public UpdateTruckStatusCommandValidator(
            TruckNotExistsValidator<UpdateTruckStatusCommand> truckNotExistsValidator,
            TruckStatusValidator<UpdateTruckStatusCommand> truckStatusValidator)
        {
            RuleFor(x => x.Status).IsInEnum();
            RuleFor(x => x.Id).SetAsyncValidator(truckNotExistsValidator);
            RuleFor(x => new TruckStatusModel(x.Id, x.Status)).SetAsyncValidator(truckStatusValidator);
        }
    }
}
