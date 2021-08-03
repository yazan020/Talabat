using System;

namespace TalabatApi.Domain.Model.Dtos
{
    public class OrderDto
    {
        public string UserName { get; set; } // yazan
        public int DeliveryPrice { get; set; } // 1 from rest repo
        public int TotalPrice { get; set; } // 3 from rest repo
        public string RestName { get; set; } // mcdonaldz from rest repo

        public DateTimeOffset Date { get; set; } // ? auto

        public int Userid { get; set; } // relation
    }
}