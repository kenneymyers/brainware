using BrainWare.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrainWare.Services
{
    public interface IOrderProductService
    {
        Task<List<OrderProduct>> GetAllOrderProducts(int orderId);
    }
}
