using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibleContext.Services
{
    public interface IAuth
    {
        Task<bool> RegisterUser(string email, string password);
        Task<bool> LoginUser(string email, string password);
    }
    public class AuthService
    {
    }
}
