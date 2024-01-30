using MediatR;

namespace Application.Truck.Update
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand>
    {
        public Task Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
