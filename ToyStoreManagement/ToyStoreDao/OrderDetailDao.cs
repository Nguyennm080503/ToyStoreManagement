using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class OrderDetailDao
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDetailDao() { _dbContext = new ToyStoreDBContext(); }
        public bool AddOrderDetails(IList<OrderDetail> orderDetails)
        {
            try
            {
                _dbContext.OrderDetails.AddRange(orderDetails);
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
