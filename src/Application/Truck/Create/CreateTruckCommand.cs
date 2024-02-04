using Domain.Enums;
using MediatR;

namespace Application.Truck.Create
{
    public sealed record CreateTruckCommand(string Code, string Name, TruckStatus Status, string Description) : IRequest<int>;
}
