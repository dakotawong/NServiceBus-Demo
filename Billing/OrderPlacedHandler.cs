using Billing.Messages;
using NServiceBus.Logging;
using Sales.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    // Handler to handle messages of type 'OrderPlaced'
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        // Get the Logger from NServiceBus
        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        // Handle the incoming message
        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            // Log Results
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Charging credit card...");

            // Create an IEvent
            var orderBilled = new OrderBilled
            {
                OrderId = message.OrderId,
            };

            // Publish the IEvent
            return context.Publish(orderBilled);
        }
    }
}
