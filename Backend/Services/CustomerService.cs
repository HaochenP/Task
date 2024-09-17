using Backend.Data.Entities;
using Backend.Data.Repositories.Abstractions;
using Backend.Services.Abstractions;
using Backend.Services.Models;

namespace Backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return customers.Select(c => new CustomerModel(c));
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return new CustomerModel(customer);
        }

        public async Task<CustomerModel> CreateCustomer(CustomerModel customerModel)
        {
            Customer customer = new Customer
            {
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Email = customerModel.Email,
                Phone = customerModel.Phone
            };
            var createdCustomer = await _customerRepository.CreateCustomer(customer);
            if (createdCustomer == null)
            {
                throw new Exception("Failed to create customer");
            }
            return new CustomerModel(createdCustomer);
        }

        public async Task<CustomerModel> UpdateCustomer(int id, CustomerModel customer)
        {
            var customerToUpdate = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone
            };
           var updatedCustomer = await _customerRepository.UpdateCustomer(id, customerToUpdate);
           return new CustomerModel(updatedCustomer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }

    }
}
