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
        private readonly ILogger<OrderProductService> _logger;
        public OrderService(SqlLiteDbContext context, ILogger<OrderProductService> logger)
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
