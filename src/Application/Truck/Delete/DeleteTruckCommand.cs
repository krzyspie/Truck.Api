using MediatR;

namespace Application.Truck.Delete
{
    public sealed record DeleteTruckCommand(ulong TruckId) : IRequest;
}
