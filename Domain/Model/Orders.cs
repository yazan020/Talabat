using System;
using System.Collections.Generic;

namespace TalabatApi.Domain.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int DeliveryPrice { get; set; }
        public int TotalPrice { get; set; }
        public string RestName { get; set; }
        public List<Product> ProductsOrdered { get; set; }
        public DateTimeOffset Date { get; set; }
    
        public int Userid { get; set; }
        public User User { get; set; }
    }
}