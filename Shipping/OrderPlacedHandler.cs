using Messages;
using NServiceBus.Logging;
using Sales.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        // Use the NServiceBus logger (Implement as static as "LogManager.GetLogger(..)" is expensive
        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        // Implement the Handler for "OrderPlaced" Event
        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            // Log the results
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Should we ship now?");

            // Return that task is completed
            return Task.CompletedTask;
        }
    }
}
