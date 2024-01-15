using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Messages
{
    // Define the 'OrderPlaced' IEvent
    public class OrderPlaced : IEvent
    {
        public string OrderId { get; set; }
    }
}
