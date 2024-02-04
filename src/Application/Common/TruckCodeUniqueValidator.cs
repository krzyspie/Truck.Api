using Domain.Abstractions;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Common
{
    public class TruckCodeUniqueValidator<T> : IAsyncPropertyValidator<T, string>
    {
        private readonly ITruckRepository _truckRepository;

        public TruckCodeUniqueValidator(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public string Name => nameof(TruckCodeUniqueValidator<T>);

        public string GetDefaultMessageTemplate(string errorCode) => "Truck with given code already exists. Code must be unique.";

        public async Task<bool> IsValidAsync(ValidationContext<T> context, string value, CancellationToken cancellation)
        {
            return !await _truckRepository.IsCodeUsedAlready(value);
        }
    }
}
