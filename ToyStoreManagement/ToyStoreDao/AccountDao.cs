using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class AccountDao : BaseToyStoreDao<Account>
    {
        private readonly ToyStoreDBContext _dbContext;
        public AccountDao() { _dbContext = new ToyStoreDBContext(); }

        public Account GetAccountByUsername(string username)
        {
            return _dbContext.Accounts.FirstOrDefault(x => x.Username == username);
        }
		public Account GetAccountByEmail(string email)
		{
			return _dbContext.Accounts.FirstOrDefault(x => x.Email == email);
		}
        public IEnumerable<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }
	}
}
