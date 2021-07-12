using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalabatApi.Domain.Model
{
    public class UserData
    {
        [Key]
        public int id { get; set; }
        public string UserAddress { get; set; }
        public long UserLat { get; set; }
        public long UserLong { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}