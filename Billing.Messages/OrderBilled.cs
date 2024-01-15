using System.Windows.Input;

namespace Billing.Messages
{
    // Define the 'OrderBilled' Event
    public class OrderBilled : IEvent
    {
        public string OrderId { get; set; }
    }
}
