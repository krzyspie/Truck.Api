using MediatR;

namespace Application.Truck.Get
{
    public class GetTrucksQueryHandler : IRequestHandler<GetTrucksQuery>
    {
        public Task Handle(GetTrucksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
