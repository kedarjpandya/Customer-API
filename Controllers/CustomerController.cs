using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CustomerCRUD.Models;

namespace CustomerCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomersDatum>> Get()
        {
            return await _context.CustomersData.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var customer = await _context.CustomersData.FirstOrDefaultAsync(m => m.id == id);
            if (customer == null)
                return NotFound();
            return Ok(customer);

        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomersDatum cust)
        {
            _context.Add(cust);
            await _context.SaveChangesAsync();
            return Ok(cust.id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CustomersDatum cust)
        {
            if (cust == null || cust.id == 0)
                return BadRequest();

            var custmer = await _context.CustomersData.FindAsync(cust.id);
            if (custmer == null)
                return NotFound();
            custmer.FirstName = cust.FirstName;
            custmer.LastName = cust.LastName;
            custmer.Email = cust.Email;
            custmer.CreatedDate = cust.CreatedDate;
            custmer.LastUpdatedDate= cust.LastUpdatedDate;
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var custmr = await _context.CustomersData.FindAsync(id);
            if (custmr == null)
                return NotFound();
            _context.CustomersData.Remove(custmr);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
