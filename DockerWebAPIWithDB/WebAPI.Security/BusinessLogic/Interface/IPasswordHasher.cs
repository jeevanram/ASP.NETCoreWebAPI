namespace DockerWebAPIWithDB.BusinessLogic.Interface
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        (bool verified, bool needToBeUpgraded) Check(string hash, string password);
    }
}
