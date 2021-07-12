using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalabatApi.Domain.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public UserData UserData { get; set; }
    }
}