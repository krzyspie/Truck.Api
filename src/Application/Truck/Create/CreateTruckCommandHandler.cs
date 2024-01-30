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
            var a = "ABC";

            return await Task.FromResult(11);
        }
    }
}
