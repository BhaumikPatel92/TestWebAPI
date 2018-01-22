using System;
using Microsoft.Azure.EventHubs.Processor;
using Microsoft.Azure.EventHubs;

namespace EventHubConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string eventHubConnectionString = "Endpoint=sb://apimgeventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=d9wyzbY7nQ8CSNlto2Vnj44wDN6qqe1INBVf14jPeoc=";
            string eventHubName = "testeventhub";
            string storageAccountName = "apimgpocstorage";
            string storageAccountKey = "zF8S8hqx7b43fG4zeNLc8BVC80A6E6qQz5JIGCev5RWhOaT9dDmHS9gqoWons3uUHCHVotgxMyGO3y/Ejbb0kQ==";
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", storageAccountName, storageAccountKey);

            string eventProcessorHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventHubName, PartitionReceiver.DefaultConsumerGroupName,eventHubConnectionString,storageConnectionString, "calculatorlogcontainer");
            Console.WriteLine("Registering EventProcessor...");
            //var options = new EventProcessorOptions();
            //options.ExceptionReceived += (sender, e) => { Console.WriteLine(e.Exception); };
            eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
            eventProcessorHost.UnregisterEventProcessorAsync().Wait();

        }
    }
}
