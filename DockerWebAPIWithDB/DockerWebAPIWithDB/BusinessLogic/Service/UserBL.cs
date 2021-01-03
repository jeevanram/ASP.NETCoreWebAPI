using DockerWebAPIWithDB.BusinessLogic.Interface;
using DockerWebAPIWithDB.Models;
using DockerWebAPIWithDB.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerWebAPIWithDB.BusinessLogic.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;

        public UserBL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }
    }
}
