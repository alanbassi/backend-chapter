using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult GetCustomers()
        {
            try
            {
                return StatusCode(200, new {
                    data = new CustomerServices().GetAll(), 
                    success = true, 
                    message = "Success" 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult GetCustomersById([FromBody] int id)
        {
            try
            {
                return StatusCode(200, new
                {
                    data = new CustomerServices().GetById(id),
                    success = true,
                    message = "Success"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult AddNewCustomer([FromBody] Customer customer)
        {
            try
            {
                return StatusCode(200, new
                {
                    data = new CustomerServices().AddNewCustomer(customer.Name, customer.LastName, customer.Document, customer.Address, customer.Email),
                    success = true,
                    message = "Success"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}