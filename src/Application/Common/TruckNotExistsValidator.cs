using Domain.Abstractions;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Common
{
    public class TruckNotExistsValidator<T> : IAsyncPropertyValidator<T, int>
    {
        private readonly ITruckRepository _truckRepository;

        public TruckNotExistsValidator(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public string Name => nameof(TruckNotExistsValidator<T>);

        public string GetDefaultMessageTemplate(string errorCode) => "Truck with given id does not exist.";

        public async Task<bool> IsValidAsync(ValidationContext<T> context, int value, CancellationToken cancellation)
        {
            return await _truckRepository.GetByIdAsync(value) is not null;
        }
    }
}
