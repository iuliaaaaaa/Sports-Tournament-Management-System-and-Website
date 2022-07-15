using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SynthesisAssignment.Models
{
    [Table("users")]
    public class User
    {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Please supply a username")]
            public string Username { get; set; }
            [Required(ErrorMessage = "Please enter a password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Required(ErrorMessage = "Please supply a valid email adress")]
            public string Email { get; set; }
            public string Role { get; set; }
        }
}
