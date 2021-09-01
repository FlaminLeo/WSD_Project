using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WSD_Project_C2004V_4.Models
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Member,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        protected UserManager<IdentityUser> _userManager;
        public OrdersController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            if (User.FindFirstValue(ClaimTypes.Role) == "Admin")
            {
                return _context.Order;
            }else
            {
                var userOrders = _context.Order.Where(Orders => Orders.CustomerID.Contains(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return userOrders;
            }

        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Order.FindAsync(id);
            //var user = await _userManager.FindByEmailAsync();
            //var 

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            order.CustomerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);

        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}