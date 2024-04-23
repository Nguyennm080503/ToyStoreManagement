using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IAccountService
    {
		Account GetAccountByUsername(string username);
        Account GetProfileAccount(int id);
        IEnumerable<Account> GetAllCustomerAccounts();
        IEnumerable<Account> GetAllStaffAccounts();
        Account GetAccountByEmail(string email);
		bool RegisterNewAccount(Account account);
        bool UpdateProfileAccount(Account account);
        public IEnumerable<Account> GetAllAccounts();
    }
}
