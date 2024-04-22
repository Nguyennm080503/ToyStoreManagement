using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IAccountRepository
    {
        Account GetAccountByUsername(string username);
        IEnumerable<Account> GetAllCustomerAccounts();
        IEnumerable<Account> GetAllStaffAccounts();
        Account GetAccountByEmail(string email);
		bool RegisterNewAccount(Account account);
    }
}
