using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus  OrderStatus { get; set; }
        public bool Done { get; set; }
    }

    public enum OrderStatus
    {
        Processing,
        Sent,
        Delivered,
    }
}
