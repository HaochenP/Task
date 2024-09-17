using Backend.Services.Models;

namespace Backend.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
        Task<CustomerModel> GetCustomerById(int id);
        Task<CustomerModel> CreateCustomer(CustomerModel customer);
        Task<CustomerModel> UpdateCustomer(int id, CustomerModel customer);
        Task<bool> DeleteCustomer(int id);
    }
}
