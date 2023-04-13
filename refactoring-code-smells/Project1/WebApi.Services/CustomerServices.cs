using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class CustomerServices
    {
        public List<Customer> GetAll()
        {
            var result = new Repository().ObterTodos();

            for (int i = 0; i < result.Count; i++)
            {
                result[i].FullName = result[i].getFullName();
            }

            return result;
        }

        public Customer GetById(int id) 
        {
            var result = new Repository().ObterPorId(id);

            result.FullName = result.getFullName();

            return result;
        }

        public bool AddNewCustomer(string name, string last_name, string document, string address, string email)
        {
            new Repository().Adicionar(new Customer() { 
                Address= address,
                Email= email,
                Document= document,
                Name= name,
                LastName= last_name,
            });

            new NotificationService().SendNotification(email);

            return true;
        }
    }
}