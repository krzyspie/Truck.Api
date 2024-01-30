using MediatR;

namespace Application.Truck.Update
{
    public sealed record UpdateTruckCommand(
        ulong TruckId, 
        string Code, 
        string Name, 
        string Description, 
        string Status) : IRequest;
}
