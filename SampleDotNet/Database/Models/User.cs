using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNet.Database.Models
{
    [Table("users")]
    public class User : BaseModel
    {
        public string Name { get; set; } = String.Empty;
        public string Username { get; set; }
        public string Password { get; set; }
    }
}