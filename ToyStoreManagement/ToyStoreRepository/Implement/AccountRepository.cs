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

		public Account GetAccountByEmail(string email)
		{
			return _accountDao.GetAccountByEmail(email);
		}

		public Account GetAccountByUsername(string username)
		{
			return _accountDao.GetAccountByUsername(username);
		}

        public IEnumerable<Account> GetAllCustomerAccounts()
        {
			return _accountDao.GetAll().Where(x => x.RoleId == 3).ToList();
        }

        public IEnumerable<Account> GetAllStaffAccounts()
        {
            return _accountDao.GetAll().Where(x => x.RoleId == 2).ToList();
        }

        public Account GetProfileAccount(int id)
        {
			return _accountDao.GetDetail(id);
        }

        public bool RegisterNewAccount(Account account)
		{
			return _accountDao.Create(account);
		}

        public bool UpdateProfileAccount(Account account)
        {
            return _accountDao.Update(account);
        }
    }
}
