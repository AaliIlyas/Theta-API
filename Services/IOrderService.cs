﻿using System.Collections.Generic;
using Theta.Models.Database;
using Theta.Models.RequestModel;

namespace Theta.Services
{
    public interface IOrderService
    {
        void AddOrder(List<OrderRequestModel> request);
        void DeleteOrder(int id);
        IEnumerable<Order> GetAllOrders();
    }
}