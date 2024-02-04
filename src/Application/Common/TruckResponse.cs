namespace Application.Common
{
    public sealed record TruckResponse(
        int Id, 
        string Code, 
        string Name, 
        int Status, 
        string Description, 
        DateTime DateCreated, 
        DateTime? DateModified);
}
