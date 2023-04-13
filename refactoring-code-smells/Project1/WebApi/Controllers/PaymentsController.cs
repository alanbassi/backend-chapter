using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult RealizarPagamento([FromQuery] string PaymentType, Payments payments)
        {
            try
            {
                new PaymentsServices().RealizarPagamento(PaymentType, payments);

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