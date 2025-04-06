using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNet.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> CheckExistUsernameAsync(string username);
    }
}