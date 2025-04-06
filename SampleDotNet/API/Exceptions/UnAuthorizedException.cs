using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNet.Application.Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException() : base() { }
        public UnAuthorizedException(string message) : base(message) { }
    }
}