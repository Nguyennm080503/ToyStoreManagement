using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IAccountRepository
    {
        Account GetAccountByUsername(string username);
    }
}
