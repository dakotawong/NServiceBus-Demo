using Messages;
using NServiceBus.Logging;
using Sales.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    public class PlaceOrderHandler :
    IHandleMessages<PlaceOrder>
    {
        // Use the NServiceBus logger (Implement as static as "LogManager.GetLogger(..)" is expensive
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        // Implement the Handler for "PlaceOrder" Messages
        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            // Log the results
            log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

            // This is normally where some business logic would occur

            // Create 'OrderPlaced' IEvent
            var orderPlaced = new OrderPlaced
            {
                OrderId = message.OrderId
            };

            // Publish the 'OrderPlaced' Event
            return context.Publish(orderPlaced);
        }
    }
}
