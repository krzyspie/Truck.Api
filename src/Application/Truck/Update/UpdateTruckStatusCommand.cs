using MediatR;

namespace Application.Truck.Update
{
    public sealed record UpdateTruckStatusCommand(ulong TruckId, string Status) : IRequest;
}
