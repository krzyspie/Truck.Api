using Domain.Enums;
using MediatR;

namespace Application.Truck.Update
{
    public sealed record UpdateTruckCommand(
        int Id, 
        string Code, 
        string Name,
        TruckStatus Status,
        string Description) : IRequest<Unit>;
}
