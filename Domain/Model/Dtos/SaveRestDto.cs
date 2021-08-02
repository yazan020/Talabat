using System.Collections.Generic;

namespace TalabatApi.Domain.Model.Dtos
{
    public class SaveRestDto
    {
        public string Name { get; set; }
        public float DeliveryPrice { get; set; }
        public int Offer { get; set; }
    }
}