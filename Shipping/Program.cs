using Messages;
using NServiceBus.Logging;
using Sales.Messages;
using System.Net;

class Program
{
    // Get the Logger from NServiceBus
    static ILog log = LogManager.GetLogger<Program>();

    static async Task Main()
    {
        // Give the Client a title
        Console.Title = "Shipping";

        // Configure our Endpoint with the name "Shipping"
        var endpointConfig = new EndpointConfiguration("Shipping");

        // Choose JSON to serialize and deserialize messages (Must be same for all endpoints)
        endpointConfig.UseSerialization<SystemJsonSerializer>();

        // Define the transport that NServiceBus will use (in our cases it used "LearningTransport").
        var transport = endpointConfig.UseTransport<LearningTransport>();

        // Start up the endpoint
        var endpointInstance = await Endpoint.Start(endpointConfig)
            .ConfigureAwait(false);

        // Wait for exit
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();

        // Stop the endpoint
        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}