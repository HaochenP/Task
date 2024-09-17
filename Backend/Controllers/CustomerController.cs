using Microsoft.AspNetCore.Mvc;
using Backend.Services.Abstractions;
using Backend.Services.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try { 
                if (id <= 0)
                {
                    return BadRequest("Invalid customer id.");
                }
                var customer = await _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            } catch (Exception)
            {
                return BadRequest("Failed to get customer");
            }


        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomers();
                return Ok(customers);
            } catch (Exception)
            {
                return BadRequest("Could not retrieve customers.");
            }

        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CustomerModel customerModel)
        {
            try { 
                if (ModelState.IsValid)
                {
                    await _customerService.CreateCustomer(customerModel);
                    if (customerModel == null)
                    { 
                    return BadRequest("Could not create the customer.");
                    }
                    return Ok(customerModel);
                }
                return BadRequest("Could not create the customer.");
            } catch (Exception)
            {
                return BadRequest("Could not create the customer.");
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerModel customer)
        {
            try { 
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedCustomer = await _customerService.UpdateCustomer(id, customer);
                if (updatedCustomer == null)
                {
                    return NotFound();
                }
                return NoContent();
            } catch (Exception)
            {
                return BadRequest("Could not update the customer.");
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return NoContent();
            } catch (Exception)
            {
                return NotFound();
            }
          
        }



    }
}
