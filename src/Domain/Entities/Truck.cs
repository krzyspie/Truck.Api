using Domain.Enums;

namespace Domain.Entities
{
    public sealed class Truck : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TruckStatus Status { get; set; }
    }
}
