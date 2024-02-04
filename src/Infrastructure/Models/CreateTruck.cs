namespace Infrastructure.Models
{
    public sealed record CreateTruck(string Code, string Name, int Status, string Description);
}
