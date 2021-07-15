using BrainWare.Data;
using BrainWare.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BrainWare.Services
{
    public class OrderService : IOrderService
    {
        private readonly SqlLiteDbContext _context;
        private readonly ILogger<OrderService> _logger;
        public OrderService(SqlLiteDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> Orders = new List<Order>();
            try
            {
                Orders = await _context.Orders
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Orders;
        }
    }
}
