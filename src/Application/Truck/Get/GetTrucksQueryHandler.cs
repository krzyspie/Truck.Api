using Application.Common;
using Domain.Abstractions;
using Mapster;
using MediatR;

namespace Application.Truck.Get
{
    public class GetTrucksQueryHandler : IRequestHandler<GetTrucksQuery, IEnumerable<TruckResponse>>
    {
        private readonly ITruckRepository _truckRepository;

        public GetTrucksQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task<IEnumerable<TruckResponse>> Handle(GetTrucksQuery request, CancellationToken cancellationToken)
        {
            var result = await _truckRepository.Get(request.FilterBy, request.FilterValue, request.SortBy, request.SortDirection);

            return result.Adapt<IEnumerable<TruckResponse>>();
        }
    }
}
