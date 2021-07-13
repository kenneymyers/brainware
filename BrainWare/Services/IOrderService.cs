using BrainWare.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainWare.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
    }
}
