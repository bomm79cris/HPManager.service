namespace HPManager.service.Infrastructure.Managers
{
    public interface IAuthManager
    {
        string Authenticate(string email, string password);
    }
}
