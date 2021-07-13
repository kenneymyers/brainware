using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainWare.Models;
using System.Threading.Tasks;

namespace BrainWare.Components
{
    public partial class OrderList
    {

        private List<Order> Orders;
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Orders = await _orderService.GetAllOrders();
                StateHasChanged();
            }
            _ = base.OnAfterRenderAsync(firstRender);
        }

        private async Task<decimal> GetOrderTotal(int orderId)
        {
            decimal total = 0;
            List<OrderProduct> products = new List<OrderProduct>();
            if (orderId != null && orderId > 0)
            {
                products = await _orderProductService.GetAllOrderProducts(orderId);
                if (products != null)
                {
                    foreach (var p in products)
                    {
                        total = total + (p.Quantity * p.Price);
                    }
                }
            }
            return total;
        }

        private async Task<List<OrderProduct>> GetAllProductsForOrder(int orderId)
        {
            List<OrderProduct> products = new List<OrderProduct>();
            if(orderId != null && orderId > 0){
                products = await _orderProductService.GetAllOrderProducts(orderId);
            }
            return products;
        }

    }
}
