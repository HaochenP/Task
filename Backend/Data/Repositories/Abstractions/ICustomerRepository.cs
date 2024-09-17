using Backend.Data.Entities;

namespace Backend.Data.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int id);
    }
}
