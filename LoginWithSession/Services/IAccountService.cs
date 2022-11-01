using LoginWithSession.Models;

namespace LoginWithSession.Services
{
    public interface IAccountService
    {
        public Account login(string userName, string password);
    }
}
