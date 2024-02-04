using Domain.Abstractions;
using MediatR;

namespace Application.Truck.Update
{
    public class UpdateTruckStatusCommandHandler : IRequestHandler<UpdateTruckStatusCommand, Unit>
    {
        private readonly ITruckRepository _truckRepository;

        public UpdateTruckStatusCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task<Unit> Handle(UpdateTruckStatusCommand request, CancellationToken cancellationToken)
        {
            await _truckRepository.UpdateStatusAync(request.Id, request.Status.ToString());

            return Unit.Value;
        }
    }
}
