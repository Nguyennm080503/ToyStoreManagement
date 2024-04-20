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
    }
}
