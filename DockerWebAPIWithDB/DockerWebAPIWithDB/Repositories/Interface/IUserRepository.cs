using DockerWebAPIWithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerWebAPIWithDB.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetUserByUserName(string userName);
    }
}
