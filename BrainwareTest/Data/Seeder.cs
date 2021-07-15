using BrainWare.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using BrainWare.Models;

namespace BrainwareTest.Data
{
    public class Seeder
    {
        private readonly SqlLiteDbContext _context;

        public Seeder(SqlLiteDbContext context)
        {
            _context = context;
        }
        public void SeedDatabase()
        {
            //Add Data
            Company co = new Company();
            co.Id = 1;
            co.CompanyName = "BrainWare Company";
            _context.Companies.Add(co);

            Order or1 = new Order();
            or1.Id = 1;
            or1.CompanyId = 1;
            or1.Description = "Our first order";
            _context.Orders.Add(or1);

            Order or2 = new Order();
            or2.Id = 2;
            or2.CompanyId = 1;
            or2.Description = "Our second order";
            _context.Orders.Add(or2);

            Order or3 = new Order();
            or3.Id = 3;
            or3.CompanyId = 1;
            or3.Description = "Our third order";
            _context.Orders.Add(or3);

            Product p1 = new Product();
            p1.Id = 1;
            p1.Name = "Pipe fitting";
            _context.Products.Add(p1);

            Product p2 = new Product();
            p2.Id = 2;
            p2.Name = "10\" straight";
            _context.Products.Add(p2);

            Product p3 = new Product();
            p3.Id = 3;
            p3.Name = "Quarter turn";
            _context.Products.Add(p3);

            Product p4 = new Product();
            p4.Id = 4;
            p4.Name = "5\" straight";
            _context.Products.Add(p4);

            Product p5 = new Product();
            p5.Id = 5;
            p5.Name = "2\" straight";
            _context.Products.Add(p5);

            OrderProduct op1 = new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 1.23M };
            _context.Add(op1);

            OrderProduct op2 = new OrderProduct { Id = 2, OrderId = 1, ProductId = 2, Quantity = 3, Price = 1.0M };
            _context.Add(op2);

            OrderProduct op3 = new OrderProduct { Id = 3, OrderId = 1, ProductId = 4, Quantity = 22, Price = 1.1M };
            _context.Add(op3);

            OrderProduct op4 = new OrderProduct { Id = 4, OrderId = 2, ProductId = 1, Quantity = 10, Price = 1.23M };
            _context.Add(op4);

            OrderProduct op5 = new OrderProduct { Id = 5, OrderId = 2, ProductId = 3, Quantity = 3, Price = 1.0M };
            _context.Add(op5);

            OrderProduct op6 = new OrderProduct { Id = 6, OrderId = 2, ProductId = 2, Quantity = 13, Price = 2.0M };
            _context.Add(op6);

            OrderProduct op7 = new OrderProduct { Id = 7, OrderId = 2, ProductId = 5, Quantity = 3, Price = 0.9M };
            _context.Add(op7);

            OrderProduct op8 = new OrderProduct { Id = 8, OrderId = 3, ProductId = 1, Quantity = 10, Price = 1.23M };
            _context.Add(op8);

            OrderProduct op9 = new OrderProduct { Id = 9, OrderId = 3, ProductId = 2, Quantity = 7, Price = 2.0M };
            _context.Add(op9);

            OrderProduct op10 = new OrderProduct { Id = 10, OrderId = 3, ProductId = 3, Quantity = 13, Price = 0.75M };
            _context.Add(op10);

            OrderProduct op11 = new OrderProduct { Id = 11, OrderId = 3, ProductId = 4, Quantity = 5, Price = 1.1M };
            _context.Add(op11);

            OrderProduct op12 = new OrderProduct { Id = 12, OrderId = 3, ProductId = 5, Quantity = 3, Price = 0.9M };
            _context.Add(op12);

            _context.SaveChanges();

        }
    }

}
