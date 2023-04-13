using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class PagarMeService
    {
        public string Key { get; set; }
        public Dictionary<int, string> PaymentType = new() { { 1, "Boleto" }, { 2, "Cartão de Crédito" }, { 3, "Cartão de Débito" }, { 4, "Pix" } };

        public PagarMeService()
        {
            if (Environment.GetEnvironmentVariable("Environment") == "PROD")
                Key = "LJWDtbR2JA4mC34h9nId4ZxZaapbr30yZV6orXdD";
            else
                Key = "JDUYtbC1JA5fghth41darqBxHiippl50cvU9tyu7";
        }

        public void EnviarPagamento(string PaymentType, Payments payment)
        {
            var c = new Repository().ObterPorId(payment.Id);

            if (!PaymentType.Contains(PaymentType))
                throw new ArgumentException($"No payment validator available for {PaymentType}");

            switch (PaymentType)
            {
                case "Boleto":
                    BoletoPayment(payment, c);
                    break;
                case "Cartão de Crédito":
                    CartaoPayment(PaymentType, payment, c);
                    break;
                case "Cartão de Débito":
                    CartaoPayment(PaymentType, payment, c);
                    break;
                case "Pix":
                    PixPayment(payment, c);
                    break;
                default:
                    throw new ArgumentException($"No payment validator available for {PaymentType}");
            }
        }

        public void BoletoPayment(Payments payment, Customer customer)
        {
            // ...
        }

        public void CartaoPayment(string PaymentType, Payments payment, Customer customer)
        {
            // ...
        }

        public void PixPayment(Payments payment, Customer customer)
        {
            // ...
        }
    }
}
