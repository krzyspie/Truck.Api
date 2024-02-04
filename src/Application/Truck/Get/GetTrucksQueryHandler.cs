using Application.Common;
using Domain.Abstractions;
using Mapster;
using MediatR;

namespace Application.Truck.Get
{
    public class GetTrucksQueryHandler : IRequestHandler<GetTrucksQuery, IEnumerable<TruckResponse>>
    {
        private readonly Dictionary<string, string> sortDirection = new()
        {
            {"ascending", "ASC" },
            {"asc", "ASC" },
            {"descending", "DESC" },
            {"desc", "DESC" }
        };

        private readonly ITruckRepository _truckRepository;

        public GetTrucksQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task<IEnumerable<TruckResponse>> Handle(GetTrucksQuery request, CancellationToken cancellationToken)
        {
            var sorting = sortDirection[request.SortDirection.ToLower()];

            var result = await _truckRepository.Get(request.FilterBy, request.FilterValue, request.SortBy, sorting);

            return result.Adapt<IEnumerable<TruckResponse>>();
        }
    }
}
