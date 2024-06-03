using InvoiceApplication.Data;
using InvoiceApplication.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using InvoiceApplication.DTOs;

namespace InvoiceApplication.Container
{
    public class CustomerContainer : ICustomerContainer
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerContainer(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            if (customers != null && customers.Count > 0)
            {
                return this._mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
            }
            return Enumerable.Empty<CustomerDto>();
        }

        public async Task<CustomerDto?> GetCustomerByCustomerId(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer != null)
            {
                return this._mapper.Map<Customer, CustomerDto>(customer);
            }
            return null;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public bool IsCustomerExists(int customerId)
        {
            return _context.Customers.Any(e => e.Id == customerId);
        }

        public async Task<Customer?> GetCustomerToDeleteByCustomerId(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }
    }
}