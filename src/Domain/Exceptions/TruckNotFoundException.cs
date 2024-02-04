namespace Domain.Exceptions
{
    public class TruckNotFoundException : Exception
    {
        public TruckNotFoundException(int id)
        {
            Message = $"Truck with id '{id}' cannot be found.";
        }

        public string Message { get; }
    }
}
