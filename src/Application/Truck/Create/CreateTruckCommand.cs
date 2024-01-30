using MediatR;

namespace Application.Truck.Create
{
    public sealed record CreateTruckCommand(string Code, string Name, int Status, string Description) : IRequest<int>;
}
