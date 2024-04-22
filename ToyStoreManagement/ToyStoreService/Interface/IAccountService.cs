using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IAccountService
    {
		Account GetAccountByUsername(string username);
		IEnumerable<Account> GetAllCustomerAccounts();
        IEnumerable<Account> GetAllStaffAccounts();
        Account GetAccountByEmail(string email);
		bool RegisterNewAccount(Account account);
	}
}
