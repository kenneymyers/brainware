using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BrainWare.Services;
using NSubstitute;
using BrainWare.Models;
using BrainwareTest.Data;
using Microsoft.Extensions.Logging;

namespace BrainwareTest
{
    public class OrderServiceTest
    {
        private IOrderService _orderService;
        private ILogger<OrderService> _logger = Substitute.For<ILogger<OrderService>>();

        [Test]
        public async Task GetAllOrders_NoParams_ReturnsThreeOrders()
        {

            using (var factory = new SampleDbContextFactory())
            {
                // Get a context
                using (var context = factory.CreateContext())
                {
                    var seeder = new Seeder(context);
                    seeder.SeedDatabase();
                    _orderService = new OrderService(context, _logger);
                    var result = await _orderService.GetAllOrders();
                    Assert.AreEqual(result.Count, 3);
                }
            }

        }
    }
}
