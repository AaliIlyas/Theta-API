using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theta.Models.RequestModel
{
    public class OrderRequestModel
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}
