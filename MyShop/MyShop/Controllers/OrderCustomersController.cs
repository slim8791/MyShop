using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCustomersController : ControllerBase
    {
        private readonly MyShopContext _context;

        public OrderCustomersController(MyShopContext context)
        {
            _context = context;
        }

        // GET: api/OrderCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderCustomer>>> GetOrderCustomer()
        {
          if (_context.OrderCustomer == null)
          {
              return NotFound();
          }
            return await _context.OrderCustomer.ToListAsync();
        }

        // GET: api/OrderCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderCustomer>> GetOrderCustomer(int id)
        {
          if (_context.OrderCustomer == null)
          {
              return NotFound();
          }
            var orderCustomer = await _context.OrderCustomer.FindAsync(id);

            if (orderCustomer == null)
            {
                return NotFound();
            }

            return orderCustomer;
        }

        // PUT: api/OrderCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderCustomer(int id, OrderCustomer orderCustomer)
        {
            if (id != orderCustomer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(orderCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderCustomerExists(id))
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

        // POST: api/OrderCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderCustomer>> PostOrderCustomer(OrderCustomer orderCustomer)
        {
          if (_context.OrderCustomer == null)
          {
              return Problem("Entity set 'MyShopContext.OrderCustomer'  is null.");
          }
          orderCustomer.OrderDateTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            _context.OrderCustomer.Add(orderCustomer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderCustomerExists(orderCustomer.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderCustomer", new { id = orderCustomer.CustomerId }, orderCustomer);
        }

        // DELETE: api/OrderCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderCustomer(int id)
        {
            if (_context.OrderCustomer == null)
            {
                return NotFound();
            }
            var orderCustomer = await _context.OrderCustomer.FindAsync(id);
            if (orderCustomer == null)
            {
                return NotFound();
            }

            _context.OrderCustomer.Remove(orderCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderCustomerExists(int id)
        {
            return (_context.OrderCustomer?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
