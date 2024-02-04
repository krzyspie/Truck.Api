using Domain.Enums;

namespace Application.Common
{
    public sealed record TruckResponse(
        int Id, 
        string Code, 
        string Name, 
        TruckStatus Status, 
        string Description, 
        DateTime DateCreated, 
        DateTime? DateModified);
}
