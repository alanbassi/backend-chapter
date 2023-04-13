using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public List<ShoppingCartItems> Items { get; set; }
    }
}