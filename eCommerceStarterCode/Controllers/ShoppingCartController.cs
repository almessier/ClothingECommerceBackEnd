using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {

        private ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{userId}")]
        public IActionResult GetShoppingCart(string userId)
        {
            var products = _context.ShoppingCarts.Include(sc => sc.User).Include(sc => sc.Product).Where(sc => sc.User.Id == userId);
            return Ok(products);
        }

        [HttpDelete("product/{productId}/user/{userId}")]
        public IActionResult DeleteProduct(int productId, string userId)
        {
            var product = _context.ShoppingCarts
                //.Include(sc => sc.User)
                //.Include(sc => sc.Product)
                .Where(sc => (sc.Product.Id == productId && sc.User.Id == userId))
                .SingleOrDefault();
            _context.Remove(product);
            _context.SaveChanges();
            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult PostShoppingCart([FromBody] ShoppingCart value)
        {
            _context.ShoppingCarts.Add(value);
            _context.SaveChanges();
            return Ok(value);
        }
    }
}
