#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GP1ComputerStore.Data;
using GP1ComputerStore.Models;

namespace GP1ComputerStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersProductsController : ControllerBase
    {
        private readonly Group1ComputerStoreContext _context;

        public OrdersProductsController(Group1ComputerStoreContext context)
        {
            _context = context;
        }

        // GET: api/OrdersProducts
        [HttpGet]

        public async Task<ActionResult<IEnumerable<OrdersProduct>>> GetOrdersProducts()
        {
            return await _context.OrdersProducts.ToListAsync();
        }

        // GET: api/OrdersProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersProduct>> GetOrdersProduct(int id)
        {
            var ordersProduct = await _context.OrdersProducts.FindAsync(id);

            if (ordersProduct == null)
            {
                return NotFound();
            }

            return ordersProduct;
        }

        // PUT: api/OrdersProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersProduct(int id, OrdersProduct ordersProduct)
        {
            if (id != ordersProduct.OrderProductId)
            {
                return BadRequest();
            }

            _context.Entry(ordersProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrdersProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersProduct>> PostOrdersProduct(OrdersProduct ordersProduct)
        {
            _context.OrdersProducts.Add(ordersProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersProduct", new { id = ordersProduct.OrderProductId }, ordersProduct);
        }

        // DELETE: api/OrdersProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersProduct(int id)
        {
            var ordersProduct = await _context.OrdersProducts.FindAsync(id);
            if (ordersProduct == null)
            {
                return NotFound();
            }

            _context.OrdersProducts.Remove(ordersProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersProductExists(int id)
        {
            return _context.OrdersProducts.Any(e => e.OrderProductId == id);
        }
    }
}
