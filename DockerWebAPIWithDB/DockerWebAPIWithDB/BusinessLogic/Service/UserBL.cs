using DockerWebAPIWithDB.BusinessLogic.Interface;
using DockerWebAPIWithDB.DTO;
using DockerWebAPIWithDB.Models;
using DockerWebAPIWithDB.Repositories.Interface;
using System;

namespace DockerWebAPIWithDB.BusinessLogic.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserBL(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public UserResponseDTO GetUser(string userName)
        {
            UserResponseDTO userResponseDTO = null;
            
            User user = _userRepository.GetUserByUserName(userName);
            if(user != null)
            {
                userResponseDTO = new UserResponseDTO()
                {
                    Email = user.Email,
                    FirstName = user.ContactFirstName,
                    LastName = user.ContactLastName,
                    UserName = user.UserName
                };
            }

            return userResponseDTO;
        }

        public void AddUser(UserRequestDTO user)
        {
            User userDB = new User()
            {
                ContactFirstName = user.FirstName,
                ContactLastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                IsActive = true,
                CreatedBy = "DAME",
                CreatedDate = DateTime.Now,
                PasswordHash = _passwordHasher.Hash(user.Password)
            };
            _userRepository.Insert(userDB);
        }

        public bool AuthenticateUser(string userName, string password)
        {
            bool isAuthenticated = false;
            User user = _userRepository.GetUserByUserName(userName);
            if (user != null)
            {
                (bool isVerified,bool needToBeUpgraded) = _passwordHasher.Check(user.PasswordHash, password);
                isAuthenticated = isVerified;
            }
            return isAuthenticated;
            
        }
    }
}
