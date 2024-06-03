using InvoiceApplication.DTOs;
using InvoiceApplication.Models;

namespace InvoiceApplication.Container
{
    public interface ICustomerContainer
    {
        public Task<IEnumerable<CustomerDto>> GetCustomers();

        public Task<CustomerDto?> GetCustomerByCustomerId(int customerId);

        public Task UpdateCustomer(Customer customer);

        public Task AddCustomer(Customer customer);

        public Task DeleteCustomer(Customer customer);

        public bool IsCustomerExists(int customerId);

        public Task<Customer?> GetCustomerToDeleteByCustomerId(int categoryId);
    }
}
