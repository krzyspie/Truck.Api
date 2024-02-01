namespace Domain.Abstractions
{
    public interface ITruckRepository
    {
        Task Create();
        void Update();
        void Delete();
        void Get();
    }
}
