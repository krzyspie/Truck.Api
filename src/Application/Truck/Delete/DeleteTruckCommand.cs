using MediatR;

namespace Application.Truck.Delete
{
    public sealed record DeleteTruckCommand(int TruckId) : IRequest;
}
