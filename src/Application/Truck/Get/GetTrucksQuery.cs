using Application.Common;
using MediatR;

namespace Application.Truck.Get;

public sealed record GetTrucksQuery(string FilterBy, string FilterValue, string SortBy, string SortDirection) : IRequest<IEnumerable<TruckResponse>>;
