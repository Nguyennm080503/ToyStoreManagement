using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IAccountService
    {
		Account GetAccountByUsername(string username);
		bool RegisterNewAccount(Account account);
	}
}
