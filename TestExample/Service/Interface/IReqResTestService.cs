using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExample.Models;

namespace TestExample.Service
{
    public interface IReqResTestService
    {
        Task<User> GetUserAsync(string id);
    }
}
