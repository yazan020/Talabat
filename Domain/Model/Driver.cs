namespace TalabatApi.Domain.Model
{
    public class Driver
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public long DriverLocation { get; set; }
        public int OrdersDelivered { get; set; }
    }
}