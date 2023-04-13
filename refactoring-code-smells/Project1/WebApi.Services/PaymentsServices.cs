using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class PaymentsServices
    {
        private readonly PagarMeService pagarMeService;
        private readonly CustomerServices customerServices;
        private readonly NotificationService notificationService;

        public PaymentsServices()
        {
            pagarMeService = new PagarMeService();
            customerServices = new CustomerServices();
            notificationService = new NotificationService();
        }

        public void RealizarPagamento(string PaymentType, Payments payments)
        {
            pagarMeService.EnviarPagamento(PaymentType, payments);

            Customer customer = customerServices.GetById(payments.Id);

            notificationService.SendNotification(customer.Email);
        }
    }
}