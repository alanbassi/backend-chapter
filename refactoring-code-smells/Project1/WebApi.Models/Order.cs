using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdShoppingCart { get; set; }
        public DateTime OrderDate { get; set; }
        private decimal TotalAmount;
        public string? CustomerName { get; set; }
        public string? ShippingAddress { get; set; }
        public Discont? Discont { get; set; }
        public List<OrderItems> Items { get; set; }

        public decimal getTotalAmount() => TotalAmount;

        public void setTotalAmount(decimal total)
        {
            TotalAmount= total;
        }
    }

    public class Discont
    {
        public decimal Apply(decimal totalAmount) => totalAmount - 10;
    }
}