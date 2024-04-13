using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class AccountDao : BaseToyStoreDao<Account>
    {
        private readonly ToyStoreDBContext _dbContext;
        public AccountDao(ToyStoreDBContext dBContext) { _dbContext = dBContext; }

    }
}
