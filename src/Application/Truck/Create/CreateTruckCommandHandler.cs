using Domain.Abstractions;
using MediatR;

namespace Application.Truck.Create
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, int>
    {
        private readonly ITruckRepository _truckRepository;

        public CreateTruckCommandHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<int> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            int truckId = await _truckRepository.CreateAsync(request.Code, request.Name, request.Status.ToString(), request.Description);

            return truckId;
        }
    }
}
