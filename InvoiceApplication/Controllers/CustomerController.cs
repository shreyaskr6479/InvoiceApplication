using InvoiceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using InvoiceApplication.Container;
using InvoiceApplication.DTOs;

namespace InvoiceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerContainer _customerContainer;

        public CustomerController(ICustomerContainer customerContainer)
        {
            this._customerContainer = customerContainer;
        }

        // GET: api/Customer/GetAllCustomers
        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            try
            {
                var customers = await this._customerContainer.GetCustomers();

                return Ok(customers);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            try
            {
                var customer = await _customerContainer.GetCustomerByCustomerId(id);

                if (customer == null)
                {
                    return NotFound();
                }
                return customer;
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            try
            {
                if (id != customer.Id)
                {
                    return BadRequest();
                }

                if (_customerContainer.IsCustomerExists(id))
                {
                    await _customerContainer.UpdateCustomer(customer);
                }
                else
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            try
            {
                await _customerContainer.AddCustomer(customer);
                return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerContainer.GetCustomerToDeleteByCustomerId(id);

                if (customer == null)
                {
                    return NotFound();
                }

                await _customerContainer.DeleteCustomer(customer);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}