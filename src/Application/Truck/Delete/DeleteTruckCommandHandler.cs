using Domain.Abstractions;
using MediatR;

namespace Application.Truck.Delete
{
    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand>
    {
        private readonly ITruckRepository _truckRepository;

        public DeleteTruckCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            await _truckRepository.DeleteAsync(request.TruckId);
        }
    }
}
