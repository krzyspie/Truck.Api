using MediatR;

namespace Application.Truck.Get
{
    public class GetTruckByIdQueryHandler : IRequestHandler<GetTruckByIdQuery>
    {
        public Task Handle(GetTruckByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
