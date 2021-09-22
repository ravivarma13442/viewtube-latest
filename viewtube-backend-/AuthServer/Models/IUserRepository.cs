using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models
{
    public interface IUserRepository
    {
        User FindUserByEmail(string email);
        User Register(User user);
        User Login(string email, string password);
        User ResetPass(string email, string oldPassword, string newPassword);
        User ForgetPass(string email, string newPassword);
}
}
