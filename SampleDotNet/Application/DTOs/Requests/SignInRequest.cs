using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNet.Application.DTOs.Requests
{
    public class SignInRequest
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = String.Empty;
    }
}