using DockerWebAPIWithDB.DTO;

namespace DockerWebAPIWithDB.BusinessLogic.Interface
{
    public interface IUserBL
    {
        public UserResponseDTO GetUser(string userName);
        public void AddUser(UserRequestDTO user);
        public bool AuthenticateUser(string userName, string password);
    }
}
