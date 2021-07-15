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
    class OrderProductServiceTest
    {

        private IOrderProductService _orderProductService;
        private ILogger<OrderProductService> _logger = Substitute.For<ILogger<OrderProductService>>();

        [Test]
        public async Task GetAllOrderProducts_PassFirstOrderId_ReturnsThreeProducts()
        {

            using (var factory = new SampleDbContextFactory())
            {
                // Get a context
                using (var context = factory.CreateContext())
                {
                    var seeder = new Seeder(context);
                    seeder.SeedDatabase();
                    _orderProductService = new OrderProductService(context, _logger);
                    var result = await _orderProductService.GetAllOrderProducts(1);
                    //There should be 3 products on the first order
                    Assert.AreEqual(result.Count, 3);
                }
            }

        }

        [Test]
        public async Task GetAllOrderProducts_PassBadOrderId_ReturnsEmptyProducts()
        {

            using (var factory = new SampleDbContextFactory())
            {
                // Get a context
                using (var context = factory.CreateContext())
                {
                    var seeder = new Seeder(context);
                    seeder.SeedDatabase();
                    _orderProductService = new OrderProductService(context, _logger);
                    var result = await _orderProductService.GetAllOrderProducts(0);
                    //There should be 3 products on the first order
                    Assert.IsEmpty(result);
                }
            }

        }

    }
}
