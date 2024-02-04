using Domain.Enums;
using MediatR;

namespace Application.Truck.Update
{
    public sealed record UpdateTruckStatusCommand(int Id, TruckStatus Status) : IRequest<Unit>;
}
