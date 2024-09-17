using Microsoft.EntityFrameworkCore;
using Backend.Data.Abstractions;
using Backend.Data.Entities;
using Backend.Data.Repositories.Abstractions;

namespace Backend.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TaskDbContext _context;
        public CustomerRepository(TaskDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var customerToUpdate = await _context.Customers.FindAsync(id);
            if (customerToUpdate == null)
            {
                throw new Exception("Customer not found");
            }
            //Update customer
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.Phone = customer.Phone;
            await _context.SaveChangesAsync();
            return customerToUpdate;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
