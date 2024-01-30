using MediatR;

namespace Application.Truck.Delete
{
    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand>
    {
        public Task Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
