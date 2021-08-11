using System;
using System.Collections.Generic;

namespace TalabatApi.Domain.Model
{
    public class Order
    {
        public int Id { get; set; } // 1
        public string UserName { get; set; } // yazan
        public int DeliveryPrice { get; set; } // 1 from rest repo
        public int TotalPrice { get; set; } // 3 from rest repo
        public string RestName { get; set; } // macdonald from rest repo
        public bool Delivered { get; set; }
        public bool OrderedAgreed { get; set; }
        public DateTimeOffset Date { get; set; } // ? auto
    
        public int Userid { get; set; } // relation
        public User User { get; set; } // relation
    }
}