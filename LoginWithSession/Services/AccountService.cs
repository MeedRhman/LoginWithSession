using LoginWithSession.Models;

namespace LoginWithSession.Services
{
    public class AccountService : IAccountService
    {
        private List<Account> Accounts;
        public AccountService()
        {
            Accounts = new List<Account> {
               new Account
               {
                    UserName = "User1",
                    Password = "Pass123" ,
                    FullName = "User Number One"
               },
               new Account
               {
                    UserName = "User2",
                    Password = "Pass123" ,
                    FullName = "User Number Two"
               }
            };

        }

        public Account login(string userName, string password)
        {
            return Accounts.SingleOrDefault(a => a.UserName == userName && a.Password == password);
        }
    }
}
