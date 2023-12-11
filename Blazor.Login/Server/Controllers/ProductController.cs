using Blazor.Login.Server.Data;
using Blazor.Login.Server.Models;
using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Login.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;

            if (!_context?.Products.Any() ?? false)
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Title = "Wireless Mouse",
                        Price = 29.99m,
                        Quantity = 3
                    },
                    new Product
                    {
                        Title = "HP Headphone",
                        Price = 79.99m,
                        Quantity = 4
                    },
                    new Product
                    {
                        Title = "Sony Keyboard",
                        Price = 119.99m,
                        Quantity = 5
                    }
                };

                _context.Products.AddRange(products);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<ProductDto> Products()
        {
            return _context.Products.Select(x => new ProductDto
            {
                Id = x.Id,
                Price = x.Price,
                Quantity = x.Quantity,
                Title = x.Title
            }).ToList();
        }
    }
}
