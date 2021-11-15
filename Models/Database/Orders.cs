using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theta.Models.Database
{
    public class Orders
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public Customers Customer { get; set; }
        public List<Products> Products { get; set; }
    }
}
