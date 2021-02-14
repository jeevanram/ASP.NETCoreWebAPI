using DockerWebAPIWithDB.Models;
using DockerWebAPIWithDB.Repositories.Interface;
using System.Linq;

namespace DockerWebAPIWithDB.Repositories.Service
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {

        public UserRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public User GetUserByUserName(string userName)
        {
            return entities.Where(usr => usr.UserName.Equals(userName)).FirstOrDefault();
        }
    }
}
