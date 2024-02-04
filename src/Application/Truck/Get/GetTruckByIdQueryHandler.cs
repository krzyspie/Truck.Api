using Application.Common;
using Domain.Abstractions;
using Domain.Exceptions;
using Mapster;
using MediatR;

namespace Application.Truck.Get
{
    public class GetTruckByIdQueryHandler : IRequestHandler<GetTruckByIdQuery, TruckResponse>
    {
        private readonly ITruckRepository _truckRepository;

        public GetTruckByIdQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<TruckResponse> Handle(GetTruckByIdQuery request, CancellationToken cancellationToken)
        {
            var truck = await _truckRepository.GetByIdAsync(request.Id);

            return truck is not null ? truck.Adapt<TruckResponse>() : throw new TruckNotFoundException(request.Id);
        }
    }
}
