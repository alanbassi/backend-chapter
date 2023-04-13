using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        public OrderController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> SaveOrder([FromBody] Order order)
        {
            try
            {
                var service = new OrderService();

                var orderSaved = await service.SaveOrder(order);

                return StatusCode(200, new
                {
                    data = orderSaved,
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
        public async Task<ActionResult> RemoveOrder([FromBody] Order order)
        {
            try
            {
                var service = new OrderService();

                await service.RemoveOrder(order);

                return StatusCode(200, new
                {
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