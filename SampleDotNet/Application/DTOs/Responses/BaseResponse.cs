using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SampleDotNet.Application.DTOs.Responses
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NoContent;
        public string Message { get; set; } = null!;
        public object Data { get; set; } = null!;
    }
}