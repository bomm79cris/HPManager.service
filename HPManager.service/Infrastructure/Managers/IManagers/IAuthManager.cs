namespace HPManager.service.Infrastructure.Managers
{
    public interface IAuthManager
    {
        public Task<string> Authenticate(string email, string password);
    }
}
