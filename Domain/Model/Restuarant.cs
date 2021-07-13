using System.Collections.Generic;

namespace TalabatApi.Domain.Model
{
    public class Restuarant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DeliveryPrice { get; set; }
        public int Offer { get; set; }
        public List<Product> Products { get; set; }
    }
}