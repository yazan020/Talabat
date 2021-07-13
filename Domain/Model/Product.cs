namespace TalabatApi.Domain.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string RestuarantName { get; set; }
        public int RestuarantId { get; set; }
        public Restuarant Restuarant { get; set; }
    }
}