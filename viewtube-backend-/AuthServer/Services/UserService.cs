using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Exceptions;
using AuthServer.Models;

namespace AuthServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public User Login(string email, string password)
        {
            var user = _repo.Login(email, password);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("Invalid user id or password");
            }
            //return null;
        }

        public User ResetPass(string email, string oldPassword, string newPassword){
            var user = _repo.FindUserByEmail(email);
            if(user != null){
                return _repo.ResetPass(email, oldPassword, newPassword);
            }
            else
            {
                 throw new UserNotFoundException("user with this email id not exists");
            }
        }

        public User ForgetPass(string email, string newPassword){
            var user = _repo.FindUserByEmail(email);
            if(user != null){
                return _repo.ForgetPass(email,newPassword);
            }
            else
            {
                 throw new UserNotFoundException("user with this email id not exists");
            }
        }

        public User RegisterUser(User userDetails)
        {
            var user = _repo.FindUserByEmail(userDetails.Email);
            if (user == null)
            {
                return _repo.Register(userDetails);
            }
            else
            {
                throw new UserAlreadyExistsException($"This email {userDetails.Email} already exists");
            }
            //return null;
        }
        public User FindByEmail(string email)
        {
            var user = _repo.FindUserByEmail(email);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException("Invalid user id or password");
            }
        }

    }
}
