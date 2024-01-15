using NServiceBus.Logging;
using Sales.Messages;
using Billing.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping
{
    public class OrderBilledHandler : IHandleMessages<OrderBilled>
    {
        // Use the NServiceBus logger (Implement as static as "LogManager.GetLogger(..)" is expensive
        static ILog log = LogManager.GetLogger<OrderBilledHandler>();

        // Implement the Handler for "OrderBilled" Event
        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            // Log the results
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Should we ship now?");

            // Return that task is completed
            return Task.CompletedTask;
        }
    }
}
