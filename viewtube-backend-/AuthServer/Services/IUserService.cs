using AuthServer.Models;

namespace AuthServer.Services
{
    public interface IUserService
    {
        User RegisterUser(User user);
        User Login(string Email, string Password);
        User FindByEmail(string email);
        User ResetPass(string email, string oldPassword, string newPassword);
        User ForgetPass(string email, string newPassword);

    }
}
