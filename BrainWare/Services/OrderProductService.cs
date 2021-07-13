using BrainWare.Data;
using BrainWare.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BrainWare.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly SqlLiteDbContext _context;
        private readonly ILogger<OrderProductService> _logger;
        public OrderProductService(SqlLiteDbContext context, ILogger<OrderProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<OrderProduct>> GetAllOrderProducts(int orderId)
        {
            List<OrderProduct> Orders = new List<OrderProduct>();
            try
            {
                Orders = await _context.OrderProducts
                    .Where(o => o.OrderId == orderId)
                    .Include(o => o.Order)
                    .ThenInclude(c => c.Company)
                    .Include(p => p.Product)
                    .ToListAsync();
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Orders;
        }
    }
}
