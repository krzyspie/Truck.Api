using Application.Truck.Update;
using Domain.Abstractions;
using Domain.Enums;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Common
{
    public class TruckStatusValidator<T> : IAsyncPropertyValidator<T, UpdateTruckStatusCommand>
    {
        private readonly Dictionary<TruckStatus, TruckStatus> statusesMap = new Dictionary<TruckStatus, TruckStatus>
        {
            { TruckStatus.Loading, TruckStatus.ToJob },
            { TruckStatus.ToJob, TruckStatus.AtJob },
            { TruckStatus.AtJob, TruckStatus.Returning },
            { TruckStatus.Returning, TruckStatus.Loading },
        };

        private readonly ITruckRepository _truckRepository;

        public TruckStatusValidator(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public string Name => nameof(TruckStatusValidator<T>);

        public string GetDefaultMessageTemplate(string errorCode) => "Cannot change to given status.";

        public async Task<bool> IsValidAsync(ValidationContext<T> context, UpdateTruckStatusCommand value, CancellationToken cancellation)
        {
            var truck = await _truckRepository.GetByIdAsync(value.Id);

            if (truck is null || truck.Status == TruckStatus.OutOfService)
            {
                return true;
            }

            var allowedStatus = statusesMap[truck.Status];

            return allowedStatus == value.Status;
        }
    }
}
