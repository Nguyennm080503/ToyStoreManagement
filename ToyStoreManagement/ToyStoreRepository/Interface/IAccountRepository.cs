using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IAccountRepository
    {
        Account GetAccountByUsername(string username);
        Account GetProfileAccount(int id);
        IEnumerable<Account> GetAllCustomerAccounts();
        IEnumerable<Account> GetAllStaffAccounts();
        Account GetAccountByEmail(string email);
		bool RegisterNewAccount(Account account);
        bool UpdateProfileAccount(Account account);
    }
}
