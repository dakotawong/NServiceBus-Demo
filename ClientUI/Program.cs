using Messages;
using NServiceBus;
using NServiceBus.Logging;

class Program
{
    // Starts the Endpoint
    static async Task Main()
    {
        // Give the Client a title
        Console.Title = "ClientUI";

        // Configure our Endpoint with the name "ClientUI"
        var endpointConfig = new EndpointConfiguration("ClientUI");

        // Choose JSON to serialize and deserialize messages (Must be same for both endpoints)
        endpointConfig.UseSerialization<SystemJsonSerializer>();

        // Define the transport that NServiceBus will use (in our cases it used "LearningTransport").
        var transport = endpointConfig.UseTransport<LearningTransport>();

        // Set Messages of type 'PlaceOrder' to be routed to 'Sales' endpoint
        var routing = transport.Routing();
        routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

        // Start up the endpoint
        var endpointInstance = await Endpoint.Start(endpointConfig)
            .ConfigureAwait(false);

        // Call the RunLoop method
        await RunLoop(endpointInstance).ConfigureAwait(false);

        // Stop the endpoint
        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }

    // Get the Logger from NServiceBus
    static ILog log = LogManager.GetLogger<Program>();

    // Loop for the Endpoint
    static async Task RunLoop(IEndpointInstance endpointInstance)
    {
        while (true)
        {
            log.Info("Press 'P' to place an order, or 'Q' to quit.");
            var key = Console.ReadKey();
            Console.WriteLine();

            switch (key.Key)
            {
                case ConsoleKey.P:
                    // Instantiate the command
                    var command = new PlaceOrder
                    {
                        OrderId = Guid.NewGuid().ToString()
                    };

                    // Send the command to the local endpoint (SendLocal() sends to current endpoint)
                    log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}");
                    await endpointInstance.Send(command)
                        .ConfigureAwait(false);

                    break;

                case ConsoleKey.Q:
                    return;

                default:
                    log.Info("Unknown input. Please try again.");
                    break;
            }
        }
    }
}
