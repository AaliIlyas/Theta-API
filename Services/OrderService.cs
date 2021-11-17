﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theta.Context;
using Theta.Models.Database;
using Microsoft.EntityFrameworkCore;
using Theta.Models.RequestModel;

namespace Theta.Services
{
    public class OrderService : IOrderService
    {
        private readonly RetailContext _context;
        public OrderService(RetailContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Order
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .ToList();

            //.FromSqlRaw<Order>("exec updated_obtain_order_with_joins");
        }

        public void AddOrder(List<OrderRequestModel> request)
        {
            var order = request.Select(r =>
            {
                var customer = _context.Customer.Find(r.CustomerId);
                var product = _context.Product.Find(r.ProductId);

                return new Order
                {
                    Customer = customer,
                    Product = product,
                    Date = DateTime.Now
                };
            });

            _context.Order.AddRange(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Order.SingleOrDefault(a => a.OrderId == id);

            _context.Order.Remove(order);
            _context.SaveChanges();
        }
    }
}
