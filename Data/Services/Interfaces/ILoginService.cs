using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
