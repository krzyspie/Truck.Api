using MediatR;

namespace Application.Truck.Update
{
    public class UpdateTruckStatusCommandHandler : IRequestHandler<UpdateTruckStatusCommand>
    {
        public Task Handle(UpdateTruckStatusCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
