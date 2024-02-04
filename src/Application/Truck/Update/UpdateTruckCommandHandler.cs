using Domain.Abstractions;
using MediatR;

namespace Application.Truck.Update
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, Unit>
    {
        private readonly ITruckRepository _truckRepository;

        public UpdateTruckCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task<Unit> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            await _truckRepository.UpdateAsync(request.Id, request.Code, request.Name, request.Status.ToString(), request.Description);

            return Unit.Value;
        }
    }
}
