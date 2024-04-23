using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace ToyStoreDao
{
    public class BaseToyStoreDao<T> where T : class
    {
        private readonly ToyStoreDBContext _dbContext;
        private static BaseToyStoreDao<T> _instance = null;

        public BaseToyStoreDao()
        {
            _dbContext = new ToyStoreDBContext();
        }

        public BaseToyStoreDao<T> Instance
        {
            get
            {
                if (_instance == null) return _instance = new BaseToyStoreDao<T>();
                return _instance;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual T GetDetail(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public bool Update(T entity)
        {
            try
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var obj = GetDetail(id);
                _dbContext.Remove(obj);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(T entity)
        {
            try
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
