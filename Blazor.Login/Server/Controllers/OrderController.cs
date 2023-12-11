using Blazor.Login.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Blazor.Login.Server.Models;
using Blazor.Login.Shared.Models;

namespace Blazor.Login.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OrderController(ApplicationDBContext context)
        {
            _context = context;

            if (!_context?.Orders.Any() ?? false)
            {
                var orders = new List<Order>
                {
                    new Order
                    {
                        OrderNo = "12345",
                        OrderDate = DateTime.Today.AddDays(-2),
                        Status = "Pending",
                        OrderTotal = 399.99m
                    },
                    new Order
                    {
                        OrderNo = "67890",
                        OrderDate = DateTime.Today.AddDays(-5),
                        Status = "Completed",
                        OrderTotal = 199.99m
                    },
                    new Order
                    {
                        OrderNo = "13579",
                        OrderDate = DateTime.Today.AddDays(-7),
                        Status = "Completed",
                        OrderTotal = 249.99m
                    }
                };

                _context.Orders.AddRange(orders);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<OrderDto> Orders()
        {
            return _context.Orders.Select(x => new OrderDto
            {
                Id = x.Id,
                OrderNo = x.OrderNo,
                OrderDate = x.OrderDate,
                Status = x.Status,
                OrderTotal = x.OrderTotal
            }).ToList();
        }
    }
}
