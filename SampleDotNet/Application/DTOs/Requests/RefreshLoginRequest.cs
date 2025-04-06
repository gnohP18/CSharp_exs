using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNet.Application.DTOs.Requests
{
    public class RefreshLoginRequest
    {
        [Required(ErrorMessage = "Refresh Token is required")]
        public string RefreshToken { get; set; } = String.Empty;
    }
}