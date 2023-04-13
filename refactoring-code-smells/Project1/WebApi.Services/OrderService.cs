using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class OrderService
    {
        public Repository repository1;

        public OrderService()
        {
            repository1 = new Repository();
        }

        public async Task<Order> SaveOrder(Order order)
        {
            ShoppingCart sc = repository1.GetShoppingCart(order.IdShoppingCart);

            foreach (var item in sc.Items)
            {
                foreach (var item2 in order.Items)
                {
                    item.Name = item2.Name;
                    item.Qty = item2.Qty;
                }
            }

            order.setTotalAmount(order.Discont.Apply(order.getTotalAmount()));

            var repository = new Repository();

            await repository.Add(order);

            var orderSaved = repository.GetOrder(order.Id);

            return orderSaved;
        }

        public async Task RemoveOrder(Order order)
        {
            var repository = new Repository();

            await repository.Remove(order);
        }
    }
}