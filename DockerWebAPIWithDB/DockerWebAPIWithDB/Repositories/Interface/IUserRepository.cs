using DockerWebAPIWithDB.Models;

namespace DockerWebAPIWithDB.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetUserByUserName(string userName);
    }
}
