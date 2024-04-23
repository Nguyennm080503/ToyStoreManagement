﻿using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();
    }
}
