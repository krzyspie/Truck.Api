using Application.Common;
using MediatR;

namespace Application.Truck.Get;

public sealed record GetTruckByIdQuery(int Id) : IRequest<TruckResponse>;
