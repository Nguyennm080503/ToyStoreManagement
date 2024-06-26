﻿using BusinessObjects.Models;
using ToyStoreRepository.Implement;
using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreService.Implement
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderdetailRepository;

        public OrderDetailService(IOrderDetailRepository orderdetailRepository)
        {
            _orderdetailRepository = orderdetailRepository;
        }
        public bool AddOrderDetails(IList<OrderDetail> orderDetails)
        {
            return _orderdetailRepository.AddOrderDetails(orderDetails);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail(int id)
        {
            return _orderdetailRepository.GetAllOrderDetail(id);
        }
    }
}
