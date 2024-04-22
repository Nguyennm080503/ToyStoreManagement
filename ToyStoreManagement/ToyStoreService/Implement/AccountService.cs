using BusinessObjects.Models;
using ToyStoreRepository.Implement;
using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreService.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) { _accountRepository = accountRepository; }

		public AccountService()
		{
			_accountRepository = new AccountRepository();
		}

		public Account GetAccountByUsername(string username)
		{
			return _accountRepository.GetAccountByUsername(username);
		}

		public bool RegisterNewAccount(Account account)
		{
			return _accountRepository.RegisterNewAccount(account);
		}

		public Account GetAccountByEmail(string email)
		{
			return _accountRepository.GetAccountByEmail(email);
		}

        public IEnumerable<Account> GetAllCustomerAccounts()
        {
            return _accountRepository.GetAllCustomerAccounts();
        }

        public IEnumerable<Account> GetAllStaffAccounts()
        {
            return _accountRepository.GetAllStaffAccounts();
        }

        public Account GetProfileAccount(int id)
        {
            return _accountRepository.GetProfileAccount(id);
        }

        public bool UpdateProfileAccount(Account account)
        {
            return _accountRepository.UpdateProfileAccount(account);
        }
    }
}
