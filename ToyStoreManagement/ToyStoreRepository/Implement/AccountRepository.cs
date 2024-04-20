using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
	public class AccountRepository : IAccountRepository
	{
		private readonly AccountDao _accountDao;

		public AccountRepository()
		{
			_accountDao = new AccountDao();
		}
		public Account GetAccountByUsername(string username)
		{
			return _accountDao.GetAccountByUsername(username);
		}

		public bool RegisterNewAccount(Account account)
		{
			return _accountDao.Create(account);
		}
	}
}
