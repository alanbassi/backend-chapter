using MongoDB.Bson;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Data
{
    public class Repository
    {
        private readonly IMongoCollection<Customer> _collectionCustomer;
        private readonly IMongoCollection<Order> _collectionOrder;
        private readonly IMongoCollection<ShoppingCart> _collectionShoppingCart;

        public Repository()
        {
            var database = new MongoClient("mongodb://root:password@mongo:27017").GetDatabase("Db");
            _collectionCustomer = database.GetCollection<Customer>("Customers");
            _collectionOrder = database.GetCollection<Order>("Order");
            _collectionShoppingCart = database.GetCollection<ShoppingCart>("ShoppingCart");

        }

        public void Adicionar(Customer entity)
        {
            _collectionCustomer.InsertOne(entity);
        }

        public List<Customer> ObterTodos()
        {
            return _collectionCustomer
                .Find(null)
                .ToEnumerable()
                .ToList();
        }

        public Customer ObterPorId(int id)
        {
            var filter = Builders<Customer>.Filter.Eq("id", id);

            return _collectionCustomer
                .Find(filter)
                .ToEnumerable()
                .FirstOrDefault();
        }

        public async Task Add(Order order)
        {
            await _collectionOrder.InsertOneAsync(order);
        }

        public Order GetOrder(int id)
        {
            var filter = Builders<Order>.Filter.Eq("id", id);

            return _collectionOrder
                .Find(filter)
                .ToEnumerable()
                .FirstOrDefault();
        }

        public async Task Remove(Order order)
        {
            var filter = Builders<Order>.Filter.Eq("id", order.Id);

            await _collectionOrder.DeleteOneAsync(filter);
        }

        public ShoppingCart GetShoppingCart(int id)
        {
            var filter = Builders<ShoppingCart>.Filter.Eq("id", id);

            return _collectionShoppingCart
                .Find(filter)
                .ToEnumerable()
                .FirstOrDefault();
        }
    }
}