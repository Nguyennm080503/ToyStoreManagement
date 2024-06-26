﻿using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IOrderDetailRepository
    {
        bool AddOrderDetails(IList<OrderDetail> orderDetails);

        public IEnumerable<OrderDetail> GetAllOrderDetail(int id);
    }
}
